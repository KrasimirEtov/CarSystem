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
using CarSystem.Data.Models;
using CarSystem.Data.Models.Associative;
using CarSystem.Services.Contracts;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;

namespace CarSystem.App.Windows
{
	/// <summary>
	/// Interaction logic for References.xaml
	/// </summary>
	public partial class References : MetroWindow
	{
		IContainer container = ContainerConfiguration.GetContainer();

		public ObservableCollection<PersonViewModel> PersonViewModels { get; set; }
		public ObservableCollection<CarViewModel> CarViewModels { get; set; }

		public References()
		{
			PersonViewModels = new ObservableCollection<PersonViewModel>();
			CarViewModels = new ObservableCollection<CarViewModel>();
			InitializeComponent();
			LoadPersonViewModels();
			LoadCarViewModels();

			PersonPickerButton.ItemsSource = PersonViewModels;
			CarPickerButton.ItemsSource = CarViewModels;
		}

		private void LoadPersonViewModels()
		{
			var peopleService = container.Resolve<IPeopleService>();
			var dbRecords = peopleService.GetAllPersonsAsync().Result;

			var observableDtoModels = ModelHandler.PersonToObservableDto(dbRecords);

			ModelHandler.ProcessObservableDtoModels(PersonViewModels, observableDtoModels);
		}

		private void LoadCarViewModels()
		{
			var carService = container.Resolve<ICarService>();
			var dbRecords = carService.GetAllCarsAsync().Result;

			var observableDtoModels = ModelHandler.CarToObservableDto(dbRecords);

			ModelHandler.ProcessObservableDtoModels(CarViewModels, observableDtoModels);
		}

		private void PreviousButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			ReturnToPreviousScreen();
		}

		private void ReturnToPreviousScreen()
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

		private void CarsTabItem_Selected(object sender, RoutedEventArgs e)
		{
			CarPickerButton.SelectedItem = null;
			CarPdfDownloadImage.Visibility = Visibility.Hidden;
		}

		private void PeopleTabItem_Selected(object sender, RoutedEventArgs e)
		{
			PersonPickerButton.SelectedItem = null;
			PersonPdfDownloadImage.Visibility = Visibility.Hidden;
		}

		private async void PersonPdfDownloadImage_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var personFinesService = container.Resolve<IPersonFinesService>();
			var exportService = container.Resolve<IExportService>();
		tryAgain:
			string fileName = SaveFileHelper();

			bool shouldRepeat = await RepeatHelperDialog(fileName);
			if (shouldRepeat)
			{
				goto tryAgain;
			}

			var person = PersonPickerButton.SelectedItem as PersonViewModel;

			var personFines = personFinesService.GetPersonFinesByPersonId(person.Id).Result;

			exportService.ExportPersonInformation(fileName, person.Name, personFines);

			SuccessfullHelperDialog(PersonPdfDownloadImage, PersonPickerButton);
		}

		private async void CarPdfDownloadImage_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var personFinesService = container.Resolve<IPersonFinesService>();
			var exportService = container.Resolve<IExportService>();
		tryAgain:
			string fileName = SaveFileHelper();

			bool shouldRepeat = await RepeatHelperDialog(fileName);
			if (shouldRepeat)
			{
				goto tryAgain;
			}

			var car = CarPickerButton.SelectedItem as CarViewModel;

			var carFines = personFinesService.GetCarFinesByCarId(car.Id).Result;

			exportService.ExportCarInformation(fileName, car.DisplayName, carFines);
			SuccessfullHelperDialog(CarPdfDownloadImage, CarPickerButton);
		}

		private void PersonPickerButton_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			PersonPdfDownloadImage.Visibility = Visibility.Visible;
		}

		private void CarPickerButton_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			CarPdfDownloadImage.Visibility = Visibility.Visible;
		}

		private string SaveFileHelper()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog()
			{
				Filter = "Pdf files (*.pdf)|*.pdf",
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
			};
			saveFileDialog.ShowDialog();

			if (string.IsNullOrEmpty(saveFileDialog.FileName))
			{
				return string.Empty;
			}

			string fileName =
					($"{saveFileDialog.FileName.Substring(0, saveFileDialog.FileName.Length - 4)}-{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}-" +
					$"{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}-{DateTime.Now.Millisecond}.pdf");

			return fileName;
		}

		private async Task<bool> RepeatHelperDialog(string fileName)
		{
			this.Cursor = Cursors.Hand;
			bool shouldRepeat = false;
			if (string.IsNullOrEmpty(fileName))
			{
				var result = await this.ShowMessageAsync("Не сте избрали име на файл", "Необходимо е да изберете име. Желаете ли да продължите?", MessageDialogStyle.AffirmativeAndNegative, MetroDialogOptions = new MetroDialogSettings()
				{
					AffirmativeButtonText = "Да, ще добавя име",
					NegativeButtonText = "Не, искам да изляза",
					AnimateHide = true,
					AnimateShow = true,
					DefaultButtonFocus = MessageDialogResult.Affirmative,
					DialogResultOnCancel = MessageDialogResult.Canceled,
				});

				if (result == MessageDialogResult.Affirmative)
				{
					shouldRepeat = true;
				}
				else
				{
					ReturnToPreviousScreen();
				}

				this.Cursor = Cursors.Arrow;
			}
			return shouldRepeat;
		}

		private async void SuccessfullHelperDialog(Image image, SplitButton splitButton)
		{
			this.Cursor = Cursors.Hand;
			var result = await this.ShowMessageAsync("Файлът бе записан успешно", "Желаете ли да експортирате още справки?", MessageDialogStyle.AffirmativeAndNegative, MetroDialogOptions = new MetroDialogSettings()
			{
				AffirmativeButtonText = "Да",
				NegativeButtonText = "Не",
				AnimateHide = true,
				AnimateShow = true,
				DefaultButtonFocus = MessageDialogResult.Affirmative,
				DialogResultOnCancel = MessageDialogResult.Canceled,
			});

			if (result == MessageDialogResult.Affirmative)
			{
				splitButton.SelectedItem = null;
				image.Visibility = Visibility.Hidden;
			}
			else
			{
				ReturnToPreviousScreen();
			}

			this.Cursor = Cursors.Arrow;
		}
	}
}
