using System.Collections.Generic;

namespace GuyGame
{
    public class QuestionObject
    {
        // Page of api
        // https://opentdb.com/api_config.php

        public string question { get; } // The acual question
        public string correctAnswer { get; } // The answer

        public  string difficulty { get; } // Difficulty of the question 

        public  string category { get; } // In witch category the question is

        public  string type { get; } // True/False or Multiple choice 

        public  List<string> incorrect_answers { get; } // List of incorrect answers

        public  string __invalid_name__category { get; }

        public QuestionObject(string question, string correctAnswer, string difficulty, string category = "",
            string type = "", List<string> incorrect_answers = null, string __invalid_name__category = null)
        {
            this.question = question;
            this.correctAnswer = correctAnswer;
            this.difficulty = difficulty;
            this.category = category;
            this.type = type;
            this.incorrect_answers = incorrect_answers;
            this.__invalid_name__category = __invalid_name__category;
        }

        public string getString()
        {
            return "I am a string";
        }
    }
}