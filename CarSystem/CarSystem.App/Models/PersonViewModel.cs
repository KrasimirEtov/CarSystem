using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.App.Models
{
	public class PersonViewModel : INotifyPropertyChanged
	{
		private int id;
		private string name;
		private string egn;
		private string displayName;

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

		public string EGN
		{
			get { return this.egn; }
			set
			{
				this.egn = value;
				NotifyPropertyChanged();
			}
		}

		public string DisplayName
		{
			get { return this.displayName; }
			set
			{
				this.displayName = value;
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
