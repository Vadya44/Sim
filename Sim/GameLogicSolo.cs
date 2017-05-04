using System;
using System.Collections.Generic;
namespace Sim
{
	public static class GameLogicSolo
	{
		public static Point[] pointsArr;
		public static Line[] UsedLines;
		public static bool playerTurn = true;
		static GameLogicSolo()
		{
			
		}
		public static Line turnSender(Point[] pArr, 
		                             Line[] lArr)
		{
			Line botTurn = null;
			pointsArr = pArr;
			UsedLines = lArr;
			for (int i = 0; i < pointsArr.Length; i++)
				for (int j = 0; j < pointsArr.Length; j++)
				{
					bool isSuit = true;
					if (i != j)
					{
						Line buff = new Line(pointsArr[i],
								     pointsArr[j]);
						for (int k = 0; k < UsedLines.Length; k++)
							if (buff == UsedLines[k])
							{
								isSuit = false;
								break;
							}
						if (isSuit)
							botTurn = buff;
					}
				}
			return botTurn;

		}
	}
}
