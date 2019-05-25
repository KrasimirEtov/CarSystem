using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data.Models.Associative;

namespace CarSystem.Services.Contracts
{
	public interface IPersonFinesService
	{
		Task<List<PersonFines>> GetFilteredPersonFinesAsync(string violationName = "", string cardId = "", string egn = "", string carNumber = "", string fineNumber = "");

		Task DeletePersonFineAsync(int personFineId);

		Task CreatePersonFineAsync(int personId, int carId, int violationId, int fineId, decimal finePrice, string fineNumber, DateTime licenceBackOn);

		Task<List<PersonFines>> GetPersonFinesByPersonId(int personId);

		Task<List<PersonFines>> GetCarFinesByCarId(int carId);
	}
}
