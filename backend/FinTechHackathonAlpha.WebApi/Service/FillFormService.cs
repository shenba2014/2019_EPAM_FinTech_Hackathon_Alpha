﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FinTechHackathonAlpha.WebApi.Entity;
using iTextSharp.text.pdf;

namespace FinTechHackathonAlpha.WebApi.Service
{
	public class FillFormService : IFillFormService
	{
		public Stream FillForm(Stream inputStream, Profile  profile)
		{
			Stream outStream = new MemoryStream();
			PdfReader pdfReader = null;
			PdfStamper pdfStamper = null;
			Stream inStream = null;
			try
			{
				pdfReader = new PdfReader(inputStream);
				pdfStamper = new PdfStamper(pdfReader, outStream);
				AcroFields form = pdfStamper.AcroFields;
				form.SetField("FirstName", $"{profile.FirstName}");
				form.SetField("LastName", $"{profile.LastName}");
				form.SetField("IDNumber", $"{profile.IDNumber}");
				form.SetField("Nationality", $"{profile.Nationality}");
				form.SetField("Email", $"{profile.Email}");
				form.SetField("PhoneNumber", $"{profile.PhoneNumber}");
				pdfStamper.FormFlattening = true;
				return outStream;
			}
			finally
			{
				pdfStamper?.Close();
				pdfReader?.Close();
				inStream?.Close();
			}
		}
	}
}
