using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinTechHackathonAlpha.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinTechHackathonAlpha.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class FinPassController : ControllerBase
    {
		[HttpGet("get-profile")]
	    public ProfileModel GetProfile()
		{
			return new ProfileModel();
		}

		[HttpPost("update-profile")]
		public void UpdateProfile([FromBody] UpdateProfileModel model)
		{
		}

		[HttpPost("upload-artifact")]
		public void UploadArtifact(string name, string type, List<IFormFile> artifacts)
	    {
	    }

	    [HttpPost("create-document-link")]
		public void CreateDocumentLink([FromBody] CreateDocumentLinkModel model)
	    {
	    }

	    [HttpGet("request-document")]
		public void DownloadDocument(string documentHash)
	    {
	    }
	}
}