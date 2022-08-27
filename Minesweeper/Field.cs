using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Minesweeper
{
    public class Field : Button
    {

		private bool revealed = false;
        private bool bomb = false;
        private bool flagged = false;

        private int val = 0;

        private Grid grid;

        private List<Field> neighborFields = new List<Field>();

		public Field(Grid grid)
		{
            this.bomb = false;
			this.grid = grid;

			this.Content = "";
			this.VerticalContentAlignment = VerticalAlignment.Center;
			this.HorizontalContentAlignment = HorizontalAlignment.Center;

			this.Background = VariablesContainer.mainFieldColor;

			this.Click += (s, e) => { this.ClickField(); };
			this.PreviewMouseRightButtonUp += this.RightClick;

			VariablesContainer.fieldsLeft++;
		}

		public void RegisterSurroundingFields()
        {

            int x = Grid.GetColumn(this);
			int y = Grid.GetRow(this);

			int xMax = VariablesContainer.mapX;
			int yMax = VariablesContainer.mapY;


			for (int i = x - 1; i < 2 + x; i++)
            {
                if (i < 0 || i == xMax)
                {
                    continue; 
                }

                for (int j = y - 1 ; j < 2 + y; j++)
                {

                    if (j < 0 || j == yMax)
                    {
                        continue;
                    }

					neighborFields.Add((Field)grid.Children.Cast<UIElement>().First(e => Grid.GetRow(e) == j && Grid.GetColumn(e) == i));

				}
            }

			neighborFields.Remove(this);

			foreach (Field f in neighborFields)
            {
                if (f.IsBomb())
                {
                    val++;
                }
            }

		}

        public void SetBomb()
        {
            this.bomb = true;
			VariablesContainer.fieldsLeft--;
		}

        public bool IsBomb()
        {
            return this.bomb;
        }

        public void RemoveNeighbor(Field neighbor)
        {
            this.neighborFields.Remove(neighbor);
        }

		public void Reveal()
		{
			grid.Children.Remove(this);
		}

        public void ClickField()
        {

			if (flagged)
			{
				return;
			}

			foreach (Field f in neighborFields)
			{
				f.RemoveNeighbor(this);
			}
			grid.Children.Remove(this);

			int x = Grid.GetColumn(this);
			int y = Grid.GetRow(this);

			Button b = new Button();
			b.Width = this.Width;
			b.Height = this.Height;
			b.HorizontalContentAlignment = HorizontalAlignment.Center;
			b.VerticalContentAlignment = VerticalAlignment.Center;
			b.FontSize = 10;
			b.Background = Brushes.White;
			b.IsEnabled = false;
			Grid.SetColumn(b, x);
			Grid.SetRow(b, y);

			if (this.revealed)
			{
				return;
			} else if (this.bomb)
			{
				System.Diagnostics.Debug.WriteLine("Bomb");

				b.Background = Brushes.Red;

				grid.Children.Add(b);
				
				// LOSE
				MyWindow.mainWindow.ccContainer.Content = MyWindow.mainWindow.youLose;

			} else if (this.val > 0)
			{
	
				b.Content = this.val;
				
				switch (this.val)
				{
					case 1: { b.Foreground = Brushes.Blue; break; }
					case 2: { b.Foreground = Brushes.Green; break; }
					case 3: { b.Foreground = Brushes.Red; break; }
					case 4: { b.Foreground = Brushes.Purple; break; }
					case 5: { b.Foreground = Brushes.Maroon; break; }
					case 6: { b.Foreground = Brushes.Turquoise; break; }
					case 7: { b.Foreground = Brushes.Black; break; }
					case 8: { b.Foreground = Brushes.Gray; break; }
				}
				b.FontWeight = FontWeights.Bold;

				grid.Children.Add(b);

				VariablesContainer.fieldsLeft--;

			} else
			{

				foreach (Field f in neighborFields)
				{
					f.ClickField();
				}

				grid.Children.Add(b);

				VariablesContainer.fieldsLeft--;

			}

			if (VariablesContainer.fieldsLeft==0)
			{
				// WIN
				MyWindow.mainWindow.ccContainer.Content = MyWindow.mainWindow.youwin;
			}

			this.revealed = true;

		}
		
		public void RightClick(object sender, RoutedEventArgs e)
		{
			if (flagged)
			{
				this.flagged = false;
				this.Background = Brushes.LightGray;
			} else
			{
				this.flagged = true;
				this.Background = Brushes.Green;
			}
		}

    }
}
