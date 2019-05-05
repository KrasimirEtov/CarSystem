using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Autofac;
using AutoMapper;
using CarSystem.App.Infrastructure;
using CarSystem.App.Models;
using CarSystem.App.Windows.Forms;
using CarSystem.Data.Models.Associative;
using CarSystem.Services.Contracts;
using MahApps.Metro.Controls;

namespace CarSystem.App.Windows
{
	/// <summary>
	/// Interaction logic for CameraRadarViolations.xaml
	/// </summary>
	public partial class CameraRadarViolations : MetroWindow
	{
		Autofac.IContainer container = ContainerConfiguration.GetContainer();

		public ObservableCollection<CameraRadarViolationsViewModel> CameraRadarViolationsList { get; set; }

		public CameraRadarViolations()
		{
			CameraRadarViolationsList = new ObservableCollection<CameraRadarViolationsViewModel>();
			InitializeComponent();
			LoadAllRecords();
			CameraRadarViolationsDataGrid.ItemsSource = CameraRadarViolationsList;
		}

		private void LoadAllRecords()
		{
			var personFinesService = container.Resolve<IPersonFinesService>();
			var dbModels = personFinesService.GetFilteredPersonFinesAsync(CarSystemConstants.CameraViolationName).Result;

			ProcessDbModels(dbModels);
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
			var personFinesService = container.Resolve<IPersonFinesService>();

			var dbModels = personFinesService.GetFilteredPersonFinesAsync(CarSystemConstants.CameraViolationName, CardIdTextBox.Text, EGNTextBox.Text, VehicleNumberTextBox.Text, FineNumberTextBox.Text).Result;

			ProcessDbModels(dbModels);
		}

		private void ClearFiltersButton_Click(object sender, RoutedEventArgs e)
		{
			CardIdTextBox.Text = "";
			FineNumberTextBox.Text = "";
			EGNTextBox.Text = "";
			VehicleNumberTextBox.Text = "";

			LoadAllRecords();
		}

		private void TextBoxChange(object sender, TextChangedEventArgs e)
		{
			if (!string.IsNullOrEmpty(CardIdTextBox.Text) || !string.IsNullOrEmpty(FineNumberTextBox.Text) || !string.IsNullOrEmpty(EGNTextBox.Text) || !string.IsNullOrEmpty(VehicleNumberTextBox.Text))
			{
				FilterButton.IsEnabled = true;
			}
			else
			{
				FilterButton.IsEnabled = false;
			}
		}

		// Use DisplayName property to visualize column names and make text centered
		private void CameraRadarViolationsDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
		{
			if (e.PropertyDescriptor is PropertyDescriptor descriptor)
			{
				e.Column.Header = descriptor.DisplayName ?? descriptor.Name;
				e.Column.HeaderStyle = new Style(typeof(DataGridColumnHeader));
				e.Column.HeaderStyle.Setters.Add(new Setter(HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
			}
		}

		private void HamburgerMenuButton_Click(object sender, RoutedEventArgs e)
		{
			HamburgerMenuFlyout.IsOpen = true;
		}

		private void ProcessDbModels(List<PersonFines> dbModels)
		{
			var dtoModels = dbModels.Select(x => Mapper.Map<CameraRadarViolationsViewModel>(x)).ToList();
			var observableDtoModels = new ObservableCollection<CameraRadarViolationsViewModel>(dtoModels);

			CameraRadarViolationsList.Clear();

			foreach (var item in observableDtoModels)
			{
				CameraRadarViolationsList.Add(item);
			}
		}

		private void CreateButton_Click(object sender, RoutedEventArgs e)
		{
			var myMenu = container.Resolve<CreateCameraRadarViolation>();
			
			myMenu.ShowDialog();
		}
	}
}
