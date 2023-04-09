using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Style;
using PizzaShop.DataAccess;
using PizzaShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ShopLibrary
{
    public class DataRepository : IDataConnection
    {
        public ProductModel GetProductById(int productId)
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Products.Where(c => c.Id == productId).FirstOrDefault();
            }
        }
        public ProductModel AddProduct(ProductModel product, CategoryModel category)
        {
            using (SqlConnector context = new SqlConnector())
            {
                CategoryModel currentCategory = context.Categories
                   .Where(c => c.Id == category.Id)
                   .FirstOrDefault();
                if (currentCategory!= null)
                {
                    product.Category = currentCategory;
                    context.Add(product);
                    context.SaveChanges();
                }

                return product;
            }
        }
        public ProductModel EditProduct(ProductModel product, CategoryModel newCategory)
        {
            using (SqlConnector context = new SqlConnector())
            {
                ProductModel currentProduct = context.Products
                   .Where(c => c.Id == product.Id)
                   .FirstOrDefault();

                if (currentProduct != null)
                {
                    CategoryModel currentCategory = context.Categories
                   .Where(c => c.Id == newCategory.Id)
                   .FirstOrDefault();
                    if (currentCategory != null)
                    {
                        currentProduct.CategoryId = currentCategory.Id;
                        currentProduct.Category = currentCategory;
                    }
                    currentProduct.Name = product.Name;
                    currentProduct.CurrentPrice = product.CurrentPrice;
                    context.SaveChanges();
                    return currentProduct;
                }
                else
                {
                    return AddProduct(product, product.Category);
                }
            }
        }
        public void DeleteProduct(ProductModel product)
        {
            using (SqlConnector context = new SqlConnector())
            {
                ProductModel CurrentProduct = context.Products
                   .Where(c => c.Id == product.Id)
                   .FirstOrDefault();

                if (CurrentProduct != null)
                {
                    context.Products.Remove(CurrentProduct);
                    context.SaveChanges();
                }
            }
        }

        public CustomerModel CreateCustomer(CustomerModel model)
        {
            using (SqlConnector context = new SqlConnector())
            {
                context.Add(model);
                context.SaveChanges();

                return model;
            }
        }
        public List<ProductModel> GetProducts_All()
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Products.Include(p => p.Category).ToList();
            }
        }
        public List<string> GetCustomersEmail_All()
        {
            using (SqlConnector context = new SqlConnector())
            {
                List<string> Emails = new List<string>();
                foreach (CustomerModel customer in context.Customers.ToList())
                {
                    Emails.Add(customer.Email);
                }
                return Emails;
            }
        }
        public List<CategoryModel> GetCategories_All()
        {
            using (SqlConnector context = new SqlConnector())
            {
                //return context.Categories.ToList();
                return context.Categories.Include(p => p.Products).ToList(); // Исправить обратно. Строка для ЛР 3
            }
        }
        public List<string> GetCategoryName()
        {
            using (SqlConnector context = new SqlConnector())
            {
                List<string> categoryNames = new List<string>();
                foreach (CategoryModel category in context.Categories.ToList())
                {
                    categoryNames.Add(category.Name);
                }
                return categoryNames;
            }
        }
        public List<ProductModel> GetProductsFromCategory(CategoryModel category)
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Products.Where(p => p.Category.Id == category.Id).ToList();
            }
        }
        public bool PasswordVerification(string email, string password)
        {
            bool verificationIsSuccess = false;
            using (SqlConnector context = new SqlConnector())
            {
                foreach (CustomerModel customer in context.Customers.ToList())
                {
                    if (customer.RoleId == role.Id && customer.Email == email && customer.HashPassword == HashingUtility.HashingPassword(password))
                        verificationIsSuccess = true;
                }
            }        //TODO - Исправить вывод - сейчас для тестов 
            return true;
        }
        public void AddCustomer(CustomerModel customer, RoleModel role, string password)
        {
            using (SqlConnector context = new SqlConnector())
            {
                RoleModel currentRole = context.Roles.Where(p => p.Id == role.Id).SingleOrDefault();
                if (currentRole != null)
                {
                    customer.Role = currentRole;
                    customer.RoleId = customer.Id;
                    customer.HashPassword = HashingUtility.HashingPassword(password);
                    context.Customers.Add(customer);
                    context.SaveChanges();
                }
            }
        }
        public void EditCustomer(CustomerModel customer)
        {
            using (SqlConnector context = new SqlConnector())
            {
                CustomerModel CurrentCustomer = context.Customers
                   .Where(c => c.Id == customer.Id)
                   .SingleOrDefault();

                if (CurrentCustomer != null)
                {
                    CurrentCustomer.FirstName = customer.FirstName;
                    CurrentCustomer.LastName = customer.LastName;
                    CurrentCustomer.Email = customer.Email;
                    CurrentCustomer.Phone = customer.Phone;
                    context.SaveChanges();
                }
            }
        }
        public void DeleteCustomer(CustomerModel customer)
        {
            using (SqlConnector context = new SqlConnector())
            {
                context.Customers.Remove(customer);
            }
        }
        public OrderModel AddOrder(CustomerModel customer, OrderModel order, AddressModel address)
        {
            using (SqlConnector context = new SqlConnector())
            {

                CustomerModel CurrentCustomer = context.Customers
                   .Where(c => c.Id == customer.Id)
                   .FirstOrDefault();

                AddressModel CurrentAddress = context.Addresses
                   .Where(c => c.Id == address.Id)
                   .FirstOrDefault();

                StatusModel CurrentStatus = context.Statuses
                   .Where(c => c.Id == order.StatusId)
                   .FirstOrDefault();

                order.Status = CurrentStatus;
                order.Address = CurrentAddress;
                order.Customer = CurrentCustomer;
                context.Orders.Add(order);
                context.SaveChanges();
                return order;
            }
        }
        public bool EmailIsUnique(string email)
        {
            bool emailIsUnique = true;
            using (SqlConnector context = new SqlConnector())
            {
                foreach (CustomerModel customer in context.Customers.ToList())
                {
                    if (customer.Email == email)
                        emailIsUnique = false;
                }
            }
            return emailIsUnique;
        }

        public CustomerModel GetByEmail(string email)
        {
            CustomerModel customerModel = new CustomerModel();
            using (SqlConnector context = new SqlConnector())
            {
                foreach (CustomerModel customer in context.Customers.ToList())
                {
                    if (customer.Email == email)
                    {
                        customerModel.Id = customer.Id;
                        customerModel.FirstName = customer.FirstName;
                        customerModel.LastName = customer.LastName;
                        customerModel.Email = customer.Email;
                        customerModel.Phone = customer.Phone;
                        customerModel.HashPassword = string.Empty;
                    }

                }
            }
            return customerModel;
        }

        public List<OrderModel> GetActiveOrdersByCustomer(CustomerModel customer)
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Orders.Where(p => p.CustomerId == customer.Id && p.Status.Id != 5 && p.Status.Id != 6)
                    .Include(p => p.Status)
                    .Include(p => p.Address)
                    .Include(p => p.OrderDetails)
                    .ToList();
            }
        }

        public List<OrderModel> GetCompletedOrdersByCustomer(CustomerModel customer)
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Orders
                    .Where(p => p.CustomerId == customer.Id && (p.Status.Id == 5 || p.Status.Id == 6))
                    .Include(p => p.Status)
                    .Include(p => p.Address)
                    .Include(p => p.OrderDetails).ToList();
            }
        }

        public void AddToCart(CustomerModel customer, ProductModel product)
        {
            List<CartsModel> carts = new List<CartsModel>();
            using (SqlConnector context = new SqlConnector())
            {
                carts = context.Carts.Where(p => p.Customer == customer && p.Product == product).ToList();

                if (carts.Count == 0)
                {

                    CustomerModel CurrentCustomer = context.Customers
                    .Where(c => c.Id == customer.Id)
                    .FirstOrDefault();

                    ProductModel CurrentProduct = context.Products
                    .Where(c => c.Id == product.Id)
                    .FirstOrDefault();


                    CartsModel cart1 = new CartsModel();
                    cart1.Customer = CurrentCustomer;
                    cart1.Product = CurrentProduct;

                    cart1.Quntity = 1;
                    context.Add(cart1);
                }
                else
                {
                    foreach (CartsModel cart in carts)
                    {
                        cart.Quntity++;
                    }
                }
                context.SaveChanges();
            }
        }

        public List<CartsModel> GetCartByCustomer(CustomerModel customer)
        {
            List<CartsModel> carts = new List<CartsModel>();
            using (SqlConnector context = new SqlConnector())
            {
                carts = context.Carts.Where(p => p.CustomerId == customer.Id).Include(p => p.Product).ToList();
            }
            return carts;
        }

        public void DeleteFromCart(CustomerModel customer, ProductModel product)
        {
            using (SqlConnector context = new SqlConnector())
            {
                var result = context.Carts.Single(p => p.CustomerId == customer.Id && p.ProductId == product.Id);
                if (result != null)
                {
                    context.Carts.Remove(result);
                    context.SaveChanges();
                }
            }
        }

        public void ReduceQuntityOfProductFromCart(CustomerModel customer, ProductModel product)
        {
            using (SqlConnector context = new SqlConnector())
            {
                var result = context.Carts.Single(p => p.CustomerId == customer.Id && p.ProductId == product.Id);
                if (result != null)
                {
                    result.Quntity--;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteAllCartsByCustomer(CustomerModel customer)
        {
            using (SqlConnector context = new SqlConnector())
            {
                var result = context.Carts.Where(p => p.CustomerId == customer.Id);
                if (result != null)
                {
                    context.Carts.RemoveRange(result);
                    context.SaveChanges();
                }
            }
        }

        public void AddOrderDetailsFromCarts(OrderModel order, ICollection<CartsModel> carts)
        {
            using (SqlConnector context = new SqlConnector())
            {
                OrderModel CurrentOrder = context.Orders
                    .Where(c => c.Id == order.Id)
                    .FirstOrDefault();

                foreach (var cart in carts)
                {
                    OrderDetailModel orderDetail = new OrderDetailModel();
                    orderDetail.PriceAtCheckout = cart.Product.CurrentPrice;
                    orderDetail.Order = CurrentOrder;
                    orderDetail.Quntity = cart.Quntity;

                    ProductModel CurrentProduct = context.Products.Where(c => c.Id == cart.ProductId).FirstOrDefault();
                    orderDetail.Product = CurrentProduct;

                    context.OrderDetails.Add(orderDetail);
                    context.SaveChanges();

                }

                //CurrentOrder.Price = carts.Sum(p => p.Price);
                context.SaveChanges();
            }
        }

        public void AddToCartFromSelectedOrderDetails(CustomerModel customer, ICollection<OrderDetailModel> orderDetailModels)
        {
            List<CartsModel> carts = new List<CartsModel>();
            using (SqlConnector context = new SqlConnector())
            {

                foreach (var orderDetail in orderDetailModels)
                {
                    carts = context.Carts.Where(p => p.Customer == customer && p.Product == orderDetail.Product).ToList();
                    if (carts.Count == 0)
                    {

                        CustomerModel CurrentCustomer = context.Customers
                        .Where(c => c.Id == customer.Id)
                        .FirstOrDefault();

                        ProductModel CurrentProduct = context.Products
                        .Where(c => c.Id == orderDetail.ProductId)
                        .FirstOrDefault();


                        CartsModel cart1 = new CartsModel();
                        cart1.Customer = CurrentCustomer;
                        cart1.Product = CurrentProduct;

                        cart1.Quntity = orderDetail.Quntity;
                        context.Add(cart1);
                    }
                    else
                    {
                        foreach (CartsModel cart in carts)
                        {
                            cart.Quntity += orderDetail.Quntity;
                        }
                    }
                }

                context.SaveChanges();
            }
        }

        public List<RoleModel> GetAllRoles()
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Roles.ToList();
            }
        }

        public List<OrderModel> GetOrders_All()
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Orders.ToList();
            }
        }

        public void DeleteCategory(CategoryModel category)
        {
            using (SqlConnector context = new SqlConnector())
            {
                var result = context.Categories.Single(p => p.Id == category.Id);
                if (result != null)
                {
                    context.Categories.Remove(result);
                    context.SaveChanges();
                }
            }
        }

        public CategoryModel AddCategory(CategoryModel category)
        {
            using (SqlConnector context = new SqlConnector())
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return category;
            }
        }

        public CategoryModel EditCategory(CategoryModel category)
        {
            using (SqlConnector context = new SqlConnector())
            {
                CategoryModel CurrentCategory = context.Categories
                   .Where(c => c.Id == category.Id)
                   .Include(c => c.Products)
                   .FirstOrDefault();

                if (CurrentCategory != null)
                {
                    CurrentCategory.Name = category.Name;
                    CurrentCategory.Image = category.Image;
                    context.SaveChanges();
                    return CurrentCategory;
                }
                else
                {
                    context.SaveChanges();
                    return AddCategory(category);
                }
            }
        }


        public CategoryModel GetCategoriesById(int categoryId)
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
            }
        }

        public List<OrderModel> GetActiveOrders_All()
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Orders.Where(p => p.Status.Id != 5 && p.Status.Id != 6)
                    .Include(p => p.Status)
                    .Include(p => p.OrderDetails)
                    .Include(p => p.Customer)
                    .Include(p => p.Address)
                    .ToList();
            }
        }

        public List<OrderModel> GetCompletedOrders()
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Orders.Where(p => p.Status.Id == 5)
                    .Include(p => p.Status)
                    .Include(p => p.OrderDetails)
                    .Include(p => p.Customer)
                    .Include(p => p.Address)
                    .ToList();
            }
        }

        public List<OrderModel> GetCancelledOrders()
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Orders.Where(p => p.Status.Id == 6)
                    .Include(p => p.Status)
                    .Include(p => p.OrderDetails)
                    .Include(p => p.Customer)
                    .Include(p => p.Address)
                    .ToList();
            }
        }

        public List<StatusModel> GetAllStatusWithoutCancell()
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Statuses.Where(p => p.Id != 6).ToList();
            }
        }

        public OrderModel ChangeStatus(OrderModel order, StatusModel status)
        {
            using (SqlConnector context = new SqlConnector())
            {
                OrderModel CurrentOrder = context.Orders
                   .Where(c => c.Id == order.Id)
                   .FirstOrDefault();

                StatusModel CurrentStatus = context.Statuses
                   .Where(c => c.Id == status.Id)
                   .FirstOrDefault();

                if (CurrentOrder != null && CurrentStatus != null)
                {
                    CurrentOrder.Status = CurrentStatus;
                    CurrentOrder.StatusId = CurrentStatus.Id;
                    if (CurrentOrder.StatusId == 5)
                    {
                        CurrentOrder.OrderFulfilled = DateTime.Now;
                    }
                    context.SaveChanges();
                    return CurrentOrder;
                }
                else
                {
                    return order;
                }
            }
        }

        public List<CustomerModel> GetCustomers_Managers()
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Customers.Where(p => p.Role.Id == 2).ToList();
            }

        }

        public List<CustomerModel> GetCustomers_Customers()
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Customers.Where(p => p.Role.Id == 1).ToList();
            }
        }

        public List<AddressModel> GetAddressesByCustomer(CustomerModel customer)
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Addresses.Where(p => p.CustomerId == customer.Id).ToList();
            }
        }

        public AddressModel AddAddressesByCustomer(AddressModel address, CustomerModel customer)
        {
            using (SqlConnector context = new SqlConnector())
            {
                CustomerModel CurrentCustomer = context.Customers
                        .Where(c => c.Id == customer.Id)
                        .FirstOrDefault();

                if (CurrentCustomer != null)
                {
                    address.Customer = CurrentCustomer;
                    address.CustomerId = CurrentCustomer.Id;
                    context.Add(address);
                    context.SaveChanges();
                }
                return address;
            }
        }

        public void DeleteAddress(AddressModel address)
        {
            using (SqlConnector context = new SqlConnector())
            {
                var result = context.Addresses.Single(p => p.Id == address.Id);
                if (result != null)
                {
                    context.Remove(result);
                    context.SaveChanges();
                }
            };
        }

        public AddressModel GetCurrentAddressByCustomer(CustomerModel customer)
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Addresses.Where(p => p.CustomerId == customer.Id && p.IsSelected == true).SingleOrDefault();
            }
        }

        public void ChangeCurrentAddressByCustomer(AddressModel oldCurrentAddress, AddressModel newCurrentAddress)
        {
            using (SqlConnector context = new SqlConnector())
            {
                AddressModel OldCurrentAddress = context.Addresses
                        .Where(c => c.Id == oldCurrentAddress.Id)
                        .FirstOrDefault();

                AddressModel NewCurrentAddress = context.Addresses
                        .Where(c => c.Id == newCurrentAddress.Id)
                        .FirstOrDefault();
                if (NewCurrentAddress != null && OldCurrentAddress != null)
                {
                    OldCurrentAddress.IsSelected = false;
                    NewCurrentAddress.IsSelected = true;
                    context.SaveChanges();
                }
            }
            
        }

        public List<OrderDetailModel> GetOrderDetails_ByOrder(OrderModel order)
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.OrderDetails.Where(p => p.OrderId == order.Id).Include(p => p.Product).ToList();
            }

        }

        public StatusModel GetCancellationStatus()
        {
            using (SqlConnector context = new SqlConnector())
            {
                return context.Statuses.Where(p => p.Id == 6).SingleOrDefault();
            }
        }
    }
}
