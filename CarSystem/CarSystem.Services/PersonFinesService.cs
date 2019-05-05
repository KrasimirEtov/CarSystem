using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data;
using CarSystem.Data.Models.Associative;
using CarSystem.Services.Contracts;

namespace CarSystem.Services
{
	public class PersonFinesService : IPersonFinesService
	{
		private readonly CarSystemDbContext context;

		public PersonFinesService(CarSystemDbContext context)
		{
			this.context = context;
		}

		public Task<List<PersonFines>> GetAllPersonFinesAsync()
		{
			return this.context.PersonFines
				.ToListAsync();
		}
	}
}
