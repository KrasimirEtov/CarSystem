using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data;
using CarSystem.Data.Models;
using CarSystem.Services.Contracts;

namespace CarSystem.Services
{
	public class CarService : ICarService
	{
		private readonly CarSystemDbContext context;

		public CarService(CarSystemDbContext context)
		{
			this.context = context;
		}

		public Task<List<Car>> GetPersonCarsAsync(int personId)
		{
			return this.context.PersonCars
				.Where(x => x.PersonId == personId)
				.Select(x => x.Car)
				.ToListAsync();
		}
	}
}
