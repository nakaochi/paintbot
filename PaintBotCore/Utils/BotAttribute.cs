using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Utils
{
	/// <summary>
	/// Bot 属性クラス
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class BotAttribute : Attribute
	{
		/// <summary>
		/// Bot ID
		/// </summary>
		public string BotId { private set; get; }

		/// <summary>
		/// 作者
		/// </summary>
		public string Author { private set; get; }

		/// <summary>
		/// Robot 属性を生成する
		/// </summary>
		/// <param name="botId">Bot Id</param>
		/// <param name="author">作者</param>
		public BotAttribute(string botId, string author)
		{
			BotId = botId;
			Author = author;
		}
	}
}
