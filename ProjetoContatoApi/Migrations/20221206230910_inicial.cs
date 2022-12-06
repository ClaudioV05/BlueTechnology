using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoContato.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    DataNasc = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "pessoas",
                columns: new[] { "Id", "DataNasc", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 1, "01/05/2000", "Maria", "José", "81784568898" });

            migrationBuilder.InsertData(
                table: "pessoas",
                columns: new[] { "Id", "DataNasc", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 2, "25/06/1999", "João", "Paulo", "81445575525" });

            migrationBuilder.InsertData(
                table: "pessoas",
                columns: new[] { "Id", "DataNasc", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 3, "11/07/1980", "Lucas", "Machado", "81578962542" });

            migrationBuilder.InsertData(
                table: "pessoas",
                columns: new[] { "Id", "DataNasc", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 4, "04/02/1999", "Juca", "Chaves", "81568896647" });

            migrationBuilder.InsertData(
                table: "pessoas",
                columns: new[] { "Id", "DataNasc", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 5, "22/09/2010", "Luciano", "Gomes", "81487554878" });

            migrationBuilder.InsertData(
                table: "pessoas",
                columns: new[] { "Id", "DataNasc", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 6, "29/07/1987", "Antônio", "Ferreira", "81545666822" });

            migrationBuilder.InsertData(
                table: "pessoas",
                columns: new[] { "Id", "DataNasc", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 7, "12/05/2010", "Larissa", "Cruz", "81456387864" });

            migrationBuilder.InsertData(
                table: "pessoas",
                columns: new[] { "Id", "DataNasc", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 8, "22/10/1982", "Claudio", "Fernandes", "81478963458" });

            migrationBuilder.InsertData(
                table: "pessoas",
                columns: new[] { "Id", "DataNasc", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 9, "05/05/2015", "Emanuel", "Lima", "81489365425" });

            migrationBuilder.InsertData(
                table: "pessoas",
                columns: new[] { "Id", "DataNasc", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 10, "14/07/2012", "Lidiane", "Almeida", "81455224568" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pessoas");
        }
    }
}
