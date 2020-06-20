using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignLanguage.EF;
using SignLanguage.Website.Areas.Administration.Models;
using SignLanguage.Website.Controllers;
using SignLanguage.Website.Models;

namespace SignLanguage.Website.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private UserManager<ApplicationUser> userManager { get; }
        private readonly UnitOfWork repository;

        public AdministrationController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager
            , UnitOfWork repository)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddGoodMeaningWord()
        {
            GoodMeaningWord goodMeaningWord = new GoodMeaningWord();

            return View(goodMeaningWord);
        }

        [HttpPost]
        public IActionResult AddGoodMeaningWord(GoodMeaningWord goodMeaningWord)
        {
            if (ModelState.IsValid)
            {
                GoodMeaningWords goodMeaningWords = new GoodMeaningWords();
                goodMeaningWords.Meaning = goodMeaningWord.WordName;
                goodMeaningWords.Url = goodMeaningWord.Url;

                repository.GoodMeaningWordsRepository.Add(goodMeaningWords);
                return View();
            }
            
            return View(goodMeaningWord);
        }

        [HttpGet]
        public ActionResult DeleteGoodMeaningWord()
        {
            var goodMeaningWords = repository.GoodMeaningWordsRepository.GetOverview().ToList();
            return View(goodMeaningWords);
        }

        [HttpPost]
        public ActionResult DeleteGoodMeaningWord(int SelectedGoodMeaningWord)
        {
            if (ModelState.IsValid)
            {
                var selected = repository.GoodMeaningWordsRepository
                    .GetOverview(x => x.IdGoodMeaningWord == SelectedGoodMeaningWord)
                    .FirstOrDefault();
                repository.GoodMeaningWordsRepository.Delete(selected);
                return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddBadMeaningWord()
        {
            var goodMeaningWords = repository.GoodMeaningWordsRepository.GetOverview().ToList();
            return View(goodMeaningWords);
        }

        [HttpPost]
        public ActionResult AddBadMeaningWord(string badMeaning, int SelectedGoodMeaningWord)
        {
            var BadMeaningWord = new BadMeaningWords
            {
                IdGoodMeaningWord = SelectedGoodMeaningWord,
                Meaning = badMeaning
            };

            repository.BadMeaningRepository.Add(BadMeaningWord);

            return View();
        }

        [HttpGet]
        public ActionResult DeleteBadMeaningWord()
        {
            var goodMeaningWords = repository.GoodMeaningWordsRepository.GetOverview().ToList();
            return View(goodMeaningWords);
        }

        [HttpPost]
        public ActionResult DeleteBadMeaningWord(int SelectedGoodMeaningWord)
        {
            var badMeaningWords = repository.BadMeaningRepository
                .GetOverview()
                .Where(x => x.IdGoodMeaningWord == SelectedGoodMeaningWord);


            foreach (var badMeaning in badMeaningWords)
            {
                repository.BadMeaningRepository.Delete(badMeaning);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationRole identityRole = new ApplicationRole
                {
                    Name = createRoleViewModel.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                SetMessageWarning("", result.Errors.SelectMany(v => v.Description).Select(me => me.ToString()));
                return View();
            }

            return View();
        }

        public async Task<IActionResult> AssingRole()
        {
            var roles = roleManager.Roles.ToList();

            roles.Where(x => x.Name == "Admin");
            var user = await userManager.GetUserAsync(User);
            await userManager.AddToRoleAsync(user, "Name of your role");
            return View();
        }

        /*[HttpPost]
        public async Task<IActionResult> AssingRole()
        {

        } */
        //Make edit/assing/delete role users
    }
}