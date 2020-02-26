using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.Models.Extension
{
    public static class ValidationExtension
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength = 8)
        {
            var options = ruleBuilder
                .NotEmpty().WithMessage("Nie podano hasła")
                .MinimumLength(minimumLength).WithMessage("Hasło musi mieć conajmniej 8 znaków")
                .Matches("[A-Z]").WithMessage("Musi zawierać chociaż jedną dużą literę")
                .Matches("[a-z]").WithMessage("Musi zawierać chociaż jedną małą literę")
                .Matches("[0-9]").WithMessage("Musi zawierać chociaż jedną cyfrę")
                .Matches("[^a-zA-Z0-9]").WithMessage("Dorobić znaki specjalne");
            return options;
        }
    }
}
