using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data.Models.Abstract;

namespace CarSystem.Data.Models
{
	public enum Fuels
	{
		Diesel,
		Gas,
		Petrol
	}

	public class Fuel : BaseEntity
	{
		public Fuels Type { get; set; }

		public ICollection<Car> Cars { get; set; }
	}
}
