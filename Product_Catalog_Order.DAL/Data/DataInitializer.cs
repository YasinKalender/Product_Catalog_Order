using Product_Catalog_Order.DAL.Context;
using Product_Catalog_Order.DAL.Entities.ORM.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Catalog_Order.DAL.Data
{
    public class DataInitializer: DropCreateDatabaseIfModelChanges<ProjectContext>
    {
        protected override void Seed(ProjectContext context)
        {

            List<Category> categories = new List<Category>()
            {

                new Category(){CategoryName="Kamera",Description="Kamera Ürünleri"},
                new Category(){CategoryName="Bilgisayar",Description="Bilgisayar Ürünleri"},
                new Category(){CategoryName="Elektirik",Description="Elektirik Ürünleri"},
                new Category(){CategoryName="Beyaz Eşya",Description="Beyaz Eşya Ürünleri"},



            };

            foreach (var item in categories)
            {
                context.Categories.Add(item);
            }

            List<Product> products = new List<Product>()
            {
                new Product(){ProductName="QROMAX PRO 2042S 4 Lü 5 Megapiksel Sony Lens 1080P Aptina Sensör Güvenlik Kamerası Seti",Description="QROMAX PRO 2042S 4 Lü 5 Megapiksel Sony Lens 1080P Aptina Sensör Güvenlik Kamerası Seti",Price=989,Stock=100,CategoryID=1,Image="1.jpg"},
                new Product(){ProductName="Promise 7 Kameralı Set Gece Görüşlü Harddisk Ve Monitör Dahil Paket Sistem",Description="Promise 7 Kameralı Set Gece Görüşlü Harddisk Ve Monitör Dahil Paket Sistem",Price=1000,Stock=500,CategoryID=1,Image="2.jpg"},
                new Product(){ProductName="QROMAX PRO 4142 5' li 5 Megapiksel SONY LENS 1080P Aptina Sensör Metal Kasa Güvenlik Kamerası Seti",Description="QROMAX PRO 4142 5' li 5 Megapiksel SONY LENS 1080P Aptina Sensör Metal Kasa Güvenlik Kamerası Seti",Price=2000,Stock=100,CategoryID=1,Image="3.jpg"},


                new Product(){ProductName="HP 15-DA1083NT CORE İ5 8265U 1.6GHZ-8GB-256GB SSD-15.6-MX130 4GB-W10 NOTEBOOK",Description="HP 15-DA1083NT CORE İ5 8265U 1.6GHZ-8GB-256GB SSD-15.6-MX130 4GB-W10 NOTEBOOK",Price=5000,Stock=100,CategoryID=2,Image="4.jpg"},
                new Product(){ProductName="HUAWEI MEDIAPAD T3 10 MSM8917 QUAD CORE-1.3GHZ-2GB-16GB-BT-9.6'-CAM- AND.7.0",Description="HUAWEI MEDIAPAD T3 10 MSM8917 QUAD CORE-1.3GHZ-2GB-16GB-BT-9.6'-CAM- AND.7.0",Price=1000,Stock=100,CategoryID=2,Image="5.jpg"},
                new Product(){ProductName="HUAWEI MEDIAPAD T3 10 MSM8917 QUAD CORE-1.3GHZ-2GB-16GB-BT-9.6'-CAM- AND.7.0",Description="HUAWEI MEDIAPAD T3 10 MSM8917 QUAD CORE-1.3GHZ-2GB-16GB-BT-9.6'-CAM- AND.7.0",Price=1000,Stock=100,CategoryID=2,Image="6.jpg"},

                 new Product(){ProductName="Osram 8,5W Led Ampül E27 Duy - 6500K Beyaz",Description="Osram 8,5W Led Ampül E27 Duy - 6500K Beyaz",Price=10,Stock=1000,CategoryID=3,Image="7.jpg"},
                new Product(){ProductName="5 Adet Philips CorePro 9W / 60W Led Ampul E27 Duy - 6500K Beyaz-806 Lümen",Description="5 Adet Philips CorePro 9W / 60W Led Ampul E27 Duy - 6500K Beyaz-806 Lümen",Price=50,Stock=1000,CategoryID=3,Image="8.jpg"},
                new Product(){ProductName="ANTEN UYDU RECEIVER NEXT 2053 HD IPTV",Description="ANTEN UYDU RECEIVER NEXT 2053 HD IPTV",Price=400,Stock=1000,CategoryID=3,Image="9.jpg"},

                 new Product(){ProductName="Vestel PUZZLE NF655 EX Vakum Buzdolabı",Description="Vestel PUZZLE NF655 EX Vakum Buzdolabı",Price=2000,Stock=1000,CategoryID=4,Image="10.jpg"},
                 new Product(){ProductName="Vestel PUZZLE NF655 EKX WIFI Buzdolabı",Description="Vestel PUZZLE NF655 EX Vakum Buzdolabı",Price=3000,Stock=1000,CategoryID=4,Image="11.jpg"},
                 new Product(){ProductName="Vestel NFK540 ECV A++ ION Buzdolabı",Description="Vestel NFK540 ECV A++ ION Buzdolabı",Price=7000,Stock=2000,CategoryID=4,Image="12.jpg"},






            };

            foreach (var item in products)
            {
                context.Products.Add(item);
            }

            context.SaveChanges();


            base.Seed(context);
        }


    }
}
