using FawryChallenge.Interfaces;
using FawryChallenge.Models.Cart;
using FawryChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryChallenge.Services
{
    public class EcommerceSystem
    {
        private readonly ShippingService _shippingService;
        private readonly CheckoutService _validator;
        private readonly ReceiptPrinter _receiptPrinter;

        public EcommerceSystem()
        {
            _shippingService = new ShippingService();
            _validator = new CheckoutService();
            _receiptPrinter = new ReceiptPrinter();
        }

        public void Checkout(Customer customer, ShoppingCart cart)
        {
            try
            {
                var validationResult = _validator.ValidateCheckout(customer, cart);
                if (!validationResult.Success)
                {
                    Console.WriteLine($"Error: {validationResult.ErrorMessage}");
                    return;
                }

                //double subtotal = (decimal)cart.Subtotal;
                var shippingItems = CreateShippingItems(cart);
                double shippingFee = (double)_shippingService.CalculateShippingFee(shippingItems);
                double subtotal = cart.Subtotal;
                double totalAmount = subtotal + shippingFee;

                if (customer.Balance < totalAmount)
                {
                    Console.WriteLine("Error: Customer's balance is insufficient");
                    return;
                }

                if (shippingItems.Count > 0)
                {
                    _shippingService.ProcessShipment(shippingItems);
                }

                customer.DeductBalance(totalAmount);
                UpdateInventory(cart);

                _receiptPrinter.PrintReceipt(customer, cart, shippingFee, totalAmount);
                cart.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during checkout: {ex.Message}");
            }
        }

        private List<IShippable> CreateShippingItems(ShoppingCart cart)
        {
            var shippingItems = new List<IShippable>();

            foreach (var item in cart.Items)
            {
                if (item.Product.RequiresShipping)
                {
                    for (int i = 0; i < item.Quantity; i++)
                    {
                        shippingItems.Add(new ShippableItem(item.Product.Name, item.Product.Weight));
                    }
                }
            }

            return shippingItems;
        }

        private void UpdateInventory(ShoppingCart cart)
        {
            foreach (var item in cart.Items)
            {
                item.Product.ReduceQuantity(item.Quantity);
            }
        }
    }
}

