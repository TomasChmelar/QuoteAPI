using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteAPI.Models
{
    public class TagQuote
    {
        public ICollection<Quote> Quotes { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
