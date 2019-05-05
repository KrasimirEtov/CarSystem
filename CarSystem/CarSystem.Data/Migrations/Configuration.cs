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
				new Gender() { Id = 1, Name = "Мъж" },
				new Gender() { Id = 2, Name = "Жена" }
				);

			// Seed emission standarts
			context.EmissionStandarts
				.AddOrUpdate(x => x.Id,
				new EmissionStandart() { Id = 1, Name = "Euro 1" },
				new EmissionStandart() { Id = 2, Name = "Euro 2" },
				new EmissionStandart() { Id = 3, Name = "Euro 3" },
				new EmissionStandart() { Id = 4, Name = "Euro 4" },
				new EmissionStandart() { Id = 5, Name = "Euro 5" },
				new EmissionStandart() { Id = 6, Name = "Euro 6" },
				new EmissionStandart() { Id = 7, Name = "Euro 6 RDE" }
				);

			// Seed fuels
			context.Fuels
				.AddOrUpdate(x => x.Id,
				new Fuel() { Id = 1, Name = "Дизел" },
				new Fuel() { Id = 2, Name = "Бензин" },
				new Fuel() { Id = 3, Name = "Газ" }
				);

			// Seed fines
			context.Fines
				.AddOrUpdate(x => x.Id,
				new Fine() { Id = 1, Name = "Превишена скорост", Violation = "Движи се с превишена скорост" },
				new Fine() { Id = 2, Name = "Оборудване", Violation = "Няма необходимите предпазни средства" },
				new Fine() { Id = 3, Name = "Неспазване на закон", Violation = "Не спазва указанията на знаците" },
				new Fine() { Id = 4, Name = "Гуми", Violation = "Не е с необходимия за сезона вид гуми" }
				);
		}
	}
}
