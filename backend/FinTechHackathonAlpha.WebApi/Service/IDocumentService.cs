using System.IO;
using FinTechHackathonAlpha.WebApi.Entity;

namespace FinTechHackathonAlpha.WebApi.Service
{
	public interface IDocumentService
	{
		Stream Create(string agency, Profile profile);
	}
}