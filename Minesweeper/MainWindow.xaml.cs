﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public View.Options options = new View.Options();
        public View.Game game = new View.Game();
        public View.Menu menu = new View.Menu();
        public View.FinishedView finished = new View.FinishedView();
        public View.LoadingView loading = new View.LoadingView();

        public Model.GameModel gameModel = new Model.GameModel();

        public Thread timeThread = new Thread(new ThreadStart(Model.GameModel.TimeThread));
		public Thread changeThread = new Thread(new ThreadStart(ChangingSceneToFinished));

		public MainWindow()
        {

            InitializeComponent();

			ccContainer.Content = menu;
            this.DataContext = gameModel;

            MyWindow.mainWindow = this;

        }

        private void Menu_Btn_Click(object sender, RoutedEventArgs e)
        {
            MyWindow.mainWindow.timeThread.Suspend();
            MyWindow.mainWindow.gameModel.BombAmount = 0;
			MyWindow.mainWindow.gameModel.FlaggedAmount = 0;
			MyWindow.mainWindow.gameModel.TimeSec = "00";
			MyWindow.mainWindow.gameModel.TimeMin = "00";

			MyWindow.mainWindow.ccContainer.Content = MyWindow.mainWindow.menu;
        }

		public static void ChangingSceneToFinished()
		{

            Thread.Sleep(3000);

            MyWindow.mainWindow.ActiveDispatcher("finished");

		}

        public void ActiveDispatcher(string view)
        {
            switch (view)
            {
                case "finished":
                    {
                        Dispatcher.Invoke(() =>
                        {
                            MyWindow.mainWindow.ccContainer.Content = MyWindow.mainWindow.finished;
                        });

                        break;
                    }
            }
			
		}
	}


}
