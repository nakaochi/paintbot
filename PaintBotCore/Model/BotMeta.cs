using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Model
{
	/// <summary>
	/// Bot メタ情報
	/// </summary>
	public class BotMeta
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
		/// Bot クラスタイプ
		/// </summary>
		public Type BotClassType { private set; get; }

		/// <summary>
		/// Bot メタ情報を生成する
		/// </summary>
		/// <param name="botId">Bot Id</param>
		/// <param name="author">作者</param>
		/// <param name="botClassType">Bot クラスタイプ</param>
		public BotMeta(string botId, string author, Type botClassType)
		{
			BotId = botId;
			Author = author;
			BotClassType = botClassType;
		}
	}
}
