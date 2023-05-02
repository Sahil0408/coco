using coco.Models;
using Microsoft.EntityFrameworkCore;
using School.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace School.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Loginmodal> LoginTableModels { get; set; }
        public DbSet<Detailmodal> Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loginmodal>().ToTable("UserLogin");
            modelBuilder.Entity<Detailmodal>().ToTable("UserRegistration");

        }

    }
}