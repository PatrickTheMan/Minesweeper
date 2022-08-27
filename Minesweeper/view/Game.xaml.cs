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

namespace Minesweeper.View
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : UserControl
    {
        public Game()
        {
            InitializeComponent();
        }
        private void UserControl_MouseWheel(object sender, MouseWheelEventArgs e)
        {

			if (e.Delta > 0)
			{
                if (ZoomSlider.Value+0.25 <= ZoomSlider.Maximum)
                {
					ZoomSlider.Value += 0.25;
				}
			}
			else
			{
				if (ZoomSlider.Value - 0.25 >= ZoomSlider.Minimum)
				{
					ZoomSlider.Value -= 0.25;
				}
			}

		}

    }
}
