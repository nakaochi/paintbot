using PaintBot.Core.Common;
using PaintBot.Core.Model;
using PaintBot.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Bots
{
	/// <summary>
	/// 単純な Bot クラス
	/// </summary>
	[Bot("SimpleBot", "nak")]
	public class SimpleBot : Bot
	{
		/// <summary>
		/// Bot 名
		/// </summary>
		public override string BotName => "シンプル Bot";

		/// <summary>
		/// 次の行動を決める
		/// </summary>
		/// <param name="map">マップ</param>
		/// <returns>アクション</returns>
		public override BotAction DecideNextAction(Map map)
		{
			// 現在位置
			var pos = map.GetBotPosition(this);
			// 現在位置のセルタイプ
			var hereCellType = map[pos];

			// 通常床で自分色じゃない場合
			if (hereCellType == ECellType.FLOOR && ColorCode != map.GetCellColor(pos))
			{
				return PaintHere();
			}

			// 周辺
			var arrounds = new List<Position>
			{
				new Position(0, 1),
				new Position(1, 0),
				new Position(0, -1),
				new Position(-1, 0),
			};

			// 次の移動先候補
			var nexts = new List<Position>();

			// 周囲に対して繰り返し
			arrounds.ForEach(a =>
			{
				// 隣の位置
				var sidePos = pos + a;
				// 隣のセルタイプ
				var sideCellType = map[sidePos];

				// 隣のセルが壁の場合、スキップ
				if (sideCellType == ECellType.WALL)
				{
					return;
				}

				// 隣の色
				var sideColor = map.GetCellColor(sidePos);

				// 隣の色が自分の色と異なる場合
				if (sideColor != ColorCode)
				{
					nexts.Add(a);
				}
			});

			// 周りに一つもなければ、ランダムに選ぶ
			if (nexts.Count == 0)
			{
				// 次の候補に、移動可能な方向を追加
				nexts.AddRange(
					arrounds
					.Where(a => map[a + pos] != ECellType.WALL)
				);
			}

			// ランダムに選ぶ
			var c = nexts[NextRand(nexts.Count)];

			// 移動する
			return Move(c);
		}
	}
}
