using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Training.Data.EF.Migrations
{
    public partial class Studios_Creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("45ffdb54-d251-4776-bb9a-499d3b5fd3d3"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("54803936-48f3-4ea5-aa71-f1fb4cc3aab7"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("7a4a9ff4-394f-49b9-993d-b195d18c2769"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("d91406e4-bf02-4c0e-a719-6c4a44e49ee5"));

            migrationBuilder.AddColumn<Guid>(
                name: "StudioId",
                table: "Videos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Studios",
                columns: new[] { "Id", "CreationDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("d9c734cf-76f6-4db6-839a-013ff6bbc875"), new DateTime(2020, 4, 21, 1, 7, 37, 656, DateTimeKind.Local).AddTicks(4257), new DateTime(2020, 4, 21, 1, 7, 37, 656, DateTimeKind.Local).AddTicks(4296), "Studio 1" },
                    { new Guid("4328e74c-d820-4f6d-8fb0-fd49a552d65d"), new DateTime(2020, 4, 21, 1, 7, 37, 656, DateTimeKind.Local).AddTicks(4949), new DateTime(2020, 4, 21, 1, 7, 37, 656, DateTimeKind.Local).AddTicks(4954), "Universal Studios" },
                    { new Guid("1d3e5008-5c35-4180-a898-55c5f5ca7fe8"), new DateTime(2020, 4, 21, 1, 7, 37, 656, DateTimeKind.Local).AddTicks(4978), new DateTime(2020, 4, 21, 1, 7, 37, 656, DateTimeKind.Local).AddTicks(4979), "Studio 3" },
                    { new Guid("bce0d965-1fe6-46e7-bc4c-94ac3628091f"), new DateTime(2020, 4, 21, 1, 7, 37, 656, DateTimeKind.Local).AddTicks(4983), new DateTime(2020, 4, 21, 1, 7, 37, 656, DateTimeKind.Local).AddTicks(4984), "Studio 4" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CreationDate", "DirectedBy", "Duration", "Genre", "ModifiedDate", "Name", "StudioId" },
                values: new object[,]
                {
                    { new Guid("eecfad93-dcfc-4d2c-bd74-dd5596eae957"), new DateTime(2020, 4, 21, 1, 7, 37, 653, DateTimeKind.Local).AddTicks(5789), "Bong Joon Ho", 132, "Comedy, Drama, Trhiller", new DateTime(2020, 4, 21, 1, 7, 37, 654, DateTimeKind.Local).AddTicks(1382), "Parasite", new Guid("d9c734cf-76f6-4db6-839a-013ff6bbc875") },
                    { new Guid("b934d480-e363-45ed-b5d6-0a5ea661df6d"), new DateTime(2020, 4, 21, 1, 7, 37, 654, DateTimeKind.Local).AddTicks(3400), "Sam Mendez", 119, "Drama, War", new DateTime(2020, 4, 21, 1, 7, 37, 654, DateTimeKind.Local).AddTicks(3429), "1917", new Guid("4328e74c-d820-4f6d-8fb0-fd49a552d65d") },
                    { new Guid("3b9320d0-10d6-4bce-a13c-a69531eac7fc"), new DateTime(2020, 4, 21, 1, 7, 37, 654, DateTimeKind.Local).AddTicks(3455), "Martin Scorsese", 209, "Biography, Crime, Drama", new DateTime(2020, 4, 21, 1, 7, 37, 654, DateTimeKind.Local).AddTicks(3457), "The Irishman", new Guid("1d3e5008-5c35-4180-a898-55c5f5ca7fe8") },
                    { new Guid("13fabf95-683a-498e-95b4-a6daba175d72"), new DateTime(2020, 4, 21, 1, 7, 37, 654, DateTimeKind.Local).AddTicks(3464), "Quentin Tarantino", 161, "Comedy, Drama", new DateTime(2020, 4, 21, 1, 7, 37, 654, DateTimeKind.Local).AddTicks(3466), "Once Upoin a Time... In Hollywood", new Guid("1d3e5008-5c35-4180-a898-55c5f5ca7fe8") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Studios");

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("13fabf95-683a-498e-95b4-a6daba175d72"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("3b9320d0-10d6-4bce-a13c-a69531eac7fc"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("b934d480-e363-45ed-b5d6-0a5ea661df6d"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("eecfad93-dcfc-4d2c-bd74-dd5596eae957"));

            migrationBuilder.DropColumn(
                name: "StudioId",
                table: "Videos");

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CreationDate", "DirectedBy", "Duration", "Genre", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("7a4a9ff4-394f-49b9-993d-b195d18c2769"), new DateTime(2020, 4, 19, 20, 49, 1, 603, DateTimeKind.Local).AddTicks(9135), "Bong Joon Ho", 132, "Comedy, Drama, Trhiller", new DateTime(2020, 4, 19, 20, 49, 1, 605, DateTimeKind.Local).AddTicks(925), "Parasite" },
                    { new Guid("54803936-48f3-4ea5-aa71-f1fb4cc3aab7"), new DateTime(2020, 4, 19, 20, 49, 1, 605, DateTimeKind.Local).AddTicks(2670), "Sam Mendez", 119, "Drama, War", new DateTime(2020, 4, 19, 20, 49, 1, 605, DateTimeKind.Local).AddTicks(2705), "1917" },
                    { new Guid("d91406e4-bf02-4c0e-a719-6c4a44e49ee5"), new DateTime(2020, 4, 19, 20, 49, 1, 605, DateTimeKind.Local).AddTicks(2720), "Martin Scorsese", 209, "Biography, Crime, Drama", new DateTime(2020, 4, 19, 20, 49, 1, 605, DateTimeKind.Local).AddTicks(2722), "The Irishman" },
                    { new Guid("45ffdb54-d251-4776-bb9a-499d3b5fd3d3"), new DateTime(2020, 4, 19, 20, 49, 1, 605, DateTimeKind.Local).AddTicks(2725), "Quentin Tarantino", 161, "Comedy, Drama", new DateTime(2020, 4, 19, 20, 49, 1, 605, DateTimeKind.Local).AddTicks(2726), "Once Upoin a Time... In Hollywood" }
                });
        }
    }
}
