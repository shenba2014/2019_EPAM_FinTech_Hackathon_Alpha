using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTechHackathonAlpha.WebApi.Entity
{
	public class Profile : IEntity
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }
	}
}
