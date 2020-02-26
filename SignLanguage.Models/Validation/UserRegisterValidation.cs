using FluentValidation;
using SignLanguage.Models.Extension;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.Models
{
    public class UserRegisterValidation : AbstractValidator<UserRegister>
    {
        public UserRegisterValidation()
        {
            RuleFor(x => x.Login).NotEmpty().WithMessage("Nie podano loginu");
            RuleFor(x => x.Login).MinimumLength(4).WithMessage("Login musi mieć przynajmniej 4 znaki");
            RuleFor(x => x.Login).MaximumLength(50).WithMessage("Login nie może być dłuższy niż 50 znaków");
            RuleFor(x => x.Password).Password();
            RuleFor(x => x.Email).NotEmpty().WithMessage("Nie podano emailu");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email jest nieprawidłowy");
            RuleFor(x => x.ConfirmEmail).Equal(x => x.Email).WithMessage("Nie potwierdziłeś emailu");
        }
        private bool BeAValidPostcode(string postcode)
        {
            // custom postcode validating logic goes here
            return false;
        }
    }
}
//https://docs.fluentvalidation.net/en/latest/custom-validators.html -> trza baze sprawdzic
//https://www.tutlane.com/tutorial/aspnet-mvc/fluent-validation-in-aspnet-mvc-with-example
//https://stackoverflow.com/questions/9367096/fluent-validation-custom-validation-rules
//https://www.jerriepelser.com/blog/using-fluent-validation-with-asp-net-mvc-part-4-database-validation/
