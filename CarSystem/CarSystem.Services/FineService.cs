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
	public class FineService : IFineService
	{
		private readonly CarSystemDbContext context;

		public FineService(CarSystemDbContext context)
		{
			this.context = context;
		}

		public Task<List<Fine>> GetAllFinesAsync()
		{
			return this.context.Fines
				.ToListAsync();
		}
	}
}
