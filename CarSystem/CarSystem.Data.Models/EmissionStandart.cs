using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data.Models.Abstract;

namespace CarSystem.Data.Models
{
	public class EmissionStandart : BaseEntity
	{
		public string Name { get; set; }

		public ICollection<Car> Cars { get; set; }
	}
}
