using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.EF
{
    public class BadMeaningWords
    {
        public int IdBadMeaningWord { get; set; }
        public int IdGoodMeaningWord { get; set; }
        public string Meaning { get; set; }
    }
}
