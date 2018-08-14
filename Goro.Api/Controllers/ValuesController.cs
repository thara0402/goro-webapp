using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goro.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Goro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly GourmetRepository _repository;

        public ValuesController(GourmetRepository repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            await GourmetClient.Search(1,1);

            //var result = await _repository.GetAllAsync();
            // foreach (var g in result)
            // {
            //     await _repository.DeleteAsync(g);
            // }

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
