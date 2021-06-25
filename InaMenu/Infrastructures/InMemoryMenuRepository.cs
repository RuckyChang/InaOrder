using InaMenu.MenuDomain;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
namespace InaMenu.Infrastructures
{
    public class InMemoryMenuRepository : MenuRepository
    {
        private ILogger<MenuRepository> _logger;
        private Dictionary<string, Menu> _storage = new Dictionary<string, Menu>();

        public InMemoryMenuRepository(ILogger<MenuRepository> logger ){
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                if (!Directory.Exists("./Data")){
                    _logger.LogInformation("./Data dir not exists. Create one.");
                    Directory.CreateDirectory("./Data");
                }

                if (File.Exists("./Data/Menu.json"))
                {
                    string contentString = File.ReadAllText("./Data/Menu.json");
                    _logger.LogInformation("read from ./Data/Menu.json.");
                    Dictionary<string, Menu> storage = JsonConvert.DeserializeObject<Dictionary<string, Menu>>(contentString);
                    if (storage != null)
                    {
                        _storage = storage;
                    }
                } 
            });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                _logger.LogInformation("save to ./Data/Menu.json.");
                string contentString = JsonConvert.SerializeObject(_storage, new JsonSerializerSettings() { Formatting = Formatting.Indented });
                File.WriteAllText("./Data/Menu.json", contentString);
            });
        }

        public Task<List<Menu>> All()
        {
            List<Menu> list = new List<Menu>();

            foreach(var data in _storage.Values)
            {
                list.Add(data);
            }

            return Task.FromResult(list);
        }

        public Task<Menu> OfId(string id)
        {
            if (_storage.ContainsKey(id))
            {
                return Task.FromResult(_storage[id]);
            }

            return Task.FromResult<Menu>(null);
        }

        public Task<string> Save(Menu menu)
        {
            if (_storage.ContainsKey(menu.Id))
            {
                _storage[menu.Id] = menu;
                return Task.FromResult(menu.Id);
            }

            _storage.Add(menu.Id, menu);

            return Task.FromResult(menu.Id);
        }
    }
}
