using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuoteAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuoteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        // GET api/<QuoteController>
        // get random quote
        [HttpGet]
        public ActionResult<Quote> Get() { }
        // POST api/<QuoteController>
        // insert new quote (without tags)
        [HttpPost]
        public ActionResult<Quote> Insert([FromBody] Quote value) { }
        // GET api/<QuoteController/5>
        // get quote with id 5
        [HttpGet("{id}")]
        public ActionResult<Quote> Get(int id) { }
        // DELETE api/<QuoteController>/5
        // delete quote with id 5
        [HttpDelete("{id?}")]
        public ActionResult<Quote> Delete(int id) { }
        // POST api/<QuoteController/5/tags>
        // link new tags with quote 5
        [HttpPost("{id}/tags")]
        public ActionResult<IEnumerable<Tag>> Insert(int id, [FromBody] IEnumerable<int> tagIds) { }
        // GET api/<QuoteController/5/tags>
        // get linked tags with quote 5
        [HttpGet("{id}/tags")]
        public ActionResult<IEnumerable<Tag>> GetTags(int id) { }
    }
}
