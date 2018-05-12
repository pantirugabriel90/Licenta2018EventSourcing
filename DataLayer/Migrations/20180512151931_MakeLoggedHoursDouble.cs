using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataLayer.Migrations
{
    public partial class MakeLoggedHoursDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoggedHOurs",
                table: "GradesStatistics",
                newName: "LoggedHours");

            migrationBuilder.AlterColumn<double>(
                name: "LoggedHours",
                table: "StudentStatistics",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoggedHours",
                table: "GradesStatistics",
                newName: "LoggedHOurs");

            migrationBuilder.AlterColumn<int>(
                name: "LoggedHours",
                table: "StudentStatistics",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
