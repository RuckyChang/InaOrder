using System;

namespace InaMenu.Controllers.Menu
{
    public class MenuStatusNotDefinedException: Exception
    {
        public MenuStatusNotDefinedException(int status): base(status.ToString()+" is not a valid status.") { }
        public MenuStatusNotDefinedException(string message) : base(message) { }
    }
}
