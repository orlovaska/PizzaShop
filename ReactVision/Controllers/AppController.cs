using Microsoft.AspNetCore.Mvc;
using PizzaShop.DataAccess;
using PizzaShop.Models;
using ShopLibrary;
using System.Collections.Generic;

namespace ReactVision.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppController : ControllerBase
    {
        private IDataConnection dataRepository;
        public AppController()
        {
            dataRepository = new DataRepository();
        }

        [HttpGet]
        [Route("getWeather")]
        public IEnumerable<string> GetWeather()
        {
            string[] arrayOfStrings = new string[]
{
        "Привет",
        "Мир",
        "Это",
        "Пример",
        "Массива",
        "Строк"
};

            return arrayOfStrings;
        }

        // Метод для добавления пользователя
        [HttpGet]
        [Route("editUser")]
        public void editUser(
 int userId, 
 string firstName,
  string lastName,
  string email,
  string phone)
        {
            dataRepository.EditUser(userId, firstName, lastName, email, phone);
        }

        // Метод для добавления пользователя
        [HttpGet]
        [Route("addCustomer")]
        public IActionResult addCustomer(
 string firstName,
  string lastName,
  string email,
  string phone,
  string password)
        {
            RoleModel customerRole = dataRepository.GetCustomerRole();
            dataRepository.AddCustomer(firstName, lastName, email, phone, password, customerRole.Id);
            return Ok();
        }

        // Метод для получения всех категорий
        [HttpGet]
        [Route("getAllCategories")]
        public IEnumerable<object> GetAllCategories()
        {
            var categories = dataRepository.GetCategories_All()
    .Select(category => new
    {
        id = category.Id,
        name = category.Name,
        imageUrl = category.ImageUrl,
    });
            //IEnumerable<CategoryModel> categories = dataRepository.GetCategories_All();
            return categories;
        }

        // Метод для добавления адреса пользователю
        [HttpGet]
        [Route("addAddressByCustomer")]
        public object AddAddressByCustomer(int customerId, string address)
        {
            AddressModel addedAddres = dataRepository.AddAddress(customerId, address);
            var anonymousAddedAddres = new
            {
                id = addedAddres.Id,
                address = addedAddres.Address,
                customerId = addedAddres.CustomerId,
            };
            return anonymousAddedAddres;
        }

        // Метод для добавления деталей заказа из корзины
        [HttpGet]
        [Route("addNewOrderFromCarts")]
        public IActionResult AddNewOrderFromCarts(int customerId, int addressId, string comment)
        {
            int newOrderId = dataRepository.AddNewOrder(customerId, addressId, comment).Id;
            dataRepository.AddOrderDetailsFromCarts(newOrderId);
            dataRepository.DeleteAllCartsByCustomer(customerId);
            return Ok();
        }

        // Метод для получения всех продуктов
        [HttpGet]
        [Route("getAllProducts")]
        public IEnumerable<object> GetAllProducts(bool hs)
        {
            var products = dataRepository.GetProducts_All()
.Select(product => new
{
id = product.Id,
name = product.Name,
imageUrl = product.ImageUrl,
description = product.Description,
categoryId = product.CategoryId,
currentPrice = product.CurrentPrice,
weightInGrams = product.WeightInGrams,
});
            //IEnumerable<CategoryModel> categories = dataRepository.GetCategories_All();
            return products;
        }

        // Метод для увеличения количества продукта в корзине
        [HttpGet]
        [Route("increaseQuantityOfProductInCart")]
        public void IncreaseQuantityOfProductInCart(int userId, int productId)
        {
            dataRepository.AddToCart(userId, productId);
            //return Ok();
        }

        // Метод для уменьшения количества продукта в корзине
        [HttpGet]
        [Route("reduceQuntityOfProductInCart")]
        public IActionResult ReduceQuntityOfProductInCart(int userId, int productId)
        {
            dataRepository.ReduceQuntityOfProductFromCart(userId, productId);
            return Ok();
        }

        // Метод для удаления продукта из корзины
        [HttpGet]
        [Route("deleteProductFromCart")]
        public IActionResult DeleteProductFromCart(int userId, int productId)
        {
            dataRepository.DeleteFromCart(userId, productId);
            return Ok();
        }

        // Метод для проверки уникальности email
        [HttpGet]
        [Route("emailIsUnique")]
        public bool EmailIsUnique(string email)
        {
            bool result = dataRepository.EmailIsUnique(email);    
            return result;
        }

        // Метод для проверки подлинности пароля
        [HttpGet]
        [Route("passwordVerification")]
        public bool PasswordVerification(string email, string password)
        {
            bool result = dataRepository.PasswordVerification(email, password);
            return result;
        }

        // Метод для получения корзины пользователя по ID
        [HttpGet]
        [Route("getUsersCart")]
        public IEnumerable<object> GetUsersCart(int userId)
        {
            IEnumerable<CartsModel> carts = dataRepository.GetCartByCustomer(userId);

            var anonymousCarts = carts.Select(cartsModel => new
            {
                id = cartsModel.Id,
                quntity = cartsModel.Quntity,
                productId = cartsModel.ProductId,
                product = new
                {
                    id = cartsModel.Product.Id,
                    name = cartsModel.Product.Name,
                    currentPrice = cartsModel.Product.CurrentPrice,
                    imageUrl = cartsModel.Product.ImageUrl,
                    description = cartsModel.Product.Description,
                    weightInGrams = cartsModel.Product.WeightInGrams,
                    categoryId = cartsModel.Product.CategoryId
                },
                price = (decimal)cartsModel.Quntity * cartsModel.Product.CurrentPrice
            }).ToList();
            return anonymousCarts;
        }

        // Метод для получения пользователя по email
        [HttpGet]
        [Route("getUserByEmail")]
        public object GetUserByEmail(string email)
        {
            CustomerModel customer = dataRepository.GetByEmail(email);
            var anonymousUser = new
            {
                id = customer.Id,
                firstName = customer.FirstName,
                lastName = customer.LastName,
                phone = customer.Phone,
                email = customer.Email
            };
            return anonymousUser;
        }
    }
}