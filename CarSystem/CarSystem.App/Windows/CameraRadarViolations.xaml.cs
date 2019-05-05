using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using CarSystem.App.Models;
using MahApps.Metro.Controls;

namespace CarSystem.App.Windows
{
	/// <summary>
	/// Interaction logic for CameraRadarViolations.xaml
	/// </summary>
	public partial class CameraRadarViolations : MetroWindow, INotifyPropertyChanged
	{
		Autofac.IContainer container = ContainerConfiguration.GetContainer();

		public event PropertyChangedEventHandler PropertyChanged;

		private List<CameraRadarViolationsViewModel> cameraRadarViolationsList;
		public List<CameraRadarViolationsViewModel> CameraRadarViolationsList
		{
			get
			{
				return this.cameraRadarViolationsList;
			}
			set
			{
				cameraRadarViolationsList = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CameraRadarViolationsList"));
			}
		}

		public CameraRadarViolations()
		{
			InitializeComponent();
			CameraRadarViolationsList = GetData(); // Call service to get all camera violations here
			this.CameraRadarViolationsDataGrid.DataContext = CameraRadarViolationsList;
		}

		private void PreviousButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			var myMenu = container.Resolve<Violations>();
			this.Close();
			myMenu.ShowDialog();
		}

		private void HomeScreenButton_Click(object sender, RoutedEventArgs e)
		{
			var startupWindow = container.Resolve<MainWindow>();
			this.Close();
			startupWindow.ShowDialog();
		}

		private void FilterButton_Click(object sender, RoutedEventArgs e)
		{
			// Call service and pass filter parameters to get filtered results here
			CameraRadarViolationsList = new List<CameraRadarViolationsViewModel>()
			{
				new CameraRadarViolationsViewModel()
				{
					CarBrand = "Audi",
					CardId = "12345678",
					CarModel = "A3",
					EGN = "123456789",
					Name = "Imeto na chovekaaaaaaaaaaaaaaaaaaaaa"
				}
			};
			CameraRadarViolationsDataGrid.ItemsSource = CameraRadarViolationsList;
		}

		private void ClearFiltersButton_Click(object sender, RoutedEventArgs e)
		{
			CardIdTextBox.Text = "";
			FineNumberTextBox.Text = "";
			EGNTextBox.Text = "";
			VehicleNumberTextBox.Text = "";
			// Call service here with empty parameters to get all data
		}

		private void TextBoxChange(object sender, TextChangedEventArgs e)
		{
			if (!string.IsNullOrEmpty(CardIdTextBox.Text) || !string.IsNullOrEmpty(FineNumberTextBox.Text) || !string.IsNullOrEmpty(EGNTextBox.Text) || !string.IsNullOrEmpty(VehicleNumberTextBox.Text))
			{
				ClearFiltersButton.IsEnabled = true;
				FilterButton.IsEnabled = true;
			}
			else
			{
				ClearFiltersButton.IsEnabled = false;
				FilterButton.IsEnabled = false;
			}
		}

		private List<CameraRadarViolationsViewModel> GetData()
		{
			var list = new List<CameraRadarViolationsViewModel>()
			{
				new CameraRadarViolationsViewModel()
				{
					CarBrand = "Audi",
					CardId = "12345678",
					CarModel = "A3",
					EGN = "123456789",
					Name = "Imeto na chovekaaaaaaaaaaaaaaaaaaaaa"
				},
				new CameraRadarViolationsViewModel()
				{
					CarBrand = "Audi",
					CardId = "12345678",
					CarModel = "A3",
					EGN = "123456789",
					Name = "Imeto na chovekaaaaaaaaaaaaaaaaaaaaa"
				}
			};
			return list;
		}
	}
}
