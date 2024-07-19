using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedMango_API.Migrations
{
    /// <inheritdoc />
    public partial class removeStripeFromShoppingCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartTotal",
                table: "ShopingCarts");

            migrationBuilder.DropColumn(
                name: "ClientSecret",
                table: "ShopingCarts");

            migrationBuilder.DropColumn(
                name: "StripePaymentIntentId",
                table: "ShopingCarts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CartTotal",
                table: "ShopingCarts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ClientSecret",
                table: "ShopingCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StripePaymentIntentId",
                table: "ShopingCarts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
