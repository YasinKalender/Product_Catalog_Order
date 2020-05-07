using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product_Catalog_Order.UI.Identity
{
    public class User:IdentityUser
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }


    }
}