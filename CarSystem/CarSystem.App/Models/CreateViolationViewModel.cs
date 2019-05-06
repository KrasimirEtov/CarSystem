using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.App.Models
{
	public class CreateViolationViewModel : INotifyPropertyChanged
	{
		private int personId;
		private int carId;
		private int fineId;
		private int violationId;
		private decimal price;
		private DateTime licenceBackOn;
		private string fineNumber;

		public int PersonId
		{
			get { return this.personId; }
			set
			{
				this.personId = value;
				NotifyPropertyChanged();
			}
		}

		public int CarId
		{
			get { return this.carId; }
			set
			{
				this.carId = value;
				NotifyPropertyChanged();
			}
		}

		public int FineId
		{
			get { return this.fineId; }
			set
			{
				this.fineId = value;
				NotifyPropertyChanged();
			}
		}

		public int ViolationId
		{
			get { return this.violationId; }
			set
			{
				this.violationId = value;
				NotifyPropertyChanged();
			}
		}

		public decimal Price
		{
			get { return this.price; }
			set
			{
				this.price = value;
				NotifyPropertyChanged();
			}
		}

		public DateTime LicenceBackOn
		{
			get { return this.licenceBackOn; }
			set
			{
				this.licenceBackOn = value;
				NotifyPropertyChanged();
			}
		}

		public string FineNumber
		{
			get { return this.fineNumber; }
			set
			{
				this.fineNumber = value;
				NotifyPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (this.PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
