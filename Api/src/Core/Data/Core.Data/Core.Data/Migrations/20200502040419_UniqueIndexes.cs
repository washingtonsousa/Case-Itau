using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Data.Migrations
{
    public partial class UniqueIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ds_nome",
                table: "tb_time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ds_uf",
                table: "tb_estado",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_time_ds_nome",
                table: "tb_time",
                column: "ds_nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_estado_ds_uf",
                table: "tb_estado",
                column: "ds_uf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_campeonato_vl_ano",
                table: "tb_campeonato",
                column: "vl_ano",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tb_time_ds_nome",
                table: "tb_time");

            migrationBuilder.DropIndex(
                name: "IX_tb_estado_ds_uf",
                table: "tb_estado");

            migrationBuilder.DropIndex(
                name: "IX_tb_campeonato_vl_ano",
                table: "tb_campeonato");

            migrationBuilder.AlterColumn<string>(
                name: "ds_nome",
                table: "tb_time",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ds_uf",
                table: "tb_estado",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
