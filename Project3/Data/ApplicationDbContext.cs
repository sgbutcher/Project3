using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project3.Models;

namespace Project3.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Project3.Models.Bedaprogram> Bedaprogram { get; set; }

        public DbSet<Project3.Models.Advisor> Advisor { get; set; }

        public DbSet<Project3.Models.Goal> Goal { get; set; }

        public DbSet<Project3.Models.Location> Location { get; set; }

        public DbSet<Project3.Models.Note> Note { get; set; }

        public DbSet<Project3.Models.Student> Student { get; set; }
    }
}
