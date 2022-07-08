using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BoardGameDB.Models;

namespace BoardGameDB.Data
{
    public class BoardGameDBContext : DbContext
    {
        public BoardGameDBContext(DbContextOptions<BoardGameDBContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Game { get; set; } = null!;
        public DbSet<GameType> GameType { get; set; } = null!;
        public DbSet<Mechanic> Mechanic { get; set; } = null!;
        public DbSet<PlayStyle> PlayStyle { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Game>()
                .HasMany(g => g.Mechanics)
                .WithMany(m => m.Games);
            
            builder.Entity<Game>()
                .HasMany(g => g.GameTypes)
                .WithMany(gt => gt.Games);

            builder.Entity<Game>()
                .HasMany(g => g.PlayStyles)
                .WithMany(ps => ps.Games);

            base.OnModelCreating(builder);
        }
    }
}