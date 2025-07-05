using FawryChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryChallenge.Services
{
    public class ShippingService
    {
        private const decimal SHIPPING_FEE = 30.0m;

        public decimal CalculateShippingFee(List<IShippable> items)
        {
            if (items == null || items.Count == 0)
                return 0;

            return SHIPPING_FEE;
        }



        public void ProcessShipment(List<IShippable> items)
        {
            if (items == null || items.Count == 0) return;

            Console.WriteLine("** Shipment notice **");

            var grouped = items.GroupBy(i => i.GetName());

            foreach (var group in grouped)
            {
                string name = group.Key;
                int quantity = group.Count();
                //double unitWeight = group.First().GetWeight();
                double totalWeightKg = group.Sum(i => i.GetWeight());

                Console.WriteLine($"{quantity}x {name} {(int)(totalWeightKg * 1000)}g");
            }

            double totalWeight = items.Sum(i => i.GetWeight());
            Console.WriteLine($"Total package weight {totalWeight:F1}kg\n");
        }


    }
}
