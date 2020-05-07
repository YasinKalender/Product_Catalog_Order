using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Product_Catalog_Order.UI.Identity.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Product_Catalog_Order.UI.Identity.Data
{
    public class IdentityDataInitializer: DropCreateDatabaseIfModelChanges<IdentityContext>
    {

        protected override void Seed(IdentityContext context)
        {
            UserManager<User> userManager = new UserManager<User>(new UserStore<User>(context));
            RoleManager<Role> roleManager = new RoleManager<Role>(new RoleStore<Role>(context));

            if (!context.Roles.Any(i=>i.Name=="Admin"))
            {
                var role = new Role() { Name = "Admin", RoleDescription="Yönetici" };

                roleManager.Create(role);
            }

            if (!context.Roles.Any(i=>i.Name=="User"))
            {
                var role = new Role() { Name = "User", RoleDescription = "Kullanıcı" };

                roleManager.Create(role);
            }

            if (!context.Users.Any(i=>i.FirstName=="Yasin"))
            {
                var user = new User() { FirstName = "Yasin", LastName = "Kalender", Email = "ysn@gmail.com", UserName="Yasko"};

                userManager.Create(user, "1234567");

                userManager.AddToRole(user.Id, "Admin");
            }


            base.Seed(context);
        }
    }
}