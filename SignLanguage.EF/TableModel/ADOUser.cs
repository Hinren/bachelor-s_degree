using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.EF
{
    public class ADOUser
    {
        public string IdUser { get; set; }
        public string Login { get; set; }
        public DateTime PasswordExpiredDate { get; set; }
        public int UserRole { get; set; } // na enuma pozniej
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Password { get; set; }
    }
}
