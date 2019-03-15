using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintBot.Core.Utils
{
	/// <summary>
	/// Assertチェック例外クラス
	/// </summary>
	public class AssertException : AppException
	{
		/// <summary>
		/// Assertチェック例外を生成する
		/// </summary>
		/// <param name="msg">メッセージ</param>
		public AssertException(string msg) : base(msg)
		{
		}

		/// <summary>
		/// Assertチェック例外を生成する
		/// </summary>
		/// <param name="msg">メッセージ</param>
		/// <param name="innerException">原因例外</param>
		public AssertException(string msg, Exception innerException) : base(msg, innerException)
		{
		}
	}
}
