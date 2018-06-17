﻿// <auto-generated />
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DataLayer.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20180617183959_tempStatistics")]
    partial class tempStatistics
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.ContextEntities.Aggregate", b =>
                {
                    b.Property<Guid>("AggregateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.Property<int>("Version");

                    b.HasKey("AggregateId");

                    b.ToTable("Aggregates");
                });

            modelBuilder.Entity("Domain.ContextEntities.Event", b =>
                {
                    b.Property<Guid>("AggregateId");

                    b.Property<DateTimeOffset>("TimeStamp");

                    b.Property<string>("AggregateType");

                    b.Property<string>("Data");

                    b.Property<string>("IssuedBy");

                    b.Property<string>("Type");

                    b.Property<int>("Version");

                    b.HasKey("AggregateId", "TimeStamp");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Domain.ContextEntities.GradeStatistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("CompletedTasks");

                    b.Property<double>("Grade");

                    b.Property<double>("LoggedHours");

                    b.Property<double>("NumberOfReplies");

                    b.Property<double>("StartedTasks");

                    b.Property<double>("StartedTopics");

                    b.HasKey("Id");

                    b.ToTable("GradesStatistics");
                });

            modelBuilder.Entity("Domain.ContextEntities.Reply", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<string>("IssuedBy");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<Guid?>("TopicId");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("Reply");
                });

            modelBuilder.Entity("Domain.ContextEntities.StudentStatistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompletedTasks");

                    b.Property<double>("Grade");

                    b.Property<double>("LoggedHours");

                    b.Property<int>("NumberOfReplies");

                    b.Property<int>("StartedTasks");

                    b.Property<int>("StarterTopics");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("StudentStatistics");
                });

            modelBuilder.Entity("Domain.ContextEntities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("TaskId");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Domain.ContextEntities.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CompletedStatus");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<double>("Hours");

                    b.Property<string>("IssuedBy");

                    b.Property<double>("LoggedHours");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Domain.ContextEntities.TaskListElement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Completed");

                    b.Property<string>("IssuedBy");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("TaskList");
                });

            modelBuilder.Entity("Domain.ContextEntities.TemporalStatistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompletedTasks");

                    b.Property<DateTime>("Date");

                    b.Property<double>("LoggedHours");

                    b.Property<int>("NumberOfReplies");

                    b.Property<int>("StartedTasks");

                    b.Property<int>("StarterTopics");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("TemporalStatistics");
                });

            modelBuilder.Entity("Domain.ContextEntities.Topic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<string>("IssuedBy");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Domain.ContextEntities.TopicListElement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IssuedBy");

                    b.Property<DateTime>("LastActivity");

                    b.Property<int>("NumberOfReplies");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("TopicList");
                });

            modelBuilder.Entity("Domain.ContextEntities.View", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DateOfLastProcessedEvent");

                    b.Property<int>("NumberOfProcessedEvent");

                    b.Property<string>("ViewName");

                    b.HasKey("Id");

                    b.ToTable("Views");
                });

            modelBuilder.Entity("Domain.ContextEntities.Reply", b =>
                {
                    b.HasOne("Domain.ContextEntities.Topic")
                        .WithMany("Replies")
                        .HasForeignKey("TopicId");
                });

            modelBuilder.Entity("Domain.ContextEntities.Tag", b =>
                {
                    b.HasOne("Domain.ContextEntities.Task")
                        .WithMany("Tags")
                        .HasForeignKey("TaskId");
                });
#pragma warning restore 612, 618
        }
    }
}
