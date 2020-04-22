using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.EF
{
    public class UsersScoreQuiz
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public int HowManyQustion { get; set; }
        public decimal EffectivenessInPercent { get; set; }
    }
}
