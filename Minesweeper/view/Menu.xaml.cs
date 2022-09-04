using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Minesweeper.View
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {

        #region Constructor
        public Menu()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Buttons
        private void Options_Button_Click(object sender, RoutedEventArgs e)
        {
			MyWindow.mainWindow.ccContainer.Content = MyWindow.mainWindow.options;
        }

		private void Play_Button_Click(object sender, RoutedEventArgs e)
        {

			MyWindow.mainWindow.ccContainer.Content = MyWindow.mainWindow.loading;

            Thread thread = new Thread(new ThreadStart(CreateNewGameThread));

            thread.Start();

		}

        #endregion Buttons

        #region Variables

        private Grid map;
        private int bombsLeft;

        #endregion Variables

        #region GameThread

        public void CreateNewGameThread()
		{

            System.Diagnostics.Debug.WriteLine("Invoke");

            

            System.Diagnostics.Debug.WriteLine("Read Settings");

            Thread.Sleep(100);

            Dispatcher.Invoke(() =>
            {
                MyWindow.mainWindow.loading.loadingViewModel.Progress = 0;
                MyWindow.mainWindow.loading.loadingViewModel.LoadingText = "Read Settings";
            });

            Thread.Sleep(100);

            Dispatcher.Invoke(() =>
                {
                    MyWindow.mainWindow.gameModel.FieldsLeft = 0;
                    try
                    {
                        MyWindow.mainWindow.gameModel.MapX = int.Parse(MyWindow.mainWindow.options.FieldY_Tbox.Text);
                    }
                    catch (Exception)
                    {
                        MyWindow.mainWindow.gameModel.MapX = 10;
                    }
                    try
                    {
                        MyWindow.mainWindow.gameModel.MapY = int.Parse(MyWindow.mainWindow.options.FieldY_Tbox.Text);
                    }
                    catch (Exception)
                    {
                        MyWindow.mainWindow.gameModel.MapY = 10;
                    }

                    try
                    {
                        MyWindow.mainWindow.gameModel.BombPercent = int.Parse(MyWindow.mainWindow.options.FieldBombPercent_Tbox.Text);
                    }
                    catch (Exception)
                    {
                        MyWindow.mainWindow.gameModel.BombPercent = 10;
                    }

                    MyWindow.mainWindow.loading.loadingViewModel.Progress = 100;
                });


            int mapX = MyWindow.mainWindow.gameModel.MapX;
            int mapY = MyWindow.mainWindow.gameModel.MapY;
            int bombPercent = MyWindow.mainWindow.gameModel.BombPercent;

            Dispatcher.Invoke(() =>
            {
                map = new Grid();
            });

            // Cal bomb amount
            if (bombPercent > 90)
            {
                bombsLeft = (mapX * mapY) / 100 * 99;
            }
            else if (bombPercent <= 0)
            {
                bombsLeft = (mapX * mapY) / 100 * 1;
            }
            else
            {
                bombsLeft = (mapX * mapY) / 100 * bombPercent;
            }

            System.Diagnostics.Debug.WriteLine("Settings: ----------");
            System.Diagnostics.Debug.WriteLine("Map X: "+mapX);
            System.Diagnostics.Debug.WriteLine("Map Y: "+mapY);
            System.Diagnostics.Debug.WriteLine("Bomb%: "+bombPercent);
            System.Diagnostics.Debug.WriteLine("--------------------");


            System.Diagnostics.Debug.WriteLine("Setting Map X");

            Thread.Sleep(100);

            Dispatcher.Invoke(() =>
            {
                MyWindow.mainWindow.loading.loadingViewModel.Progress = 0;
                MyWindow.mainWindow.loading.loadingViewModel.LoadingText = "Setting Map X";
            });

            Thread.Sleep(100);

            Dispatcher.Invoke(() =>
            {
                // Set map x amount of columns
                map.SetValue(Grid.ColumnProperty, 1);
                for (int i = 0; i < mapX; i++)
                {
                    map.ColumnDefinitions.Add(new ColumnDefinition());
                }
            });

            System.Diagnostics.Debug.WriteLine("Setting Map Y");

            Thread.Sleep(100);

            Dispatcher.Invoke(() =>
            {
                MyWindow.mainWindow.loading.loadingViewModel.Progress = 0;
                MyWindow.mainWindow.loading.loadingViewModel.LoadingText = "Setting Map Y";
            });

            Thread.Sleep(100);

            Dispatcher.Invoke(() =>
            {
                // Set map y amount of rows
                map.SetValue(Grid.RowProperty, 1);
                for (int i = 0; i < mapY; i++)
                {
                    map.RowDefinitions.Add(new RowDefinition());
                }

                MyWindow.mainWindow.loading.loadingViewModel.Progress = 100;
            });

            System.Diagnostics.Debug.WriteLine("Creating Map");

            Thread.Sleep(100);

            Dispatcher.Invoke(() =>
            {
                MyWindow.mainWindow.loading.loadingViewModel.Progress = 0;
                MyWindow.mainWindow.loading.loadingViewModel.LoadingText = "Creating Map";
            });

            Thread.Sleep(100);

            // Create map
            AddLineOfFieldsThread(mapX, mapY);

            System.Diagnostics.Debug.WriteLine("Placing Bombs");

            Thread.Sleep(100);

            Dispatcher.Invoke(() =>
            {
                MyWindow.mainWindow.loading.loadingViewModel.Progress = 0;
                MyWindow.mainWindow.loading.loadingViewModel.LoadingText = "Placing Bombs";
            });

            Thread.Sleep(100);

            // Place bombs
            PlaceBombs(mapX, mapY);

            System.Diagnostics.Debug.WriteLine("Register Neighbors On Fields");

            Thread.Sleep(100);

            Dispatcher.Invoke(() =>
            {
                MyWindow.mainWindow.loading.loadingViewModel.Progress = 0;
                MyWindow.mainWindow.loading.loadingViewModel.LoadingText = "Register Neighbors On Fields";
            });

            Thread.Sleep(100);


            // Register neighborFields
            RegisterNeighborFieldsThread(mapX, mapY);

            while (MyWindow.mainWindow.loading.loadingViewModel.Progress<100)
            {
                Thread.Sleep(1000);
            }

            System.Diagnostics.Debug.WriteLine("Loading Done");

            Thread.Sleep(100);

            Dispatcher.Invoke(() =>
            {
                MyWindow.mainWindow.loading.loadingViewModel.Progress = 0;
                MyWindow.mainWindow.loading.loadingViewModel.LoadingText = "Done";
                MyWindow.mainWindow.loading.loadingViewModel.Progress = 100;
            });

            Thread.Sleep(100);

            Dispatcher.Invoke(() =>
            {
                MyWindow.mainWindow.game.Container_SP.Content = map;

                // Set container to game
                MyWindow.mainWindow.ccContainer.Content = MyWindow.mainWindow.game;

                // Start time
                if (MyWindow.mainWindow.timeThread.ThreadState == ThreadState.Unstarted)
                {
                    MyWindow.mainWindow.timeThread.Start();
                }
                else
                {
                    MyWindow.mainWindow.timeThread.Resume();
                }
            });
		}

        #endregion GameThread

        #region Private Methods

		private void AddLineOfFieldsThread(int mapX, int mapY)
		{
            double currentField = 0.0;

            for (int i = 0; i < mapX; i++)
            {
                for (int j = 0; j < mapY; j++)
                {
                    Dispatcher.Invoke(() =>
                    {
                        MyWindow.mainWindow.loading.loadingViewModel.Progress = Math.Round((currentField / (mapX * mapY) * 100), 0);
                        System.Diagnostics.Debug.WriteLine(MyWindow.mainWindow.loading.loadingViewModel.Progress);
                    

                        Field f;

                        f = new Field(map);


                        MyWindow.mainWindow.gameModel.NormalFields.Add(f);

                        Grid.SetColumn(f, i);
                        Grid.SetRow(f, j);

                        map.Children.Add(f);
                    });

                    currentField++;
                }
            }		
		}

		private void RegisterNeighborFieldsThread(int mapX, int mapY)
		{
            double currentField = 0.0;

            for (int i = 0; i < mapX; i++)
            {
                for (int j = 0; j < mapY; j++)
                {
                    Dispatcher.Invoke(() =>
                    {
                        MyWindow.mainWindow.loading.loadingViewModel.Progress = Math.Round((currentField / ((mapX) * mapY) * 100), 0);
                        System.Diagnostics.Debug.WriteLine(MyWindow.mainWindow.loading.loadingViewModel.Progress);

                        ((Field)map.Children.Cast<UIElement>().First(a => Grid.GetRow(a) == i && Grid.GetColumn(a) == j)).RegisterSurroundingFields();
                    });

                    currentField++;
                }

                // I TRIED MULTI-Threading BUT IT WAS SLOWER - IDK WHY THO
                //Thread thread = new Thread(new ThreadStart(()=> RegisterNeighbor(mapX, mapY, i)));
                //thread.Start();
            }
		}

        private void RegisterNeighbor(int mapX, int mapY, double currentLine)
        {
            double currentField = 0.0;

            for (int j = 0; j < mapY; j++)
            {
                Dispatcher.Invoke(() =>
                {
                    MyWindow.mainWindow.loading.loadingViewModel.Progress = Math.Round((currentField * currentLine / ((mapX) * mapY) * 100), 0);
                    System.Diagnostics.Debug.WriteLine(MyWindow.mainWindow.loading.loadingViewModel.Progress);

                    ((Field)map.Children.Cast<UIElement>().First(a => Grid.GetRow(a) == currentLine && Grid.GetColumn(a) == j)).RegisterSurroundingFields();
                });

                currentField++;
            }
        }

		private void PlaceBombs(int mapX, int mapY)
		{
			Random r = new Random();
            double tempBombMax = bombsLeft;

			while (bombsLeft != 0)
			{

                Dispatcher.Invoke(() =>
                {
                    MyWindow.mainWindow.loading.loadingViewModel.Progress = Math.Round(100 - ((double)bombsLeft / tempBombMax * 100), 0);
                
                System.Diagnostics.Debug.WriteLine(MyWindow.mainWindow.loading.loadingViewModel.Progress);

                    int x = r.Next(mapX);
				    int y = r.Next(mapY);

				    Field f = (Field)map.Children.Cast<UIElement>().First(a => Grid.GetRow(a) == x && Grid.GetColumn(a) == y);

				if (!f.IsBomb())
				{
					f.SetBomb();
                    MyWindow.mainWindow.gameModel.BombFields.Add(f);
                    MyWindow.mainWindow.gameModel.NormalFields.Remove(f);
					bombsLeft--;
				}
                });

            }
		}

        #endregion Private Methods

	}
}
