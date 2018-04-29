using Domain;
using Domain.ContextEntities;
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
        public DbSet<TopicListElement> TopicList { get; set; }
        public DbSet<Domain.ContextEntities.Task> Tasks { get; set; }
        public DbSet<Domain.ContextEntities.Topic> Topics { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Aggregate> Aggregates { get; set; }
        public DbSet<View> Views { get; set; }
        public DbSet<StudentStatistics> StudentStatistics { get; set; }
        public DbSet<GradeStatistics> GradesStatistics { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(ConfigReader.GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasKey(e => new { e.AggregateId, e.TimeStamp });
        }
    }
}
