using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaMenu.Controllers.Menu.Package
{
    public class Price
    {
        public int Currency { get; set; }
        public Double Quantity { get; set; }

        public Price(int currency, Double quantity)
        {
            Currency = currency;
            Quantity = quantity;
        }
    }
}
