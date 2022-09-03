using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Model
{
    public class LoadingViewModel
    {

		private int progress = 10;

		public int Progress
		{
			get { return progress; }
			set { progress = value; }
		}

		private string loadingText = "yes";

		public string LoadingText
		{
			get { return loadingText; }
			set { loadingText = value; }
		}



	}
}
