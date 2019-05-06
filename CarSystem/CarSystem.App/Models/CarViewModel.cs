using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.App.Models
{
	public class CarViewModel : INotifyPropertyChanged
	{
		private int id;
		private string brand;
		private string model;
		private string number;

		public int Id
		{
			get { return this.id; }
			set
			{
				this.id = value;
				NotifyPropertyChanged();
			}
		}

		public string Brand
		{
			get { return this.brand; }
			set
			{
				this.brand = value;
				NotifyPropertyChanged();
			}
		}

		public string Model
		{
			get { return this.model; }
			set
			{
				this.model = value;
				NotifyPropertyChanged();
			}
		}

		public string Number
		{
			get { return this.number; }
			set
			{
				this.number = value;
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
