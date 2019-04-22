using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Security.AccessControl;
using NUnit.Framework;
using static System.Int32;


namespace GuyGame
{
    public class FlowClass
    {
        private BackgroundMusic backgroundMusic;
        
        public FlowClass()
        {
            ConsoleColers.SpecialEventColor();
            Console.WriteLine("Press enter to begin your journey");
            Console.ReadLine();
            Console.Clear();
            backgroundMusic =  new BackgroundMusic();    // Start random song as background music
            NewGame();
        }

        private static void NewGame()
        {
            GameSettings.NewSettings();
            
            ConsoleColers.StoryColor();    // Change the color to story mod
            Console.WriteLine("New game has started");
            Console.WriteLine();
            
            ConsoleColers.StoryColor();
            ScrollingText.slowScrollingText(10);
            SpeakClass.speakString("Rise and shine Warrior \nThis is were your journey begins");
            SpeakClass.speakString("More plot...");
            
            ScrollingText.slowScrollingText(5);

            showQuestion(DB.DB.getQuestion());
            DB.DB.NewQuestion();
            
            Console.ReadLine();
            
            Console.ReadLine();

        }

        private static void showQuestion(QuestionObject questionObject)
        {
            SpeakClass.speakString("Question: " + questionObject.question);
            
            SpeakClass.speakString("Choose the correct answer:");
            int numberOfAnswers;
            if (questionObject.type.Equals("boolean"))
            {
                numberOfAnswers = 1;
                // Make the random shuffle True or False 50/50 and not answer(1)/number_Of_wong_answers(x)
                var possibleAnswers = questionObject.incorrect_answers;
                possibleAnswers = Shuffle(possibleAnswers);
                
                var possibleAnswer = new List<string> {possibleAnswers[0], questionObject.correctAnswer};
                possibleAnswer = Shuffle(possibleAnswers);
                Console.WriteLine("0." + "False");
                Console.WriteLine("1." + "True");

                var answer = ValidInputNumber(0, numberOfAnswers);
                var answerText = "";
                if (answer == 0)
                {
                    if (questionObject.correctAnswer.Equals("False"))
                    {
                        answerText = "Your Are correct";
                    }
                    else
                    {
                        answerText = "Wrong answer";
                    }
                }
                else if (answer == 1)
                {
                    if (questionObject.correctAnswer.Equals("True"))
                    {
                        answerText = "Your Are correct";
                    }
                    else
                    {
                        answerText = "Wrong answer";   
                    }
                }
               
                SpeakClass.speakString(answerText);

            }
            else
            {
                numberOfAnswers = questionObject.incorrect_answers.Count;
                var possibleAnswers = questionObject.incorrect_answers;
                possibleAnswers.Add(questionObject.correctAnswer);
                possibleAnswers = Shuffle(possibleAnswers);
                var counter = 0;
                foreach (var incorrectAnswers in possibleAnswers)
                {
                    SpeakClass.speakString(counter + ". " +incorrectAnswers);
                    counter++;
                }
                var answer = ValidInputNumber(0, numberOfAnswers);
                SpeakClass.speakString("Correct answer " + questionObject.correctAnswer);

            }
        }
        
       private static int ValidInputNumber(int minimumNumber, int maximumNumber)    // Function takes 2 int number and ask user to enter number between the 2 numbers 
       {
           int userNumber;
           while (true)
           {
               while (!TryParse(Console.ReadLine(), out  userNumber))
               {
                   Console.WriteLine("Please enter a number");
               }

               if (!(minimumNumber <= userNumber && userNumber <= maximumNumber))
               {
                   Console.WriteLine("Number not int the range of " + minimumNumber + "-" + maximumNumber);
               }
               else
               {
                   break;
               }
           }
           return userNumber;
       }

        private static List<T> Shuffle<T>(List<T> list)  
        {  
            var rng = new Random();  
            var n = list.Count;  
            while (n > 1) {  
                n--;  
                var k = rng.Next(n + 1);  
                var value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }
            return list;
        }
    }
    
}