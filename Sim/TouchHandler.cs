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
                default:
                    break;
            }
        }
        public static void MovedTouch(float x1, float y1, float x2, float y2)
        {
            MainMenu.MovedTouch(x1, y1, x2, y2);
        }
    }
}