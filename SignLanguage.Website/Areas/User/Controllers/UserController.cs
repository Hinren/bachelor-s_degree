using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignLanguage.ADO;
using SignLanguage.Logic;
using SignLanguage.Models;
using SignLanguage.Models.Models;
using SignLanguage.Website.Controllers;
using System.Linq;

namespace SignLanguage.Website.Areas.User.Controllers
{
    //TODO  actuaaly i have static model to rember user in system, but is not good solve
    //i need change this to get user more discreetly later read more about authentication and change this
    [Area("User")]
    public class UserController : BaseController
    {
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
            //TODO Make more safety this part of program. Is not good practise, but actually i need user in controller
            using (var contex = new SignlanguageDatabaseContext())
            {
                var userData = contex.Users.Where(x => x.Login == userLogin.Login && x.Password == userLogin.Password).FirstOrDefault();
                StaticUser.IdUser = userData.IdUser;
                StaticUser.UserRole = userData.UserRole;
                StaticUser.Email = userData.Email;
            }
            return RedirectToAction("Learn", "Learning", new { area = "Learning" });
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
        public ActionResult Register(UserRegister userRegister)
        {
            if (ModelState.IsValid)
            {
                RegisterUser.CreateNewAccount(userRegister);
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