using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryChallenge.Models.Products
{
    public abstract class Product
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }
        public bool RequiresShipping { get; private set; }
        public double Weight { get; private set; }

        protected Product(string name, double price, int quantity, bool requiresShipping, double weight)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            RequiresShipping = requiresShipping;
            Weight = weight;
        }

        public abstract bool IsExpired();

        public bool IsInStock(int requestedQuantity) => Quantity >= requestedQuantity;

        public void ReduceQuantity(int amount)
        {
            if (amount > Quantity)
                throw new InvalidOperationException("Cannot reduce quantity below zero");
            Quantity -= amount;
        }
    }

}

