namespace Assets.Scripts
{
    internal struct Border
    {
        internal float Left;
        internal float Right;
        internal float Top;
        internal float Bottom;
    }

    internal class Settings
    {
        internal static Border Field = new Border{Left = -20, Right = 20, Top = 16, Bottom = -1 };
        internal static Border World = new Border {Left = -23, Right = 23, Top = 19, Bottom = -4};
    }
}
