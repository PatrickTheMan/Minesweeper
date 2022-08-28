using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Minesweeper.Model
{
	public class GameModel
	{

		private static int bombsLeft;

		public static int BombsLeft
		{
			get { return bombsLeft; }
			set { bombsLeft = value; }
		}

		private int flaggedAmount;

		public int FlaggedAmount
		{
			get { return flaggedAmount; }
			set { flaggedAmount = value; }
		}


		public static int fieldsLeft;

		public static int mapX;
		public static int mapY;
		public static int bombPercent;

		public static Brush mainFieldColor = Brushes.LightGray;

	}
}
