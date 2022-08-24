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
            MyWindow.mainWindow.ccContainer.Content = MyWindow.mainWindow.options;
        }

    }
}
