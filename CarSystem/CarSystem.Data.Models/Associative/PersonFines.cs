using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data.Models.Abstract;

namespace CarSystem.Data.Models.Associative
{
	public class PersonFines : BaseEntity
	{
		public decimal Price { get; set; }

		public DateTime LicenceBackOn { get; set; }

		public string FineNumber { get; set; }

		public int PersonId { get; set; }
		public int FineId { get; set; }

		public virtual Person Person { get; set; }
		public virtual Fine Fine { get; set; }
	}
}
