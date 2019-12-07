using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTechHackathonAlpha.WebApi.Models
{
	public class CreateDocumentLinkModel
	{
		public string Agency { get; set; }

		public string Type { get; set; }

		public string[] Items { get; set; }
	}
}
