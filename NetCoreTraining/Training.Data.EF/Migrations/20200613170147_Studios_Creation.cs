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
                    { new Guid("d9c734cf-76f6-4db6-839a-000000000001"), new DateTime(2020, 6, 13, 14, 1, 47, 22, DateTimeKind.Local).AddTicks(7842), new DateTime(2020, 6, 13, 14, 1, 47, 22, DateTimeKind.Local).AddTicks(7859), "Studio 1" },
                    { new Guid("d9c734cf-76f6-4db6-839a-000000000002"), new DateTime(2020, 6, 13, 14, 1, 47, 22, DateTimeKind.Local).AddTicks(8438), new DateTime(2020, 6, 13, 14, 1, 47, 22, DateTimeKind.Local).AddTicks(8442), "Studio 2" },
                    { new Guid("d9c734cf-76f6-4db6-839a-000000000003"), new DateTime(2020, 6, 13, 14, 1, 47, 22, DateTimeKind.Local).AddTicks(8461), new DateTime(2020, 6, 13, 14, 1, 47, 22, DateTimeKind.Local).AddTicks(8462), "Studio 3" },
                    { new Guid("d9c734cf-76f6-4db6-839a-000000000004"), new DateTime(2020, 6, 13, 14, 1, 47, 22, DateTimeKind.Local).AddTicks(8465), new DateTime(2020, 6, 13, 14, 1, 47, 22, DateTimeKind.Local).AddTicks(8466), "Studio 4" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CreationDate", "DirectedBy", "Duration", "Genre", "ModifiedDate", "Name", "StudioId" },
                values: new object[,]
                {
                    { new Guid("380adbe8-4a03-45fd-8e49-40e7113d347f"), new DateTime(2020, 6, 13, 14, 1, 47, 19, DateTimeKind.Local).AddTicks(1993), "Bong Joon Ho", 132, "Comedy, Drama, Trhiller", new DateTime(2020, 6, 13, 14, 1, 47, 20, DateTimeKind.Local).AddTicks(7859), "Parasite", new Guid("d9c734cf-76f6-4db6-839a-000000000001") },
                    { new Guid("0b326dfe-a0c6-491b-b529-cc93bd1f91ff"), new DateTime(2020, 6, 13, 14, 1, 47, 20, DateTimeKind.Local).AddTicks(9655), "Sam Mendez", 119, "Drama, War", new DateTime(2020, 6, 13, 14, 1, 47, 20, DateTimeKind.Local).AddTicks(9684), "1917", new Guid("d9c734cf-76f6-4db6-839a-000000000002") },
                    { new Guid("0698d753-6dec-49d9-8d72-cd28dcb3eb9b"), new DateTime(2020, 6, 13, 14, 1, 47, 20, DateTimeKind.Local).AddTicks(9708), "Martin Scorsese", 209, "Biography, Crime, Drama", new DateTime(2020, 6, 13, 14, 1, 47, 20, DateTimeKind.Local).AddTicks(9710), "The Irishman", new Guid("d9c734cf-76f6-4db6-839a-000000000003") },
                    { new Guid("5276c2d3-cc9b-48b4-9880-fdacf3df502e"), new DateTime(2020, 6, 13, 14, 1, 47, 20, DateTimeKind.Local).AddTicks(9717), "Quentin Tarantino", 161, "Comedy, Drama", new DateTime(2020, 6, 13, 14, 1, 47, 20, DateTimeKind.Local).AddTicks(9718), "Once Upoin a Time... In Hollywood", new Guid("d9c734cf-76f6-4db6-839a-000000000004") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Studios");

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("0698d753-6dec-49d9-8d72-cd28dcb3eb9b"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("0b326dfe-a0c6-491b-b529-cc93bd1f91ff"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("380adbe8-4a03-45fd-8e49-40e7113d347f"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("5276c2d3-cc9b-48b4-9880-fdacf3df502e"));

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
