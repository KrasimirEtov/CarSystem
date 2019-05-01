using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using CarSystem.App.Infrastructure;

namespace CarSystem.App
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			var container = ContainerConfiguration.GetContainer();
			var startupWindow = container.Resolve<MainWindow>();
			startupWindow.ShowDialog();
		}
	}
}
