using System;

namespace GuyGame
{
    public static class ConsoleColers
    {
        private static readonly ConsoleColor defaultBackgroundColor = Console.BackgroundColor;
        private static readonly ConsoleColor defaultForegroundColor = Console.ForegroundColor;

        public static void StoryColor()    // Story color mod
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        public static void SpecialEventColor()    // Story color mod
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
        }

        
        public static void FightingColor()    // Fighting color mod
        {
            Console.BackgroundColor = defaultBackgroundColor ;
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        
        public static void ChangeSettings()    // Fighting color mod
        {
//            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
    }
}