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
			VariablesContainer.fieldsLeft = 0;

			try
			{
				VariablesContainer.mapX = int.Parse(MyWindow.mainWindow.options.FieldY_Tbox.Text);
			}
			catch (Exception)
			{
				VariablesContainer.mapX = 10;
			}
			try
			{
				VariablesContainer.mapY = int.Parse(MyWindow.mainWindow.options.FieldY_Tbox.Text);
			}
			catch (Exception)
			{
				VariablesContainer.mapY = 10;
			}
			try
			{
				VariablesContainer.bombPercent = int.Parse(MyWindow.mainWindow.options.FieldBombPercent_Tbox.Text);
			}
			catch (Exception)
			{
				VariablesContainer.bombPercent = 10;
			}


			int mapX = VariablesContainer.mapX;
			int mapY = VariablesContainer.mapY;
			int bombPercent = VariablesContainer.bombPercent;

			map = new Grid();

			// Cal bomb amount
			if (bombPercent>90)
			{
				bombsLeft = (mapX * mapY) / 100 * 99;
			} else if (bombPercent<=0)
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
				RegisterNeighborFieldsThread(i,mapY);
			}

			MyWindow.mainWindow.game.Container_SP.Content = map;


			// Set container to game
			MyWindow.mainWindow.ccContainer.Content = MyWindow.mainWindow.game;


		}

		private void AddLineOfFieldsThread(int xPosition, int yAmount)
		{

			for (int j = 0; j < yAmount; j++)
			{
				Field f;

				f = new Field(map);

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

				if (!((Field)map.Children.Cast<UIElement>().First(a => Grid.GetRow(a) == x && Grid.GetColumn(a) == y)).IsBomb())
				{
					((Field)map.Children.Cast<UIElement>().First(a => Grid.GetRow(a) == x && Grid.GetColumn(a) == y)).SetBomb();
					bombsLeft--;
				}

			}

		}

	}
}
