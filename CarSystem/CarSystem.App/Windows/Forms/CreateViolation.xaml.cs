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
		public ObservableCollection<ViolationViewModel> ViolationsViewModels { get; set; }

		public CreateViolation()
		{
			PersonViewModels = new ObservableCollection<PersonViewModel>();
			CarViewModels = new ObservableCollection<CarViewModel>();
			FineViewModels = new ObservableCollection<FineViewModel>();
			ViolationsViewModels = new ObservableCollection<ViolationViewModel>();
			LoadPersonViewModels();
			InitializeComponent();
		}

		private void LoadPersonViewModels()
		{
			var personFinesService = container.Resolve<IPeopleService>();
			var dbRecords = personFinesService.GetAllPersonsAsync().Result;

			var observableDtoModels = ModelHandler.PersonToObservableDto(dbRecords);

			ModelHandler.ProcessObservableDtoModels(PersonViewModels, observableDtoModels);
		}

		private async void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			this.Cursor = Cursors.Hand;
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
			this.Cursor = Cursors.Arrow;
		}

		private async void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			this.Cursor = Cursors.Hand;
			var result = await this.ShowMessageAsync("Сигурни ли сте?", "Ако излезете сега, записът няма да бъде добавен в системата ни!", MessageDialogStyle.AffirmativeAndNegative, MetroDialogOptions = new MetroDialogSettings()
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
	}
}
