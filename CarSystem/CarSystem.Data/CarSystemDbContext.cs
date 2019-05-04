using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data.Models;
using CarSystem.Data.Models.Associative;

namespace CarSystem.Data
{
	public class CarSystemDbContext : DbContext
	{
		public CarSystemDbContext() : base("CarSystemDb")
		{

		}

		public DbSet<Person> People { get; set; }

		public DbSet<Gender> Genders { get; set; }

		public DbSet<Car> Cars { get; set; }

		public DbSet<EmissionStandart> EmissionStandarts { get; set; }

		public DbSet<Fine> Fines { get; set; }

		public DbSet<Fuel> Fuels { get; set; }

		public DbSet<PersonCars> PersonCars { get; set; }

		public DbSet<PersonFines> PersonFines { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
