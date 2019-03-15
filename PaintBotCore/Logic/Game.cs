using PaintBot.Core.Utils;
using PaintBot.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using PaintBot.Core.Common;

namespace PaintBot.Core.Logic
{
	/// <summary>
	/// ゲームロジッククラス
	/// </summary>
	public class Game
	{
		/// <summary>
		/// プレイヤーリスト
		/// </summary>
		private List<Player> Players { set; get; }

		/// <summary>
		/// マップデータ
		/// </summary>
		private Map Map { set; get; }

		/// <summary>
		/// Bot メタ情報のリスト
		/// </summary>
		private List<BotMeta> BotMetaList { set; get; }

		/// <summary>
		/// 現在バトル中のロボットのリスト
		/// </summary>
		private List<Bot> Bots { set; get; }

		/// <summary>
		/// ゲームステータス
		/// </summary>
		public EGameStatus Status { private set; get; } = EGameStatus.PREPARING;

		/// <summary>
		/// ターン数
		/// </summary>
		public int TurnCount { private set; get; }

		/// <summary>
		/// 最大ターン数
		/// </summary>
		public int MaxTurnCount { private set; get; }

		/// <summary>
		/// ゲームイベントの delegate 型
		/// </summary>
		/// <param name="e">ゲームイベント</param>
		public delegate void GameEventAction(GameEvent e);

		/// <summary>
		/// ゲームイベントの通知イベント
		/// </summary>
		public event GameEventAction OnEventNotification;

		/// <summary>
		/// Gameを生成する
		/// </summary>
		public Game()
		{
		}

		/// <summary>
		/// Gameを初期化する
		/// </summary>
		/// <param name="botMetaList">Botメタ情報のリスト</param>
		/// <param name="players">プレイヤー情報のリスト</param>
		/// <param name="map">マップ情報</param>
		public void Init(List<BotMeta> botMetaList, List<Player> players, Map map)
		{
			// Assertチェック
			Assert.IsNotNull(botMetaList, nameof(botMetaList));
			Assert.IsNotNull(players, nameof(players));
			Assert.IsNotNull(map, nameof(map));

			// 情報を保持
			BotMetaList = new List<BotMeta>(botMetaList);
			Players = new List<Player>(players);
			Map = new Map(map);

			// 準備中
			Status = EGameStatus.PREPARING;
		}

		/// <summary>
		/// ゲームを開始する
		/// </summary>
		/// <param name="maxTurnCount">最大ターン数</param>
		public void StartGame(int maxTurnCount)
		{
			// プレイ中の場合
			if (Status == EGameStatus.PLAYING)
			{
				throw new AppException("プレイ中なので、開始できません");
			}

			// Bot のリストを初期化
			Bots = new List<Bot>();

			// 各プレイヤーの Bot を初期配置
			foreach (var player in Players)
			{
				string botId = player.BotId;

				// Bot インスタンスを生成
				var bot = CreateBot(botId);
				// プレイヤーを登録
				bot.Player = player;

				// リストに追加
				Bots.Add(bot);
			}

			// マップを初期化
			Map.Init(Bots);

			// ターン数を初期化
			TurnCount = 0;
			// 最大ターン数を初期化
			MaxTurnCount = maxTurnCount;

			// プレイ中
			Status = EGameStatus.PLAYING;
		}

		/// <summary>
		/// 次のターンの処理を行う
		/// </summary>
		/// <returns>ゲームを続行する場合 true, それ以外の場合 false</returns>
		public bool NextTurn()
		{
			// プレイ中ではない場合
			if (Status != EGameStatus.PLAYING)
			{
				throw new AppException("プレイ中ではありません");
			}
			// ターン数が最大に達した場合
			if (TurnCount >= MaxTurnCount)
			{
				// ステータスを終了にする
				Status = EGameStatus.FINISHED;

				// 終了
				return false;
			}

			// ターン数を 1 増やす
			TurnCount += 1;

			// アクションリスト
			var actList = new List<BotActionInternal>();

			foreach (var bot in Bots)
			{
				// Bot 周辺のマップ情報
				Map map = null;

				// Bot に次の行動を決めてもらう
				var action = bot.DecideNextAction(map);

				// 内部クラスでラップ
				var act = new BotActionInternal(Map, bot, action);
				// リストに追加
				actList.Add(act);
			}

			// 移動アクションを実行
			ActMove(actList);

			// ボール投げアクションを実行
			ActThrowBall(actList);

			// 塗りアクションを実行
			ActPaintHere(actList);

			// 続行
			return true;
		}

		/// <summary>
		/// アクション後の位置をチェック
		/// </summary>
		/// <remarks>
		/// 移動後の位置がぶつかる場合は、移動をキャンセルする。
		/// while で繰り返すのは、移動がキャンセルされたことで
		/// 移動しなかった場合にぶつかるケースがあるため
		/// 一回もぶつからなくなるまで繰り返す。
		/// </remarks>
		/// <param name="actList">アクションのリスト</param>
		private void ActMove(List<BotActionInternal> actList)
		{
			// アクション後の位置をチェック
			var nextInfoList = actList
				.Select(a => new { Action = a, CurPos = a.GetCurrentBotPos(), NextPos = a.GetNextPos() })
				.ToList();

			// 移動先が壁かどうかチェック
			nextInfoList.ForEach(a =>
			{
				// 移動以外の場合、何もしない
				if (a.Action.ActionType != EActionType.MOVE)
				{
					return;
				}
				// 移動先が壁の場合
				if (Map[a.NextPos] == ECellType.WALL)
				{
					// キャンセル
					a.Action.Cancel = true;

					// イベント通知
					NoticeEvent(EEventType.MOVE_TO_WALL, a.Action.Bot, a.NextPos);
				}
			});

			// チェックフラグ
			var checkFlag = true;

			// 移動後の位置チェック
			while (checkFlag)
			{
				// 次はループしない
				checkFlag = false;

				// １次ループ
				for (int i = 0; i < nextInfoList.Count - 1; i++)
				{
					// １つ目
					var a = nextInfoList[i];

					// ２次ループ
					for (int j = i + 1; j < nextInfoList.Count; j++)
					{
						// ２つ目
						var b = nextInfoList[i];

						// 移動後の位置が一致しない場合
						if (a.NextPos != b.NextPos)
						{
							continue;
						}

						// a が移動でキャンセルされていない場合、キャンセル
						if (a.Action.ActionType == EActionType.MOVE && !a.Action.Cancel)
						{
							a.Action.Cancel = true;
							checkFlag = true;

							// イベント通知
							NoticeEvent(EEventType.COLLISION_MOVE, a.Action.Bot, a.NextPos);
						}
						// b が移動でキャンセルされていない場合、キャンセル
						if (b.Action.ActionType == EActionType.MOVE && !b.Action.Cancel)
						{
							b.Action.Cancel = true;
							checkFlag = true;

							// イベント通知
							NoticeEvent(EEventType.COLLISION_MOVE, b.Action.Bot, b.NextPos);
						}
					}
				}
			}

			// Botの位置を更新
			actList
				.Where(a => a.ActionType == EActionType.MOVE && !a.Cancel)
				.ToList()
				.ForEach(a => {
					Map.SetBotPosition(a.Bot, a.GetNextPos());
					// イベント通知
					NoticeEvent(EEventType.MOVED, a.Bot, Map.GetBotPosition(a.Bot));
				});
		}

		/// <summary>
		/// ボール投げアクションを実行する
		/// </summary>
		/// <param name="actList">アクションリスト</param>
		private void ActThrowBall(List<BotActionInternal> actList)
		{
			// 投げた位置のリスト
			var thrownPosList = new List<Position>();

			// ボール投げアクションに対して、繰り返し
			actList
				.Where(a => a.ActionType == EActionType.THROW_BALL)
				.ToList()
				.ForEach(a =>
				{
					// Bot
					var bot = a.Bot;
					// Bot の位置
					var botPos = Map.GetBotPosition(bot);
					// キャスト
					var act = a.Action as BotActionThrowBall;
					// 投げる位置
					var throwPos = new Position(botPos.X + act.X, botPos.Y + act.Y);

					// 通常床以外の場合
					if (Map[throwPos] != ECellType.FLOOR)
					{
						// セルタイプで分岐
						switch (Map[throwPos])
						{
							case ECellType.WALL:
								// イベント通知
								NoticeEvent(EEventType.THREW_TO_WALL, bot, throwPos);
								break;
							case ECellType.WIRE_MESH:
								// イベント通知
								NoticeEvent(EEventType.THREW_TO_WIRE_MESH, bot, throwPos);
								break;
							case ECellType.START:
								// イベント通知
								NoticeEvent(EEventType.THREW_TO_START, bot, throwPos);
								break;
							default:
								// イベント通知
								NoticeEvent(EEventType.THREW_TO_WALL, bot, throwPos);
								break;
						}

						// 無効
						return;
					}

					// 投げる位置に Bot がいる場合
					if (Map.ExistsBot(throwPos))
					{
						// イベント通知
						NoticeEvent(EEventType.THREW_TO_BOT, bot, throwPos);

						// 無効
						return;
					}

					// 色コード
					var colorCode = bot.ColorCode;

					// すでにこのターンでボールを投げている場合
					if (thrownPosList.Contains(throwPos))
					{
						colorCode = Consts.COLORCODE_BLACK;

						// イベント通知
						NoticeEvent(EEventType.COLLISION_BALL, bot, throwPos);
					}
					// まだボールを投げていない場合
					else
					{
						thrownPosList.Add(throwPos);

						// イベント通知
						NoticeEvent(EEventType.THREW_BALL, bot, throwPos);
					}

					// 指定の位置を塗る
					Map.SetCellColor(throwPos, colorCode);
				});
		}

		/// <summary>
		/// 塗りアクションを実行する
		/// </summary>
		/// <param name="actList">アクションリスト</param>
		private void ActPaintHere(List<BotActionInternal> actList)
		{
			// 塗りアクションに対して、繰り返し
			actList
				.Where(a => a.ActionType == EActionType.PAINT_HERE)
				.ToList()
				.ForEach(a =>
				{
					// Bot
					var bot = a.Bot;
					// Bot の位置
					var botPos = Map.GetBotPosition(bot);
					// 色コード
					var colorCode = bot.ColorCode;
					
					// 通常床は塗れる
					if (Map[botPos] == ECellType.FLOOR)
					{
						// 指定の位置を塗る
						Map.SetCellColor(botPos, colorCode);

						// イベント通知
						NoticeEvent(EEventType.PAINTED_HERE, bot, botPos);
					}
					// 金網は塗れない
					else
					{
						// イベント通知
						NoticeEvent(EEventType.PAINTING_WIRE_MESH, bot, botPos);
					}
				});
		}

		/// <summary>
		/// ゲームを強制終了する
		/// </summary>
			public void StopGame()
		{
			// ステータスを終了
			Status = EGameStatus.FINISHED;
		}

		/// <summary>
		/// BotId から Bot インスタンスを生成する
		/// </summary>
		/// <param name="botId">BotId</param>
		/// <returns>Bot インスタンス</returns>
		/// <exception cref="UserException">BotId に該当する Bot メタが存在しない場合</exception>
		private Bot CreateBot(string botId)
		{
			// メタ情報から Bot クラスタイプを取得する
			var botTypes = from meta in BotMetaList
						where meta.BotId == botId
						select meta.BotClassType;

			// 見つからない場合
			if (botTypes == null || botTypes.Count() == 0)
			{
				throw new UserException($"指定の BotId は定義されていません: {botId}");
			}

			// Bot インスタンスを生成する
			var bot = Activator.CreateInstance(botTypes.First()) as Bot;

			// 結果を返す
			return bot;
		}

		/// <summary>
		/// イベントを通知する
		/// </summary>
		/// <param name="eventType">イベントタイプ</param>
		/// <param name="bot">Bot</param>
		/// <param name="pos">イベントの位置</param>
		private void NoticeEvent(EEventType eventType, Bot bot, Position pos = null)
		{
			// イベントハンドラが無ければ
			if (OnEventNotification == null)
			{
				return;
			}

			// イベントを生成
			var e = new GameEvent(eventType, bot, pos);

			// イベントハンドラをコール
			OnEventNotification(e);
		}

		/// <summary>
		/// 内部アクションクラス
		/// </summary>
		private class BotActionInternal
		{
			/// <summary>
			/// マップ
			/// </summary>
			public Map Map { private set; get; }
			/// <summary>
			/// Bot
			/// </summary>
			public Bot Bot { private set; get; }
			/// <summary>
			/// アクション
			/// </summary>
			public BotAction Action { private set; get; }

			/// <summary>
			/// キャンセルフラグ
			/// </summary>
			public bool Cancel { set; get; } = false;

			/// <summary>
			/// アクションタイプ
			/// </summary>
			public EActionType ActionType => Action.ActionType;

			/// <summary>
			/// アクションを生成する
			/// </summary>
			/// <param name="map"></param>
			/// <param name="bot"></param>
			/// <param name="act"></param>
			public BotActionInternal(Map map, Bot bot, BotAction act)
			{
				Map = map;
				Bot = bot;
				Action = act;
			}

			/// <summary>
			/// Botの現在位置を取得する
			/// </summary>
			/// <returns>現在位置</returns>
			public Position GetCurrentBotPos() => Map.GetBotPosition(Bot);

			/// <summary>
			/// 移動後の位置を取得する
			/// </summary>
			/// <returns>移動後の位置（移動しない場合は、現在位置）</returns>
			public Position GetNextPos()
			{
				// Botの現在地
				var pos = GetCurrentBotPos();

				// 移動しない、もしくは移動だったがキャンセルされた場合
				if (ActionType != EActionType.MOVE || Cancel)
				{
					// 現在位置を返す
					return pos;
				}

				// キャスト
				var moveAct = Action as BotActionMove;

				// 移動先の位置
				var newPos = new Position(pos.X + moveAct.X, pos.Y + moveAct.Y);

				// 結果を返す
				return newPos;
			}
		}
	}
}
