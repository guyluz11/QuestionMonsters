
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using GuyGame.DB;
using NUnit.Framework;

namespace GuyGame.Tests
{

    public class DBTest
    {
//
//        public static readonly List<string> listOfCategories = new List<string>    
//        {
//            "Any Category", "General Knowledge", "Entertainment: Books", "Entertainment: Film",
//            "Entertainment: Music", "Entertainment: Musicals & Theatres", "Entertainment: Television",
//            "Entertainment: Video Games", "Entertainment: Board Games", "Science & Nature",
//            "Science: Computers", "Science: Mathematics", "Mythology", "Sports", "Geography", "History",
//            "Politics", "Art", "Celebrities", "Animals", "Vehicles", "Entertainment: Comics",
//            "Science: Gadgets", "Entertainment: Japanese Anime & Manga", "Entertainment: Cartoon & Animations"
//        }; //List of all categories in openTrivia api
//
//        public static readonly Dictionary<string, string> dictionaryOfDifficulties = new Dictionary<string, string>
//        {
//            {"Any Difficulty", "0"}, {"Easy", "easy"}, {"Medium", "medium"}, {"Hard", "hard"}
//        };    // List of all difficulties of Open Trivia API
//        
//        public static readonly Dictionary<string, string>  dictionaryOfTypes = new Dictionary<string, string>
//        {
//            {"Any Type", "0"}, {"Multiple Choice", "multiple"}, {"True / False", "boolean"}
//        };    // List of all types in Open Trivia API
//
//


        [Test]
        [TestCase(1, 1, "Easy", "True / False")]
        public void getQuestionObjectFor_1_Easy_MultipleChoice(int numberOfQuestions, int categoryNumber, string difficulty, string type)
        {
            // Arrange
            
            // 1 = General_Knowledge
            // Easy = easy
            // Multiple Choice = multiple
            List<QuestionObject> listOfQuestions;

            // Act
            listOfQuestions = getQuestionObjectList(numberOfQuestions, categoryNumber, difficulty, type);
            
            // Assert
            Assert.That(listOfQuestions, Has.Exactly(numberOfQuestions).Items);
            
            Assert.That(listOfQuestions, Has.Exactly(numberOfQuestions).Matches<QuestionObject>(item => 
                item.category == OpenTriviaDb.listOfCategories[categoryNumber] && 
                item.difficulty ==  OpenTriviaDb.dictionaryOfDifficulties[difficulty] &&
                item.type == OpenTriviaDb.dictionaryOfTypes[type]), "Not All the types are as they suppose to be");

        }

        [Test]
        public void getQuestionObjectFor_1_Easy_TrueFalse()
        {
            
            // 1 = General_Knowledge
            // Easy = easy
            // Multiple Choice = True / False
            const int numberOfQuestions = 1;
            const int categoryNumber = 1;
            const string difficulty = "Easy";
            const string type = "True / False";
            List<QuestionObject> listOfQuestions;
            
            // Act
            listOfQuestions = getQuestionObjectList(numberOfQuestions, categoryNumber, difficulty, type);

            Assert.That(listOfQuestions, Has.Exactly(numberOfQuestions).Items);
            
            Assert.That(listOfQuestions, Has.Exactly(numberOfQuestions).Matches<QuestionObject>(item => 
                item.category == OpenTriviaDb.listOfCategories[categoryNumber] &&
                item.difficulty == OpenTriviaDb.dictionaryOfDifficulties[difficulty] &&
                item.type == OpenTriviaDb.dictionaryOfTypes[type]));
            
        }

        public bool ChackMe(string a, string b)
        {
            return true;
        }
        [Test]
        public void CheckObjectFromDB()
        {
            // Arrange
            const int numberOfQuestions = 1;
            var categoryNumber = 0;
            const string difficulty = "Any Difficulty";
            const string type = "Any Type";
            List<QuestionObject> questionObjectsList; 
            // Act
            categoryNumber = categoryNumber == 0 ? 0 : categoryNumber + 8;    // Category start from 0 and jump to 9 and up
            questionObjectsList = getQuestionObjectList(numberOfQuestions, categoryNumber, difficulty, type);

            
            // Assert
            Console.WriteLine(questionObjectsList[0].difficulty);
            Assert.That(questionObjectsList, Has.Exactly(numberOfQuestions).Property("difficulty").EqualTo("medium"));


            Assert.That(questionObjectsList, Has.Exactly(1).Matches<QuestionObject>(item => item.difficulty == "medium"));

//            Assert.That(questionObjectsList.Count, Is.EqualTo(1));
//            
//            Assert.That(OpenTriviaDb.listOfCategories, Does.Contain(DB.DB.getQuestion().category));
//            
//            Assert.That(OpenTriviaDb.dictionaryOfDifficulties.Values, Does.Contain(DB.DB.getQuestion().difficulty));
//            
//            Assert.That(DB.DB.getQuestion().type, Is.EqualTo("multiple").Or.EqualTo("boolean"));
//
//            Assert.That(DB.DB.type, Is.EqualTo("Any Type"));

        }

        public List<QuestionObject> getQuestionObjectList(int numberOfQuestions, int categoryNumber, string difficulty, string type)
        {
            DB.DB.GenerateNewTriviaQuestion(numberOfQuestions, categoryNumber, difficulty, type);
            return DB.DB.getListOfQuestions();

        }
        
        
    }
}