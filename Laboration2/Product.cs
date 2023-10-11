using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration2
{
    internal class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; internal set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
            
        }


    }
}
