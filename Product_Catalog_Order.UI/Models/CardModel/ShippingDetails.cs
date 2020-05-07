using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Product_Catalog_Order.UI.Models.CardModel
{
    public class ShippingDetails
    {
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please Correct Enter Adress")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Please Correct Enter City")]

        public string City { get; set; }

        [Required(ErrorMessage = "Please Correct Enter Region")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Please Correct Enter PostaCode")]
        public string PostaCode { get; set; }
    }
}