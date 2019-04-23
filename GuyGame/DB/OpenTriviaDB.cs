using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace GuyGame.DB
{
    public class OpenTriviaDb  //Class To get all data from db
    {
        public static readonly List<string> listOfCategories = new List<string>    
        {
            "Any Category", "General Knowledge", "Entertainment: Books", "Entertainment: Film",
            "Entertainment: Music", "Entertainment: Musicals & Theatres", "Entertainment: Television",
            "Entertainment: Video Games", "Entertainment: Board Games", "Science & Nature",
            "Science: Computers", "Science: Mathematics", "Mythology", "Sports", "Geography", "History",
            "Politics", "Art", "Celebrities", "Animals", "Vehicles", "Entertainment: Comics",
            "Science: Gadgets", "Entertainment: Japanese Anime & Manga", "Entertainment: Cartoon & Animations"
        }; //List of all categories in openTrivia api

        public static readonly Dictionary<string, string> dictionaryOfDifficulties = new Dictionary<string, string>
        {
            {"Any Difficulty", "0"}, {"Easy", "easy"}, {"Medium", "medium"}, {"Hard", "hard"}
        };    // List of all difficulties of Open Trivia API
        
        public static readonly Dictionary<string, string>  dictionaryOfTypes = new Dictionary<string, string>
        {
            {"Any Type", "0"}, {"Multiple Choice", "multiple"}, {"True / False", "boolean"}
        };    // List of all types in Open Trivia API
        
       
        
        
        public static List<QuestionObject> GetNewTriviaQuestions(int numberOfQuestions, int categoryNumber,
            string difficulty, string type)
        {
            categoryNumber = categoryNumber == 0 ? 0 : categoryNumber + 8;    // Category start from 0 and jump to 9 and up
            var urlForJson = "https://opentdb.com/api.php?amount=" + numberOfQuestions + "&category=" + (categoryNumber) + "&difficulty=" + dictionaryOfDifficulties[difficulty] + "&type=" + dictionaryOfTypes[type];

            Console.WriteLine("This is the url:");
            Console.WriteLine(urlForJson);
//       
            var jasonString = GetHtmlOfUrl(urlForJson).Result;
           
            Console.WriteLine();
            jasonString = jasonString.Substring(jasonString.IndexOf('['));
            jasonString = jasonString.Substring(0, jasonString.Length -1);
            

            Console.WriteLine("Jason string:");
            Console.WriteLine(jasonString);
            Console.WriteLine();
            Console.WriteLine();

            var listQuestuinsObject = new JavaScriptSerializer();
            var listTrivia = (List<OpenTrivaJasonObject>)listQuestuinsObject.Deserialize(jasonString, typeof(List<OpenTrivaJasonObject>));
            
            var QuestionObjectList = new List<QuestionObject>();
            string questionTemp;
            string correctAnswerTemp ;
            string difficultyTemp;
            string categoryTemp;
            string typeTemp;
            List<string> incorrectAnswersTemp;
            string invalidNameCategoryTemp;

            foreach (var questionObjectTemp in listTrivia)
            {
                questionTemp = questionObjectTemp.question;
                correctAnswerTemp = questionObjectTemp.correct_answer;
                difficultyTemp = questionObjectTemp.difficulty;
                categoryTemp= questionObjectTemp.category;
                typeTemp = questionObjectTemp.type;
                incorrectAnswersTemp = questionObjectTemp.incorrect_answers;
                invalidNameCategoryTemp= questionObjectTemp.__invalid_name__category;
                var questionObject = new QuestionObject(questionTemp, correctAnswerTemp, difficultyTemp, categoryTemp, typeTemp, incorrectAnswersTemp, invalidNameCategoryTemp);

                
                 QuestionObjectList.Add(questionObject);
            }
            return QuestionObjectList;
        }
        
        
        
        // Returns JSON string 
        private static async Task<string> GetHtmlOfUrl(string uri)
        {
            //http://www.google.com.pk
            using (var client = new HttpClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;    // Change the protocol, The site dont support TLS 1.0
                using (var response = await client.GetAsync(uri))
                {
                    using (var content = response.Content)
                    {
                        var myContent = await content.ReadAsStringAsync();
                        return myContent;
                    }
                }
                
            }
        }    
    }
}