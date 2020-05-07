using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SignLanguage.EF.Models
{
    [Table("LogException")]
    public class LogException
    {
        public int LogExceptionId { get; set; }
        public string ExceptionPath { get; set; }
        public DateTime When { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
