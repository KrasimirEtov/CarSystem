using System.Collections.Generic;
using CarSystem.Data.Models.Associative;

namespace CarSystem.Services.Contracts
{
	public interface IExportService
	{
		void ExportPersonInformation(string fileName, string personName, List<PersonFines> personFines);

		void ExportCarInformation(string fileName, string carInfo, List<PersonFines> carFines);
	}
}
