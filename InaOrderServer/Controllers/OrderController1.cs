using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InaOrderServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController1 : ControllerBase
    {
        // GET: api/<OrderController1>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController1>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
