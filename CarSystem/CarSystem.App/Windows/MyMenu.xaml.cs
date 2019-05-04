using Autofac;
using CarSystem.App.Infrastructure;
using MahApps.Metro.Controls;

namespace CarSystem.App.Windows
{
	/// <summary>
	/// Interaction logic for Menu.xaml
	/// </summary>
	public partial class MyMenu : MetroWindow
	{
		IContainer container = ContainerConfiguration.GetContainer();

		public MyMenu()
		{
			InitializeComponent();
		}

		private void PreviousButton_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			var startupWindow = container.Resolve<MainWindow>();
			this.Close();
			startupWindow.ShowDialog();
		}

		private void ViolationsTile_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			var violationsWindow = container.Resolve<Violations>();
			this.Close();
			violationsWindow.ShowDialog();
		}
	}
}
