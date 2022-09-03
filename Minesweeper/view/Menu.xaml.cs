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
        

        public Menu()
        {
            InitializeComponent();
        }

        private void Options_Button_Click(object sender, RoutedEventArgs e)
        {
			MyWindow.mainWindow.ccContainer.Content = MyWindow.mainWindow.options;
        }

		private Grid map;
		private int bombsLeft;

		private void Play_Button_Click(object sender, RoutedEventArgs e)
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


			int mapX = MyWindow.mainWindow.gameModel.MapX;
			int mapY = MyWindow.mainWindow.gameModel.MapY;
			int bombPercent = MyWindow.mainWindow.gameModel.BombPercent;

			map = new Grid();

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


			// Set map x amount of columns
			map.SetValue(Grid.ColumnProperty, 1);
			for (int i = 0; i < mapX; i++)
			{
				map.ColumnDefinitions.Add(new ColumnDefinition());
			}

			// Set map y amount of rows
			map.SetValue(Grid.RowProperty, 1);
			for (int i = 0; i < mapY; i++)
			{
				map.RowDefinitions.Add(new RowDefinition());
			}

			// Spawn bombs in a line
			for (int i = 0; i < mapX; i++)
			{
				AddLineOfFieldsThread(i, mapY);
			}

			// Place bombs
			PlaceBombs(mapX, mapY);

			// Register neighborFields
			for (int i = 0; i < mapX; i++)
			{
				RegisterNeighborFieldsThread(i, mapY);
			}


			MyWindow.mainWindow.game.Container_SP.Content = map;

			// Set container to game
			MyWindow.mainWindow.ccContainer.Content = MyWindow.mainWindow.game;

			// Start time
			if (MyWindow.mainWindow.timeThread.ThreadState == ThreadState.Unstarted)
			{
				MyWindow.mainWindow.timeThread.Start();
			} else
			{
				MyWindow.mainWindow.timeThread.Resume();
			}
			
		}

		private void AddLineOfFieldsThread(int xPosition, int yAmount)
		{

			for (int j = 0; j < yAmount; j++)
			{
				Field f;

				f = new Field(map);
				MyWindow.mainWindow.gameModel.NormalFields.Add(f);

				Grid.SetColumn(f, xPosition);
				Grid.SetRow(f, j);

				map.Children.Add(f);

			}
			
		}

		private void RegisterNeighborFieldsThread(int xPosition, int yAmount)
		{
			for (int i = 0; i < yAmount; i++)
			{

				((Field)map.Children.Cast<UIElement>().First(a => Grid.GetRow(a) == xPosition && Grid.GetColumn(a) == i)).RegisterSurroundingFields();

			}
		}

		private void PlaceBombs(int mapX, int mapY)
		{
			Random r = new Random();

			while (bombsLeft != 0)
			{
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

			}

		}

	}
}
