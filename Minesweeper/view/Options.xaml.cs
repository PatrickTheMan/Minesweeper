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
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : UserControl
    {

        #region Constructor
        public Options()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Buttons
        private void Button_Click(object sender, RoutedEventArgs e)
        {
			MyWindow.mainWindow.ccContainer.Content = MyWindow.mainWindow.menu;
        }

		private void Easy_Btn(object sender, RoutedEventArgs e)
		{
            this.FieldX_Tbox.Text = "10";
			this.FieldY_Tbox.Text = "10";

			this.FieldBombPercent_Tbox.Text = "5";
		}

		private void Normal_Btn(object sender, RoutedEventArgs e)
		{
			this.FieldX_Tbox.Text = "15";
			this.FieldY_Tbox.Text = "15";

			this.FieldBombPercent_Tbox.Text = "10";
		}

		private void Hard_Btn(object sender, RoutedEventArgs e)
		{
			this.FieldX_Tbox.Text = "20";
			this.FieldY_Tbox.Text = "20";

			this.FieldBombPercent_Tbox.Text = "15";
		}

		private void Insane_Btn(object sender, RoutedEventArgs e)
		{
			this.FieldX_Tbox.Text = "25";
			this.FieldY_Tbox.Text = "25";

			this.FieldBombPercent_Tbox.Text = "15";
		}

		private void Demon_Btn(object sender, RoutedEventArgs e)
		{
			this.FieldX_Tbox.Text = "50";
			this.FieldY_Tbox.Text = "50";

			this.FieldBombPercent_Tbox.Text = "15";
		}

		private void God_Btn(object sender, RoutedEventArgs e)
		{
			this.FieldX_Tbox.Text = "100";
			this.FieldY_Tbox.Text = "100";

			this.FieldBombPercent_Tbox.Text = "20";
		}

        #endregion Buttons

    }
}
