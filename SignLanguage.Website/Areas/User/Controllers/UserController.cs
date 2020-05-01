using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignLanguage.EF;
using SignLanguage.Logic;
using SignLanguage.Models;
using SignLanguage.Website.Controllers;
using System;
using System.Linq;

namespace SignLanguage.Website.Areas.User.Controllers
{
    //TODO  actuaaly i have static model to rember user in system, but is not good solve
    //i need change this to get user more discreetly later read more about authentication and change this
    [Area("User")]
    public class UserController : BaseController
    {
        private readonly SignLanguageContex databaseContext;

        public UserController(SignLanguageContex databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            UserLogin userLogin = new UserLogin();
            return View(userLogin);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(UserLogin userLogin)
        {
            var userData = databaseContext.Users.Where(x => x.Login == userLogin.Login && x.Password == userLogin.Password).FirstOrDefault();
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            UserRegister userRegister = new UserRegister();
            return View(userRegister);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(UserRegister viewUserRegister)
        {
            if (ModelState.IsValid)
            {
                CryptographyProcessor cryptographyProcessor = new CryptographyProcessor();
                var hashedPassword = cryptographyProcessor.GenerateHash(viewUserRegister.Password);

                ADOUser userDatabase = new ADOUser();
                userDatabase.Email = viewUserRegister.Email;
                userDatabase.Login = viewUserRegister.Login;
                userDatabase.Password = hashedPassword;
                userDatabase.IdUser = Guid.NewGuid().ToString("N");
                userDatabase.PasswordExpiredDate = DateTime.Now.AddMonths(2);
                userDatabase.UserRole = 1;
                userDatabase.EmailConfirmed = true;
                databaseContext.Users.Add(userDatabase);
                databaseContext.SaveChanges();
                //RegisterUser.CreateNewAccount(userRegister);
                return View();
            }
            else
            {
                SetMessageWarning("", ModelState.Values.SelectMany(v => v.Errors).Where(me => me != null).Select(me => me.ErrorMessage));
                return View();
            }
        }
    }
}