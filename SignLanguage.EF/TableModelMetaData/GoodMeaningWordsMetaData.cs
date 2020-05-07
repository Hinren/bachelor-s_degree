using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SignLanguage.EF.TableModelMetaData
{
    [Table("GoodMeaningWords")]
    public class GoodMeaningWordsMetaData
    {
        [Required]
        [Column("IdGoodMeaningWord")]
        public int IdGoodMeaningWord { get; set; }
        [Required]
        [StringLength(50)]
        [Column("Meaning")]
        public string Meaning { get; set; }
        [Required]
        [StringLength(300)]
        [Column("Url")]
        public string Url { get; set; }
    }
}
