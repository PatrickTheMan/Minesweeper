using System;
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

namespace Minesweeper.view
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

        private void Play_Button_Click(object sender, RoutedEventArgs e)
        {
            int mapX = int.Parse(MyWindow.mainWindow.options.FieldX_Tbox.Text);
			int mapY = int.Parse(MyWindow.mainWindow.options.FieldY_Tbox.Text);

			Grid map = new Grid();

            map.SetValue(Grid.ColumnProperty, 1);
            for (int i = 0; i < mapX; i++)
            {
				map.ColumnDefinitions.Add(new ColumnDefinition());
            }

			map.SetValue(Grid.RowProperty, 1);
			for (int i = 0; i < mapY; i++)
			{
				map.RowDefinitions.Add(new RowDefinition());
			}

            for (int i = 0; i < mapX; i++)
            {
                for (int j = 0; j < mapY; j++)
                {

					Field f = new Field(map);
					f.Margin = new Thickness(0.5);

					Grid.SetColumn(f, i);
					Grid.SetRow(f, j);

					map.Children.Add(f);

				}
            }

			// Register neighborFields
			for (int i = 0; i < mapX; i++)
			{
				for (int j = 0; j < mapY; j++)
				{

					((Field)map.Children.Cast<UIElement>().First(a => Grid.GetRow(a) == i && Grid.GetColumn(a) == j)).RegisterSurroundingFields();

				}
			}

			


			MyWindow.mainWindow.game.Content = map;


            // Start game
            MyWindow.mainWindow.ccContainer.Content = MyWindow.mainWindow.game;
        }

    }
}
