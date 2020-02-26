using SignLanguage.Models.Models.QuizToDisplayOnView;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.Models.Models
{
    public class StartQuiz
    {
        public string url { get; set; }
        public List<CorrectWord> WordsToDisplay { get; set; }
        public StartQuiz(string url, List<CorrectWord> wordsToDisplay)
        {
            this.url = url;
            WordsToDisplay = wordsToDisplay;
        }
    }
}
