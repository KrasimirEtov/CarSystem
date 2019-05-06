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
using CarSystem.App.Infrastructure.Helpers;
using CarSystem.App.Models;
using CarSystem.App.Windows.Forms;
using CarSystem.Data.Models.Associative;
using CarSystem.Services.Contracts;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace CarSystem.App.Windows
{
	/// <summary>
	/// Interaction logic for Violations.xaml
	/// </summary>
	public partial class Violations : MetroWindow
	{
		Autofac.IContainer container = ContainerConfiguration.GetContainer();

		public ObservableCollection<ViolationsViewModel> ViolationsViewModels { get; set; }

		public Violations()
		{
			ViolationsViewModels = new ObservableCollection<ViolationsViewModel>();
			InitializeComponent();
			LoadAllRecords();
			ViolationsDataGrid.ItemsSource = ViolationsViewModels;
		}

		private void LoadAllRecords()
		{
			var personFinesService = container.Resolve<IPersonFinesService>();
			var dbRecords = personFinesService.GetFilteredPersonFinesAsync(CarSystemConstants.CameraViolationName).Result;

			var observableDtoModels = ModelHandler.PersonFinesToObservableDto(dbRecords);
			ModelHandler.ProcessObservableDtoModels(ViolationsViewModels, observableDtoModels);
		}

		private void PreviousButton_Click(object sender, RoutedEventArgs e)
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

		private void FilterButton_Click(object sender, RoutedEventArgs e)
		{
			var personFinesService = container.Resolve<IPersonFinesService>();

			var dbRecords = personFinesService.GetFilteredPersonFinesAsync(CarSystemConstants.CameraViolationName, CardIdTextBox.Text, EGNTextBox.Text, VehicleNumberTextBox.Text, FineNumberTextBox.Text).Result;

			var observableDtoModels = ModelHandler.PersonFinesToObservableDto(dbRecords);
			ModelHandler.ProcessObservableDtoModels(ViolationsViewModels, observableDtoModels);
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
		private void ViolationsDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
		{
			if (e.PropertyDescriptor is PropertyDescriptor descriptor)
			{
				e.Column.Header = descriptor.DisplayName ?? descriptor.Name;
				//e.Column.HeaderStyle = new Style(typeof(DataGridColumnHeader));
				//e.Column.HeaderStyle.Setters.Add(new Setter(HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
			}
		}

		private void HamburgerMenuButton_Click(object sender, RoutedEventArgs e)
		{
			HamburgerMenuFlyout.IsOpen = true;
		}

		private void CreateButton_Click(object sender, RoutedEventArgs e)
		{
			var myMenu = container.Resolve<CreateViolation>();
			
			myMenu.ShowDialog();
		}

		private async void DeleteItem_Click(object sender, RoutedEventArgs e)
		{
			var rowData = ViolationsDataGrid.SelectedItem as ViolationsViewModel;
			this.Cursor = Cursors.Hand;
			var result = await this.ShowMessageAsync("Сигурни ли сте?", "Записът ще бъде изтрит от системата!", MessageDialogStyle.AffirmativeAndNegative, MetroDialogOptions = new MetroDialogSettings()
			{
				AffirmativeButtonText = "Да",
				AnimateHide = true,
				AnimateShow = true,
				NegativeButtonText = "Не",
				DefaultButtonFocus = MessageDialogResult.Affirmative,
				DialogResultOnCancel = MessageDialogResult.Canceled,
			});

			if (result == MessageDialogResult.Affirmative)
			{
				var service = container.Resolve<IPersonFinesService>();
				await service.DeletePersonFineAsync(rowData.PersonFineId);
				ViolationsViewModels.Remove(rowData);
			}
			this.Cursor = Cursors.Arrow;
		}

		// Disable contextMenu in data grid headers
		private void DisableContextMenuOnDgHeaders_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			DependencyObject DepObject = (DependencyObject)e.OriginalSource;

			while ((DepObject != null) && !(DepObject is DataGridColumnHeader) && !(DepObject is DataGridRow))
			{
				DepObject = VisualTreeHelper.GetParent(DepObject);
			}

			if (DepObject == null)
			{
				return;
			}

			if (DepObject is DataGridColumnHeader)
			{
				ViolationsDataGrid.ContextMenu.Visibility = Visibility.Collapsed;
			}
			else
			{
				ViolationsDataGrid.ContextMenu.Visibility = Visibility.Visible;
			}
		}
	}
}
