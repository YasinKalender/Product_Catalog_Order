using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product_Catalog_Order.UI.Identity.Context
{
    public class IdentityContext:IdentityDbContext<User>
    {

        public IdentityContext()
        {
            Database.Connection.ConnectionString = @"Server=(localdb)\MSSQLLocalDB; Database=Product_Catalog_Order; integrated security=true";
        }
    }
}