using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Model
{
    public class LoadingViewModel : INotifyPropertyChanged
    {

		private double progress = 0;

		public double Progress
		{
			get { return progress; }
			set { progress = value; NotifyPropertyChanged(); }
		}

		private string loadingText = "";
		public string LoadingText
		{
			get { return loadingText; }
			set { loadingText = value; NotifyPropertyChanged(); }
		}

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
