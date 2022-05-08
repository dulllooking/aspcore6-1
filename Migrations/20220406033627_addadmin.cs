using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspcore6_1.Migrations
{
    public partial class addadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id", "Age", "DateTime", "Name" },
                values: new object[] { 1, 20, new DateTime(2022, 4, 6, 11, 36, 26, 902, DateTimeKind.Local).AddTicks(6445), "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
