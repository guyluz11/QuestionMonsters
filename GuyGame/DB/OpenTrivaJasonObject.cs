using System;
using System.Collections.Generic;

namespace GuyGame.DB
{
    
    public class OpenTrivaJasonObject
    {
        public string category { get; set; }
        public string type { get; set; }
        public string difficulty { get; set; }
        public string question { get; set; }
        public string correct_answer { get; set; }
        public List<string> incorrect_answers { get; set; }
        public string __invalid_name__category { get; set; }
    }
}