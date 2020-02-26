using SignLanguage.ADO;
using SignLanguage.Models;
using System;

namespace SignLanguage.Logic
{
    public  class RegisterUser
    {
        //Hash password and add salt
        public static void CreateNewAccount(UserRegister userRegister)
        {
            var context = new SignlanguageDatabaseContext();
            Users createNewuser = new Users();
            createNewuser.Email = userRegister.Email;
            createNewuser.EmailConfirmed = true;
            createNewuser.IdUser = Guid.NewGuid().ToString("N");
            createNewuser.Login = userRegister.Login;
            createNewuser.Password = userRegister.Password;
            createNewuser.PasswordExpiredDate = DateTime.Now.AddMonths(6);
            createNewuser.UserRole = 1;
            context.Users.Add(createNewuser);
            context.SaveChanges();
        }
    }
}
