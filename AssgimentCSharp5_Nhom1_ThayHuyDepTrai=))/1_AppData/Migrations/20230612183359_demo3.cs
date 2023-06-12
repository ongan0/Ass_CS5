using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_AppData.Migrations
{
    public partial class demo3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Delivery_Addresses_Delivery_AddressID",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Delivery_Addresses_Users_CustomerID",
                table: "Delivery_Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Delivery_Addresses_CustomerID",
                table: "Delivery_Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Bills_Delivery_AddressID",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "Delivery_AddressID",
                table: "Bills");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Receiver_Address",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Receiver_Name",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "Receiver_Address",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "Receiver_Name",
                table: "Bills");

            migrationBuilder.AddColumn<Guid>(
                name: "Delivery_AddressID",
                table: "Bills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Addresses_CustomerID",
                table: "Delivery_Addresses",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_Delivery_AddressID",
                table: "Bills",
                column: "Delivery_AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Delivery_Addresses_Delivery_AddressID",
                table: "Bills",
                column: "Delivery_AddressID",
                principalTable: "Delivery_Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_Addresses_Users_CustomerID",
                table: "Delivery_Addresses",
                column: "CustomerID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
