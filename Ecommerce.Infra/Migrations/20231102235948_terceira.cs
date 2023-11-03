using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Infra.Migrations
{
    public partial class terceira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSubcategory_Products_ProductId",
                table: "ProductSubcategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSubcategory_Subcategories_SubcategoryId",
                table: "ProductSubcategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSubcategory",
                table: "ProductSubcategory");

            migrationBuilder.RenameTable(
                name: "ProductSubcategory",
                newName: "ProductSubcategories");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSubcategory_SubcategoryId",
                table: "ProductSubcategories",
                newName: "IX_ProductSubcategories_SubcategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSubcategories",
                table: "ProductSubcategories",
                columns: new[] { "ProductId", "SubcategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSubcategories_Products_ProductId",
                table: "ProductSubcategories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSubcategories_Subcategories_SubcategoryId",
                table: "ProductSubcategories",
                column: "SubcategoryId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSubcategories_Products_ProductId",
                table: "ProductSubcategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSubcategories_Subcategories_SubcategoryId",
                table: "ProductSubcategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSubcategories",
                table: "ProductSubcategories");

            migrationBuilder.RenameTable(
                name: "ProductSubcategories",
                newName: "ProductSubcategory");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSubcategories_SubcategoryId",
                table: "ProductSubcategory",
                newName: "IX_ProductSubcategory_SubcategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSubcategory",
                table: "ProductSubcategory",
                columns: new[] { "ProductId", "SubcategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSubcategory_Products_ProductId",
                table: "ProductSubcategory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSubcategory_Subcategories_SubcategoryId",
                table: "ProductSubcategory",
                column: "SubcategoryId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
