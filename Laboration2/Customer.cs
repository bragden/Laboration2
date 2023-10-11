using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration2
{
    internal class Customer
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public List<Product> Cart { get; }

        public Customer(string name, string password)
        {
            Name = name;
            Password = password;
            Cart = new List<Product>();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <Cart.Count; i++)
            {
                sb.AppendLine($"{Cart[i].Name} {Cart[i].Price}");
            }
            sb.AppendLine($"Total price: {Cart.Sum(p => p.Price)}");
            return sb.ToString();
        }




    }
}
