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
        public RazorAppDbContext(DbContextOptions<RazorAppDbContext> options) : base(options) { }

        public DbSet<UserEvent> UserEvent { get; set; } = default!;
        public DbSet<ApplicationUser> ApplicationUser { get; set; } = default!;
        public DbSet<Friendship> Friendship { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure Friendship relationships
            builder.Entity<Friendship>()
                .HasOne(f => f.User)
                .WithMany(u => u.Friendships)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            builder.Entity<Friendship>()
                .HasOne(f => f.Friend)
                .WithMany(u => u.FriendOf)
                .HasForeignKey(f => f.FriendId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
