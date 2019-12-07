using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FinTechHackathonAlpha.WebApi.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinTechHackathonAlpha.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficialAccountController : ControllerBase
    {
		private readonly IOfficialAccountAccessValidator _officialAccountAccessValidator;
		private readonly ILogger<OfficialAccountController> _logger;

		public OfficialAccountController(IOfficialAccountAccessValidator officialAccountAccessValidator, ILogger<OfficialAccountController> logger)
		{
			_officialAccountAccessValidator = officialAccountAccessValidator;
			_logger = logger;
		}

		[HttpGet]
		public string ValidateAccess(string signature, string timestamp, string nonce, string echostr)
		{
			if (_officialAccountAccessValidator.IsValid(signature, timestamp, nonce, echostr))
			{
				return echostr;
			}
			else
			{
				using (var streamReader = new StreamReader(Request.Body))
				{
					var requestString = streamReader.ReadToEnd();
					_logger.LogError($"Validate acess failed: {requestString}");
					return requestString;
				}
			}
		}
	}
}