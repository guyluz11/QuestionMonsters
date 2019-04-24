using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GuyGame.DB;
using NUnit.Framework;

namespace GuyGame.Tests
{
    public class DBTestData
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(1, 1, "Easy", "Multiple Choice");
                yield return new TestCaseData(1, 1, "Easy", "True / False");
                
            }    
        }
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

        public static IEnumerable ListOfALlQuestionCategoriesCombinationWithoutRandom()
        {
            var testCases = new List<TestCaseData>();

            for (var i = 1; i < OpenTriviaDb.listOfCategories.Count; i++)
            {
                foreach (var j in OpenTriviaDb.dictionaryOfDifficulties)
                {
                    if (j.Key.Equals("Any Difficulty"))
                    {
                        continue;
                    }

                    foreach (var z in OpenTriviaDb.dictionaryOfTypes)
                    {
                        if (z.Key.Equals("Any Type"))
                        {
                            continue;
                        }
                        testCases.Add(new TestCaseData(1, i, j.Key, z.Key));
                    }
                }
            }

            return testCases;

        }
    }
}