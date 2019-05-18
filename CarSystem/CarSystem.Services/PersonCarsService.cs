using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data;
using CarSystem.Data.Models;
using CarSystem.Data.Models.Associative;
using CarSystem.Services.Contracts;

namespace CarSystem.Services
{
	public class PersonCarsService : IPersonCarsService
	{
		private readonly CarSystemDbContext context;

		public PersonCarsService(CarSystemDbContext context)
		{
			this.context = context;
		}

		public async Task CreatePersonCarAsync(Person person, int carId)
		{
			var personCarRecord = new PersonCars()
			{
				Person = person,
				CarId = carId
			};

			this.context.PersonCars.Add(personCarRecord);
			await this.context.SaveChangesAsync();
		}
	}
}
