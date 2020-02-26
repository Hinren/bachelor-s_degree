using ServiceStack.FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SignLanguage.Models
{
    [Validator(typeof(UserRegisterValidation))]
    public class UserRegister
    {
        [DisplayName("Login")]
        public string Login { get; set; }
        [DisplayName("Hasło")]
        public string Password { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Potwierdź email")]
        public string ConfirmEmail { get; set; }
    }
}
