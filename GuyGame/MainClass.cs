using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using GuyGame.DB;


namespace GuyGame
{
    internal static class MainClass
    {
        
        private static bool a =false;
        
        public static void Main(string[] args)
        {

            new FlowClass();    // Start the game

            Console.WriteLine("Good by");
            Console.ReadKey();
        
              
        }

       

    }
    
}