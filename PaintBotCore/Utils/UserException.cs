using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Utils
{
	/// <summary>
	/// ユーザー例外クラス
	/// </summary>
	public class UserException : Exception
	{
		/// <summary>
		/// ユーザー例外を生成する
		/// </summary>
		/// <param name="msg">メッセージ</param>
		public UserException(string msg) : base(msg)
		{
		}

		/// <summary>
		/// ユーザー例外を生成する
		/// </summary>
		/// <param name="msg">メッセージ</param>
		/// <param name="innerException">原因例外</param>
		public UserException(string msg, Exception innerException) : base(msg, innerException)
		{
		}
	}
}
