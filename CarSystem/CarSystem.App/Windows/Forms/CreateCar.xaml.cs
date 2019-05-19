using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using CarSystem.App.Infrastructure.Helpers;
using CarSystem.App.Models;
using CarSystem.Services.Contracts;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace CarSystem.App.Windows.Forms
{
	/// <summary>
	/// Interaction logic for CreateCar.xaml
	/// </summary>
	public partial class CreateCar : MetroWindow
	{
		Autofac.IContainer container = ContainerConfiguration.GetContainer();

		public ObservableCollection<FuelViewModel> FuelViewModels { get; set; }
		public ObservableCollection<EmissionStandartViewModel> EmissionStandartViewModels { get; set; }

		public CreateCar()
		{
			FuelViewModels = new ObservableCollection<FuelViewModel>();
			EmissionStandartViewModels = new ObservableCollection<EmissionStandartViewModel>();
			InitializeComponent();
			LoadFuelViewModels();
			LoadEmissionStandartViewModels();

			FuelPickerButton.ItemsSource = FuelViewModels;
			EmissionStandartPickerButton.ItemsSource = EmissionStandartViewModels;
		}

		private void LoadFuelViewModels()
		{
			var fuelService = container.Resolve<IFuelService>();
			var dbRecords = fuelService.GetAllFuelsAsync().Result;

			var observableDtoModels = ModelHandler.FuelsToObservableDto(dbRecords);

			ModelHandler.ProcessObservableDtoModels(FuelViewModels, observableDtoModels);
		}

		private void LoadEmissionStandartViewModels()
		{
			var emissionStandartService = container.Resolve<IEmissionStandartService>();
			var dbRecords = emissionStandartService.GetAllEmissionStandartsAsync().Result;

			var observableDtoModels = ModelHandler.EmissionStandartsToObservableDto(dbRecords);

			ModelHandler.ProcessObservableDtoModels(EmissionStandartViewModels, observableDtoModels);
		}

		private void TextBoxChange(object sender, TextChangedEventArgs e)
		{
			ResolveClearButtonStatus();
			ResolveSaveButtonStatus();
		}

		private void FuelPickerButton_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ResolveClearButtonStatus();
			ResolveSaveButtonStatus();
		}

		private void EmissionStandartPickerButton_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ResolveClearButtonStatus();
			ResolveSaveButtonStatus();
		}

		private async void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			this.Cursor = Cursors.Hand;

			var carBrand = BrandTextBox.Text;
			var carModel = ModelTextBox.Text;
			var enginePower = int.Parse(EnginePowerNumericUpDown.Value.ToString());
			var peopleCarry = int.Parse(PeopleCarryNumericUpDown.Value.ToString());
			var weight = int.Parse(WeightNumericUpDown.Value.ToString());
			var color = ColorTextBox.Text;
			var number = NumberTextBox.Text;
			var fuel = FuelPickerButton.SelectedItem as FuelViewModel;
			var emissionStandart = EmissionStandartPickerButton.SelectedItem as EmissionStandartViewModel;

			var carService = container.Resolve<ICarService>();
			await carService.CreateCarAsync(carBrand, carModel, enginePower, peopleCarry, weight, color, fuel.Id, emissionStandart.Id, number);

			var result = await this.ShowMessageAsync("Записът бе добавен", "Превозното срество бе успешно добавено в системата.", MessageDialogStyle.AffirmativeAndNegative, MetroDialogOptions = new MetroDialogSettings()
			{
				AffirmativeButtonText = "Върни се обратно",
				NegativeButtonText = "Добави още",
				AnimateHide = true,
				AnimateShow = true,
				DefaultButtonFocus = MessageDialogResult.Affirmative,
				DialogResultOnCancel = MessageDialogResult.Canceled,
			});

			if (result == MessageDialogResult.Affirmative)
			{
				this.Close();
			}
			else
			{
				ClearFields();
			}

			this.Cursor = Cursors.Arrow;
		}

		private async void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			this.Cursor = Cursors.Hand;
			var result = await this.ShowMessageAsync("Сигурни ли сте?", "Ако излезете сега, записът няма да бъде добавен в системата!", MessageDialogStyle.AffirmativeAndNegative, MetroDialogOptions = new MetroDialogSettings()
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
				this.Close();
			}

			this.Cursor = Cursors.Arrow;
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			ClearFields();
		}

		private void ClearFields()
		{
			BrandTextBox.Text = "";
			ModelTextBox.Text = "";
			EnginePowerNumericUpDown.Value = 50;
			PeopleCarryNumericUpDown.Value = 3;
			WeightNumericUpDown.Value = 0;
			ColorTextBox.Text = "";
			NumberTextBox.Text = "";

			ClearButton.IsEnabled = false;
			SaveButton.IsEnabled = false;
			FuelPickerButton.SelectedItem = null;
			EmissionStandartPickerButton.SelectedItem = null;
		}

		private void ResolveClearButtonStatus()
		{
			bool buttonEnabled = false;
			var fuel = FuelPickerButton.SelectedItem as FuelViewModel;
			var emissionStandart = EmissionStandartPickerButton.SelectedItem as EmissionStandartViewModel;

			if (!string.IsNullOrEmpty(BrandTextBox.Text) || !string.IsNullOrEmpty(ModelTextBox.Text) || !string.IsNullOrEmpty(ColorTextBox.Text) || !string.IsNullOrEmpty(NumberTextBox.Text))
			{
				buttonEnabled = true;
			}

			if (fuel != null || emissionStandart != null)
			{
				buttonEnabled = true;
			}

			ClearButton.IsEnabled = buttonEnabled ? true : false;
		}

		private void ResolveSaveButtonStatus()
		{
			bool buttonEnabled = true;
			var fuel = FuelPickerButton.SelectedItem as FuelViewModel;
			var emissionStandart = EmissionStandartPickerButton.SelectedItem as EmissionStandartViewModel;

			if (string.IsNullOrEmpty(BrandTextBox.Text) || string.IsNullOrEmpty(ModelTextBox.Text) || string.IsNullOrEmpty(ColorTextBox.Text) || string.IsNullOrEmpty(NumberTextBox.Text))
			{
				buttonEnabled = false;
			}

			if (fuel == null || emissionStandart == null)
			{
				buttonEnabled = false;
			}

			SaveButton.IsEnabled = buttonEnabled ? true : false;
		}
	}
}
