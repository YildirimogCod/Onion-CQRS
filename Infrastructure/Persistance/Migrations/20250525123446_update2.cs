using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 5, 25, 12, 34, 45, 572, DateTimeKind.Utc).AddTicks(1928), "Jewelery, Tools & Clothing" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 5, 25, 12, 34, 45, 572, DateTimeKind.Utc).AddTicks(1942), "Health & Health" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 5, 25, 12, 34, 45, 572, DateTimeKind.Utc).AddTicks(1953), "Sports & Garden" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 25, 12, 34, 45, 572, DateTimeKind.Utc).AddTicks(4468));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 25, 12, 34, 45, 572, DateTimeKind.Utc).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 25, 12, 34, 45, 572, DateTimeKind.Utc).AddTicks(4471));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 25, 12, 34, 45, 572, DateTimeKind.Utc).AddTicks(4473));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2025, 5, 25, 12, 34, 45, 575, DateTimeKind.Utc).AddTicks(338), "Kapının koşuyorlar explicabo beatae cezbelendi.", "Quis." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2025, 5, 25, 12, 34, 45, 575, DateTimeKind.Utc).AddTicks(372), "Dergi explicabo non uzattı masaya.", "Ama autem." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2025, 5, 25, 12, 34, 45, 575, DateTimeKind.Utc).AddTicks(403), "Blanditiis laboriosam sunt velit sit.", "Quam." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 5, 25, 15, 34, 45, 578, DateTimeKind.Local).AddTicks(8263), "Odit nemo adipisci türemiş ipsa bilgisayarı aspernatur praesentium quam. Bilgiyasayarı gitti et bilgiyasayarı ışık ea nisi.", 5.981978531721220m, 367.38m, "Unbranded Soft Bike" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 5, 25, 15, 34, 45, 578, DateTimeKind.Local).AddTicks(8382), "Sequi voluptatem sequi filmini amet qui et quia beatae hesap. Ullam voluptatem filmini et dolore türemiş.", 2.626384923985970m, 182.83m, "Refined Concrete Cheese" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
