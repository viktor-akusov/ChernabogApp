using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChernabogApp.Models;

namespace ChernabogApp.Data
{
    public class ChernabogAppContext : DbContext
    {
        public ChernabogAppContext (DbContextOptions<ChernabogAppContext> options)
            : base(options)
        {
        }

        public DbSet<ChernabogApp.Models.Spell> Spell { get; set; } = default!;

    }
}
