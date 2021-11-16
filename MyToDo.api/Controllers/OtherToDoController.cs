using Microsoft.AspNetCore.Mvc;
using MyToDo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyToDo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherToDoController : ControllerBase
    {
        private readonly IToDoService _otherService;

        public OtherToDoController(IToDoService otherToDo)
        {

        }

        // GET: api/<OtherToDoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OtherToDoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OtherToDoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OtherToDoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OtherToDoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
