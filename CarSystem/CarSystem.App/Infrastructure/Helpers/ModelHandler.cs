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
		public static void ProcessObservableDtoModels<T>(ObservableCollection<T> toModify, ObservableCollection<T> source)
		{
			toModify.Clear();

			foreach (var item in source)
			{
				toModify.Add(item);
			}
		}

		public static ObservableCollection<ViolationsViewModel> PersonFinesToObservableDto(List<PersonFines> dbRecords)
		{
			var dtoModels = dbRecords.Select(x => Mapper.Map<ViolationsViewModel>(x)).ToList();

			return new ObservableCollection<ViolationsViewModel>(dtoModels);
		}

		public static ObservableCollection<PersonViewModel> PersonToObservableDto(List<Person> dbRecords)
		{
			var dtoModels = dbRecords.Select(x => Mapper.Map<PersonViewModel>(x)).ToList();

			return new ObservableCollection<PersonViewModel>(dtoModels);
		}

		public static ObservableCollection<CarViewModel> CarToObservableDto(List<Car> dbRecords)
		{
			var dtoModels = dbRecords.Select(x => Mapper.Map<CarViewModel>(x)).ToList();

			return new ObservableCollection<CarViewModel>(dtoModels);
		}

		public static ObservableCollection<ViolationViewModel> ViolationsToObservableDto(List<Violation> dbRecords)
		{
			var dtoModels = dbRecords.Select(x => Mapper.Map<ViolationViewModel>(x)).ToList();

			return new ObservableCollection<ViolationViewModel>(dtoModels);
		}

		public static ObservableCollection<FineViewModel>FinesToObservableDto(List<Fine> dbRecords)
		{
			var dtoModels = dbRecords.Select(x => Mapper.Map<FineViewModel>(x)).ToList();

			return new ObservableCollection<FineViewModel>(dtoModels);
		}

		public static ObservableCollection<GenderViewModel> GendersToObservableDto(List<Gender> dbRecords)
		{
			var dtoModels = dbRecords.Select(x => Mapper.Map<GenderViewModel>(x)).ToList();

			return new ObservableCollection<GenderViewModel>(dtoModels);
		}
	}
}
