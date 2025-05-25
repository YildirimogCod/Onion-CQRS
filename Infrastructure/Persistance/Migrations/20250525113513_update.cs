using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 5, 25, 11, 35, 13, 47, DateTimeKind.Utc).AddTicks(1405), "Home & Jewelery" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 5, 25, 11, 35, 13, 47, DateTimeKind.Utc).AddTicks(1416), "Beauty" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 5, 25, 11, 35, 13, 47, DateTimeKind.Utc).AddTicks(1421), "Shoes" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 25, 11, 35, 13, 47, DateTimeKind.Utc).AddTicks(3430));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 25, 11, 35, 13, 47, DateTimeKind.Utc).AddTicks(3431));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 25, 11, 35, 13, 47, DateTimeKind.Utc).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 25, 11, 35, 13, 47, DateTimeKind.Utc).AddTicks(3434));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2025, 5, 25, 11, 35, 13, 49, DateTimeKind.Utc).AddTicks(6739), "Veniam çarpan dağılımı eve nihil.", "Sandalye." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2025, 5, 25, 11, 35, 13, 49, DateTimeKind.Utc).AddTicks(6773), "Dolorem karşıdakine consequuntur modi ötekinden.", "Ullam molestiae." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2025, 5, 25, 11, 35, 13, 49, DateTimeKind.Utc).AddTicks(6800), "Mıknatıslı aperiam corporis anlamsız tv.", "Sit." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 5, 25, 14, 35, 13, 53, DateTimeKind.Local).AddTicks(2342), "Voluptatem kutusu explicabo bundan dolorem sinema odio ex eve. Aspernatur çarpan duyulmamış adresini. Balıkhaneye numquam veritatis otobüs velit yapacakmış inventore.", 6.799782863042070m, 901.09m, "Unbranded Fresh Mouse" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 5, 25, 14, 35, 13, 53, DateTimeKind.Local).AddTicks(2689), "Telefonu vel masaya. İure koştum layıkıyla labore kapının. Kulu layıkıyla çünkü quia ut ipsam exercitationem consectetur accusantium deleniti. Gazete tempora voluptatem. Çıktılar yaptı lakin totam.", 4.242928767833990m, 954.10m, "Handcrafted Cotton Chips" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 5, 4, 15, 8, 56, 645, DateTimeKind.Utc).AddTicks(8429), "Baby" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 5, 4, 15, 8, 56, 645, DateTimeKind.Utc).AddTicks(8522), "Shoes, Beauty & Baby" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 5, 4, 15, 8, 56, 645, DateTimeKind.Utc).AddTicks(8533), "Kids" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 15, 8, 56, 646, DateTimeKind.Utc).AddTicks(2389));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 15, 8, 56, 646, DateTimeKind.Utc).AddTicks(2392));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 15, 8, 56, 646, DateTimeKind.Utc).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 4, 15, 8, 56, 646, DateTimeKind.Utc).AddTicks(2397));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2025, 5, 4, 15, 8, 56, 650, DateTimeKind.Utc).AddTicks(767), "Voluptatum masaya quam koştum quasi.", "Batarya." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2025, 5, 4, 15, 8, 56, 650, DateTimeKind.Utc).AddTicks(877), "Düşünüyor karşıdakine sandalye qui deleniti.", "Adipisci lakin." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2025, 5, 4, 15, 8, 56, 650, DateTimeKind.Utc).AddTicks(923), "Perferendis quia ışık consectetur sit.", "Aperiam." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 5, 4, 18, 8, 56, 653, DateTimeKind.Local).AddTicks(3030), "Ve çarpan umut bilgiyasayarı umut ve çorba mi sıla oldular. Fugit illo ışık sinema tv sıla qui ducimus. Bahar yaptı blanditiis.", 5.249819577337760m, 672.16m, "Handmade Rubber Chair" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 5, 4, 18, 8, 56, 653, DateTimeKind.Local).AddTicks(3311), "Sit sed ullam eve nostrum accusantium. Dolores dolore sevindi oldular alias domates sed. Kapının sit salladı consequatur non. Çıktılar nemo ab illo lambadaki layıkıyla sayfası mıknatıslı. Non odit cesurca tempora velit ducimus.", 2.361022126467450m, 347.14m, "Awesome Frozen Shirt" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");
        }
    }
}
