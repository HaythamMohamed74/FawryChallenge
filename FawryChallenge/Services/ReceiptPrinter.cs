using FawryChallenge.Models.Cart;
using FawryChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryChallenge.Services
{
    public class ReceiptPrinter
    {
       

        public void PrintReceipt(Customer customer, ShoppingCart cart, double shippingFee, double totalAmount)
        {
            Console.WriteLine("** Checkout receipt **");

            foreach (var item in cart.Items)
            {
                int quantity = item.Quantity;
                string name = item.Product.Name;
                int totalPrice = (int)item.Product.Price * quantity;
                Console.WriteLine($"{quantity}x {name} {totalPrice}");
            }

            Console.WriteLine("----------------------");

           
            Console.WriteLine("{0,-10} {1}", "Subtotal", (int)cart.Subtotal);
            Console.WriteLine("{0,-10} {1}", "Shipping", (int)shippingFee);
            Console.WriteLine("{0,-10} {1}", "Amount", (int)totalAmount);
        }
    }
}


