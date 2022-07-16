using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DeltaX_WebApp.Models;

namespace DeltaX_WebApp.Data
{
    public class DeltaX_WebAppContext : DbContext
    {
        public DeltaX_WebAppContext (DbContextOptions<DeltaX_WebAppContext> options)
            : base(options)
        {
        }

        public DbSet<DeltaX_WebApp.Models.Movie> Movie { get; set; }

        public DbSet<DeltaX_WebApp.Models.Actor> Actor { get; set; }

        public DbSet<DeltaX_WebApp.Models.MovieActor> MovieActor { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<MovieActor>()
            .HasKey(ma => new { ma.MovieId, ma.ActorId });
          modelBuilder.Entity<MovieActor>()
          .HasOne<Movie>(sc => sc.Movie)
          .WithMany(s => s.MovieActors)
          .HasForeignKey(sc => sc.MovieId);


          modelBuilder.Entity<MovieActor>()
          .HasOne<Actor>(sc => sc.Actor)
          .WithMany(s => s.MovieActors)
          .HasForeignKey(sc => sc.ActorId);
        }
  }
}
