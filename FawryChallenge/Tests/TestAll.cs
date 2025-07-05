using FawryChallenge.Models.Cart;
using FawryChallenge.Models.Products;
using FawryChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryChallenge.Tests
{
    public class TestAll
    {
        public static void RunTests()
        {
            Console.WriteLine("***All Functional TESTS***\n");
           
            var products = CreateTestProducts();
            var customer = new Customer("Haytham Mohamed", 2000);
            var ecommerce = new Services.EcommerceSystem();

            TestNormalCheckout(products, customer, ecommerce);
            TestEmptyCart(customer, ecommerce);
            TestInsufficientBalance(products, customer, ecommerce);
            TestOutOfStock(products, ecommerce);
            TestExpiredProduct(ecommerce);
            //TestDigitalOnlyItems(products, customer, ecommerce);

            Console.WriteLine("=== Task Completed ===");
        }

        private static Dictionary<string, Product> CreateTestProducts()
        {
            return new Dictionary<string, Product>
            {
                ["cheese"] = new ExpirableProduct("Cheese", 100, 10, DateTime.Now.AddDays(7), true, 0.2),
                ["biscuits"] = new ExpirableProduct("Biscuits", 150, 5, DateTime.Now.AddDays(30), true, 0.7),
                ["tv"] = new NonExpireProduct("TV", 500, 3, true, 15.0),
                ["mobile"] = new NonExpireProduct("Mobile", 800, 2, true, 0.3),
                ["scratchCard"] = new NonExpireProduct("Mobile Scratch Card", 50, 20, false, 0.0)
            };
        }

        private static void TestNormalCheckout(Dictionary<string, Product> products, Customer customer, Services.EcommerceSystem ecommerce)
        {
            Console.WriteLine("TEST 1: Normal checkout");
            var cart = new ShoppingCart();
            cart.AddProduct(products["cheese"], 2);
            cart.AddProduct(products["biscuits"], 1);
            //cart.AddProduct(products["scratchCard"], 1);
            ecommerce.Checkout(customer, cart);
        }

        private static void TestEmptyCart(Customer customer, Services.EcommerceSystem ecommerce)
        {
            Console.WriteLine("TEST 2: Empty cart");
            var cart = new ShoppingCart();
            ecommerce.Checkout(customer, cart);
        }

        private static void TestInsufficientBalance(Dictionary<string, Product> products, Customer customer, Services.EcommerceSystem ecommerce)
        {
            Console.WriteLine("TEST 3: Insufficient balance");
            var cart = new ShoppingCart();
            cart.AddProduct(products["tv"], 3);
            ecommerce.Checkout(customer, cart);
        }

        private static void TestOutOfStock(Dictionary<string, Product> products, Services.EcommerceSystem ecommerce)
        {
            Console.WriteLine("TEST 4: Out of stock");
            try
            {
                var cart = new ShoppingCart();
                cart.AddProduct(products["cheese"], 20);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void TestExpiredProduct(Services.EcommerceSystem ecommerce)
        {
            Console.WriteLine("TEST 5: Expired product");
            var expiredProduct = new ExpirableProduct("Expired Cheese", 100, 5, DateTime.Now.AddDays(-1), true, 0.2);
            var cart = new ShoppingCart();
            cart.AddProduct(expiredProduct, 1);
            ecommerce.Checkout(new Customer("Test", 500), cart);
        }

        //private static void TestDigitalOnlyItems(Dictionary<string, Product> products, Customer customer, Services.EcommerceSystem ecommerce)
        //{
        //    Console.WriteLine("TEST 6: Digital items only");
        //    var cart = new ShoppingCart();
        //    cart.AddProduct(products["scratchCard"], 3);
        //    ecommerce.Checkout(customer, cart);
        //}
    }
}

