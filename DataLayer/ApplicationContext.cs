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
        public DbSet<TaskListElement> TaskList { get; set; }
        public DbSet<Domain.Views.Entities.Task> Tasks { get; set; }
       //public DbSet<Topic> Topics { get; set; }
       //public DbSet<ProcessedEvent> ProcessedEvents { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Aggregate> Aggregates { get; set; }
        public DbSet<View> Views { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-P6BH1QB\\SQLEXPRESS;Initial Catalog=Licenta2018;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcessedEvent>()
                .HasKey(e => new { e.AggregateId, e.Version });
            modelBuilder.Entity<Event>()
                .HasKey(e => new { e.AggregateId, e.TimeStamp });
        }
    }
}
