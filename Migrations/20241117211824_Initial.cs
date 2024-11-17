using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XmlBillingSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORY",
                columns: table => new
                {
                    CATEGORY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY", x => x.CATEGORY_ID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LAST_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PHONE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.CUSTOMER_ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PRICE = table.Column<double>(type: "float", nullable: false),
                    TAX = table.Column<double>(type: "float", nullable: false),
                    STOCK = table.Column<int>(type: "int", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CATEGORY_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUCT_CATEGORY",
                        column: x => x.CATEGORY_ID,
                        principalTable: "CATEGORY",
                        principalColumn: "CATEGORY_ID");
                });

            migrationBuilder.CreateTable(
                name: "BILL",
                columns: table => new
                {
                    BILL_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    REFERENCE_NUMBER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TOTAL_AMOUNT = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BILL", x => x.BILL_ID);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_BILLS",
                        column: x => x.CustomerId,
                        principalTable: "CUSTOMER",
                        principalColumn: "CUSTOMER_ID");
                });

            migrationBuilder.CreateTable(
                name: "BILL_ITEM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    QUANTITY = table.Column<int>(type: "int", nullable: false),
                    PRICE = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    STOCK = table.Column<int>(type: "int", nullable: false),
                    SUB_TOTAL = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BILL_ITEM", x => new { x.BillId, x.ID });
                    table.ForeignKey(
                        name: "FK_BILL_ITEM_BILL",
                        column: x => x.BillId,
                        principalTable: "BILL",
                        principalColumn: "BILL_ID");
                    table.ForeignKey(
                        name: "FK_BILL_ITEM_PRODUCT",
                        column: x => x.ID,
                        principalTable: "PRODUCT",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BILL_CustomerId",
                table: "BILL",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BILL_ITEM_ID",
                table: "BILL_ITEM",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_CATEGORY_ID",
                table: "PRODUCT",
                column: "CATEGORY_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BILL_ITEM");

            migrationBuilder.DropTable(
                name: "BILL");

            migrationBuilder.DropTable(
                name: "PRODUCT");

            migrationBuilder.DropTable(
                name: "CUSTOMER");

            migrationBuilder.DropTable(
                name: "CATEGORY");
        }
    }
}
