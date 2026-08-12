using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketInventoryApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddTransferListFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferList_Products_SelectedProductId",
                table: "TransferList");

            migrationBuilder.DropIndex(
                name: "IX_TransferList_SelectedProductId",
                table: "TransferList");

            migrationBuilder.RenameColumn(
                name: "SelectedProductId",
                table: "TransferList",
                newName: "Quantity");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "TransferList",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedByUserId",
                table: "TransferList",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "TransferList",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "TransferList",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransferList_LocationId",
                table: "TransferList",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferList_ModifiedByUserId",
                table: "TransferList",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferList_ProductId",
                table: "TransferList",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransferList_Locations_LocationId",
                table: "TransferList",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferList_Products_ProductId",
                table: "TransferList",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferList_Users_ModifiedByUserId",
                table: "TransferList",
                column: "ModifiedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferList_Locations_LocationId",
                table: "TransferList");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferList_Products_ProductId",
                table: "TransferList");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferList_Users_ModifiedByUserId",
                table: "TransferList");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_TransferList_LocationId",
                table: "TransferList");

            migrationBuilder.DropIndex(
                name: "IX_TransferList_ModifiedByUserId",
                table: "TransferList");

            migrationBuilder.DropIndex(
                name: "IX_TransferList_ProductId",
                table: "TransferList");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "TransferList");

            migrationBuilder.DropColumn(
                name: "ModifiedByUserId",
                table: "TransferList");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "TransferList");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "TransferList");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "TransferList",
                newName: "SelectedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferList_SelectedProductId",
                table: "TransferList",
                column: "SelectedProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransferList_Products_SelectedProductId",
                table: "TransferList",
                column: "SelectedProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
