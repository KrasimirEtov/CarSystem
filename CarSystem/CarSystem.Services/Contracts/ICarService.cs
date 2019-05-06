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
	}
}
