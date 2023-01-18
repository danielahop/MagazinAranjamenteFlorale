using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagazinAranjamenteFlorale.Migrations
{
    public partial class OfferUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferProduct");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Offer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Offer_ProductID",
                table: "Offer",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Product_ProductID",
                table: "Offer",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Product_ProductID",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Offer_ProductID",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Offer");

            migrationBuilder.CreateTable(
                name: "OfferProduct",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferProduct", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OfferProduct_Offer_OfferID",
                        column: x => x.OfferID,
                        principalTable: "Offer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferProduct_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferProduct_OfferID",
                table: "OfferProduct",
                column: "OfferID");

            migrationBuilder.CreateIndex(
                name: "IX_OfferProduct_ProductID",
                table: "OfferProduct",
                column: "ProductID");
        }
    }
}
