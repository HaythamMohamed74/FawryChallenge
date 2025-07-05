using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryChallenge.Models.Products
{
    public class ExpirableProduct : Product
    {
        private readonly DateTime _expirationDate;
        public ExpirableProduct(string name, double price, int quantity, DateTime expirationDate,
                            bool requiresShipping, double weight)
          : base(name, price, quantity, requiresShipping, weight)
        {
            _expirationDate = expirationDate;
        }

        public override bool IsExpired()
        {
         return DateTime.Now > _expirationDate;
        }
    }
}
