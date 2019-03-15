using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Common
{
	/// <summary>
	/// アクションタイプ
	/// </summary>
	public enum EActionType
	{
		/// <summary>
		/// 移動
		/// </summary>
		MOVE,

		/// <summary>
		/// ペイントボールを投げる
		/// </summary>
		THROW_BALL,

		/// <summary>
		/// 現在地を塗る
		/// </summary>
		PAINT_HERE,
	}
}
