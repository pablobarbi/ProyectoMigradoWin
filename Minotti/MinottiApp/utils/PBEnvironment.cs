namespace Minotti.utils
{
    public static class PBEnvironment
    {
        public static int GetEnvironment(out Structures.environment Env)
        {
            Env = new  Structures.environment
            {
                ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width,
                ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
            };
            return 1;
        }
    }
}
