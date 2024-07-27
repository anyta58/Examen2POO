using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoExamen2.Migrations
{
    /// <inheritdoc />
    public partial class creacionTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "clients",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    identity_number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "loans",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    client_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    loan_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    commission_rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    interes_rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    term = table.Column<int>(type: "int", nullable: false),
                    disbursement_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    first_payment_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loans", x => x.id);
                    table.ForeignKey(
                        name: "FK_loans_clients_client_id",
                        column: x => x.client_id,
                        principalSchema: "dbo",
                        principalTable: "clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "amortizations",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    client_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    installment_number = table.Column<int>(type: "int", nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    days = table.Column<int>(type: "int", nullable: false),
                    interest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    principal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    level_payment_without_SVSD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    level_payment_with_SVSD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    principal_balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amortizations", x => x.id);
                    table.ForeignKey(
                        name: "FK_amortizations_loans_client_id",
                        column: x => x.client_id,
                        principalSchema: "dbo",
                        principalTable: "loans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_amortizations_client_id",
                schema: "dbo",
                table: "amortizations",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_loans_client_id",
                schema: "dbo",
                table: "loans",
                column: "client_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "amortizations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "loans",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "clients",
                schema: "dbo");
        }
    }
}
