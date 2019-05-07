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
	public class ViolationService : IViolationService
	{
		private readonly CarSystemDbContext context;

		public ViolationService(CarSystemDbContext context)
		{
			this.context = context;
		}

		public Task<List<Violation>> GetAllViolationsAsync()
		{
			return this.context.Violations
				.ToListAsync();
		}
	}
}
