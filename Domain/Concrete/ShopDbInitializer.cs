using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Entities;

namespace Domain.Concrete
{
    public class ShopDbInitializer : DropCreateDatabaseAlways<EFDbContext>
    //public class ShopDbInitializer : CreateDatabaseIfNotExists<EFDbContext>
    {
        protected override void Seed(EFDbContext db)
        {
            #region Categories

            List<Category> categories = new List<Category>
            {
                new Category {Name = "Перчатки", PathPart = "Gloves"},
                new Category {Name = "Варежки", PathPart = "Mittens"},
                new Category {Name = "Шарфы", PathPart = "Scarves"},
                new Category {Name = "Шапки", PathPart = "Hats"},
                new Category {Name = "Носки", PathPart = "Socks"}
            };
            categories.ForEach(c => db.Categories.Add(c));
            db.SaveChanges();

            #endregion

            #region Products

            db.Products.Add(new Product
            {
                Name = "Красный шарф из альпаки",
                About = "Связан тройной косичкой",
                Category = categories.First(x => x.PathPart == "Scarves"),
                BasePrice = 1800M,
                IsSale = true,
                Quantity = 1,
                SalePercent = 10
            });

            db.Products.Add(new Product
            {
                Name = "Жесткие варежки для -40°",
                About = "Связан двойной косичкой",
                Category = categories.First(x => x.PathPart == "Mittens"),
                BasePrice = 1000M,
                IsSale = false,
                Quantity = 10,
                SalePercent = 0
            });

            db.Products.Add(new Product
            {
                Name = "Шапочка с бамбошкой для даунов",
                About = "Связан одинарной косичкой",
                Category = categories.First(x => x.PathPart == "Hats"),
                BasePrice = 3200M,
                IsSale = true,
                Quantity = 8,
                SalePercent = 45
            });

            db.Products.Add(new Product
            {
                Name = "Мужские перчатки casual",
                About = "Повседневный стиль",
                Category = categories.First(x => x.PathPart == "Gloves"),
                BasePrice = 2400M,
                IsSale = true,
                Quantity = 3,
                SalePercent = 10
            });

            db.Products.Add(new Product
            {
                Name = "Домашние гетры",
                About = "Для нее в холодные дни",
                Category = categories.First(x => x.PathPart == "Socks"),
                BasePrice = 2400M,
                IsSale = true,
                Quantity = 2,
                SalePercent = 25
            });

            db.SaveChanges();

            #endregion

            //UserID ненастоящие

            #region Orders

            var p1 = db.Products.Find(1);
            var p2 = db.Products.Find(2);
            var p3 = db.Products.Find(3);


            if (p1 != null && p2 != null && p3 != null)
            {
                List<Order> orders = new List<Order>()
                {
                    new Order()
                    {
                        SessionID = Guid.NewGuid().ToString(),
                        Product = p1,
                        Quantity = 1,
                        CostPerItem = p1.CurrentPrice,
                        UserID = Guid.NewGuid().ToString()
                    },
                    new Order()
                    {
                        SessionID = Guid.NewGuid().ToString(),
                        Product = p2,
                        Quantity = 1,
                        CostPerItem = p2.CurrentPrice,
                        UserID = Guid.NewGuid().ToString()
                    },
                    new Order()
                    {
                        SessionID = Guid.NewGuid().ToString(),
                        Product = p3,
                        Quantity = 1,
                        CostPerItem = p3.CurrentPrice,
                        UserID = Guid.NewGuid().ToString()
                    }
                };
                orders.ForEach(x => db.Orders.Add(x));
            }


            db.SaveChanges();

            #endregion
        }
    }
}