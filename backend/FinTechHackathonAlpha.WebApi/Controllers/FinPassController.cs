using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinTechHackathonAlpha.WebApi.Entity;
using FinTechHackathonAlpha.WebApi.Models;
using FinTechHackathonAlpha.WebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinTechHackathonAlpha.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class FinPassController : ControllerBase
    {
		private readonly IProfileRepository _profileRepository;
		private readonly IProfileArtifactRepository _profileArtifactRepository;

		public FinPassController(IProfileRepository profileRepository, IProfileArtifactRepository profileArtifactRepository)
	    {
			_profileRepository = profileRepository;
			_profileArtifactRepository = profileArtifactRepository;
		}

		[HttpGet("get-profile")]
	    public async Task<Profile> GetProfileAsync(int id)
		{
			return await _profileRepository.GetByIdAsync(id);
		}

		[HttpPost("update-profile")]
		public async Task UpdateProfileAsync([FromBody] Profile model)
		{
			if (model.Id == 0)
			{
				await _profileRepository.CreateAsync(model);
			}
			else
			{
				await _profileRepository.UpdateAsync(model.Id, model);
			}
		}

		[HttpPost("upload-artifact")]
		public void UploadArtifact(string name, string type, List<IFormFile> artifacts)
	    {
	    }

		[HttpDelete("delete-artifact")]
	    public void DeleteArtifact(string id)
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