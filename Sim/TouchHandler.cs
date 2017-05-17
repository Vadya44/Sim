namespace Sim
{
    public static class TouchHandler
    {
        public static void JustTouch(float x, float y)
        {
            switch (GameView.activeScene)
            {
                case "Multiplayer":
                    Multiplayer.JustTouch(x, y);
                    break;
                case "MainMenu":
                    MainMenu.JustTouch(x, y);
                    break;
                case "ModeSelect":
                    ModeSelect.JustTouch(x, y);
                    break;
                case "Game_Solo":
                    Game_Solo.JustTouch(x, y);
                    break;
                case "NumberSelect":
                    NumberSelect.JustTouch(x, y);
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
                case "Multiplayer":
                    Multiplayer.MovedTouch(x1, y1, x2, y2);
                    break;
                case "MainMenu":
                    MainMenu.MovedTouch(x1, y1, x2, y2);
                    break;
                case "ModeSelect":
                    ModeSelect.MovedTouch(x1, y1, x2, y2);
                    break;
                case "Game_Solo":
                    Game_Solo.MovedTouch(x1, y1, x2, y2);
                    break;
                case "NumberSelect":
                    NumberSelect.MovedTouch(x1, y1, x2, y2);
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