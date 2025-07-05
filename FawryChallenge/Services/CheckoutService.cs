using FawryChallenge.Models.Cart;
using FawryChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryChallenge.Services
{
    public class CheckoutService
    {
        public Checkout ValidateCheckout(Customer customer, ShoppingCart cart)
        {
            var result = new Checkout();

            if (cart.IsEmpty)
            {
                result.ErrorMessage = "Cart is empty";
                return result;
            }

            foreach (var item in cart.Items)
            {
                if (item.Product.IsExpired())
                {
                    result.ErrorMessage = $"{item.Product.Name} is expired";
                    return result;
                }

                if (!item.Product.IsInStock(item.Quantity))
                {
                    result.ErrorMessage = $"{item.Product.Name} is out of stock";
                    return result;
                }
            }

            result.Success = true;
            return result;
        }
    }
}
