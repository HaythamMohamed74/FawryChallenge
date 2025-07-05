using FawryChallenge.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryChallenge.Models.Cart
{
    public class ShoppingCart
    {
        private readonly List<CartItem> _items = new List<CartItem>();

        public IReadOnlyList<CartItem> Items => _items.AsReadOnly();
        public bool IsEmpty => _items.Count == 0;
        public double Subtotal => _items.Sum(item => item.TotalPrice);

        public void AddProduct(Product product, int quantity)
        {
            ValidateAddProduct(product, quantity);

            var existingItem = _items.FirstOrDefault(item => item.Product.Name == product.Name);
            if (existingItem != null)
            {
                _items.Remove(existingItem);
                quantity += existingItem.Quantity;
            }

            _items.Add(new CartItem(product, quantity));
        }

        public void Clear() => _items.Clear();

        private void ValidateAddProduct(Product product, int quantity)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (quantity <= 0) throw new ArgumentException("Quantity must be positive");
            if (!product.IsInStock(quantity))
                throw new InvalidOperationException($"Insufficient stock for {product.Name}");
        }
    }
}
