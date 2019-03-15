using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Common
{
	/// <summary>
	/// イベントタイプ
	/// </summary>
	public enum EEventType
	{
		/// <summary>
		/// 移動した
		/// </summary>
		MOVED,

		/// <summary>
		/// ボールを投げた
		/// </summary>
		THREW_BALL,

		/// <summary>
		/// 現在位置を塗った
		/// </summary>
		PAINTED_HERE,

		/// <summary>
		/// 移動したがぶつかった
		/// </summary>
		COLLISION_MOVE,

		/// <summary>
		/// ボールがぶつかった
		/// </summary>
		COLLISION_BALL,

		/// <summary>
		/// ボールが Bot にぶつかった
		/// </summary>
		THREW_TO_BOT,

		/// <summary>
		/// ボールを壁に投げた
		/// </summary>
		THREW_TO_WALL,

		/// <summary>
		/// ボールを金網に投げた
		/// </summary>
		THREW_TO_WIRE_MESH,

		/// <summary>
		/// ボールをスタート台に投げた
		/// </summary>
		THREW_TO_START,

		/// <summary>
		/// 壁に向かって移動した
		/// </summary>
		MOVE_TO_WALL,

		/// <summary>
		/// ありえない移動
		/// </summary>
		ILLEGAL_MOVE,

		/// <summary>
		/// ありえないボール投げ
		/// </summary>
		ILLEGAL_THROW,

		/// <summary>
		/// 金網は塗れない
		/// </summary>
		PAINTING_WIRE_MESH,
	}
}
