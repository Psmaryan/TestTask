using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class SentenceContext : DbContext
    {
        public SentenceContext()
            : base("SentenceContext")
        { }

        public DbSet<Sentence> Sentences { get; set; }
    }
}