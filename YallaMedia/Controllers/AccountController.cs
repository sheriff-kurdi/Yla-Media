using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YallaMedia.ViewModels;

namespace YallaMedia.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly SignInManager<IdentityUser> sigInManger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(SignInManager<IdentityUser> sigInManger, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.sigInManger = sigInManger;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult AddEditor()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddEditor(RegisterViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                // 1 : Copy Data from RegisterViewModel to IdentityUser
                IdentityUser user = new IdentityUser
                {
                    UserName = userModel.Email,
                    Email = userModel.Email,
                };
                // 2 : store user in DB :UserManager class
                var result = await userManager.CreateAsync(user, userModel.Password);
                //3 : Process ? Successed or Fail
                if (result.Succeeded)
                {

                    IdentityRole role = new IdentityRole()
                    {
                        Name = "Editor"
                    };

                    // if role did not exist create it
                    if(! await roleManager.RoleExistsAsync("Editor"))
                    {
                        IdentityResult roleResult = await roleManager.CreateAsync(role);
                        if (roleResult.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, "Editor");
                        }

                    }
                    //of role exists
                    // add to role
                    await userManager.AddToRoleAsync(user, "Editor");

                    await sigInManger.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");

                }
                // 4 : in case of any error in registerations
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(userModel);
        }

  

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailExist(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null) return Json(true);
            else return Json($"The Email {email} is Already in Use");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}