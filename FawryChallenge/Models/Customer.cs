using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryChallenge.Models
{
    public class Customer
    {
        public string Name { get; private set; }
        public double Balance { get; private set; }

        public Customer(string name, double balance)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Balance = balance >= 0 ? balance : throw new ArgumentException("Balance cannot be negative");
        }

        public void DeductBalance(double amount)
        {
            if (amount < 0) throw new ArgumentException("Amount cannot be negative");
            if (amount > Balance) throw new InvalidOperationException("Insufficient balance");
            Balance -= amount;
        }
    }
}

