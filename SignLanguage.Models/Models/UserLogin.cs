using System;
using System.ComponentModel;

namespace SignLanguage.Models
{
    public class UserLogin
    {
        [DisplayName("Login")]
        public string Login { get; set; }
        [DisplayName("Hasło")]
        public string Password { get; set; }
    }
}
