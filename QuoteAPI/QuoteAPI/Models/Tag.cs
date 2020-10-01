﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteAPI.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        [ForeignKey("Quote")]
        public int QuoteId { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
    }
}
