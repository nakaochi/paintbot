using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Utils
{
	/// <summary>
	/// 乱数クラス
	/// </summary>
	public class Rand
	{
		/// <summary>
		/// 乱数インスタンス
		/// </summary>
		private static Random _Random { set; get; }  = new Random();

		/// <summary>
		/// 乱数を生成する
		/// </summary>
		/// <param name="max">最大値</param>
		/// <returns>生成した乱数（0 以上 max 未満）</returns>
		public int NextRand(int max)
		{
			return _Random.Next(max);
		}
	}
}
