using Domain;
using Domain.Views.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataLayer
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }
        public ApplicationContext()
        {
        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<ProcessedEvent> ProcessedEvents { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Aggregate> Aggregates { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcessedEvent>()
                .HasKey(e => new { e.AggregateId, e.Version });
        }
    }
}
