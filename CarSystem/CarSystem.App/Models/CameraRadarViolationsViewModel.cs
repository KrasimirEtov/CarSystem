using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.App.Models
{
	public class CameraRadarViolationsViewModel
	{
		[DisplayName("Име")]
		public string Name { get; set; }

		[DisplayName("ЕГН")]
		public string EGN { get; set; }

		[DisplayName("Лична карта")]
		public string CardId { get; set; }

		[DisplayName("Марка")]
		public string CarBrand { get; set; }

		[DisplayName("Модел")]
		public string CarModel { get; set; }

		[DisplayName("Номер")]
		public string CarNumber { get; set; }
	}
}
