using System.Windows;
using System.Windows.Controls;
using Autofac;
using CarSystem.App.Infrastructure;
using CarSystem.App.Windows;
using MahApps.Metro.Controls;

namespace CarSystem.App
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		IContainer container = ContainerConfiguration.GetContainer();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void StartupButton_Click(object sender, RoutedEventArgs e)
		{
			var myMenu = container.Resolve<MyMenu>();
			this.Close();
			myMenu.ShowDialog();
		}
	}
}
