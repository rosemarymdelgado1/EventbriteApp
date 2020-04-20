using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceCatalogApi.Migrations
{
    public partial class Olive_0413 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "eventcategoryhilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "eventitemhilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "eventlocationhilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "eventtypehilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "eventcategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Category = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventcategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "eventlocation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    State = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventlocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "eventtype",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventtype", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "eventItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    EventDateTime = table.Column<DateTime>(nullable: false),
                    Venue = table.Column<string>(maxLength: 100, nullable: false),
                    Organizer = table.Column<string>(maxLength: 100, nullable: false),
                    PictureUrl = table.Column<string>(nullable: true),
                    EventCategoryId = table.Column<int>(nullable: false),
                    EventTypeId = table.Column<int>(nullable: false),
                    EventLocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_eventItem_eventcategory_EventCategoryId",
                        column: x => x.EventCategoryId,
                        principalTable: "eventcategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_eventItem_eventlocation_EventLocationId",
                        column: x => x.EventLocationId,
                        principalTable: "eventlocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_eventItem_eventtype_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "eventtype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_eventItem_EventCategoryId",
                table: "eventItem",
                column: "EventCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_eventItem_EventLocationId",
                table: "eventItem",
                column: "EventLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_eventItem_EventTypeId",
                table: "eventItem",
                column: "EventTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventItem");

            migrationBuilder.DropTable(
                name: "eventcategory");

            migrationBuilder.DropTable(
                name: "eventlocation");

            migrationBuilder.DropTable(
                name: "eventtype");

            migrationBuilder.DropSequence(
                name: "eventcategoryhilo");

            migrationBuilder.DropSequence(
                name: "eventitemhilo");

            migrationBuilder.DropSequence(
                name: "eventlocationhilo");

            migrationBuilder.DropSequence(
                name: "eventtypehilo");
        }
    }
}
