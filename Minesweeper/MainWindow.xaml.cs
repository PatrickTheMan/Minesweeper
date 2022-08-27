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
        public View.YouLoseView youLose = new View.YouLoseView();
		public View.YouWinView youwin = new View.YouWinView();

		public MainWindow()
        {

            InitializeComponent();

			ccContainer.Content = menu;

            MyWindow.mainWindow = this;

        }

	}
}
