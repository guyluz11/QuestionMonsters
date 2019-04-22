using System;
using System.Collections;
using System.Collections.Generic;
using GuyGame.DB;
using static System.Int32;

namespace GuyGame
{
    public static class GameSettings
    {
   
        
        public static void NewSettings()
        {
            ConsoleColers.ChangeSettings();
            Console.WriteLine("Game settings");
            Console.WriteLine();
            Console.WriteLine("Please enter the number of the setting that you wants to choose and not the name of it");
            Console.WriteLine();
            Console.WriteLine("Choose Category:");
            var counter = 0;
            foreach (var categoryTemp in OpenTriviaDb.listOfCategories)
            {
                Console.WriteLine(counter + ". " + categoryTemp);
                counter++;
            }
            Console.WriteLine();

            var categoryString = chooseItemFromList(OpenTriviaDb.listOfCategories,"Category");
            
            
            var categoryNumber = OpenTriviaDb.listOfCategories.IndexOf(categoryString);
            var difficulty = chooseItemFromList(OpenTriviaDb.dictionaryOfDifficulties,"Difficulty");
            var types = chooseItemFromList(OpenTriviaDb.dictionaryOfTypes,"Type");
            
            
            Console.WriteLine();
            Console.WriteLine("Category: " + categoryNumber);
            Console.WriteLine("Difficulty: " + difficulty);
            Console.WriteLine("Type: " + types);
            Console.WriteLine();
            DB.DB.category = categoryNumber;
            DB.DB.difficulty = difficulty;
            DB.DB.type = types;
            DB.DB.GenerateNewTriviaQuestion(1, categoryNumber, difficulty, types);

        }

        private static string chooseItemFromList(ICollection propertyIEnumerable, string propertyToPrint) // Show the list and ask for the user to pick one
        {
            Console.WriteLine("Choose" + propertyToPrint +":");
            var counter = 0;
            Console.WriteLine(propertyIEnumerable.GetType());
            Console.WriteLine();
            foreach (var categoryTemp in propertyIEnumerable)
            {
                if (propertyIEnumerable.GetType() == typeof(Dictionary<string, string>))
                {
                    Console.WriteLine(counter + ". " + ((KeyValuePair<string, string>) categoryTemp).Key);
                }
                else
                {
                    Console.WriteLine(counter + ". " + categoryTemp);

                }
                counter++;
            }
            Console.WriteLine();
            var selectedItemNumber = ValidNumber(propertyToPrint,0,  propertyIEnumerable.Count - 1);
            if (propertyIEnumerable.GetType() == typeof(Dictionary<string, string>))
            {
                var propertyIEnumerableAsDictionary = (Dictionary<string, string>) propertyIEnumerable;
                var counterTemp = 0;
                var keyChooseByUser = "";
                foreach (var keyValue in propertyIEnumerable)
                {
                    if (counterTemp == selectedItemNumber)
                    {
                        Console.WriteLine(((KeyValuePair<string, string>)keyValue).Key);
                        keyChooseByUser = ((KeyValuePair<string, string>)keyValue).Key;
                        break;
                    }
                    counterTemp++;
                }
                return keyChooseByUser;
            }
            var propertyIEnumerableAsList = (List<string>) propertyIEnumerable;
            return propertyIEnumerableAsList[selectedItemNumber];
        }
        private static int ValidNumber(string propertyToPrint,int minimumNumber, int maximumNumber)    // Function takes 2 int number and ask user to enter number between the 2 numbers 
        {
            Console.Write( propertyToPrint + " number: ");
            int userNumber;
            while (true)
            {
                while (!TryParse(Console.ReadLine(), out  userNumber))
                {
                    Console.WriteLine("Please enter a number");
                    Console.Write( propertyToPrint + " number: ");
                }

                if (!(minimumNumber <= userNumber && userNumber <= maximumNumber))
                {
                    Console.WriteLine("Number not int the range of " + minimumNumber + "-" + maximumNumber);
                    Console.Write( propertyToPrint + " number: ");
                }
                else
                {
                    break;
                }
            }
            return userNumber;
        }

    }
}