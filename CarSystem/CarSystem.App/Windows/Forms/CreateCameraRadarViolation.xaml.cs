using System;
using System.Collections.Generic;
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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace CarSystem.App.Windows.Forms
{
	/// <summary>
	/// Interaction logic for CreateCameraRadarViolation.xaml
	/// </summary>
	public partial class CreateCameraRadarViolation : MetroWindow
	{
		public CreateCameraRadarViolation()
		{
			InitializeComponent();
		}

		private async void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			await this.ShowMessageAsync("Записът бе добавен", "Нарушението бе успешно добавено в системата.", MessageDialogStyle.Affirmative, MetroDialogOptions = new MetroDialogSettings()
			{
				AffirmativeButtonText = "Върни се обратно.",
				AnimateHide = true,
				AnimateShow = true,
			});
			this.Close();
		}

		private async void CancelButton_Click(object sender, RoutedEventArgs e)
		{
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
		}
	}
}
