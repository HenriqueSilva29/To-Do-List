using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class ParamGeral : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "unidade_antes_do_inicio",
                table: "ParamGeral",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "idusuario",
                table: "ParamGeral",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ParamGeral_idusuario",
                table: "ParamGeral",
                column: "idusuario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParamGeral_Usuario_idusuario",
                table: "ParamGeral",
                column: "idusuario",
                principalTable: "Usuario",
                principalColumn: "idusuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParamGeral_Usuario_idusuario",
                table: "ParamGeral");

            migrationBuilder.DropIndex(
                name: "IX_ParamGeral_idusuario",
                table: "ParamGeral");

            migrationBuilder.DropColumn(
                name: "idusuario",
                table: "ParamGeral");

            migrationBuilder.AlterColumn<int>(
                name: "unidade_antes_do_inicio",
                table: "ParamGeral",
                type: "int",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);
        }
    }
}
