using System;
using System.Collections.Generic;
using System.IO;
using System.Speech.Synthesis;

namespace GuyGame
{
    public static class SpeakClass
    {
        static readonly SpeechSynthesizer
            synthesizer = new SpeechSynthesizer {Volume = 100, Rate = 3}; // Initializing the speechSynthesizer 

        public static void newEnemyEn(string enemyName, int numberOfEnemies = 1) // What to say when encountering enemy
        {
            var rand = new Random();

                
            var encounteringStringOptions = new List<string>    // List of possible string to say when you encountered enemies 
            {
                "You have encountered ", "Prepare for battle against ", "Now you will face "  
            };
            var randomStringNumber = rand.Next(encounteringStringOptions.Count);    // stores the rand string number from the list
            var textToSpeak = encounteringStringOptions[randomStringNumber]; // Create the variable to save all the text and insert random string from the list
            var numberOfEnemiesString =
                numberOfEnemies > 1 ? numberOfEnemies + " " : ""; // if more than 1 enemy than say the number 

            textToSpeak += numberOfEnemiesString + enemyName;    // Add the number of enemy and enemy name to to the string   

            speakString(textToSpeak);    // Speak and print the final string
        }

        public static void speakString(string textToSpeak)    // Speak and print the final output
        {
            Console.WriteLine(textToSpeak);
            synthesizer.Speak(textToSpeak);
        }
    }
}