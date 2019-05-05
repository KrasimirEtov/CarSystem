using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CarSystem.App.Windows;
using CarSystem.Data;
using CarSystem.Services;
using CarSystem.Services.Contracts;

namespace CarSystem.App.Infrastructure
{
	public class ContainerConfiguration
	{
		public static IContainer GetContainer()
		{
			var builder = new ContainerBuilder();

			// Register windows
			builder.RegisterType<MyMenu>().AsSelf();
			builder.RegisterType<MainWindow>().AsSelf();
			builder.RegisterType<Violations>().AsSelf();
			builder.RegisterType<CameraRadarViolations>().AsSelf();

			// Register Database context
			builder.RegisterType<CarSystemDbContext>().AsSelf();

			// Register services
			builder.RegisterType<PeopleService>().As<IPeopleService>();
			builder.RegisterType<PersonFinesService>().As<IPersonFinesService>();

			return builder.Build();
		}
	}
}
