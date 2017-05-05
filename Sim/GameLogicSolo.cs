using System;
using System.Collections.Generic;
namespace Sim
{
    public static class GameLogicSolo
    {
        public static bool playerTurn = true;
        public static Line turnSender(Point[] pArr,
                                     List<Line> linesList)
        {
            for (int i = 0; i < pArr.Length; i++)
            {
                for (int j = 0; j < pArr.Length; j++)
                {

                    if (i != j)
                    {
                        Line buff = new Line(pArr[i],
                                     pArr[j]);
                        if (!linesList.Contains(buff))
                        {
                            return buff;
                        }
                    }
                }
            }
            return null;

        }
    }
}
