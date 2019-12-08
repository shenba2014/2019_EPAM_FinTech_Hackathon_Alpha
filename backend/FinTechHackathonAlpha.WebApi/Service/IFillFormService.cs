using System.IO;
using FinTechHackathonAlpha.WebApi.Entity;

namespace FinTechHackathonAlpha.WebApi.Service
{
	public interface IFillFormService
	{
		Stream FillForm(Stream inputStream, Profile profile);
	}
}