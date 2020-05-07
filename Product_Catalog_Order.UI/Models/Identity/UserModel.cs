using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product_Catalog_Order.UI.Models.Identity
{
    public class UserModel
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }
    }
}