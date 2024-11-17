using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XmlBillingSystem.Migrations
{
    /// <inheritdoc />
    public partial class ChangePK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BILL_ITEM",
                table: "BILL_ITEM");

            migrationBuilder.AlterColumn<decimal>(
                name: "PRICE",
                table: "BILL_ITEM",
                type: "decimal(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)");

            migrationBuilder.AddColumn<int>(
                name: "BillItemId",
                table: "BILL_ITEM",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BILL_ITEM",
                table: "BILL_ITEM",
                column: "BillItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BILL_ITEM_BillId",
                table: "BILL_ITEM",
                column: "BillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BILL_ITEM",
                table: "BILL_ITEM");

            migrationBuilder.DropIndex(
                name: "IX_BILL_ITEM_BillId",
                table: "BILL_ITEM");

            migrationBuilder.DropColumn(
                name: "BillItemId",
                table: "BILL_ITEM");

            migrationBuilder.AlterColumn<decimal>(
                name: "PRICE",
                table: "BILL_ITEM",
                type: "decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,17)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BILL_ITEM",
                table: "BILL_ITEM",
                columns: new[] { "BillId", "ID" });
        }
    }
}
