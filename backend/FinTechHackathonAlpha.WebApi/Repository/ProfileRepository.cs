using FinTechHackathonAlpha.WebApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTechHackathonAlpha.WebApi.Repository
{
	public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
	{
		public ProfileRepository(FinPassDbContext dbContext) : base(dbContext)
		{
		}
	}
}
