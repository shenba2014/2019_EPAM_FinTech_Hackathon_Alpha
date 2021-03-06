﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinTechHackathonAlpha.WebApi.OfficialAccount
{
    public class EchoUrlValidator : IEchoUrlValidator
	{
		private readonly IConfiguration _configuration;

		public EchoUrlValidator(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public bool IsValid(string signature, string timestamp, string nonce, string echostr)
		{
			var token = _configuration.GetValue<string>("OfficialAccountToken");
            var values = new string[] { token, timestamp, nonce };
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