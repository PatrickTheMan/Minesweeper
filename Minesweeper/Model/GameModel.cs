using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Minesweeper.Model
{
	public class GameModel : INotifyPropertyChanged
	{
		public List<Field> BombFields = new List<Field>();
		public List<Field> NormalFields = new List<Field>();

		#region
		private string timeSec = "00";

		public string TimeSec
		{
			get { return timeSec; }
			set { timeSec = value; NotifyPropertyChanged(); }
		}

		private string timeMin = "00";

		public string TimeMin
		{
			get { return timeMin; }
			set { timeMin = value; NotifyPropertyChanged(); }
		}

		public static void TimeThread()
		{

			while (true) 
			{
				int sec = int.Parse(MyWindow.mainWindow.gameModel.TimeSec);

				if (sec < 9)
				{
					MyWindow.mainWindow.gameModel.TimeSec = "0" + (sec + 1);
				}
				else
				{
					if (sec == 60)
					{
						MyWindow.mainWindow.gameModel.TimeSec = "00";

						int min = int.Parse(MyWindow.mainWindow.gameModel.TimeMin);

						if (min < 9)
						{
							MyWindow.mainWindow.gameModel.TimeMin = "0" + (min + 1);
						}
						else
						{
							MyWindow.mainWindow.gameModel.TimeMin = "" + (min + 1);
						}

					} else
					{
						MyWindow.mainWindow.gameModel.TimeSec = "" + (sec + 1);
					}
				}

				Thread.Sleep(1000);
			}
		}

		#endregion

		private int bombAmount;

		public int BombAmount
		{
			get { return bombAmount; }
			set { bombAmount = value; NotifyPropertyChanged(); }
		}

		private int bombsLeft;

		public int BombsLeft
		{
			get { return bombsLeft; }
			set { bombsLeft = value; }
		}

		private int flaggedAmount;

		public int FlaggedAmount
		{
			get { return flaggedAmount; }
			set { flaggedAmount = value; NotifyPropertyChanged(); }
		}

		private int mapX;

		public int MapX
		{
			get { return mapX; }
			set { mapX = value; }
		}

		private int mapY;

		public int MapY
		{
			get { return mapY; }
			set { mapY = value; }
		}

		private int fieldsLeft;

		public int FieldsLeft
		{
			get { return fieldsLeft; }
			set { fieldsLeft = value; }
		}

		private int bombPercent;

		public int BombPercent
		{
			get { return bombPercent; }
			set { bombPercent = value; }
		}

		private double donePercent;

		public double DonePercent
		{
			get { return donePercent; }
			set 
			{ 
				if (value==0)
				{
					donePercent = Math.Round(100 - ((double)fieldsLeft / ((mapX * mapY) - bombAmount) * 100),2);
				} else
				{
					donePercent = 100;
				}
			}
		}


		public static Brush mainFieldColor = Brushes.LightGray;



		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
