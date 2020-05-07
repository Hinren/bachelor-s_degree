using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SignLanguage.EF.TableModelMetaData
{
    [Table("UsersScoreQuiz")]
    public class UsersScoreQuizMetaData
    {
        [Required]
        [Column("Id")]
        
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        [Column("IdUser")]
        public string IdUser { get; set; }
        [Required]
        [Column("HowManyQustion")]
        public int HowManyQustion { get; set; }
        [Required]
        [Column("EffectivenessInPercent")]
        public decimal EffectivenessInPercent { get; set; }
    }
}
