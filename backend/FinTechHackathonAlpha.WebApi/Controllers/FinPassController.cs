using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinTechHackathonAlpha.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class FinPassController : ControllerBase
    {
		[HttpGet("get-profile")]
	    public string GetProfile()
	    {
		    return "GetProfile";
	    }

		[HttpPost("update-profile")]
		public void UpdateProfile([FromBody] string value)
		{
		}

		[HttpPost("upload-artifact")]
		public void UploadArtifact([FromBody] string value)
	    {
	    }

	    [HttpPost("create-document-link")]
		public void CreateDocumentLink()
	    {
	    }

	    [HttpGet("request-document")]
		public void DownloadDocument()
	    {
	    }
	}
}