using Microsoft.AspNetCore.Mvc;
using SignLanguage.EF.MetaData;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignLanguage.EF.Models
{
    [Table("LogException")]
    [ModelMetadataType(typeof(LogExceptionMetaData))]
    public class LogException 
    {
        public int LogExceptionId { get; set; }
        [Required]
        [StringLength(1)]
        [Column("ExceptionPath")]
        public string ExceptionPath { get; set; }
        public DateTime When { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
