using CarSystem.Data.Models.Abstract;

namespace CarSystem.Data.Models.Associative
{
	public class PersonCars : BaseEntity
	{
		public int PersonId { get; set; }
		public int CarId { get; set; }

		public virtual Person Person { get; set; }
		public virtual Car Car { get; set; }
	}
}
