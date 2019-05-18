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
	/// Interaction logic for CreateViolation.xaml
	/// </summary>
	public partial class CreateViolation : MetroWindow
	{
		Autofac.IContainer container = ContainerConfiguration.GetContainer();

		public ObservableCollection<PersonViewModel> PersonViewModels { get; set; }
		public ObservableCollection<CarViewModel> CarViewModels { get; set; }
		public ObservableCollection<FineViewModel> FineViewModels { get; set; }
		public ObservableCollection<ViolationViewModel> ViolationViewModels { get; set; }

		public CreateViolation()
		{
			PersonViewModels = new ObservableCollection<PersonViewModel>();
			CarViewModels = new ObservableCollection<CarViewModel>();
			FineViewModels = new ObservableCollection<FineViewModel>();
			ViolationViewModels = new ObservableCollection<ViolationViewModel>();
			InitializeComponent();
			LoadPersonViewModels();

			PersonPickerButton.ItemsSource = PersonViewModels;
			CarPickerButton.ItemsSource = CarViewModels;
			ViolationPickerButton.ItemsSource = ViolationViewModels;
			FinePickerButton.ItemsSource = FineViewModels;
		}

		private void LoadPersonViewModels()
		{
			var peopleService = container.Resolve<IPeopleService>();
			var dbRecords = peopleService.GetAllPersonsAsync().Result;

			var observableDtoModels = ModelHandler.PersonToObservableDto(dbRecords);

			ModelHandler.ProcessObservableDtoModels(PersonViewModels, observableDtoModels);
		}

		private void LoadCarViewModels(int personId)
		{
			var carService = container.Resolve<ICarService>();
			var dbRecords = carService.GetPersonCarsAsync(personId).Result;

			var observableDtoModels = ModelHandler.CarToObservableDto(dbRecords);

			ModelHandler.ProcessObservableDtoModels(CarViewModels, observableDtoModels);
		}

		private void LoadViolationsViewModels()
		{
			var violationService = container.Resolve<IViolationService>();
			var dbRecords = violationService.GetAllViolationsAsync().Result;

			var observableDtoModels = ModelHandler.ViolationsToObservableDto(dbRecords);
			ModelHandler.ProcessObservableDtoModels(ViolationViewModels, observableDtoModels);
		}

		private void LoadFineViewModels()
		{
			var fineService = container.Resolve<IFineService>();
			var dbRecords = fineService.GetAllFinesAsync().Result;

			var observableDtoModels = ModelHandler.FinesToObservableDto(dbRecords);
			ModelHandler.ProcessObservableDtoModels(FineViewModels, observableDtoModels);
		}

		private async void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			this.Cursor = Cursors.Hand;

			var person = PersonPickerButton.SelectedItem as PersonViewModel;
			var car = CarPickerButton.SelectedItem as CarViewModel;
			var violation = ViolationPickerButton.SelectedItem as ViolationViewModel;
			var fine = FinePickerButton.SelectedItem as FineViewModel;
			var finePrice = decimal.Parse(FinePriceNumericUpDown.Value.Value.ToString());
			var fineNumber = FineNumberNumericUpDown.Value.Value.ToString();
			var licenceBackOn = DateTime.Parse(LicenceBackOnDatePicker.Text);

			var personFinesService = container.Resolve<IPersonFinesService>();
			await personFinesService.CreatePersonFineAsync(person.Id, car.Id, violation.Id, fine.Id, finePrice, fineNumber, licenceBackOn);

			var result = await this.ShowMessageAsync("Записът бе добавен", "Нарушението бе успешно добавено в системата.", MessageDialogStyle.AffirmativeAndNegative, MetroDialogOptions = new MetroDialogSettings()
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
			PersonPickerButton.SelectedItem = null;
			ClearButton.IsEnabled = false;
			SaveButton.IsEnabled = false;

			CarPickerLabel.Visibility = Visibility.Hidden;
			CarPickerButton.Visibility = Visibility.Hidden;
			CarPickerButton.SelectedItem = null;

			ViolationPickerLabel.Visibility = Visibility.Hidden;
			ViolationPickerButton.Visibility = Visibility.Hidden;
			ViolationPickerButton.SelectedItem = null;

			FinePickerLabel.Visibility = Visibility.Hidden;
			FinePickerButton.Visibility = Visibility.Hidden;
			FinePickerButton.SelectedItem = null;

			LicenceBackOnDatePickerLabel.Visibility = Visibility.Hidden;
			LicenceBackOnDatePicker.Visibility = Visibility.Hidden;
			LicenceBackOnDatePicker.Text = "";

			FinePriceLabel.Visibility = Visibility.Hidden;
			FinePriceNumericUpDown.Visibility = Visibility.Hidden;
			FinePriceNumericUpDown.Value = 0;

			FineNumberLabel.Visibility = Visibility.Hidden;
			FineNumberNumericUpDown.Visibility = Visibility.Hidden;
			FineNumberNumericUpDown.Value = 0;
		}

		private void PersonPickerButton_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			CarPickerLabel.Visibility = Visibility.Visible;
			CarPickerButton.Visibility = Visibility.Visible;
			ClearButton.IsEnabled = true;

			var personViewModel = PersonPickerButton.SelectedItem as PersonViewModel;

			if (personViewModel != null)
			{
				LoadCarViewModels(personViewModel.Id);
			}
		}

		private void CarPickerButton_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ViolationPickerLabel.Visibility = Visibility.Visible;
			ViolationPickerButton.Visibility = Visibility.Visible;

			var carViewModel = CarPickerButton.SelectedItem as CarViewModel;

			if (carViewModel != null)
			{
				LoadViolationsViewModels();
			}
		}

		private void FinePickerButton_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var fineViewModel = FinePickerButton.SelectedItem as FineViewModel;

			if (fineViewModel != null)
			{
				LicenceBackOnDatePickerLabel.Visibility = Visibility.Visible;
				LicenceBackOnDatePicker.Visibility = Visibility.Visible;
			}
		}

		private void ViolationPickerButton_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			FinePickerLabel.Visibility = Visibility.Visible;
			FinePickerButton.Visibility = Visibility.Visible;
			var violationViewModel = ViolationPickerButton.SelectedItem as ViolationViewModel;

			if (violationViewModel != null)
			{
				LoadFineViewModels();
			}
		}

		private void LicenceBackOnDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			if (!String.IsNullOrEmpty(LicenceBackOnDatePicker.Text))
			{
				FinePriceLabel.Visibility = Visibility.Visible;
				FinePriceNumericUpDown.Value = 0;
				FinePriceNumericUpDown.Visibility = Visibility.Visible;

				FineNumberLabel.Visibility = Visibility.Visible;
				FineNumberNumericUpDown.Visibility = Visibility.Visible;
				FineNumberNumericUpDown.Value = 0;

				SaveButton.IsEnabled = true;
			}
		}
	}
}
