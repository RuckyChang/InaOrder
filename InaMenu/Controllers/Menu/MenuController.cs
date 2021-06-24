using InaMenu.Application;
using InaMenu.Controllers.Menu.Package;
using InaMenu.MenuDomain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InaMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private MenuRepository _repo;

        public MenuController(MenuRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<MenuController>
        [HttpGet]
        public async Task<AllResponse> Get()
        {
            AllMenu allMenu = new AllMenu(_repo);

            List<MenuDomain.Menu> list = await allMenu.Execute();

            return new AllResponse()
            {
                menus = MenuHelper.ConvertToHttpPackageMenu(list)
            };
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public async Task<OfIdResponse> Get(string id)
        {
            MenuOfId menuOfId = new MenuOfId(_repo);

            MenuDomain.Menu menu = await menuOfId.Execute(id);

            return new OfIdResponse()
            {
                menu = MenuHelper.ConvertToHttpPackageMenu(menu)
            };
        }

        // POST api/<MenuController>
        [HttpPost]
        public async Task<CreateResponse> Post(CreateRequest req)
        {
            CreateMenu createMenu = new CreateMenu(_repo);

            Dictionary<string, MenuDomain.Product> products = new Dictionary<string, MenuDomain.Product>();

            foreach(var kvp in req.products)
            {
                var Price = kvp.Value.Price;

                products.Add(kvp.Key, new MenuDomain.Product(
                    id: kvp.Value.Id,
                    name: kvp.Value.Name,
                    price: new MenuDomain.Price(
                        currency: (Currency)Price.Currency,
                        quantity: Price.Quantity
                        )
                ));
            }

            var status = (Status)req.status;

            var id = await createMenu.Execute(
                name: req.name,
                products: products,
                status: status
                );

            var menuOfId = new MenuOfId(_repo);

            var menu = await menuOfId.Execute(id);

            return new CreateResponse()
            {
                menu = new Menu.Package.Menu()
                {
                    Id = id,
                    Name = menu.Name,
                    Products = ProductHelper.ConvertToHttpPackageProduct(menu.Products),
                    Status = (int)menu.Status
                }
            };
        }

       

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
