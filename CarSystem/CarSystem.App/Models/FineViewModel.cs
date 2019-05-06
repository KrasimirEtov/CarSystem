using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.App.Models
{
	public class FineViewModel : INotifyPropertyChanged
	{
		private int id;
		private string name;
		private string violation;

		public int Id
		{
			get { return this.id; }
			set
			{
				this.id = value;
				NotifyPropertyChanged();
			}
		}

		public string Name
		{
			get { return this.name; }
			set
			{
				this.name = value;
				NotifyPropertyChanged();
			}
		}

		public string Violation
		{
			get { return this.violation; }
			set
			{
				this.violation = value;
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
