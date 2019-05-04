using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data.Models.Abstract;
using CarSystem.Data.Models.Associative;

namespace CarSystem.Data.Models
{
	public enum Fines
	{
		SpeedLimit,
		NonCompliance,
		Tyres,
		Equipment,
		Custom
	}
	public class Fine : BaseEntity
	{
		public Fines Type { get; set; }

		public string Violation { get; set; }

		public virtual ICollection<PersonFines> PersonFines { get; set; }
	}
}
