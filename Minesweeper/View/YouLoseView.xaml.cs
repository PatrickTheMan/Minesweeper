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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minesweeper.View
{
	/// <summary>
	/// Interaction logic for YouLoseView.xaml
	/// </summary>
	public partial class YouLoseView : UserControl
	{
		public YouLoseView()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			MyWindow.mainWindow.ccContainer.Content = MyWindow.mainWindow.menu;
		}
	}
}
