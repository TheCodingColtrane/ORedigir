using Microsoft.EntityFrameworkCore.Migrations;

namespace ORedigir.Migrations
{
    public partial class NovaPK_tblTurma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_TurmaID",
                table: "Usuario");

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

            migrationBuilder.AddColumn<string>(
                name: "Professor",
                table: "Turma",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24cbb7d8-c116-4369-8242-17d94fa467e9", "7dcd39c5-cfbf-4c4c-9fe3-bd4fa0180031", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "efc0fff4-9eab-4800-bf64-1074182a2e62", "94b8d91c-7739-4aba-b3ed-7c865b381d37", "Professor", "Professor" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "48ee90b4-2201-48f8-a4ba-d7cc6cc56abd", "9ecf9304-dc8e-43cd-b9a7-9d8c245b39b4", "Aluno", "Aluno" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TurmaID",
                table: "Usuario",
                column: "TurmaID",
                unique: true,
                filter: "[TurmaID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuario_TurmaID",
                table: "Usuario");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24cbb7d8-c116-4369-8242-17d94fa467e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48ee90b4-2201-48f8-a4ba-d7cc6cc56abd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efc0fff4-9eab-4800-bf64-1074182a2e62");

            migrationBuilder.DropColumn(
                name: "Professor",
                table: "Turma");

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

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TurmaID",
                table: "Usuario",
                column: "TurmaID");
        }
    }
}
