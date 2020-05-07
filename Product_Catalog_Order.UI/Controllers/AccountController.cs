using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Product_Catalog_Order.UI.Identity;
using Product_Catalog_Order.UI.Identity.Context;
using Product_Catalog_Order.UI.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product_Catalog_Order.UI.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        UserManager<User> userManager = new UserManager<User>(new UserStore<User>(new IdentityContext()));
        RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentityContext()));

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel users)
        {
            User user = new User();

            user.FirstName = users.FirstName;
            user.LastName = users.LastName;
            user.UserName = users.Username;
            user.Email = users.Mail;

            IdentityResult result = userManager.Create(user, users.Password);

            if (result.Succeeded)
            {
                if (roleManager.RoleExists("User"))
                {
                    userManager.AddToRole(user.Id, "User");
                    
                    return RedirectToAction("Index", "Home");
                }
            }


            return View(users);
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Login(Login login, string ReturnUrl)
        {

            var user = userManager.Find(login.Username, login.Password);

            if (user != null)
            {
                var userauthentication = HttpContext.GetOwinContext().Authentication;

                var useridentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                var userprop = new AuthenticationProperties()
                {
                    IsPersistent = false

                };

                userauthentication.SignOut();
                userauthentication.SignIn(userprop, useridentity);

                if (!string.IsNullOrEmpty(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                return RedirectToAction("Index", "Home");

            }

            return View();
        }

        public ActionResult Logout()
        {
            var user = HttpContext.GetOwinContext().Authentication;

            user.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}