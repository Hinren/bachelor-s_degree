using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.Models
{
    public class QuizViewModel
    {
        public string Url { get; set; }
        public List<Quiz> Quizzes { get; set; } = new List<Quiz>();
    }
}
