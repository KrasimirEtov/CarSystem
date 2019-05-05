using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data.Models.Abstract;
using CarSystem.Data.Models.Associative;

namespace CarSystem.Data.Models
{
	public class Fine : BaseEntity
	{
		public string Name { get; set; }

		public string Violation { get; set; }

		public virtual ICollection<PersonFines> PersonFines { get; set; }
	}
}
