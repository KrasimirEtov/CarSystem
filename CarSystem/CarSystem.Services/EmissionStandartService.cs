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
	public class EmissionStandartService : IEmissionStandartService
	{
		private readonly CarSystemDbContext context;

		public EmissionStandartService(CarSystemDbContext context)
		{
			this.context = context;
		}

		public Task<List<EmissionStandart>> GetAllEmissionStandartsAsync()
		{
			return this.context.EmissionStandarts
				.ToListAsync();
		}
	}
}
