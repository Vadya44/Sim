using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Sim
{
    public static class TouchHandler
    {
        public static void JustTouch(float x, float y)
        {
            switch (GameView.activeScene)
            {
                case "MainMenu":
                    MainMenu.JustTouch(x, y);
                    break;
                case "Authentication":
                    Authentication.JustTouch(x, y);
                    break;
                case "Game_Ranked":
                    Game_Ranked.JustTouch(x, y);
                    break;
                case "Game_Solo":
                    Game_Solo.JustTouch(x, y);
                    break;
                case "LeaderBoard":
                    LeaderBoard.JustTouch(x, y);
                    break;
                case "Ranked_No_Connection":
                    Ranked_No_Connection.JustTouch(x, y);
                    break;
                case "Result_Ranked":
                    Result_Ranked.JustTouch(x, y);
                    break;
                case "Result_Solo":
                    Result_Solo.JustTouch(x, y);
                    break;
                case "Rules":
                    Rules.JustTouch(x, y);
                    break;
                default:
                    break;
            }
        }
        public static void MovedTouch(float x1, float y1, float x2, float y2)
        {
            switch (GameView.activeScene)
            {
                case "MainMenu":
                    MainMenu.MovedTouch(x1, y1, x2, y2);
                    break;
                case "Authentication":
                    Authentication.MovedTouch(x1, y1, x2, y2);
                    break;
                case "Game_Ranked":
                    Game_Ranked.MovedTouch(x1, y1, x2, y2);
                    break;
                case "Game_Solo":
                    Game_Solo.MovedTouch(x1, y1, x2, y2);
                    break;
                case "LeaderBoard":
                    LeaderBoard.MovedTouch(x1, y1, x2, y2);
                    break;
                case "Ranked_No_Connection":
                    Ranked_No_Connection.MovedTouch(x1, y1, x2, y2);
                    break;
                case "Result_Ranked":
                    Result_Ranked.MovedTouch(x1, y1, x2, y2);
                    break;
                case "Result_Solo":
                    Result_Solo.MovedTouch(x1, y1, x2, y2);
                    break;
                case "Rules":
                    Rules.MovedTouch(x1, y1, x2, y2);
                    break;
                default:
                    break;
            }
        }
    }
}