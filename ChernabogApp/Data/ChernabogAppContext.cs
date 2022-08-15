using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChernabogApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ChernabogApp.Data
{
    public class ChernabogAppContext : IdentityDbContext<IdentityUser>
    {
        public ChernabogAppContext (DbContextOptions<ChernabogAppContext> options)
            : base(options)
        {
        }

        public DbSet<ChernabogApp.Models.Spell> Spell { get; set; } = default!;

        public DbSet<ChernabogApp.Models.Monster>? Monster { get; set; }

        public DbSet<ChernabogApp.Models.MonsterCategory>? MonsterCategory { get; set; }

    }
}
