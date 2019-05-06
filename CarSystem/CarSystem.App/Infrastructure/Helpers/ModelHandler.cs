using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarSystem.App.Models;
using CarSystem.Data.Models;
using CarSystem.Data.Models.Associative;

namespace CarSystem.App.Infrastructure.Helpers
{
	public static class ModelHandler
	{
		public static ObservableCollection<CameraRadarViolationsViewModel> PersonFinesToObservableDto(List<PersonFines> dbRecords)
		{
			var dtoModels = dbRecords.Select(x => Mapper.Map<CameraRadarViolationsViewModel>(x)).ToList();

			return new ObservableCollection<CameraRadarViolationsViewModel>(dtoModels);
		}

		public static ObservableCollection<PersonViewModel> PersonToObservableDto(List<Person> dbRecords)
		{
			var dtoModels = dbRecords.Select(x => Mapper.Map<PersonViewModel>(x)).ToList();

			return new ObservableCollection<PersonViewModel>(dtoModels);
		}

		public static void ProcessObservableDtoModels<T>(ObservableCollection<T> toModify, ObservableCollection<T> source)
		{
			toModify.Clear();

			foreach (var item in source)
			{
				toModify.Add(item);
			}
		}
	}
}
