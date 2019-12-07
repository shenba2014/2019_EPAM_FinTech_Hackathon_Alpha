using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinTechHackathonAlpha.WebApi.Entity;

namespace FinTechHackathonAlpha.WebApi.Repository
{
	public class ProfileArtifactRepository : GenericRepository<ProfileArtifact>, IProfileArtifactRepository
	{
		public ProfileArtifactRepository(FinPassDbContext dbContext) : base(dbContext)
		{
		}
	}
}
