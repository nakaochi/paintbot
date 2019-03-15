using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Model
{
	/// <summary>
	/// プレイヤークラス
	/// </summary>
	public class Player
	{
		/// <summary>
		/// プレイヤー名
		/// </summary>
		public string Name { private set; get; }

		/// <summary>
		/// Bot Id
		/// </summary>
		public string BotId { private set; get; }

		/// <summary>
		/// 色コード (rrggbb)
		/// </summary>
		public string ColorCode { private set; get; }

		/// <summary>
		/// プレイヤーを生成する
		/// </summary>
		/// <param name="name">プレイヤー名</param>
		/// <param name="botId">Bot Id</param>
		/// <param name="colorCode">色コード</param>
		public Player(string name, string botId, string colorCode)
		{
			Name = name;
			BotId = botId;
			ColorCode = colorCode;
		}
	}
}
