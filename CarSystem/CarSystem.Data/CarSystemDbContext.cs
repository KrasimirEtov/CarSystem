using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data.Models;

namespace CarSystem.Data
{
	public class CarSystemDbContext : DbContext
	{
		public CarSystemDbContext() : base("CarSystemDb")
		{

		}

		public DbSet<Person> People { get; set; }

		public DbSet<Gender> Genders { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
