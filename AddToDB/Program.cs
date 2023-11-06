using Microsoft.EntityFrameworkCore;
using PizzaShop.DataAccess;
using PizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;


namespace PizzaShop
{
    class Program
    {
        static string[] RussianNames = new string[]
        {
            "Александр",
            "Мария",
            "Михаил",
            "Анна",
            "Артём",
            "София",
            "Иван",
            "Виктория",
            "Дмитрий",
            "Полина",
            "Максим",
            "Елизавета",
            "Андрей",
            "Анастасия",
            "Кирилл",
            "Ксения",
            "Сергей",
            "Валерия",
            "Николай",
            "Екатерина",
            "Павел",
            "Варвара",
            "Алексей",
            "Маргарита",
            "Денис",
            "Ольга",
            "Артур",
            "Юлия",
            "Егор",
            "Татьяна"
        };

        static string[] RussianSurnames = new string[]
        {
            "Иванов",
            "Смирнов",
            "Кузнецов",
            "Попов",
            "Соколов",
            "Лебедев",
            "Козлов",
            "Новиков",
            "Морозов",
            "Петров",
            "Волков",
            "Соловьев",
            "Васильев",
            "Зайцев",
            "Павлов",
            "Семенов",
            "Голубев",
            "Виноградов",
            "Богданов",
            "Воробьев",
            "Федоров",
            "Михайлов",
            "Беляев",
            "Тарасов",
            "Белов",
            "Комаров",
            "Орлов",
            "Киселев",
            "Макаров",
            "Андреев"
        };

        static string[] PhoneNumbers = new string[]
        {
            "1234567890",
            "2345678901",
            "3456789012",
            "4567890123",
            "5678901234",
            "6789012345",
            "7890123456",
            "8901234567",
            "9012345678",
            "0123456789",
            "2345678901",
            "3456789012",
            "4567890123",
            "5678901234",
            "6789012345",
            "7890123456",
            "8901234567",
            "9012345678",
            "0123456789",
            "2345678901",
            "3456789012",
            "4567890123",
            "5678901234",
            "6789012345",
            "7890123456",
            "8901234567",
            "9012345678",
            "0123456789",
            "2345678901",
            "3456789012"
        };

        static string[] Emails = new string[]
        {
            "example1@example.com",
            "example2@example.com",
            "example3@example.com",
            "example4@example.com",
            "example5@example.com",
            "example6@example.com",
            "example7@example.com",
            "example8@example.com",
            "example9@example.com",
            "example10@example.com",
            "example11@example.com",
            "example12@example.com",
            "example13@example.com",
            "example14@example.com",
            "example15@example.com",
            "example16@example.com",
            "example17@example.com",
            "example18@example.com",
            "example19@example.com",
            "example20@example.com",
            "example21@example.com",
            "example22@example.com",
            "example23@example.com",
            "example24@example.com",
            "example25@example.com",
            "example26@example.com",
            "example27@example.com",
            "example28@example.com",
            "example29@example.com",
            "example30@example.com"
        };

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static DateTime RandomDay()
        {
            Random random = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        public static void ClearAll()
        {
            using (var dbContext = new SqlConnector())
            {
                dbContext.Categories.RemoveRange(dbContext.Categories);
                dbContext.Customers.RemoveRange(dbContext.Customers);
                dbContext.Orders.RemoveRange(dbContext.Orders);
                dbContext.Products.RemoveRange(dbContext.Products);
                dbContext.OrderDetails.RemoveRange(dbContext.OrderDetails);
                dbContext.Carts.RemoveRange(dbContext.Carts);
                dbContext.Addresses.RemoveRange(dbContext.Addresses);
                dbContext.Roles.RemoveRange(dbContext.Roles);
                dbContext.Statuses.RemoveRange(dbContext.Statuses);

                dbContext.SaveChanges();
            }
        }





        static void Main(string[] args)
        {
            ClearAll();
            AddCategories();

            AddRolls();
            AddSets();

            AddStatuses();

            AddRoles();
            AddCustomers();

            Console.WriteLine("Выполнение закончено");
            Console.ReadLine();
        }

        public static void AddCategories()
        {
            string[] imageUrls = {
                "https://s3.smartofood.ru/rollme59_ru/menu/dfcf5a5a-227f-55fa-8218-9a06e7b05e4b.jpg",
    "https://s3.smartofood.ru/rollme59_ru/menu/25f6f65d-d417-5fc4-936a-8996c366e9ec.jpg",
    "https://s3.smartofood.ru/rollme59_ru/menu/5b61a4eb-4134-5bcb-80da-ebc058b9161e.jpg",
    "https://s3.smartofood.ru/rollme59_ru/menu/5eb331f5-d261-58cb-88b0-08034886d8a4.jpg",
    "https://s3.smartofood.ru/rollme59_ru/menu/ff84ee71-f6de-5d89-ada9-bb753a39d9fc.jpg",


};

            using SqlConnector context = new SqlConnector();

            string[] category123 = { "Роллы", "Сеты", "Запеченные роллы", "Горячие блюда",  "Напитки" };
            for (int i = 0; i < category123.Length; i++)
            {
                CategoryModel category = new CategoryModel();
                {
                    category.Name = category123[i];
                    
                    category.ImageUrl = imageUrls[i];
                    context.AddAsync(category);
                }
            }
            context.SaveChanges();
        }

        public static void AddRoles()
        {
            using SqlConnector context = new SqlConnector();


            RoleModel roleModel = new RoleModel();
            {
                roleModel.Role = "Покупатель";
            }
            context.Add(roleModel);

            RoleModel roleModel1 = new RoleModel();
            {
                roleModel1.Role = "Менеджер";
            }
            context.Add(roleModel1);

            context.SaveChanges();
        }

        public static void AddStatuses()
        {
            using SqlConnector context = new SqlConnector();

            Random random = new Random();

            string[] statuses = { "Оформлен", "Подтвержен", "Готовится", "В доставке", "Завершен", "Отменен" };
            for (int i = 0; i < statuses.Length; i++)
            {
                StatusModel status = new StatusModel();
                {
                    status.Status = statuses[i];    
                }
                context.Add(status);
            }
            context.SaveChanges();
        }

        public static void AddCustomers()
        {
            using SqlConnector context = new SqlConnector();

            for (int i = 0; i < 30; i++)
            {
                Random random = new Random();

                CustomerModel customer = new CustomerModel();
                {
                    customer.RoleId = context.Roles.Where(p => p.Role == "Покупатель").SingleOrDefault().Id;
                    customer.Phone = PhoneNumbers[i];
                    customer.Email = Emails[i];
                    customer.FirstName = RussianNames[i];
                    customer.LastName = RussianSurnames[i];
                }
                context.Add(customer);
            }
            context.SaveChanges();
        }

        public static void AddRolls()
        {
            string[] names = {
            "3 сыра",
            "Бонито",
            "Калифорния крабс",
            "Калифорния с креветкой",
            "Калифорния с лососем",
            "Красный эби",
            "Филадельфия карамельная",
            "Филадельфия хот (острый!)",
            "Унаги филадельфия",
        };

            int[] weights = {
    250,
    215,
    235,
    245,
    240,
    250,
    330,
    255,
    280
};
            string[] imageUrls = new string[]
        {
            "https://s3.smartofood.ru/rollme59_ru/menu/e74521d4-b037-5765-8065-4ef72d59ba1e.jpg",
            "https://s3.smartofood.ru/rollme59_ru/menu/e505b725-197a-50c7-9152-23bad265825c.jpg",
            "https://s3.smartofood.ru/rollme59_ru/menu/43696858-e00f-5aea-93db-d96408a59015.jpg",
            "https://s3.smartofood.ru/rollme59_ru/menu/e1658fa4-b420-5e0b-b374-7d746cdeca65.jpg",
            "https://s3.smartofood.ru/rollme59_ru/menu/bd403bef-089e-5d06-9c69-112e64d6632a.jpg",
            "https://s3.smartofood.ru/rollme59_ru/menu/ff582d9f-383d-5cd3-b642-3d750fd5ef4d.jpg",
            "https://s3.smartofood.ru/rollme59_ru/menu/b2e2f426-e976-5442-b615-0e33332dfa54.jpg",
            "https://s3.smartofood.ru/rollme59_ru/menu/cd977dd0-904c-5979-9e41-3e2bce2e40a4.jpg",
            "https://s3.smartofood.ru/rollme59_ru/menu/ccca721a-3786-5e1c-ab21-c70bca1e2e6c.jpg"
        };

            string[] descriptions = {
            "8шт., Рис Shinaki, сыр творожный, сыр чеддер, сыр пармезан, тамаго, майонез, нори",
            "8шт. - 215гр., 4шт. - 107гр., Рис Shinaki, лосось терияки, сыр творожный, огурец свежий, стружка тунца, нори",
            "8шт. - 235гр., 4шт. - 117гр., Рис Shinaki, снежный краб, огурец свежий, икра тобико, майонез, нори",
            "8шт. - 245гр., 4шт. - 122гр., Рис Shinaki, тигровая креветка су-вид, сыр творожный, огурец свежий, икра тобико, нори",
            "8шт. - 240гр., 4шт. - 120гр., Рис Shinaki, лосось охлажденный, сыр творожный, огурец свежий, икра тобико, нори",
            "8шт. - 250гр., 4шт. - 125гр., Рис Shinaki, сыр творожный, тигровая креветка су-вид, томаты, икра тобико, нори",
            "8шт. - 330гр., 4шт. - 165гр., Рис Shinaki, сыр творожный, авокадо, лосось запеченный, сахар тростниковый, нори",
            "8шт. - 255гр., 4шт. - 127гр., Рис Shinaki, сыр творожный, лосось охлажденый",
             "8шт. - 240гр., 4шт. - 120гр., Рис Shinaki, лосось охлажденный, сыр творожный, огурец свежий, икра тобико, нори",};
            using SqlConnector context = new SqlConnector();

            Random random = new Random();
            for (int i = 0; i < names.Length; i++)
            {
                ProductModel product = new ProductModel();
                {
                    product.Name = names[i];
                    product.WeightInGrams = weights[i];
                    product.Description = descriptions[i];

                    product.CurrentPrice = Convert.ToDecimal(random.Next(10000) / 100);
                    product.CategoryId = context.Categories.Where(p => p.Name == "Роллы").SingleOrDefault().Id ;
                    product.ImageUrl =imageUrls[i];
                }
                context.Add(product);
            }
            context.SaveChanges();
        }

        public static void AddSets()
        {
            string[] setNames = {
    "Сет №1",
    "Сет №2",
    "Сет №3",
    "Сет №4",
    "Сет №5",
    "Сет №6",
    "Сет №7",
    "Сет №8"
};

            string[] setDescriptions = {
    "32шт. (на двоих) в сете: Филадельфия с огурцом 4шт., Филадельфия хот 4шт., Маки с лососем 8шт., Маки с креветкой 8шт., Маки с огурцом 8шт.",
    "32шт. (на троих) в сете: Филадельфия классик 8шт., Филадельфия с огурцом 8шт., Филадельфия хот 8шт., Калифорния с лососем 8шт.",
    "48 шт. (на 4-5 человек) в сете: Филадельфия классик 8 шт., Филадельфия с огурцом 8 шт., Филадельфия хот 8 шт., Калифорния с лососем 8 шт., Калифорния с креветкой 8 шт., Калифорния крабс 8 шт.",
    "24шт. (на двоих) в сете: Чакин острый 8шт., Чакин с такуаном 8шт., Ролл 3 сыра 8шт.",
    "56шт. (на 4-5 человек) в сете: Маки с такуаном 8шт., Маки с томаго 8шт., Чакин острый 8шт., 3 сыра 8шт., Бонито 8шт., Калифорния крабс 8шт., Филадельфия с огурцом 8шт.",
    "56шт. (на двоих) в сете: Маки с такуаном 8шт., Маки с томаго 8шт., Маки с лососем 8шт., Маки с креветкой 8шт., Маки с огурцом 8шт., Маки с сыром 8шт., Маки с крабом 8шт.",
    "40шт. (на троих) в сете: Чакин острый 8шт., Чакин с такуаном 8шт., 3 сыра 8шт., Бонито 8шт., Морской 8шт.",
    "40шт. (на троих) в сете: Бруталити 8шт., Чука сливочный 8шт., Сливочный чикен 8шт., Маки тори 8шт., Классика жанра 8шт."
};

            int[] setWeights = {
    590,
    1035,
    1515,
    755,
    1450,
    775,
    1185,
    1225
};
            string[] imageUrls = {
    "https://s3.smartofood.ru/rollme59_ru/menu/4beb94be-5e40-5bec-bf35-4e2a178b40a6.jpg",
    "https://s3.smartofood.ru/rollme59_ru/menu/d4181bc2-6109-5130-8ade-c0be7d124b18.jpg",
    "https://s3.smartofood.ru/rollme59_ru/menu/af534d1e-3d58-5231-88f3-fb6546640933.jpg",
    "https://s3.smartofood.ru/rollme59_ru/menu/b86322cc-d78b-5c18-8102-f8938bb74802.jpg",
    "https://s3.smartofood.ru/rollme59_ru/menu/be6bcb43-8b65-551a-971c-7c405a6d2db7.jpg",
    "https://s3.smartofood.ru/rollme59_ru/menu/989d39f1-8657-5999-929f-dc9f882dea80.jpg",
    "https://s3.smartofood.ru/rollme59_ru/menu/2fead64b-6b6e-587e-83a8-f2939c08f079.jpg",
    "https://s3.smartofood.ru/rollme59_ru/menu/6d46fd1c-e598-5454-84de-d15abb6dd2fe.jpg"
};

            using SqlConnector context = new SqlConnector();

            Random random = new Random();

            for (int i = 0; i < setNames.Length; i++)
            {
                ProductModel product = new ProductModel();
                {
                    product.Name = setNames[i];
                    product.CurrentPrice = Convert.ToDecimal(random.Next(10000) / 100);
                    product.CategoryId = context.Categories.Where(p => p.Name == "Сеты").SingleOrDefault().Id;
                    product.ImageUrl = imageUrls[i];
                    product.Description = setDescriptions[i];
                    product.WeightInGrams = setWeights[i];
                }
                context.Add(product);
            }
            context.SaveChanges();
        }
    }
}
