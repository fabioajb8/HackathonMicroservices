using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Persistence.Migrations
{
    public partial class createDb7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "Email", "NIF", "Name", "OldId", "Address_City", "Address_Line1", "Address_Line2", "Address_PostalCode", "Address_State" },
                values: new object[] { new Guid("e978e7ac-ccb7-47dc-91e5-d83cf381ddcc"), "fajb_developer@gmail.com", "267924607", "Fábio", 0, "Sintra", "Rua1", "Rua2", "2715", "Lisboa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: new Guid("e978e7ac-ccb7-47dc-91e5-d83cf381ddcc"));
        }
    }
}
