using PaintBot.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Common
{
	/// <summary>
	/// ゲームイベントのクラス
	/// </summary>
	public class GameEvent
	{
		/// <summary>
		/// Bot
		/// </summary>
		public Bot Bot { private set; get; }

		/// <summary>
		/// イベントタイプ
		/// </summary>
		public EEventType EventType { private set; get; }

		/// <summary>
		/// イベントの対象となる位置
		/// </summary>
		/// <remarks>
		/// 移動の場合は、移動した位置
		/// ボール投げの場合は、投げた位置
		/// 塗った場合は、塗った位置
		/// </remarks>
		public Position Position { private set; get; }

		/// <summary>
		/// イベントを生成する
		/// </summary>
		/// <param name="type">イベントタイプ</param>
		/// <param name="bot">Bot</param>
		/// <param name="pos">イベントの位置</param>
		public GameEvent(EEventType type, Bot bot, Position pos = null)
		{
			EventType = type;
			Bot = bot;
			Position = pos;
		}
	}
}
