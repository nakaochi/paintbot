using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Common
{
	/// <summary>
	/// ゲームステータス
	/// </summary>
	public enum EGameStatus
	{
		/// <summary>
		/// 準備中
		/// </summary>
		PREPARING,

		/// <summary>
		/// 準備完了
		/// </summary>
		PREPARED,

		/// <summary>
		/// プレイ中
		/// </summary>
		PLAYING,

		/// <summary>
		/// 終了
		/// </summary>
		FINISHED,
	}
}
