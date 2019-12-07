using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinTechHackathonAlpha.WebApi.Configuration;
using Microsoft.Extensions.Options;

namespace FinTechHackathonAlpha.WebApi.Security
{
	public class OfficialAccountAccessValidator : IOfficialAccountAccessValidator
	{
		private readonly IOptionsMonitor<OfficialAccountSetting> _officialAccountSetting;

		public OfficialAccountAccessValidator(IOptionsMonitor<OfficialAccountSetting> officialAccountSetting)
		{
			_officialAccountSetting = officialAccountSetting;
		}

		public bool IsValid(string signature, string timestamp, string nonce, string echostr)
		{
			var values = new string[] { _officialAccountSetting.CurrentValue.Token, timestamp, nonce };
			values = values.OrderBy(v => v).ToArray();
			var toEncryptValue = string.Join(string.Empty, values);
			var sha1Value = SHA1HashHelper.ComputeSHA1HashString(toEncryptValue);
			if (sha1Value.Equals(signature, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			else
			{
				var requestValues = string.Join(",", signature, timestamp, nonce, echostr);
				System.Diagnostics.Trace.WriteLine(string.Format("requestValues:{0},sha1Value:{1}", requestValues, sha1Value));
				return false;
			}
		}
	}
}
