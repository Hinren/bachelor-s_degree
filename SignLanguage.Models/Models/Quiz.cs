using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.Models.Models
{
    public class Quiz
    {
        public int IdGoodMeaningWord { get; set; }
        public string Meaning { get; set; }
        public int? IdBadMeaning { get; set; }
    }
}
