using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Razor_App.Models;

namespace Razor_App.Data
{
    public class RazorAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public RazorAppDbContext (DbContextOptions<RazorAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Razor_App.Models.UserEvent> UserEvent { get; set; } = default!;
        public DbSet<Razor_App.Models.ApplicationUser> ApplicationUser { get; set; } = default!;
    }
}
