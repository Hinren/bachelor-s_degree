using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SignLanguage.EF.Models
{
    [Table("ActivityOnWebsite")]
    public class ActivityOnWebsite
    {
        public int ActivityOnWebsiteId { get; set; }
        public string Controller { get; set; }
        [Column("Action")]
        public string ActionName { get; set; }
        public string httpTypeAction { get; set; }
        public string Userid { get; set; }
    }
}
