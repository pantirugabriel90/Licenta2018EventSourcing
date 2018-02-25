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
    [Migration("20180225111129_AddViewsTable")]
    partial class AddViewsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Views.Entities.Aggregate", b =>
                {
                    b.Property<Guid>("AggregateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.Property<int>("Version");

                    b.HasKey("AggregateId");

                    b.ToTable("Aggregates");
                });

            modelBuilder.Entity("Domain.Views.Entities.Event", b =>
                {
                    b.Property<Guid>("AggregateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AggregateType");

                    b.Property<string>("Data");

                    b.Property<string>("IssuedBy");

                    b.Property<DateTimeOffset>("TimeStamp");

                    b.Property<string>("Type");

                    b.Property<int>("Version");

                    b.HasKey("AggregateId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Domain.Views.Entities.ProcessedEvent", b =>
                {
                    b.Property<Guid>("AggregateId");

                    b.Property<int>("Version");

                    b.HasKey("AggregateId", "Version");

                    b.ToTable("ProcessedEvent");
                });

            modelBuilder.Entity("Domain.Views.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("TaskId");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Domain.Views.Entities.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CompletedStatus");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<double>("Hours");

                    b.Property<double>("LoggedHours");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Domain.Views.Entities.TaskListElement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Completed");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("TaskList");
                });

            modelBuilder.Entity("Domain.Views.Entities.View", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DateOfLastProcessedEvent");

                    b.Property<int>("NumberOfProcessedEvent");

                    b.Property<string>("ViewName");

                    b.HasKey("Id");

                    b.ToTable("Views");
                });

            modelBuilder.Entity("Domain.Views.Entities.Tag", b =>
                {
                    b.HasOne("Domain.Views.Entities.Task")
                        .WithMany("Tags")
                        .HasForeignKey("TaskId");
                });
#pragma warning restore 612, 618
        }
    }
}
