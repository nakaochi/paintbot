using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Utils
{
	/// <summary>
	/// App例外クラス
	/// </summary>
	public class AppException : Exception
	{
		/// <summary>
		/// App例外を生成する
		/// </summary>
		/// <param name="msg">メッセージ</param>
		public AppException(string msg) : base(msg)
		{
		}

		/// <summary>
		/// App例外を生成する
		/// </summary>
		/// <param name="msg">メッセージ</param>
		/// <param name="innerException">原因例外</param>
		public AppException(string msg, Exception innerException) : base(msg, innerException)
		{
		}
	}
}
