using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Retete.Models;

namespace Retete.Data
{
    public class ReteteContext : DbContext
    {
        public ReteteContext (DbContextOptions<ReteteContext> options)
            : base(options)
        {
        }

        public DbSet<Retete.Models.Member> Member { get; set; } = default!;

        public DbSet<Retete.Models.Category>? Category { get; set; }

        public DbSet<Retete.Models.Recipe>? Recipe { get; set; }
    }
}
