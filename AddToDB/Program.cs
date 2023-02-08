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

        static void Main(string[] args)
        {
            //AddRolls();
            //AddSushi();
            //AddBurgers();
            AddBut();
            //string[] category123 = { "Суши", "Роллы", "Бургеры", "Сеты", "Шаурма", "Салаты", "Напитки" };
            //for (int i = 0; i < category123.Length; i++)
            //{
            //    CategoryModel category = new CategoryModel();
            //    {
            //        category.Name = category123[i];
            //        Image image = Image.FromFile(@"C:\Users\User\Desktop\Shop\Категории\"+ category123[i].ToString() +".jpg");
            //        category.Image = ImageToByteArray(image);
            //        context.AddAsync(category);
            //    }
            //}



            //for (int i = 5; i < 8; i++)
            //{
            //    Product product = new Product(); { product.Id = i; }
            //    context.Products.Attach(product);
            //    context.Remove(product);
            //}

            //for (int i = 0; i < 5; i++)
            //{
            //    Customer customer = new Customer();
            //    {
            //        customer.FirstName = RandomString(random.Next(6));
            //        customer.Lastname = RandomString(random.Next(10));
            //    }
            //    context.Add(customer);
            //}

            //for (int i = 0; i < 5; i++)
            //{
            //    Order order = new Order();
            //    {
            //        order.OrderFulfilled = RandomDay();
            //        order.OrderPlaced = RandomDay();
            //        order.CustomerId = 2;
            //    }
            //    context.Add(order);
            //}

            //var products = from product in context.Products
            //               where product.Id < 13
            //               orderby product.Price
            //               select product;

            //var products = context.Products
            //    .Where(p => p.Id < 13)
            //    .OrderBy(p => p.Price);

            //foreach (Product product in products)
            //{
            //    Console.WriteLine(product.Id);
            //    Console.WriteLine(product.Name);
            //    Console.WriteLine(product.Price);
            //    Console.WriteLine();
            //}

            //List<int> productsId = new List<int>(); //получение уникальный Id продуктов
            //foreach (Product product in context.Products)
            //{
            //    productsId.Add(product.Id);
            //}
            //var uniqueItemsProductsId = productsId.Distinct().ToList();

            //List<int> orderId = new List<int>(); //получение уникальный Id ордеров
            //foreach (Order order in context.Orders)
            //{
            //    orderId.Add(order.Id);
            //}
            //var uniqueItemsOrderId = orderId.Distinct().ToList();


            //for (int i = 0; i < 150; i++) //добавление рандомных ОрдерДетейлс через листы Id продуктов и ордеров
            //{
            //    OrderDetail orderDetail = new OrderDetail();
            //    orderDetail.Quntity = random.Next(200);
            //    orderDetail.ProductId = uniqueItemsProductsId.ToArray()[random.Next(uniqueItemsProductsId.Count)];
            //    orderDetail.OrderId = uniqueItemsOrderId.ToArray()[random.Next(uniqueItemsOrderId.Count)];
            //    context.Add(orderDetail);
            //}

            //context.OrderDetails.Distinct();

            Console.WriteLine("Выполнение закончено");
            Console.ReadLine();
        }
        public static void AddRolls()
        {
            using SqlConnector context = new SqlConnector();

            Random random = new Random();

            string[] rolls = { "Калифорния", "Филадельфия", "Бостон", "Темпура", "Цезарь", "Канада", "Сальмон" };
            for (int i = 0; i < rolls.Length; i++)
            {
                ProductModel product = new ProductModel();
                {
                    product.Name = $"{rolls[i]} ролл";
                    product.СurrentPrice = Convert.ToDecimal(random.Next(10000) / 100);
                    product.CategoryId = 3;
                    Image image = Image.FromFile(@"C:\Users\User\Desktop\Shop\Роллы\" + rolls[i].ToString() + ".jpg");
                    product.Image = ImageToByteArray(image);
                }
                context.Add(product);
            }
            context.SaveChanges();
        }
        public static void AddBut()
        {
            using SqlConnector context = new SqlConnector();

            Random random = new Random();

            ProductModel product = new ProductModel();
            {
                product.Name = "Бабочка";
                product.СurrentPrice = Convert.ToDecimal(random.Next(10000) / 100);
                product.CategoryId = 4;
                Image image = Image.FromFile(@"C:\Users\User\Desktop\Shop\Категории\" + "Бабочка" + ".jpg");
                product.Image = ImageToByteArray(image);
            }
            context.Add(product);
            context.SaveChanges();
        }
        public static void AddBurgers()
        {
            using SqlConnector context = new SqlConnector();

            Random random = new Random();

            string[] burgers = { "Фишбургер", "Крабсбургер", "Чизбургер", "Чикенбургер", "Черный бургер", "Классический бургер", "Гамбургер" };
            for (int i = 0; i < burgers.Length; i++)
            {
                ProductModel product = new ProductModel();
                {
                    product.Name = burgers[i];
                    product.СurrentPrice = Convert.ToDecimal(random.Next(10000) / 100);
                    product.CategoryId = 4;
                    Image image = Image.FromFile(@"C:\Users\User\Desktop\Shop\Бургеры\" + burgers[i].ToString() + ".jpg");
                    product.Image = ImageToByteArray(image);
                }
                context.Add(product);
            }
            context.SaveChanges();
        }
        public static void AddSushi()
        {
            using SqlConnector context = new SqlConnector();

            Random random = new Random();

            string[] sushi = { "с угрем", "с лососем", "с тунцом", "с креветкой", "с гребешком"};
            for (int i = 0; i < sushi.Length; i++)
            {
                ProductModel product = new ProductModel();
                {
                    product.Name = $"Суши {sushi[i]}";
                    product.СurrentPrice = Convert.ToDecimal(random.Next(10000) / 100);
                    product.CategoryId = 2;
                    Image image = Image.FromFile(@"C:\Users\User\Desktop\Shop\Суши\" + sushi[i].ToString() + ".jpg");
                    product.Image = ImageToByteArray(image);
                }
                context.Add(product);
            }
            context.SaveChanges();
        }
    }
}
