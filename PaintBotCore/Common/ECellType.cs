using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Common
{
	/// <summary>
	/// セルタイプ
	/// </summary>
	public enum ECellType
	{
		/// <summary>
		/// 通常床
		/// </summary>
		FLOOR,

		/// <summary>
		/// スタート台
		/// </summary>
		/// <remarks>
		/// 金網と同じ：移動可能、色塗り不可
		/// </remarks>
		START,

		/// <summary>
		/// 壁
		/// </summary>
		WALL,

		/// <summary>
		/// 網床
		/// </summary>
		WIRE_MESH,
	}
}
