using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.EF
{
    public class UsersScoreQuiz
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public int HowManyQuestions { get; set; }
        public int HowManyCorrect { get; set; }
    }
}
