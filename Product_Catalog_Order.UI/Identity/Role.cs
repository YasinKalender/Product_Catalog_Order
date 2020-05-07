using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product_Catalog_Order.UI.Identity
{
    public class Role:IdentityRole
    {
        public string RoleDescription { get; set; }
        public Role()
        {

        }

        public Role(string rolename,string roledescription)
        {
            this.Name = rolename;
            this.RoleDescription = roledescription;
        }
    }
}