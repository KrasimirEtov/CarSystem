using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data.Models;

namespace CarSystem.Services.Contracts
{
	public interface ICarService
	{
		Task<List<Car>> GetPersonCarsAsync(int personId);

		Task<List<Car>> GetAllCarsAsync();

		Task CreateCarAsync(string carBrand, string carModel, int enginePower, int peopleCarry, int weight, string color, int fuelId, int emissionStandartId, string number);
	}
}
