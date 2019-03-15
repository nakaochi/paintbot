using PaintBot.Core.Common;
using PaintBot.Core.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Utils
{
	/// <summary>
	/// ローダークラス
	/// </summary>
	public static class GameLoader
	{
		/// <summary>
		/// アセンブリから Bot クラスをスキャンする
		/// </summary>
		/// <param name="asm">捜査対象のアセンブリ（指定しない場合はプログラムエントリーのアセンブリ）</param>
		/// <returns>Bot IDと Bot クラスタイプ のマップ</returns>
		public static List<BotMeta> ScanBots(Assembly asm = null)
		{
			// 戻り値
			var ret = new List<BotMeta>();

			// 指定のアセンブリを読み込む
			ret.AddRange(ScanBotsInternal(asm));
			// PaintBotCoreアセンブリを読み込む
			ret.AddRange(ScanBotsInternal(Assembly.GetExecutingAssembly()));

			// 結果を返す
			return ret;
		}

		/// <summary>
		/// アセンブリから Bot クラスをスキャンする
		/// </summary>
		/// <param name="asm">捜査対象のアセンブリ（指定しない場合はプログラムエントリーのアセンブリ）</param>
		/// <returns>Bot IDと Bot クラスタイプ のマップ</returns>
		private static List<BotMeta> ScanBotsInternal(Assembly asm = null)
		{
			try
			{
				Debug.WriteLine("スキャン開始");

				// アセンブリが指定されていない場合
				if (asm == null)
				{
					// プログラムエントリーのアセンブリを検索する
					asm = Assembly.GetEntryAssembly();
				}

				Debug.WriteLine($"Assembly : {asm.FullName}");

				// 戻り値
				var ret = new List<BotMeta>();

				// 探す属性のタイプ
				Type attributeType = typeof(BotAttribute);

				// アセンブリの中から Robot を継承した Type を取得
				var robotTypes = from type in asm.GetTypes()
								 where type.IsSubclassOf(typeof(Bot))
								 select type;

				// 見つかった属性に対して繰り返し
				foreach (var type in robotTypes)
				{
					// Bot 属性
					var robotAttr = type.GetCustomAttribute(attributeType) as BotAttribute;

					// Bot 属性が定義されていない場合、読み飛ばす
					if (robotAttr == null || robotAttr.BotId == null)
					{
						continue;
					}

					// Bot メタ情報
					var meta = new BotMeta(robotAttr.BotId, robotAttr.Author, type);

					// 戻り値に追加
					ret.Add(meta);

					Debug.WriteLine($"{robotAttr.BotId} : {type.FullName}");
				}

				// Bot Id でソート
				ret.Sort((a, b) => a.BotId.CompareTo(b.BotId));

				// 結果を返す
				return ret;
			}
			catch (Exception ex)
			{
				throw new AppException("Bot クラスのスキャンに失敗しました", ex);
			}
		}

		/// <summary>
		/// マップをロードする
		/// </summary>
		/// <param name="filePath">マップデータのファイル</param>
		/// <returns>マップIDとMapオブジェクトのマップ</returns>
		public static Dictionary<string, Map> LoadMap(string filePath)
		{
			// 行番号
			var lineIndex = 0;

			try
			{
				// 戻り値
				var ret = new Dictionary<string, Map>();

				// ファイルを開く
				using (var stream = new StreamReader(filePath, Encoding.UTF8))
				{
					// マップID
					string mapId = null;

					// セルリスト
					var cellList = new List<ECellType>();

					// マップの幅
					var width = 0;
					// マップの高さ
					var height = 0;

					// マップを生成して戻り値に追加
					Action addRet = () =>
					{
						if (cellList.Count > 0)
						{
							// 新しいマップを生成
							var map = new Map(mapId, width, height, cellList);

							// スタート台の数が 2 未満の場合
							if (map.GetStartList().Count < 2)
							{
								throw new AppException($"スタート台の数が少なすぎます: mapId={mapId}");
							}

							// 戻り値に追加
							ret[mapId] = map;

							// 初期化
							cellList = new List<ECellType>();
							width = 0;
							height = 0;
						}
					};

					// 繰り返し
					while (true)
					{
						// 次の行を読み込む
						var line = stream.ReadLine();
						// 取得できない場合ループを抜ける
						if (line == null)
						{
							// マップを生成して戻り値に追加
							addRet();
							break;
						}

						// 行番号を１つ上げる
						lineIndex += 1;

						// # のインデックスを取得
						var sharpIndex = line.IndexOf("#");
						// # 以降はコメントなので、削除
						if (sharpIndex >= 0)
						{
							line = line.Substring(0, sharpIndex);
						}

						// 前後の空白を取り除く
						line = line.Trim();
						// 空文字列の場合
						if (line.Length == 0)
						{
							// 読み飛ばす
							continue;
						}

						// 先頭が : の行はマップID定義
						if (line.StartsWith(":"))
						{
							// マップを生成して戻り値に追加
							addRet();

							// 先頭の : を除いた文字列を mapId として保持
							mapId = line.Substring(1);
							continue;
						}

						// セルタイプのリストに変換する
						var cells = ParseToCellList(line);

						// 最初の行の場合
						if (width == 0)
						{
							width = cells.Count;
						}
						// 幅が異なる場合
						else if (width != cells.Count)
						{
							throw new AppException($"マップの幅が揃っていません: line={line}, width={width}");
						}

						// リストに追加
						cellList.AddRange(cells);

						// １行追加
						height += 1;
					}
				}

				// 結果を返す
				return ret;
			}
			catch (Exception ex)
			{
				throw new UserException($"ファイルが読み込めません: file={filePath}, lineIndex={lineIndex}", ex);
			}
		}

		/// <summary>
		/// 文字列を ECellType のリストに変換する
		/// </summary>
		/// <param name="str">文字列</param>
		/// <returns>ECellType のリスト</returns>
		private static List<ECellType> ParseToCellList(string str)
		{
			// 戻り値
			var ret = new List<ECellType>();

			// 文字列を ',' で区切って繰り返し
			foreach(var s in str.Split(new char[] {','}))
			{
				try
				{
					// 数値に変換
					var v = Int32.Parse(s);
					// ECellType に変換して戻り値に追加
					ret.Add((ECellType)v);
				}
				catch (Exception ex)
				{
					throw new AppException($"マップデータのフォーマットが正しくないです: {s}", ex);
				}
			}

			// 結果を返す
			return ret;
		}
	}
}
