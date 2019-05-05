using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.App.Models
{
	public class CameraRadarViolationsViewModel : INotifyPropertyChanged
	{
		private string name;
		private string egn;
		private string cardId;
		private string carBrand;
		private string carModel;
		private string carNumber;

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

		[DisplayName("Лична карта")]
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

		[DisplayName("Номер")]
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
