using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SignLanguage.EF.Models
{
    [Table("ActivityOnWebsite")]
    public class ActivityOnWebsite
    {
        [Column("ActivityOnWebsiteId")]
        public int ActivityOnWebsiteId { get; set; }
        [Column("Controller")]
        public string Controller { get; set; }
        [Column("Action")]
        public string ActionName { get; set; }
        [Column("httpTypeAction")]
        public string httpTypeAction { get; set; }
        [Column("Userid")]
        public string Userid { get; set; }
        [Column("When")]
        public DateTime When { get; set; }
    }
}
