using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Utils
{
	/// <summary>
	/// Assertチェックユーティリティ
	/// </summary>
	public static class Assert
	{
		/// <summary>
		/// null ではないことを確認する
		/// </summary>
		/// <param name="obj">対象オブジェクト</param>
		/// <param name="name">オブジェクト（変数）の名前</param>
		public static void IsNotNull(object obj, string name)
		{
			// null の場合
			if (obj == null)
			{
				throw new AssertException(@"${name} は null じゃダメです");
			}
		}

		/// <summary>
		/// null もしくは空文字列ではないことを確認する
		/// </summary>
		/// <param name="str">対象文字列</param>
		/// <param name="name">オブジェクト（変数）の名前</param>
		public static void IsNotNullOrEmpty(string str, string name)
		{
			// null もしくは空文字列の場合
			if (String.IsNullOrEmpty(str))
			{
				throw new AssertException(@"${name} は null もしくは空文字列じゃダメです");
			}
		}

		/// <summary>
		/// false ではないことを確認する
		/// </summary>
		/// <param name="b">真偽値</param>
		/// <param name="name">オブジェクト（変数）の名前</param>
		public static void IsTrue(bool b, string name)
		{
			// false の場合
			if (b == false)
			{
				throw new AssertException(@"${name} は false じゃダメです");
			}
		}

		/// <summary>
		/// 数値が指定値より大きいことを確認する
		/// </summary>
		/// <param name="v">数値</param>
		/// <param name="n">比較値</param>
		/// <param name="name">オブジェクト（変数）の名前</param>
		public static void IsGreaterThan(int v, int n, string name)
		{
			// v が n 以下の場合
			if (v <= n)
			{
				throw new AssertException(@"${name} は {n} 以下じゃダメです");
			}
		}

		/// <summary>
		/// 数値が指定値の範囲にあることを確認する
		/// </summary>
		/// <param name="v">数値</param>
		/// <param name="min">最小値</param>
		/// <param name="max">最大値</param>
		/// <param name="name">オブジェクト（変数）の名前</param>
		public static void IsBetween(int v, int min, int max, string name)
		{
			// v が min 未満、もしくは max より大きい場合
			if (v < min || v > max)
			{
				throw new AssertException(@"${name} は {min} と {max} の間じゃないとダメです");
			}
		}
	}
}
