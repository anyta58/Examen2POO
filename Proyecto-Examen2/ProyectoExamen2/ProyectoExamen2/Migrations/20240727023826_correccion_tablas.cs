using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoExamen2.Migrations
{
    /// <inheritdoc />
    public partial class correccion_tablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_amortizations_loans_client_id",
                schema: "dbo",
                table: "amortizations");

            migrationBuilder.RenameColumn(
                name: "client_id",
                schema: "dbo",
                table: "amortizations",
                newName: "loand_id");

            migrationBuilder.RenameIndex(
                name: "IX_amortizations_client_id",
                schema: "dbo",
                table: "amortizations",
                newName: "IX_amortizations_loand_id");

            migrationBuilder.AddForeignKey(
                name: "FK_amortizations_loans_loand_id",
                schema: "dbo",
                table: "amortizations",
                column: "loand_id",
                principalSchema: "dbo",
                principalTable: "loans",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_amortizations_loans_loand_id",
                schema: "dbo",
                table: "amortizations");

            migrationBuilder.RenameColumn(
                name: "loand_id",
                schema: "dbo",
                table: "amortizations",
                newName: "client_id");

            migrationBuilder.RenameIndex(
                name: "IX_amortizations_loand_id",
                schema: "dbo",
                table: "amortizations",
                newName: "IX_amortizations_client_id");

            migrationBuilder.AddForeignKey(
                name: "FK_amortizations_loans_client_id",
                schema: "dbo",
                table: "amortizations",
                column: "client_id",
                principalSchema: "dbo",
                principalTable: "loans",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
