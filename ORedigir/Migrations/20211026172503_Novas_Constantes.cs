using Microsoft.EntityFrameworkCore.Migrations;

namespace ORedigir.Migrations
{
    public partial class Novas_Constantes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81a5a2d4-df97-4441-bde7-7c99ad6a72fe");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0182055b-e0b0-4380-806e-180c7914ac45", "d5ca5992-73c2-46c5-870e-49b29b88f5d7", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4266932-e778-450b-9f27-43dffb6c21bd", "be222316-2f4d-4223-bcee-78d7d7b7a9e4", "Professor", "Professor" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aecc1577-ba07-454a-9e10-a19734f82f73", "017a1789-4038-4eda-87c5-878816320d0e", "Aluno", "Aluno" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0182055b-e0b0-4380-806e-180c7914ac45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aecc1577-ba07-454a-9e10-a19734f82f73");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4266932-e778-450b-9f27-43dffb6c21bd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "81a5a2d4-df97-4441-bde7-7c99ad6a72fe", "d54987cc-ce29-42c9-9b95-ddcb1c5b931f", "Admin", "Admin" });
        }
    }
}
