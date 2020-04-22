using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignLanguage.Website.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserId { get; set; }
    }
}
