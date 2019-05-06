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
using Autofac;
using CarSystem.App.Infrastructure;
using MahApps.Metro.Controls;

namespace CarSystem.App.Windows
{
	/// <summary>
	/// Interaction logic for Violations.xaml
	/// </summary>
	public partial class ViolationsNOTUSED : MetroWindow
	{
		IContainer container = ContainerConfiguration.GetContainer();

		public ViolationsNOTUSED()
		{
			InitializeComponent();
		}

		private void PreviousButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			var myMenu = container.Resolve<MyMenu>();
			this.Close();
			myMenu.ShowDialog();
		}

		private void HomeScreenButton_Click(object sender, RoutedEventArgs e)
		{
			var startupWindow = container.Resolve<MainWindow>();
			this.Close();
			startupWindow.ShowDialog();
		}

		private void CameraRadarTile_Click(object sender, RoutedEventArgs e)
		{
			var startupWindow = container.Resolve<Violations>();
			this.Close();
			startupWindow.ShowDialog();
		}
	}
}
