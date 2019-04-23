using System.Windows;
using System.Windows.Controls;
using CarSystem.App.Windows;
using MahApps.Metro.Controls;

namespace CarSystem.App
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void StartupButton_Click(object sender, RoutedEventArgs e)
		{
			var myMenu = new MyMenu();
			this.Close();
			myMenu.ShowDialog();
		}
	}
}
