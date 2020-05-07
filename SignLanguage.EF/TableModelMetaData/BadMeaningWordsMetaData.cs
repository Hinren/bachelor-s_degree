using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SignLanguage.EF.MetaData
{
    class BadMeaningWordsMetaData
    {
        [Required]
        [Column("IdBadMeaningWord")]
        public int IdBadMeaningWord { get; set; }
        [Required]
        [Column("IdGoodMeaningWord")]
        public int IdGoodMeaningWord { get; set; }
        [Required]
        [StringLength(50)]
        [Column("Meaning")]
        public string Meaning { get; set; }
    }
}
