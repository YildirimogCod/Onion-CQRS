using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class refactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 5, 27, 21, 20, 31, 980, DateTimeKind.Utc).AddTicks(8468), "Games" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 5, 27, 21, 20, 31, 980, DateTimeKind.Utc).AddTicks(8479), "Toys" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 5, 27, 21, 20, 31, 980, DateTimeKind.Utc).AddTicks(8542), "Jewelery, Jewelery & Grocery" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 27, 21, 20, 31, 981, DateTimeKind.Utc).AddTicks(1286));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 27, 21, 20, 31, 981, DateTimeKind.Utc).AddTicks(1288));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 27, 21, 20, 31, 981, DateTimeKind.Utc).AddTicks(1290));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 27, 21, 20, 31, 981, DateTimeKind.Utc).AddTicks(1292));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2025, 5, 27, 21, 20, 31, 984, DateTimeKind.Utc).AddTicks(1625), "Ea hesap consectetur değirmeni in.", "Sed." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2025, 5, 27, 21, 20, 31, 984, DateTimeKind.Utc).AddTicks(1674), "Layıkıyla quam consequuntur numquam doğru.", "Umut yapacakmış." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2025, 5, 27, 21, 20, 31, 984, DateTimeKind.Utc).AddTicks(1711), "Doğru karşıdakine sıfat bahar ötekinden.", "Quaerat." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 5, 28, 0, 20, 31, 997, DateTimeKind.Local).AddTicks(2407), "Lambadaki bilgisayarı kutusu magni bilgisayarı yaptı deleniti dolore ratione. Tv bundan un. Ullam ipsa nihil türemiş patlıcan. Sequi uzattı quam gülüyorum düşünüyor consequatur labore iusto ab ışık. Quia layıkıyla yaptı adresini doğru ötekinden ducimus mıknatıslı quaerat.", 9.549464562709260m, 300.89m, "Refined Plastic Hat" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 5, 28, 0, 20, 31, 997, DateTimeKind.Local).AddTicks(2547), "Doğru quaerat orta salladı teldeki in yaptı nisi. Doğru voluptate ea göze domates kulu türemiş mutlu nesciunt.", 5.292712194104180m, 871.99m, "Rustic Steel Keyboard" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 5, 26, 13, 58, 28, 333, DateTimeKind.Utc).AddTicks(5096), "Baby, Shoes & Kids" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 5, 26, 13, 58, 28, 333, DateTimeKind.Utc).AddTicks(5114), "Games & Beauty" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name" },
                values: new object[] { new DateTime(2025, 5, 26, 13, 58, 28, 333, DateTimeKind.Utc).AddTicks(5122), "Clothing" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 26, 13, 58, 28, 333, DateTimeKind.Utc).AddTicks(8329));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 26, 13, 58, 28, 333, DateTimeKind.Utc).AddTicks(8332));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 26, 13, 58, 28, 333, DateTimeKind.Utc).AddTicks(8334));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 26, 13, 58, 28, 333, DateTimeKind.Utc).AddTicks(8336));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2025, 5, 26, 13, 58, 28, 337, DateTimeKind.Utc).AddTicks(3221), "Ab kalemi layıkıyla eum otobüs.", "Vel." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2025, 5, 26, 13, 58, 28, 337, DateTimeKind.Utc).AddTicks(3271), "Quia praesentium qui aut çorba.", "Adipisci sokaklarda." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Title" },
                values: new object[] { new DateTime(2025, 5, 26, 13, 58, 28, 337, DateTimeKind.Utc).AddTicks(3307), "Veniam quia gidecekmiş velit biber.", "İusto." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 5, 26, 16, 58, 28, 397, DateTimeKind.Local).AddTicks(6411), "Eve bahar praesentium voluptatem et göze bilgisayarı için aspernatur. Göze ut nemo numquam ipsam ışık quia in odit. Dağılımı ötekinden gazete labore odio. İpsum exercitationem reprehenderit yapacakmış.", 3.350143122640010m, 685.65m, "Awesome Wooden Chicken" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 5, 26, 16, 58, 28, 397, DateTimeKind.Local).AddTicks(6526), "Layıkıyla perferendis adanaya kalemi gülüyorum salladı. Dışarı vel olduğu suscipit ab gül ışık.", 5.647847865487530m, 671.49m, "Incredible Frozen Chair" });
        }
    }
}
