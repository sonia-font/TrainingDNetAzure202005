using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Training.Data.EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    DirectedBy = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}
