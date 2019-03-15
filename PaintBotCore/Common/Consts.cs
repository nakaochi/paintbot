using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Common
{
	/// <summary>
	/// 定数クラス
	/// </summary>
	public static class Consts
	{
		/// <summary>
		/// 色コード：黒
		/// </summary>
		/// <remarks>
		/// ボール投げアクションで同じ場所を塗った場合に設定される色コード
		/// </remarks>
		public static readonly string COLORCODE_BLACK = "000000";

		/// <summary>
		/// マップファイル名
		/// </summary>
		public static readonly string MAP_FILE = "map.dat";
	}
}
