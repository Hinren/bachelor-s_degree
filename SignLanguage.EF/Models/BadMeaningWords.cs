using Microsoft.AspNetCore.Mvc;
using SignLanguage.EF.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SignLanguage.EF
{
    [Table("BadMeaningWords")]
    public class BadMeaningWords
    {
        public int IdBadMeaningWord { get; set; }
        public int IdGoodMeaningWord { get; set; }
        public string Meaning { get; set; }
    }
}
