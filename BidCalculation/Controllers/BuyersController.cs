using Microsoft.AspNetCore.Mvc;

namespace BidCalculation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BuyersController : ControllerBase
    {
        // GET: api/<BuyersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return ["value1", "value2"];
        }

        // GET api/<BuyersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BuyersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BuyersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BuyersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
