using InaMenu.Application;
using InaMenu.Controllers.Menu;
using InaMenu.Controllers.Menu.Package;
using InaMenu.Filters;
using InaMenu.MenuDomain;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [MenuStatusNotDefinedExcpetionFilter]
        [HttpPost]
        public async Task<CreateResponse> Post(CreateRequest req)
        {
            CreateMenu createMenu = new CreateMenu(_repo);

            if (!Enum.IsDefined(typeof(MenuStatus), req.status))
            {
                throw new MenuStatusNotDefinedException(req.status);
            }

            var id = await createMenu.Execute(
                name: req.name,
                products: ProductHelper.ConvertToDomainProduct(req.products),
                status: (MenuStatus)req.status
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
        [MenuStatusNotDefinedExcpetionFilter]
        [HttpPut("{id}")]
        public async Task<UpdateMenuResponse> Put(string id, UpdateMenuRequest req)
        {
            if (!Enum.IsDefined(typeof(MenuStatus), req.status))
            {
                throw new MenuStatusNotDefinedException(req.status);
            }

            UpdateMenu updateMenu = new UpdateMenu(_repo)
            {
                Name = req.name,
                Products = ProductHelper.ConvertToDomainProduct(req.products),
                Status = (MenuStatus)req.status
            };

            await updateMenu.Execute(id);

            return new UpdateMenuResponse();
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
