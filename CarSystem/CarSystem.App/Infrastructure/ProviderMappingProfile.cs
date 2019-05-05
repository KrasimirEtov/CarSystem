using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarSystem.App.Models;
using CarSystem.Data.Models.Associative;

namespace CarSystem.App.Infrastructure
{
	public class ProviderMappingProfile : Profile
	{
		public ProviderMappingProfile()
		{
			CreateMap<PersonFines, CameraRadarViolationsViewModel>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Person.FirstName + src.Person.LastName))
				.ForMember(dest => dest.EGN, opt => opt.MapFrom(src => src.Person.EGN))
				.ForMember(dest => dest.CardId, opt => opt.MapFrom(src => src.Person.CardId))
				.ForMember(dest => dest.CarModel, opt => opt.MapFrom(src => src.Car.Model))
				.ForMember(dest => dest.CarBrand, opt => opt.MapFrom(src => src.Car.Brand))
				.ForMember(dest => dest.CarNumber, opt => opt.MapFrom(src => src.Car.Number));
		}
	}
}
