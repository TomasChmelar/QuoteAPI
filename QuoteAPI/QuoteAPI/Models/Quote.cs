using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuoteAPI.Models
{
    public class Quote
    {
        [Key]
        public int QuoteId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        [NotMapped]
        public ICollection<TagQuote> TagQuotes { get; set; }
    }
}
