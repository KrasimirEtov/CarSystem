﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CarSystem.App.Windows;
using CarSystem.App.Windows.Forms;
using CarSystem.Data;
using CarSystem.Services;
using CarSystem.Services.Contracts;

namespace CarSystem.App.Infrastructure
{
	public class ContainerConfiguration
	{
		private static IContainer container = null;

		public static IContainer GetContainer()
		{
			if (container == null)
			{
				container = InitializeContainer();
			}
			return container;
		}

		public static IContainer InitializeContainer()
		{
			var builder = new ContainerBuilder();

			// Register windows
			builder.RegisterType<MyMenu>().AsSelf();
			builder.RegisterType<MainWindow>().AsSelf();
			builder.RegisterType<Registrations>().AsSelf();
			builder.RegisterType<Violations>().AsSelf();
			builder.RegisterType<References>().AsSelf();

			// Register form windows
			builder.RegisterType<CreateViolation>().AsSelf();
			builder.RegisterType<CreatePerson>().AsSelf();
			builder.RegisterType<CreateCar>().AsSelf();

			// Register Database context
			builder.RegisterType<CarSystemDbContext>().AsSelf();

			// Register services
			builder.RegisterType<PeopleService>().As<IPeopleService>();
			builder.RegisterType<PersonFinesService>().As<IPersonFinesService>();
			builder.RegisterType<CarService>().As<ICarService>();
			builder.RegisterType<ViolationService>().As<IViolationService>();
			builder.RegisterType<FineService>().As<IFineService>();
			builder.RegisterType<GendersService>().As<IGendersService>();
			builder.RegisterType<PersonCarsService>().As<IPersonCarsService>();
			builder.RegisterType<EmissionStandartService>().As<IEmissionStandartService>();
			builder.RegisterType<FuelService>().As<IFuelService>();
			builder.RegisterType<ExportService>().As<IExportService>();

			return builder.Build();
		}
	}
}
