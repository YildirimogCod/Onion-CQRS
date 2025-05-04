using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priorty = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 4, 15, 8, 56, 645, DateTimeKind.Utc).AddTicks(8429), false, "Baby" },
                    { 2, new DateTime(2025, 5, 4, 15, 8, 56, 645, DateTimeKind.Utc).AddTicks(8522), false, "Shoes, Beauty & Baby" },
                    { 3, new DateTime(2025, 5, 4, 15, 8, 56, 645, DateTimeKind.Utc).AddTicks(8533), true, "Kids" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "ParentId", "Priorty" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 4, 15, 8, 56, 646, DateTimeKind.Utc).AddTicks(2389), false, "Elektrik", 0, 1 },
                    { 2, new DateTime(2025, 5, 4, 15, 8, 56, 646, DateTimeKind.Utc).AddTicks(2392), false, "Moda", 0, 2 },
                    { 3, new DateTime(2025, 5, 4, 15, 8, 56, 646, DateTimeKind.Utc).AddTicks(2395), false, "Bilgisayar", 1, 1 },
                    { 4, new DateTime(2025, 5, 4, 15, 8, 56, 646, DateTimeKind.Utc).AddTicks(2397), false, "Kadın", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 4, 15, 8, 56, 650, DateTimeKind.Utc).AddTicks(767), "Voluptatum masaya quam koştum quasi.", false, "Batarya." },
                    { 2, 3, new DateTime(2025, 5, 4, 15, 8, 56, 650, DateTimeKind.Utc).AddTicks(877), "Düşünüyor karşıdakine sandalye qui deleniti.", true, "Adipisci lakin." },
                    { 3, 4, new DateTime(2025, 5, 4, 15, 8, 56, 650, DateTimeKind.Utc).AddTicks(923), "Perferendis quia ışık consectetur sit.", false, "Aperiam." }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreatedAt", "Description", "Discount", "IsDeleted", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 4, 18, 8, 56, 653, DateTimeKind.Local).AddTicks(3030), "Ve çarpan umut bilgiyasayarı umut ve çorba mi sıla oldular. Fugit illo ışık sinema tv sıla qui ducimus. Bahar yaptı blanditiis.", 5.249819577337760m, false, 672.16m, "Handmade Rubber Chair" },
                    { 2, 3, new DateTime(2025, 5, 4, 18, 8, 56, 653, DateTimeKind.Local).AddTicks(3311), "Sit sed ullam eve nostrum accusantium. Dolores dolore sevindi oldular alias domates sed. Kapının sit salladı consequatur non. Çıktılar nemo ab illo lambadaki layıkıyla sayfası mıknatıslı. Non odit cesurca tempora velit ducimus.", 2.361022126467450m, false, 347.14m, "Awesome Frozen Shirt" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_CategoryId",
                table: "Details",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
