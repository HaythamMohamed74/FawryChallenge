using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryChallenge.Models
{
    public class Checkout
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public double Subtotal { get; set; }
        public double ShippingFee { get; set; }
        public double TotalAmount { get; set; }
    }
}
