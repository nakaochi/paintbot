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
	/// Bot クラス
	/// </summary>
	public abstract class Bot
	{
		/// <summary>
		/// プレイヤー情報
		/// </summary>
		private Player _player = null;

		/// <summary>
		/// プレイヤー情報
		/// </summary>
		/// <remarks>
		/// このプロパティはインスタンス生成時に自動的に代入されるため、
		/// コンストラクタ等で値をセットする必要はありません
		/// </remarks>
		public Player Player {
			set {
				// すでに値がある場合
				if (_player != null)
				{
					throw new AppException("すでにPlayer情報は初期化されています");
				}
				// セット
				_player = value;
			}
			get { return _player; }
		}

		/// <summary>
		/// Bot 名
		/// </summary>
		/// <remarks>
		/// Botを識別するための名前です
		/// </remarks>
		public abstract string BotName { get; }

		/// <summary>
		/// 乱数オブジェクト
		/// </summary>
		private Rand Rand { set; get; } = new Rand();

		/// <summary>
		/// 色コード
		/// </summary>
		public string ColorCode => Player?.ColorCode;

		/// <summary>
		/// 乱数を取得する
		/// </summary>
		/// <param name="max">最大値</param>
		/// <returns>生成した乱数（0 以上 max 未満）</returns>
		public int NextRand(int max) => Rand.NextRand(max);

		/// <summary>
		/// 次の行動を決定する
		/// </summary>
		/// <param name="map">マップ情報</param>
		/// <returns>次のアクション</returns>
		public abstract BotAction DecideNextAction(Map map);

		/// <summary>
		/// 移動アクションを生成する
		/// </summary>
		/// <param name="x">相対 X 座標の値</param>
		/// <param name="y">相対 Y 座標の値</param>
		/// <returns>アクション</returns>
		protected BotAction Move(int x, int y) => new BotActionMove(x, y);

		/// <summary>
		/// 移動アクションを生成する
		/// </summary>
		/// <param name="pos">相対位置</param>
		/// <returns>アクション</returns>
		protected BotAction Move(Position pos) => new BotActionMove(pos.X, pos.Y);

		//== ボール投げは機能を無効化
		///// <summary>
		///// ボール投げアクションを生成する
		///// </summary>
		///// <param name="x">相対 X 座標の値</param>
		///// <param name="y">相対 Y 座標の値</param>
		///// <returns>アクション</returns>
		//protected BotAction ThrowBall(int x, int y) => new BotActionThrowBall(x, y);

		/// <summary>
		/// 現在地塗りアクションを生成する
		/// </summary>
		/// <returns>アクション</returns>
		protected BotAction PaintHere() => new BotActionPaintHere();
	}
}
