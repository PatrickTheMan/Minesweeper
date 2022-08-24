using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Minesweeper
{
    public class Field : Button
    {

        private bool isBomb;
        private bool isFlagged;

        private string val;

        private Grid grid;

        private List<Field> neighborFields = new List<Field>();


        public Field(bool isBomb, Grid grid)
        {
            this.grid = grid;
            this.isBomb = isBomb;

            //this.SetBinding(ContentProperty,val);
            this.Click += (s,e) => { this.ClickField(); };
        }

		public Field(Grid grid)
		{
            this.isBomb = false;
			this.grid = grid;

			//this.SetBinding(ContentProperty, val);
			this.Click += (s, e) => { this.ClickField(); };
		}

		public void RegisterSurroundingFields()
        {

            int x = Grid.GetColumn(this);
			int y = Grid.GetRow(this);

            int xMax = int.Parse(MyWindow.mainWindow.options.FieldX_Tbox.Text);
			int yMax = int.Parse(MyWindow.mainWindow.options.FieldY_Tbox.Text);


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

		}

        public void ClickField()
        {

            foreach (Field f in neighborFields)
            {
				grid.Children.Remove(f);
			}

            neighborFields.Clear();
            
        }

    }
}
