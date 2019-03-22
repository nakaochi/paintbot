using PaintBot.Core.Common;
using PaintBot.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Model
{
	/// <summary>
	/// マップ情報
	/// </summary>
	public class Map
	{
		/// <summary>
		/// マップID
		/// </summary>
		public string MapId { private set; get; }

		/// <summary>
		/// マップの幅
		/// </summary>
		public int Width { private set; get; }

		/// <summary>
		/// マップの高さ
		/// </summary>
		public int Height { private set; get; }

		/// <summary>
		/// セルのリスト
		/// </summary>
		private List<ECellType> CellList { set; get; }

		/// <summary>
		/// セル色のリスト
		/// </summary>
		private List<string> PaintedCellList { set; get; }

		/// <summary>
		/// Bot と位置のマップ
		/// </summary>
		private Dictionary<Bot, Position> BotPosMap { set; get; }

		/// <summary>
		/// 指定位置のセルタイプを設定・取得するインデクサ
		/// </summary>
		/// <param name="pos">位置</param>
		/// <returns>セルタイプ</returns>
		public ECellType this[Position pos]
		{
			set
			{
				CellList[ConvertIndex(pos)] = value;
			}
			get
			{
				return CellList[ConvertIndex(pos)];
			}
		}

		/// <summary>
		/// 指定位置のセルタイプを設定・取得するインデクサ
		/// </summary>
		/// <param name="x">X座標</param>
		/// <param name="y">Y座標</param>
		/// <returns>セルタイプ</returns>
		public ECellType this[int x, int y]
		{
			set
			{
				CellList[ConvertIndex(x, y)] = value;
			}
			get
			{
				return CellList[ConvertIndex(x, y)];
			}
		}

		/// <summary>
		/// 座標値をインデックスに変換する
		/// </summary>
		/// <param name="x">X座標</param>
		/// <param name="y">Y座標</param>
		/// <returns>インデックス</returns>
		private int ConvertIndex(int x, int y) => Width * y + x;

		/// <summary>
		/// 位置をインデックスに変換する
		/// </summary>
		/// <param name="pos">位置</param>
		/// <returns>インデックス</returns>
		private int ConvertIndex(Position pos) => Width * pos.Y + pos.X;

		/// <summary>
		/// インデックスを位置に変換する
		/// </summary>
		/// <param name="index">インデックス</param>
		/// <returns>位置</returns>
		private Position ConvertPosition(int index) => new Position(index / Width, index % Width);

		/// <summary>
		/// マップを生成する
		/// </summary>
		/// <param name="mapId">マップID</param>
		/// <param name="width">マップの幅</param>
		/// <param name="height">マップの高さ</param>
		/// <param name="cellList">セルのリスト</param>
		public Map(string mapId, int width, int height, List<ECellType> cellList)
		{
			Assert.IsNotNullOrEmpty(mapId, nameof(mapId));
			Assert.IsBetween(width, 3, 20, nameof(width));
			Assert.IsBetween(height, 3, 20, nameof(height));
			Assert.IsNotNull(cellList, nameof(cellList));
			Assert.IsTrue(width * height == cellList.Count, "マップの幅と高さの積 == セルリストの数");

			MapId = mapId;
			Width = width;
			Height = height;
			CellList = new List<ECellType>(cellList);
		}

		/// <summary>
		/// マップをコピー生成する
		/// </summary>
		/// <param name="baseMap">コピー元のMap</param>
		public Map(Map baseMap)
		{
			Assert.IsNotNull(baseMap, nameof(baseMap));

			MapId = baseMap.MapId;
			Width = baseMap.Width;
			Height = baseMap.Height;
			CellList = new List<ECellType>(baseMap.CellList);
		}

		/// <summary>
		/// マップ情報を初期化する
		/// </summary>
		/// <param name="bots">Bot のリスト</param>
		public void Init(List<Bot> bots)
		{
			// スタート台の位置のリスト
			var startCellList = GetStartList();

			// スタート台が足りない場合
			if (bots.Count > startCellList.Count)
			{
				throw new AppException($"スタート台の数より Bot の数のほうが大きいです: bots={bots.Count}, スタート台={startCellList.Count}");
			}

			// 乱数を生成
			var r = new Random();

			// Bot に対して繰り返し
			bots.ForEach(bot =>
			{
				// ランダムなインデックスを取得
				var n = r.Next(startCellList.Count);
				// 位置を取得
				var pos = startCellList[n];

				// Bot の位置を設定する
				SetBotPosition(bot, pos);

				// リストから位置を削除
				startCellList.Remove(pos);
			});
		}

		/// <summary>
		/// スタート台の位置をリストで取得する
		/// </summary>
		/// <returns>スタート台の位置のリスト</returns>
		public List<Position> GetStartList()
		{
			// インデックス
			int index = -1;

			// スタート台の位置のリスト
			var ret = new List<Position>();

			while (index + 1 < CellList.Count)
			{
				// スタート台の位置
				index = CellList.IndexOf(ECellType.START, index + 1);

				// 見つからなかった場合
				if (index < 0)
				{
					break;
				}

				// リストに追加
				ret.Add(ConvertPosition(index));
			}

			// 結果を返す
			return ret;
		}

		/// <summary>
		/// 指定 Bot の位置を取得する
		/// </summary>
		/// <param name="bot">Bot</param>
		/// <returns>位置（見つからない場合 null）</returns>
		public Position GetBotPosition(Bot bot)
		{
			return BotPosMap[bot];
		}

		/// <summary>
		/// Bot の位置を設定する
		/// </summary>
		/// <param name="bot">Bot</param>
		/// <param name="pos">位置</param>
		public void SetBotPosition(Bot bot, Position pos)
		{
			BotPosMap[bot] = pos;
		}

		/// <summary>
		/// 指定位置を指定の色を設定する
		/// </summary>
		/// <param name="pos">位置</param>
		/// <param name="colorCode">色コード</param>
		public void SetCellColor(Position pos, string colorCode)
		{
			PaintedCellList[ConvertIndex(pos)] = colorCode;
		}

		/// <summary>
		/// 指定位置を指定の色を取得する
		/// </summary>
		/// <param name="pos">位置</param>
		/// <returns>色コード</returns>
		public string GetCellColor(Position pos)
		{
			return PaintedCellList[ConvertIndex(pos)];
		}

		/// <summary>
		/// 指定位置を指定の色を取得する
		/// </summary>
		/// <param name="x">X座標</param>
		/// <param name="y">Y座標</param>
		/// <returns>色コード</returns>
		public string GetCellColor(int x, int y)
		{
			return PaintedCellList[ConvertIndex(x, y)];
		}

		/// <summary>
		/// 指定位置に Bot がいるかどうか判定する
		/// </summary>
		/// <param name="pos">位置</param>
		/// <returns>Bot がいる場合 true, それ以外の場合 false</returns>
		public bool ExistsBot(Position pos)
		{
			return BotPosMap.ContainsValue(pos);
		}
	}
}
