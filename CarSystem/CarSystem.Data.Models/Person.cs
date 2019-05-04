using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data.Models.Abstract;
using CarSystem.Data.Models.Associative;

namespace CarSystem.Data.Models
{
	public class Person : BaseEntity
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string EGN { get; set; }

		public string CardId { get; set; }

		public int GenderId { get; set; }
		public Gender Gender { get; set; }

		public virtual ICollection<PersonCars> PersonCars { get; set; }

		public virtual ICollection<PersonFines> PersonFines { get; set; }
	}
}
