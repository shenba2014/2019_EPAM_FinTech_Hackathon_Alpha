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
	    public ProfileModel GetProfile(int id)
		{
			return new ProfileModel();
		}

		[HttpPost("update-profile")]
		public void UpdateProfile([FromBody] UpdateProfileModel model)
		{
			if (model.Id == 0)
			{
				_profileRepository.CreateAsync(new Profile
				{
					FirstName = model.FirstName,
					LastName = model.LastName
				});
			}
			else
			{
				_profileRepository.UpdateAsync(model.Id, new Profile
				{
					Id = model.Id,
					FirstName = model.FirstName,
					LastName = model.LastName
				});
			}
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