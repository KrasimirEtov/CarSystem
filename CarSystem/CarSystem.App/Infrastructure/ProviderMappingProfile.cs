using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarSystem.App.Models;
using CarSystem.Data.Models;
using CarSystem.Data.Models.Associative;

namespace CarSystem.App.Infrastructure
{
	public class ProviderMappingProfile : Profile
	{
		public ProviderMappingProfile()
		{
			// PersonFines -> ViolationsViewModel
			CreateMap<PersonFines, ViolationsViewModel>()
				.ForMember(dest => dest.PersonFineId, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.FinePrice, opt => opt.MapFrom(src => src.Price.ToString() + " лв."))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Person.FirstName + " " + src.Person.LastName))
				.ForMember(dest => dest.EGN, opt => opt.MapFrom(src => src.Person.EGN))
				.ForMember(dest => dest.CardId, opt => opt.MapFrom(src => src.Person.CardId))
				.ForMember(dest => dest.CarModel, opt => opt.MapFrom(src => src.Car.Model))
				.ForMember(dest => dest.CarBrand, opt => opt.MapFrom(src => src.Car.Brand))
				.ForMember(dest => dest.CarNumber, opt => opt.MapFrom(src => src.Car.Number));

			// CreateViolationViewModel -> PersonFines
			CreateMap<CreateViolationViewModel, PersonFines>()
				.ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.CarId))
				.ForMember(dest => dest.FineId, opt => opt.MapFrom(src => src.FineId))
				.ForMember(dest => dest.FineNumber, opt => opt.MapFrom(src => src.FineNumber))
				.ForMember(dest => dest.LicenceBackOn, opt => opt.MapFrom(src => src.LicenceBackOn))
				.ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.PersonId))
				.ForMember(dest => dest.ViolationId, opt => opt.MapFrom(src => src.ViolationId))
				.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
				.ForAllOtherMembers(opt => opt.Ignore());

			// Person -> PersonViewModel
			CreateMap<Person, PersonViewModel>()
				.ForMember(dest => dest.EGN, opt => opt.MapFrom(src => src.EGN))
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
				.ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName + " - " + src.EGN))
				.ForAllOtherMembers(opt => opt.Ignore());

			// Fine -> FineViewModel
			CreateMap<Fine, FineViewModel>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.Violation, opt => opt.MapFrom(src => src.Violation))
				.ForAllOtherMembers(opt => opt.Ignore());

			// Violation -> ViolationViewModel
			CreateMap<Violation, ViolationViewModel>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
				.ForAllOtherMembers(opt => opt.Ignore());

			// Car -> CarViewModel
			CreateMap<Car, CarViewModel>()
				.ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
				.ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Brand + " " + src.Model + " - " + src.Number))
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
				.ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
				.ForAllOtherMembers(opt => opt.Ignore());

			// Gender -> GenderViewModel
			CreateMap<Gender, GenderViewModel>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
				.ForAllOtherMembers(opt => opt.Ignore());
		}
	}
}
