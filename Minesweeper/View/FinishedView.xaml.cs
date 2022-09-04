using Minesweeper.Model;
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

namespace Minesweeper.View
{
	/// <summary>
	/// Interaction logic for FinishedView.xaml
	/// </summary>
	public partial class FinishedView : UserControl
	{

        #region Constructor
        public FinishedView()
		{
			InitializeComponent();
		}

        #endregion Constructor

        #region Buttons
        private void Button_Click(object sender, RoutedEventArgs e)
		{
			MyWindow.mainWindow.gameModel.BombAmount = 0;
			MyWindow.mainWindow.gameModel.FlaggedAmount = 0;
			MyWindow.mainWindow.gameModel.TimeSec = "00";
			MyWindow.mainWindow.gameModel.TimeMin = "00";

			MyWindow.mainWindow.changeThread = new Thread(new ThreadStart(MainWindow.ChangingSceneToFinished));
			MyWindow.mainWindow.ccContainer.Content = MyWindow.mainWindow.menu;
		}

        #endregion Buttons

    }
}
