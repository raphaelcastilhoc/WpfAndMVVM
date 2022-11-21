using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using WpfAndMVVM.Models;

namespace WpfAndMVVM.Infrastructure
{
    public class GameDbConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> gameConfiguration)
        {
            gameConfiguration.ToTable("Games");

            gameConfiguration.HasKey(x => x.Id);
            gameConfiguration.Property(e => e.Id).ValueGeneratedOnAdd();

            gameConfiguration.Property<string>("Title").IsRequired();
            gameConfiguration.Property<GameGenre>("Genre").IsRequired();
            gameConfiguration.Property<DateTime>("ReleaseDate").IsRequired();
        }
    }
}