using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FinTechHackathonAlpha.WebApi.Entity;

namespace FinTechHackathonAlpha.WebApi.Service
{
	public class DocumentService : IDocumentService
	{
		private readonly IFillFormService _fillFormService;

		public DocumentService(IFillFormService fillFormService)
		{
			_fillFormService = fillFormService;
		}

		public Stream Create(string agency, Profile profile)
		{
			var formFile = $"Forms\\{agency}\\form.pdf";
			var resultPDFOutputStream = new MemoryStream();
			using (Stream pdfInputStream = new FileStream(path: formFile, mode: FileMode.Open))
			using (Stream resultPDFStream = _fillFormService.FillForm(pdfInputStream, profile))
			{
				resultPDFStream.Position = 0;
				Console.WriteLine(resultPDFStream.Position.ToString());
				resultPDFStream.CopyTo(resultPDFOutputStream);
			}
			return resultPDFOutputStream;
		}
	}
}
