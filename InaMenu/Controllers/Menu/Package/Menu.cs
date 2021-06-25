using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InaMenu.Controllers.Menu.Package
{
    public class Menu
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public int Status { get; set; }
    }
}
