using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;
using AdPlayTest_Pias.Data;

namespace AdPlayTest_Pias.Models
{
    public class ChinookDbContext : DbContext
    {
        public ChinookDbContext(DbContextOptions<ChinookDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AppSeed.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Track> Tracks { get; set; }
    }
}
