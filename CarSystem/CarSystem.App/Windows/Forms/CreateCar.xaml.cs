using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CarSystem.App.Infrastructure;
using MahApps.Metro.Controls;

namespace CarSystem.App.Windows.Forms
{
	/// <summary>
	/// Interaction logic for CreateCar.xaml
	/// </summary>
	public partial class CreateCar : MetroWindow
	{
		Autofac.IContainer container = ContainerConfiguration.GetContainer();

		public CreateCar()
		{
			InitializeComponent();
		}

		private void TextBoxChange(object sender, TextChangedEventArgs e)
		{

		}
	}
}
