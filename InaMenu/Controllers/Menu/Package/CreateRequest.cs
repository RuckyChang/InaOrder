using System.Collections.Generic;

namespace InaMenu.Controllers.Menu.Package
{
    public class CreateRequest
    {
        public string name { get; set; }
        public List<Product> products { get; set; }
        public int status { get; set; }
    }
}
