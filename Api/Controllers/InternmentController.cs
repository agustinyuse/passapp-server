using Application.Features.Interment.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternmentController : ApiController
    {
        public InternmentController(ISender sender) : base(sender)
        {

        }

        // GET: api/<InternmentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<InternmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InternmentController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommand createCommand)
        {
            var result = await sender.Send(createCommand);

            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

        // PUT api/<InternmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InternmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
