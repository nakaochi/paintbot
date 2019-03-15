using PaintBot.Core.Model;
using PaintBot.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Common
{
	/// <summary>
	/// Bot アクション
	/// </summary>
	public abstract class BotAction
	{
		/// <summary>
		/// アクションタイプ
		/// </summary>
		public EActionType ActionType { private set; get; }

		/// <summary>
		/// Bot アクションを生成する
		/// </summary>
		/// <param name="actionType">アクションタイプ</param>
		protected BotAction(EActionType actionType)
		{
			ActionType = actionType;
		}
	}

	/// <summary>
	/// Bot アクション：移動
	/// </summary>
	internal sealed class BotActionMove : BotAction
	{
		/// <summary>
		/// 相対 X 座標の値
		/// </summary>
		public int X { private set; get; }

		/// <summary>
		/// 相対 Y 座標の値
		/// </summary>
		public int Y { private set; get; }

		/// <summary>
		/// Bot アクションを生成する
		/// </summary>
		/// <param name="x">相対 X 座標の値</param>
		/// <param name="y">相対 Y 座標の値</param>
		public BotActionMove(int x, int y) : base(EActionType.MOVE)
		{
			// 移動する範囲が大きすぎる場合
			if (Math.Abs(x) + Math.Abs(y) >= 2)
			{
				throw new UserException("移動可能範囲を超えています");
			}

			// 現在地には移動できない
			if (x == 0 && y == 0)
			{
				throw new UserException("現在地には移動できません");
			}

			X = x;
			Y = y;
		}
	}

	/// <summary>
	/// Bot アクション：ペイントボールを投げる
	/// </summary>
	internal sealed class BotActionThrowBall : BotAction
	{
		/// <summary>
		/// 相対 X 座標の値
		/// </summary>
		public int X { private set; get; }

		/// <summary>
		/// 相対 Y 座標の値
		/// </summary>
		public int Y { private set; get; }

		/// <summary>
		/// Bot アクションを生成する
		/// </summary>
		/// <param name="x">相対 X 座標の値</param>
		/// <param name="y">相対 Y 座標の値</param>
		public BotActionThrowBall(int x, int y) : base(EActionType.THROW_BALL)
		{
			// 絶対値を計算
			var absX = Math.Abs(x);
			var absY = Math.Abs(y);

			// 移動する範囲が大きすぎる場合
			if (absX >= 3 || absY >= 3 || absX + absY >= 4)
			{
				throw new UserException("移動可能範囲を超えています");
			}

			// 現在地には投げられない
			if (x == 0 && y == 0)
			{
				throw new UserException("現在地には投げられません");
			}

			X = x;
			Y = y;
		}
	}

	/// <summary>
	/// Bot アクション：現在地を塗る
	/// </summary>
	internal sealed class BotActionPaintHere : BotAction
	{
		/// <summary>
		/// Bot アクションを生成する
		/// </summary>
		public BotActionPaintHere() : base(EActionType.PAINT_HERE)
		{
		}
	}
}
