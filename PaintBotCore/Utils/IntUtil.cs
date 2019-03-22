using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Utils
{
	/// <summary>
	/// int のユーティリティクラス
	/// </summary>
	public static class IntUtil
	{
		/// <summary>
		/// 数値の回数所定の処理を繰り返す
		/// </summary>
		/// <param name="num">繰り返す回数</param>
		/// <param name="act">繰り返す処理（引数はインデックス。0スタート）</param>
		public static void Times(this int num, Action<int> act)
		{
			// 繰り返し
			for (int i = 0; i < num; i ++)
			{
				// 処理を実行
				act(i);
			}
		}
	}
}
