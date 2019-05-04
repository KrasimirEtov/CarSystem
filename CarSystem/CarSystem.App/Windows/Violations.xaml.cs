﻿using System;
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
using Autofac;
using CarSystem.App.Infrastructure;
using MahApps.Metro.Controls;

namespace CarSystem.App.Windows
{
	/// <summary>
	/// Interaction logic for Violations.xaml
	/// </summary>
	public partial class Violations : MetroWindow
	{
		IContainer container = ContainerConfiguration.GetContainer();

		public Violations()
		{
			InitializeComponent();
		}

		private void HomeScreenButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var startupWindow = container.Resolve<MainWindow>();
			this.Close();
			startupWindow.ShowDialog();
		}

		private void PreviousButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var myMenu = container.Resolve<MyMenu>();
			this.Close();
			myMenu.ShowDialog();
		}
	}
}