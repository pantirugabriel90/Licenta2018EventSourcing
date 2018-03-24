using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataLayer.Migrations
{
    public partial class Topiclist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessedEvent");

            migrationBuilder.CreateTable(
                name: "TopicList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IssuedBy = table.Column<string>(nullable: true),
                    LastActivity = table.Column<DateTime>(nullable: false),
                    NumberOfReplies = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    IssuedBy = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reply",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    IssuedBy = table.Column<string>(nullable: true),
                    TopicId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reply_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reply_TopicId",
                table: "Reply",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reply");

            migrationBuilder.DropTable(
                name: "TopicList");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.CreateTable(
                name: "ProcessedEvent",
                columns: table => new
                {
                    AggregateId = table.Column<Guid>(nullable: false),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessedEvent", x => new { x.AggregateId, x.Version });
                });
        }
    }
}
