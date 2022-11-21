using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WpfAndMVVM.Models;

namespace WpfAndMVVM.Infrastructure
{
    public class GamingDbContext : DbContext
    {
        public GamingDbContext(DbContextOptions<GamingDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameDbConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
