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
            modelBuilder.Entity<Game>().HasData(GetGames());
            base.OnModelCreating(modelBuilder);
        }

        private List<Game> GetGames()
        {
            return new List<Game>
            {
                new Game("Diablo", GameGenre.RPG, DateTime.Now, 1),
                new Game("Tony Hawk", GameGenre.Sport, DateTime.Now, 2),
                new Game("COD", GameGenre.Action, DateTime.Now, 3)
            };
        }
    }
}
