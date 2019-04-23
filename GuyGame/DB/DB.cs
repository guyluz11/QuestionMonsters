using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace GuyGame.DB
{
    public static class DB // Class to call all the dbs
    {
        public static int numberOfQuestions = 1;
        public static int category = 0;
        public static string difficulty = "Any Difficulty";
        public static string type = "Any Type";


        private static int questionsCounter;
        private static List<QuestionObject> listOfQuestions;

        public static void GenerateNewTriviaQuestion(int numberOfQuestionsInsert = 1, int categoryInsert = 0,
            string difficultyInsert = "Any Difficulty", string typeInsert = "Any Type")
        {
            numberOfQuestions = numberOfQuestionsInsert;
            category = categoryInsert;
            difficulty = difficultyInsert;
            type = typeInsert;

            listOfQuestions = OpenTriviaDb.GetNewTriviaQuestions(numberOfQuestions, category,
                difficulty, type);
                Console.WriteLine("This is list: " + listOfQuestions);
            if (listOfQuestions.Count == 0)
            {
                Console.WriteLine("No category combination" );
                Console.WriteLine("Please restart the game and choose different one" );

                throw new NullReferenceException(nameof(listOfQuestions));
            }
            questionsCounter = 0;
        }


        public static void NewQuestion()
        {
            if (questionsCounter + 1 > listOfQuestions.Count - 1)
            {
                return;
            }

            questionsCounter++;
        }


        public static QuestionObject getQuestion()
        {
            if (listOfQuestions == null)
            {
                GenerateNewTriviaQuestion();
                
            }

            if (listOfQuestions.Count -1 > questionsCounter)
            {
                return listOfQuestions[questionsCounter];
            }
            questionsCounter = listOfQuestions.Count -1;
            return listOfQuestions[questionsCounter];
        }

        public static void getNextQuestion()
        {
        }

        public static int getNumberOfQuestions()
        {
            return listOfQuestions.Count;
        }

        public static List<QuestionObject> getListOfQuestions()
        {
            return listOfQuestions;
        }
    }
}