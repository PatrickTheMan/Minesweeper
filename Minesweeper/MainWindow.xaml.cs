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

        public view.Options options = new view.Options();
        public view.Game game = new view.Game();
        public view.Menu menu = new view.Menu();

        public MainWindow()
        {

            InitializeComponent();

            ccContainer.Content = menu;

            MyWindow.mainWindow = this;

        }



        
    }
}
