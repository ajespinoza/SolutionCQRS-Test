using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Solution.Persistence.Migrations
{
    public partial class SolutionMigrationInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("a9a1cec6-a6a5-419f-916c-ff81ba940e80"), "Curso de C# basico", new DateTime(2025, 4, 24, 17, 38, 57, 766, DateTimeKind.Local).AddTicks(9209), new DateTime(2026, 4, 24, 17, 38, 57, 768, DateTimeKind.Local).AddTicks(4057), 56m, "C# desde 0 hasta avanzado" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("60b9e0b2-97b5-4a2c-95c6-ad32c9517bfc"), "Curso de Javascript", new DateTime(2025, 4, 24, 17, 38, 57, 769, DateTimeKind.Local).AddTicks(2256), new DateTime(2026, 4, 24, 17, 38, 57, 769, DateTimeKind.Local).AddTicks(2260), 30m, "Javascript desde 0 hasta avanzado" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
