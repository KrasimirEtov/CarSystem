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
	public class PeopleService : IPeopleService
	{
		private readonly CarSystemDbContext context;

		public PeopleService(CarSystemDbContext context)
		{
			this.context = context;
		}

		public Task<List<Person>> GetAllPersonsAsync()
		{
			return this.context.People
				.ToListAsync();
		}
	}
}
