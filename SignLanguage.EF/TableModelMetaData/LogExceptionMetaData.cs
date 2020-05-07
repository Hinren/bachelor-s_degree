using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SignLanguage.EF.MetaData
{
    public class LogExceptionMetaData
    {
        [Required]
        [Column("LogExceptionId")]
        public int LogExceptionId { get; set; }
        [Required]
        [StringLength(100)]
        [Column("ExceptionPath")]
        public string ExceptionPath { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column("When")]
        public DateTime When { get; set; }
        [Required]
        [Column("ExceptionMessage")]
        public string ExceptionMessage { get; set; }
    }
}
