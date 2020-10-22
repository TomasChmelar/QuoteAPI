using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteAPI.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<TagQuote> TagQuote { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tag>().HasData(new Tag { TagId = 1, Name = "Ze Života", Category = Category.Author }) ;
            modelBuilder.Entity<Tag>().HasData(new Tag { TagId = 2, Name = "Na pováženou", Category = Category.Author });
            modelBuilder.Entity<Quote>().HasData(new Quote { QuoteId = 1, Text = "Tak dlouho se chodí se džbánem pro vodu, až se ucho utrhne", Date= new DateTime(2000, 1, 1, 7, 21, 52)});
            modelBuilder.Entity<Quote>().HasData(new Quote { QuoteId = 2, Text = "Proč chodit ven, když je zima", Date = new DateTime(1985, 1, 2, 6, 2, 20)});

            modelBuilder.Entity<TagQuote>()
            .HasOne(g => g.Quote)
            .WithMany(u => u.TagQuotes)
            .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TagQuote>()
                .HasOne(g => g.Tag)
                .WithMany(u => u.TagQuotes)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TagQuote>().HasKey(tq => new { tq.QuoteId, tq.TagId });

        }

    }
}
