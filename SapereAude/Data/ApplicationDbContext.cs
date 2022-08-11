using Microsoft.EntityFrameworkCore;
using SapereAude.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapereAude.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Suggestion> Suggestions { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
