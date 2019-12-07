using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTechHackathonAlpha.WebApi.Models
{
	public class UpdateProfileModel
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Gender { get; set; }

		public string IDCard { get; set; }
	}
}
