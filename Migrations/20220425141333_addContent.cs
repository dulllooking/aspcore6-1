using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspcore6_1.Migrations
{
    public partial class addContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "contact_Us",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2022, 4, 25, 22, 13, 32, 722, DateTimeKind.Local).AddTicks(31));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "contact_Us");

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2022, 4, 25, 22, 1, 5, 846, DateTimeKind.Local).AddTicks(563));
        }
    }
}
