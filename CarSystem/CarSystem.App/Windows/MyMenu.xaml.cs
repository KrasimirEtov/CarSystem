using MahApps.Metro.Controls;

namespace CarSystem.App.Windows
{
	/// <summary>
	/// Interaction logic for Menu.xaml
	/// </summary>
	public partial class MyMenu : MetroWindow
	{
		public MyMenu()
		{
			InitializeComponent();
		}

		private void PreviousButton_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			var startupWindow = new MainWindow();
			this.Close();
			startupWindow.ShowDialog();
		}
	}
}
