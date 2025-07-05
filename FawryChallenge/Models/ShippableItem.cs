using FawryChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryChallenge.Models
{
    public class ShippableItem : IShippable
    {
        private readonly string _name;
        private readonly double _weight;

        public ShippableItem(string name, double weight)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _weight = weight >= 0 ? weight : throw new ArgumentException("Weight cannot be negative");
        }

        public string GetName() => _name;
        public double GetWeight() => _weight;
    }
}
