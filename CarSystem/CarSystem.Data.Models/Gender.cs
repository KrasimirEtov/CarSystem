using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data.Models.Abstract;

namespace CarSystem.Data.Models
{
	public enum Genders
	{
		Male,
		Female
	}

	public class Gender : BaseEntity
	{
		public Genders Type { get; set; }

		public ICollection<Person> Persons { get; set; }
	}
}
