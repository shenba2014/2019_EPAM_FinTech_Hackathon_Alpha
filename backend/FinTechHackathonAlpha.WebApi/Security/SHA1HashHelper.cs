using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FinTechHackathonAlpha.WebApi.Security
{
	public class SHA1HashHelper
	{
		static byte[] ComputeSHA1Hash(byte[] input)
		{
			if (input == null)
				throw new ArgumentNullException("input");

			using (var sha1 = new SHA1Managed())
			{
				var result = sha1.ComputeHash(input);
				return result;
			}
		}

		public static string ComputeSHA1HashString(string input, bool lowercaseResult = true)
		{
			var inputBytes = Encoding.UTF8.GetBytes(input);
			return BytesToString(ComputeSHA1Hash(inputBytes), lowercaseResult);
		}

		static string BytesToString(byte[] input, bool lowercase = true)
		{
			if (input == null || input.Length == 0)
				return string.Empty;

			var sb = new StringBuilder(input.Length * 2);
			for (var i = 0; i < input.Length; i++)
			{
				sb.AppendFormat(lowercase ? "{0:x2}" : "{0:X2}", input[i]);
			}
			return sb.ToString();
		}
	}
}
