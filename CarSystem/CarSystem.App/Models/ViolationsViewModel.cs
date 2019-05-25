using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.App.Models
{
	public class ViolationsViewModel : INotifyPropertyChanged
	{
		private int personFineId;
		private string finePrice;
		private string name;
		private string egn;
		private string cardId;
		private string carBrand;
		private string carModel;
		private string carNumber;
		private string fineNumber;

		[DisplayName("№")]
		public int PersonFineId
		{
			get { return this.personFineId; }
			set
			{
				this.personFineId = value;
				NotifyPropertyChanged();
			}
		}

		[DisplayName("№ фиш")]
		public string FineNumber
		{
			get { return this.fineNumber; }
			set
			{
				this.fineNumber = value;
				NotifyPropertyChanged();
			}
		}

		[DisplayName("Глоба")]
		public string FinePrice
		{
			get { return this.finePrice; }
			set
			{
				this.finePrice = value;
				NotifyPropertyChanged();
			}
		}

		[DisplayName("Име")]
		public string Name
		{
			get { return this.name; }
			set
			{
				this.name = value;
				NotifyPropertyChanged();
			}
		}

		[DisplayName("ЕГН")]
		public string EGN
		{
			get { return this.egn; }
			set
			{
				this.egn = value;
				NotifyPropertyChanged();
			}
		}

		[DisplayName("№ Л.К")]
		public string CardId
		{
			get { return this.cardId; }
			set
			{
				this.cardId = value;
				NotifyPropertyChanged();
			}
		}

		[DisplayName("Марка")]
		public string CarBrand
		{
			get { return this.carBrand; }
			set
			{
				this.carBrand = value;
				NotifyPropertyChanged();
			}
		}

		[DisplayName("Модел")]
		public string CarModel
		{
			get { return this.carModel; }
			set
			{
				this.carModel = value;
				NotifyPropertyChanged();
			}
		}

		[DisplayName("№ кола")]
		public string CarNumber
		{
			get { return this.carNumber; }
			set
			{
				this.carNumber = value;
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
