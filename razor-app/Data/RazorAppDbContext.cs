using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Razor_App.Models;

namespace Razor_App.Data
{
    public class RazorAppDbContext : DbContext
    {
        public RazorAppDbContext (DbContextOptions<RazorAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Razor_App.Models.UserEvent> UserEvent { get; set; } = default!;
    }
}
