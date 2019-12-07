using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FinTechHackathonAlpha.WebApi.OfficialAccount;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinTechHackathonAlpha.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficialAccountController : ControllerBase
    {
		private readonly IEchoUrlValidator _echoUrlValidator;
		private readonly ILogger<OfficialAccountController> _logger;

		public OfficialAccountController(IEchoUrlValidator echoUrlValidator, ILogger<OfficialAccountController> logger)
	    {
			_echoUrlValidator = echoUrlValidator;
			_logger = logger;
		}

		[HttpGet]
		public string ValidateAccess(string signature, string timestamp, string nonce, string echostr)
		{
			if (_echoUrlValidator.IsValid(signature, timestamp, nonce, echostr))
			{
				return echostr;
			}
			else
			{
				_logger.LogError($"Validate Failed:requestString={Request.QueryString.ToString()}");
				return Request.QueryString.ToString();
			}
		}
	}
}