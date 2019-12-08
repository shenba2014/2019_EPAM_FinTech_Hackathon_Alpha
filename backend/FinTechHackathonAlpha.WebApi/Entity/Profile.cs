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

		public string Gender { get; set; }

		public string IDNumber { get; set; }

		public string Email { get; set; }

		public string Address { get; set; }

		public string Nationality { get; set; }

		public string PhoneNumber { get; set; }
	}
}
