using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.Migrations
{
    public partial class initDatabaseModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_campeonato",
                columns: table => new
                {
                    id_brasileirao = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vl_ano = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_campeonato", x => x.id_brasileirao);
                });

            migrationBuilder.CreateTable(
                name: "tb_estado",
                columns: table => new
                {
                    id_estado = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ds_uf = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_estado", x => x.id_estado);
                });

            migrationBuilder.CreateTable(
                name: "tb_time",
                columns: table => new
                {
                    id_time = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ds_nome = table.Column<string>(nullable: false),
                    id_estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_time", x => x.id_time);
                    table.ForeignKey(
                        name: "FK_tb_time_tb_estado_id_estado",
                        column: x => x.id_estado,
                        principalTable: "tb_estado",
                        principalColumn: "id_estado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_posicao",
                columns: table => new
                {
                    id_posicao = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    vl_pontos = table.Column<int>(nullable: false),
                    vl_jogos = table.Column<int>(nullable: false),
                    vl_vitorias = table.Column<int>(nullable: false),
                    vl_empates = table.Column<int>(nullable: false),
                    vl_derrotas = table.Column<int>(nullable: false),
                    vl_golspro = table.Column<int>(nullable: false),
                    vl_golscontra = table.Column<int>(nullable: false),
                    vl_posicao = table.Column<int>(nullable: false),
                    id_time = table.Column<int>(nullable: false),
                    id_campeonato = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_posicao", x => x.id_posicao);
                    table.ForeignKey(
                        name: "FK_tb_posicao_tb_campeonato_id_campeonato",
                        column: x => x.id_campeonato,
                        principalTable: "tb_campeonato",
                        principalColumn: "id_brasileirao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_posicao_tb_time_id_time",
                        column: x => x.id_time,
                        principalTable: "tb_time",
                        principalColumn: "id_time",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_posicao_id_campeonato",
                table: "tb_posicao",
                column: "id_campeonato");

            migrationBuilder.CreateIndex(
                name: "IX_tb_posicao_id_time",
                table: "tb_posicao",
                column: "id_time");

            migrationBuilder.CreateIndex(
                name: "IX_tb_time_id_estado",
                table: "tb_time",
                column: "id_estado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_posicao");

            migrationBuilder.DropTable(
                name: "tb_campeonato");

            migrationBuilder.DropTable(
                name: "tb_time");

            migrationBuilder.DropTable(
                name: "tb_estado");
        }
    }
}
