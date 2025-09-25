using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InheritanceMapping.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentsInheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashPayments_Payments_Id",
                        column: x => x.Id,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditCardPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCardPayments_Payments_Id",
                        column: x => x.Id,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashPayments");

            migrationBuilder.DropTable(
                name: "CreditCardPayments");

            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
