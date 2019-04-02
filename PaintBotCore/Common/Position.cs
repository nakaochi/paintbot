using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Common
{
	/// <summary>
	/// 位置クラス
	/// </summary>
	public sealed class Position
	{
		/// <summary>
		/// X 座標
		/// </summary>
		public int X { private set; get; }

		/// <summary>
		/// Y 座標
		/// </summary>
		public int Y { private set; get; }

		/// <summary>
		/// 位置の加算
		/// </summary>
		/// <param name="a">左要素</param>
		/// <param name="b">右要素</param>
		/// <returns>加算した結果の位置</returns>
		public static Position operator+ (Position a, Position b)
		{
			return new Position(a.X + b.X, a.Y + b.Y);
		}

		/// <summary>
		/// 位置を生成する
		/// </summary>
		/// <param name="x">X 座標</param>
		/// <param name="y">Y 座標</param>
		public Position(int x, int y)
		{
			X = x;
			Y = y;
		}

		public override bool Equals(object obj)
		{
			// 相手が null もしくは Position ではない場合
			if (obj == null || obj is Position == false)
			{
				// 不一致
				return false;
			}

			// キャスト
			var b = obj as Position;

			// それぞれ座標値が一致しているか
			return X == b.X && Y == b.Y;
		}

		public override int GetHashCode()
		{
			return Y << 16 + X;
		}

		// 文字列化
		public override string ToString()
		{
			return $"({X}, {Y})";
		}
	}
}
