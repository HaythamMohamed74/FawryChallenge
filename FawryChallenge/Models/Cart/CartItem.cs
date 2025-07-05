using FawryChallenge.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryChallenge.Models.Cart
{
    public class CartItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public double TotalPrice => Product.Price * Quantity;

        public CartItem(Product product, int quantity)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
            Quantity = quantity > 0 ? quantity : throw new ArgumentException("Quantity must be positive");
        }
    }
}

