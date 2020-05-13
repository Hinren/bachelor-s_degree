using System;

namespace SignLanguage.EF.Models
{
    public class LogException 
    {
        public int LogExceptionId { get; set; }
        public string ExceptionPath { get; set; }
        public DateTime When { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
