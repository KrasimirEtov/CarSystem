using System;
using System.Collections.Generic;
using System.Linq;
using CarSystem.Data.Models;
using CarSystem.Data.Models.Associative;
using CarSystem.Services.Contracts;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace CarSystem.Services
{
	public class ExportService : IExportService
	{
		public void ExportPersonInformation(string fileName, string personName, List<PersonFines> personFines)
		{
			var writer = new PdfWriter(fileName);
			var pdf = new PdfDocument(writer);
			var document = new Document(pdf, PageSize.A4);

			document.Add(new Paragraph($"Violations made by {personName}"));
			document.Add(new Paragraph(Environment.NewLine));
			if (!personFines.Any())
			{
				document.Add(new Paragraph("This person has no violations."));
			}
			else
			{
				document.Add(new Paragraph($"Person information:\nName: {personFines[0].Person.FirstName} {personFines[0].Person.LastName}\r\nEGN: {personFines[0].Person.EGN}\r\nCard Id: {personFines[0].Person.CardId}\r\nOwned vehicles: {personFines[0].Person.PersonCars.Count}\r\nNumber of fines: {personFines[0].Person.PersonFines.Count}"));
				document.Add(new Paragraph(Environment.NewLine));
				document.Add(new Paragraph("Violations:\n"));
				foreach (var item in personFines)
				{
					document.Add(new Paragraph($"Type: {item.Fine.Name}\r\nViolation: {item.Fine.Violation}\r\nFine number: {item.FineNumber}\r\nVehicle: {item.Car.Brand} {item.Car.Model} {item.Car.Number}\r\n"));
				}
			}
			document.Close();
			writer.Close();
		}

		public void ExportCarInformation(string fileName, string carInfo, List<PersonFines> carFines)
		{
			var writer = new PdfWriter(fileName);
			var pdf = new PdfDocument(writer);
			var document = new Document(pdf, PageSize.A4);

			document.Add(new Paragraph($"Violations made by car {carInfo}"));
			document.Add(new Paragraph(Environment.NewLine));
			if (!carFines.Any())
			{
				document.Add(new Paragraph("This person has no violations."));
			}
			else
			{
				document.Add(new Paragraph($"Person information:\nName: {carFines[0].Person.FirstName} {carFines[0].Person.LastName}\r\nEGN: {carFines[0].Person.EGN}\r\nCard Id: {carFines[0].Person.CardId}\r\nOwned vehicles: {carFines[0].Person.PersonCars.Count}\r\nNumber of fines: {carFines[0].Person.PersonFines.Count}"));
				document.Add(new Paragraph(Environment.NewLine));
				document.Add(new Paragraph("Violations:\n"));
				foreach (var item in carFines)
				{
					document.Add(new Paragraph($"Type: {item.Fine.Name}\r\nViolation: {item.Fine.Violation}\r\nFine number: {item.FineNumber}\r\nVehicle: {item.Car.Brand} {item.Car.Model} {item.Car.Number}\r\n"));
				}
			}
			document.Close();
			writer.Close();
		}
	}
}
