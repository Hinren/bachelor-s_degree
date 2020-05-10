using SignLanguage.Models;
using System.Collections.Generic;

namespace SignLanguage.Website.Areas.Quiz.Models
{
    public class QuizViewModel
    {
        public string Url { get; set; }
        public List<QuizData> Quizzes { get; set; } = new List<QuizData>();

        public QuizViewModel(List<QuizData> Quizzes, string Url)
        {
            this.Quizzes = Quizzes;
            this.Url = Url;
        }
        public QuizViewModel()
        {
        }
    }
}
