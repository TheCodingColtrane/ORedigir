using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ORedigir.Migrations
{
    public partial class NovaTabela_Log : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    LogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipoLog = table.Column<short>(type: "smallint", nullable: false),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Criado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.LogID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fcbd3319-0e06-4341-bf98-72959bb1cca1", "a4bc2e9a-177a-4481-a398-bb8474962bc0", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5d13984-73df-4f66-a76e-d3bcdc6184d7", "9be1cbb3-d336-4401-9831-666934016084", "Professor", "Professor" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd531082-99b4-4abf-8b30-17a5d30f65b5", "5f6a53b4-d0e4-41b1-afff-aa62b33fb12f", "Aluno", "Aluno" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5d13984-73df-4f66-a76e-d3bcdc6184d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcbd3319-0e06-4341-bf98-72959bb1cca1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd531082-99b4-4abf-8b30-17a5d30f65b5");

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
    }
}
