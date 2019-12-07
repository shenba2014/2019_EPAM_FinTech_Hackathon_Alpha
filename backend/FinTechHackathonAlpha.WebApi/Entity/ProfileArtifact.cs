using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTechHackathonAlpha.WebApi.Entity
{
	public class ProfileArtifact: IEntity
	{
		public int Id { get; set; }

		public int ProfileId { get; set; }

		public string Name { get; set; }

		public string Type { get; set; }

		public byte[] Content { get; set; }
	}
}
