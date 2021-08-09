using Microsoft.EntityFrameworkCore.Migrations;

namespace Dotz.Migrations
{
    public partial class FixOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oder_Users_UserId",
                table: "Oder");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Oder_OrderId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Oder",
                table: "Oder");

            migrationBuilder.RenameTable(
                name: "Oder",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_Oder_UserId",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Extract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Order_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Order_OrderId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Extract");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Oder");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "Oder",
                newName: "IX_Oder_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Oder",
                table: "Oder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Oder_Users_UserId",
                table: "Oder",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Oder_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Oder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
