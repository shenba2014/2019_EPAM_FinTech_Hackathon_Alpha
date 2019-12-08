using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTechHackathonAlpha.WebApi.Entity
{
	public class DocumentTemplate : IEntity
	{
		public int Id { get; set; }

		public string Agency { get; set; }

		public byte[] Content { get; set; }
	}
}
