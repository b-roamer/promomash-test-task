using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.ProvinceId);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_Users_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceId");
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2eb8fb8b-7c66-4413-b18f-f25e91ca0809"), new DateTime(2023, 10, 13, 17, 3, 31, 609, DateTimeKind.Utc).AddTicks(8700), "Kazakhstan", new DateTime(2023, 10, 13, 17, 3, 31, 609, DateTimeKind.Utc).AddTicks(8700) },
                    { new Guid("aa2f72aa-303c-45e5-a744-510e9152d83d"), new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(3230), "USA", new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(3230) }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "ProvinceId", "CountryId", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0e277eba-e766-4bd4-996f-ec4624603f47"), new Guid("2eb8fb8b-7c66-4413-b18f-f25e91ca0809"), new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(4300), "Almaty", new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(4300) },
                    { new Guid("133d9a2d-cee2-4629-bc13-7cab76ae68ff"), new Guid("aa2f72aa-303c-45e5-a744-510e9152d83d"), new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(8640), "Washington", new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(8640) },
                    { new Guid("537d09ab-9615-41f4-b4c8-bc4fee49c452"), new Guid("2eb8fb8b-7c66-4413-b18f-f25e91ca0809"), new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(8450), "Astana", new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(8450) },
                    { new Guid("e56ff022-a741-4545-8132-bc30206b310c"), new Guid("aa2f72aa-303c-45e5-a744-510e9152d83d"), new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(8630), "New York", new DateTime(2023, 10, 13, 17, 3, 31, 610, DateTimeKind.Utc).AddTicks(8630) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                table: "Provinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId",
                table: "Users",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProvinceId",
                table: "Users",
                column: "ProvinceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
