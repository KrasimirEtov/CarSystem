using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data.Models.Abstract;

namespace CarSystem.Data.Models
{
	public enum EmissionStandarts
	{
		Euro1,
		Euro2,
		Euro3,
		Euro4,
		Euro5,
		Euro6,
		Euro6RDE
	}

	public class EmissionStandart : BaseEntity
	{
		public EmissionStandarts Type { get; set; }

		public ICollection<Car> Cars { get; set; }
	}
}
