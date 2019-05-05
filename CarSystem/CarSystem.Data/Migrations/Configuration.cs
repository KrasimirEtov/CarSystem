namespace CarSystem.Data.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;
	using CarSystem.Data.Models;
	using CarSystem.Data.Models.Associative;

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

			// Seed violations
			context.Violations
				.AddOrUpdate(x => x.Id,
				new Violation() { Id = 1, Name = "Camera", Message = "Засечен от камера" },
				new Violation() { Id = 2, Name = "Slip", Message = "Получил фиш" },
				new Violation() { Id = 3, Name = "Act", Message = "Получил акт" }
				);

			// Seed Person
			context.People
				.AddOrUpdate(x => x.Id,
				new Person() { Id = 1, CardId = "1234", EGN = "12345", FirstName = "Gordon", LastName = "Freeman", GenderId = 1 }
				);

			// Seed Car
			context.Cars
				.AddOrUpdate(x => x.Id,
				new Car() { Id = 1, Brand = "Audi", EmissionStandartId = 1, EnginePower = 125, FuelId = 3, Model = "A3", Number = "PA1997KM", Paint = "Black", PeopleCarry = 5, Weight = 3500 }
				);

			// Seed Person Cars
			context.PersonCars
				.AddOrUpdate(x => x.Id,
				new PersonCars() { Id = 1, PersonId = 1, CarId = 1 }
				);

			// Seed Person Fines
			context.PersonFines
				.AddOrUpdate(x => x.Id,
				new PersonFines() { Id = 1, CarId = 1, FineId = 1, FineNumber = "3021", PersonId = 1, LicenceBackOn = DateTime.Now, Price = 150, ViolationId = 1 }
				);
		}
	}
}
