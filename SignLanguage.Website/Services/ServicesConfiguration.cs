using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SignLanguage.EF;
using SignLanguage.EF.Models;
using SignLanguage.EF.Repository;
using SignLanguage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignLanguage.Website.Services
{
    public static class ServicesConfiguration
    {

        public static void AddCustomServicesDependencyInjection(this IServiceCollection services)
        {
            #region Repisotory
            services.AddScoped<UnitOfWork>();

            services.AddScoped<IRepository<GoodMeaningWords>, GoodMeaningWordsRepository>();
            services.AddScoped<IRepository<LogException>, LogExceptionRepository>();
            services.AddScoped<IRepository<BadMeaningWords>, BadMeaningWordsRepository>();
            services.AddScoped<IRepository<UsersScoreQuiz>, UsersScoreQuizRepository>();

            #endregion

            #region Validation fluent

            services.AddScoped<IValidator<UserRegister>, UserRegisterValidation>();

            #endregion
        }

    }
}
