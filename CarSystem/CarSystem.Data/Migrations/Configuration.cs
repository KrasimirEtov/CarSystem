namespace CarSystem.Data.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;
	using CarSystem.Data.Models;

	internal sealed class Configuration : DbMigrationsConfiguration<CarSystem.Data.CarSystemDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(CarSystem.Data.CarSystemDbContext context)
		{
			// Seed genders
			context.Genders
				.AddOrUpdate(x => x.Id,
				new Gender() { Id = 1, Type = Genders.Male },
				new Gender() { Id = 2, Type = Genders.Female }
				);

			// Seed emission standarts
			context.EmissionStandarts
				.AddOrUpdate(x => x.Id,
				new EmissionStandart() { Id = 1, Type = EmissionStandarts.Euro1 },
				new EmissionStandart() { Id = 2, Type = EmissionStandarts.Euro2 },
				new EmissionStandart() { Id = 3, Type = EmissionStandarts.Euro3 },
				new EmissionStandart() { Id = 4, Type = EmissionStandarts.Euro4 },
				new EmissionStandart() { Id = 5, Type = EmissionStandarts.Euro5 },
				new EmissionStandart() { Id = 6, Type = EmissionStandarts.Euro6 },
				new EmissionStandart() { Id = 7, Type = EmissionStandarts.Euro6RDE }
				);

			// Seed fuels
			context.Fuels
				.AddOrUpdate(x => x.Id,
				new Fuel() { Id = 1, Type = Fuels.Diesel },
				new Fuel() { Id = 2, Type = Fuels.Petrol },
				new Fuel() { Id = 3, Type = Fuels.Gas }
				);

			// Seed fines
			context.Fines
				.AddOrUpdate(x => x.Id,
				new Fine() { Id = 1, Type = Fines.SpeedLimit, Violation = "Движи се с превишена скорост" },
				new Fine() { Id = 2, Type = Fines.Equipment, Violation = "Няма необходимите предпазни средства" },
				new Fine() { Id = 3, Type = Fines.NonCompliance, Violation = "Не спазва указанията на знаците" },
				new Fine() { Id = 4, Type = Fines.Tyres, Violation = "Не е с необходимия за сезона вид гуми" }
				);
		}
	}
}
