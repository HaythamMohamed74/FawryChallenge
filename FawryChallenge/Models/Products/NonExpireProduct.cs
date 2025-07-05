using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryChallenge.Models.Products
{
    public class NonExpireProduct : Product
    {
        public NonExpireProduct(string name, double price, int quantity, bool requiresShipping, double weight)
           : base(name, price, quantity, requiresShipping, weight)
        {

        }
        public override bool IsExpired()
        {
           return false; 
        }
    }
}
