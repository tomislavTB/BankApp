using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(maxLength: 5, nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IBAN = table.Column<string>(maxLength: 15, nullable: false),
                    Phone = table.Column<string>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banks_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    IBAN = table.Column<string>(maxLength: 15, nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Savings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartOfSaving = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Interest_rate = table.Column<decimal>(nullable: false),
                    AccountTypeId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    BankId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Savings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Savings_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Savings_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Savings_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Current Account" },
                    { 2, "Savings Account" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Croatia" },
                    { 2, "United States" },
                    { 3, "France" },
                    { 4, "England" },
                    { 5, "Netherlands" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name", "Zip" },
                values: new object[,]
                {
                    { 1, 1, "Zagreb", "10000" },
                    { 2, 2, "New York", "10001" },
                    { 4, 3, "Paris", "75000" },
                    { 3, 4, "London ", "56273" },
                    { 5, 5, "Amsterdam ", "1011" }
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "CityId", "Email", "IBAN", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, 1, "PBZ@nesto.com", "221111111111111", "PBZ", "0915555555" },
                    { 2, 2, "ParisBank@nesto.com", "331111111111111", "The Paris National Bank", "0917777777" },
                    { 3, 2, "NYbank@nesto.com", "441111111111111", "Bank of New York", "0918888888" },
                    { 4, 2, "Lloyds@nesto.com", "551111111111111", "Lloyds Bank", "0919991111" },
                    { 5, 2, "Rabobank@nesto.com", "661111111111111", "Rabobank", "0918751111" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "Birthdate", "CityId", "Email", "FirstName", "IBAN", "LastName" },
                values: new object[,]
                {
                    { 1, "Tatooine 5", new DateTime(1996, 3, 1, 11, 30, 15, 0, DateTimeKind.Unspecified), 1, "lukeS@nesto.com", "Luke", "111111111111111", "Skywalker" },
                    { 3, "Alderaan  5", new DateTime(1996, 3, 1, 11, 30, 15, 0, DateTimeKind.Unspecified), 1, "Princess@nesto.com", "Leia", "333333333333333", "Organa" },
                    { 4, "Cantonica 9", new DateTime(1994, 3, 1, 11, 30, 15, 0, DateTimeKind.Unspecified), 1, "Chewie@nesto.com", "Han", "444444444444444", "Solo" },
                    { 5, "Dagobah 17", new DateTime(1984, 3, 1, 11, 30, 15, 0, DateTimeKind.Unspecified), 1, "obi_wan@nesto.com", "Obi-Wan", "555555555555555", "Kenobi" },
                    { 2, "Naboo  3", new DateTime(1989, 1, 15, 10, 30, 15, 0, DateTimeKind.Unspecified), 2, "Anakin@nesto.com", "Darth", "22222222222222", "Vader" }
                });

            migrationBuilder.InsertData(
                table: "Savings",
                columns: new[] { "Id", "AccountTypeId", "Amount", "BankId", "ClientId", "Interest_rate", "StartOfSaving" },
                values: new object[,]
                {
                    { 1, 1, 500000, 1, 1, 0.2m, new DateTime(2015, 3, 1, 11, 30, 15, 0, DateTimeKind.Unspecified) },
                    { 3, 1, 700000, 3, 3, 0.3m, new DateTime(2018, 1, 1, 15, 30, 15, 0, DateTimeKind.Unspecified) },
                    { 4, 2, 180000, 4, 4, 0.0m, new DateTime(2011, 7, 1, 9, 30, 15, 0, DateTimeKind.Unspecified) },
                    { 5, 1, 175800, 5, 5, 0.4m, new DateTime(2014, 9, 1, 7, 30, 15, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 100000, 2, 2, 0.0m, new DateTime(2017, 4, 1, 13, 30, 15, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Banks_CityId",
                table: "Banks",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CityId",
                table: "Clients",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Savings_AccountTypeId",
                table: "Savings",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Savings_BankId",
                table: "Savings",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Savings_ClientId",
                table: "Savings",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Savings");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
