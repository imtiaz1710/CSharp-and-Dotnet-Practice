using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FristDemo.Data.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("3059e1e0-ffb9-4f1f-bdca-12ec3182b282"), "8eecb4d5-ca0f-466b-9f7e-cc85ca2028fb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("d2da3d4e-08e3-43d6-a2b7-e2a74a91af23"), "e4d166ff-1825-435d-a333-d00df0e4220b", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("062c6794-7392-4056-b400-a6e10abfe5c2"), "cfe1470a-522f-4d5b-8f3a-eb9948a8149a", "Student", "STUDENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("062c6794-7392-4056-b400-a6e10abfe5c2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3059e1e0-ffb9-4f1f-bdca-12ec3182b282"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d2da3d4e-08e3-43d6-a2b7-e2a74a91af23"));
        }
    }
}
