using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuoteAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuoteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuoteController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> GetQuote() 
        {
            return await _context.Quotes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> GetQuote(int id) 
        {
            var quote = await _context.Quotes.FindAsync(id);

            if (quote == null)
            {
                return NotFound();
            }

            return quote;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Tag>>> GetTag(int id)
        {
            return await _context.Tags.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Quote>> PostQuote(int quote, Quote value)
        {
            _context.Quotes.Add(value);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuote", new { quote = value.QuoteId }, quote);
        }

        [HttpDelete("{id?}")]
        public async Task<ActionResult<Quote>> DeleteQuote(int id) 
        {
            var quote = await _context.Quotes.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }

            _context.Quotes.Remove(quote);
            await _context.SaveChangesAsync();

            return quote;
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<IEnumerable<Tag>>> PostQuote(int id, [FromBody] IEnumerable<int> tagIds)
        {
            IList<TagQuote> quoteTags = new List<TagQuote>();
            foreach (var item in tagIds)
            {
                TagQuote newQuote = new TagQuote
                {
                    QuoteId = id,
                    TagId = item
                };
                quoteTags.Add(newQuote);
            }
            _context.TagQuote.AddRange(quoteTags);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTags", quoteTags);
        }
    }
}
