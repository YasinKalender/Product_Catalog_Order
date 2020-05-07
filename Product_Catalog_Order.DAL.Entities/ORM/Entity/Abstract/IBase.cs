using Product_Catalog_Order.DAL.Entities.ORM.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Order.DAL.Entities.ORM.Entity.Abstract
{
    public interface IBase
    {

        int ID { get; set; }
        DateTime AddDate { get; set; }

        DateTime? UpdateDate { get; set; }

        DateTime? DeleteDate { get; set; }

        Status Status { get; set; }
    }
}
