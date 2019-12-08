using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FinTechHackathonAlpha.WebApi.Entity;
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
		public async Task<Profile> UpdateProfileAsync([FromBody] Profile model)
		{
			if (model.Id == 0)
			{
				await _profileRepository.CreateAsync(model);
				return model;
			}
			else
			{
				await _profileRepository.UpdateAsync(model.Id, model);
				return model;
			}
		}

	    [HttpGet("get-artifacts")]
	    public IEnumerable<ProfileArtifact> GetProfileArtifacts(int profileId)
	    {
		    return _profileArtifactRepository.GetAll().Where(p => p.ProfileId == profileId)
			    .Select(p => new ProfileArtifact
			    {
				    Name = p.Name,
				    Type = p.Type,
				    ProfileId = p.ProfileId
			    });
	    }

	    [HttpPost("upload-artifact")]
		public async Task<ProfileArtifact> UploadArtifactAsync(int profileId, string type, IFormFile artifact)
	    {
		    using (var memoryStream = new MemoryStream())
		    {
			    await artifact.CopyToAsync(memoryStream);

			    // Upload the file if less than 2 MB
			    if (memoryStream.Length < 2097152)
			    {
				    var profileArtifact = new ProfileArtifact()
				    {
						ProfileId = profileId,
						Name = Path.GetFileName(artifact.FileName),
						Type = type,
					    Content = memoryStream.ToArray()
				    };
				    await _profileArtifactRepository.CreateAsync(profileArtifact);

				    profileArtifact.Content = null;
					return profileArtifact;
			    }
			    else
			    {
				    ModelState.AddModelError("File", "The file is too large.");
				    return null;
			    }
		    }
	    }

		[HttpDelete("delete-artifact")]
	    public async Task DeleteArtifactAsync(int id)
		{
			 await _profileArtifactRepository.DeleteAsync(id);
		}

	    [HttpGet("download-artifact")]
		public async Task<IActionResult> DownloadArtifact(int id)
	    {
		   var profileArtifact = await  _profileArtifactRepository.GetByIdAsync(id);

			if (profileArtifact == null)
				return NotFound();

			var stream = new MemoryStream(profileArtifact.Content);

			if (stream == null)
			    return NotFound();

		    return File(stream, "application/octet-stream", profileArtifact.Name);
		}

	    [HttpGet("request-document")]
		public void RequestDocument(string agency, int profileId, string additionArtifacts)
	    {
	    }
	}
}