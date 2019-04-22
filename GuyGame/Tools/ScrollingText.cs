using System;

namespace GuyGame
{
    public static class ScrollingText
    {
        public static void slowScrollingText(int numberOfLinesToScroll)
        {
            for (var i = 0; i < numberOfLinesToScroll; i++)
            {
                Console.WriteLine();
                System.Threading.Thread.Sleep(500);   
            }
        }
    }
}