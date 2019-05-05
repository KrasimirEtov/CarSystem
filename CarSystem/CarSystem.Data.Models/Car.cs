using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data.Models.Abstract;
using CarSystem.Data.Models.Associative;

namespace CarSystem.Data.Models
{
	public class Car : BaseEntity
	{
		public string Brand { get; set; }

		public string Model { get; set; }

		public string Paint { get; set; }

		public int EnginePower { get; set; }

		public int PeopleCarry { get; set; }

		public decimal Weight { get; set; }

		public string Number { get; set; }

		public int FuelId { get; set; }
		public Fuel Fuel { get; set; }

		public int EmissionStandartId { get; set; }
		public EmissionStandart EmissionStandart { get; set; }

		public virtual ICollection<PersonCars> PersonCars { get; set; }

		public virtual ICollection<PersonFines> PersonFines { get; set; }

	}
}
