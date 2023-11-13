using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Infra.Migrations
{
    public partial class moreinformationsaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observation",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverName",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 88888,
                column: "ConcurrencyStamp",
                value: "4052ca73-3363-4345-893a-31e13dfb78d4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "10ac38b9-2e8d-4ce9-b5a9-bbec6e8f5d7f");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Observation",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ReceiverName",
                table: "Addresses");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 88888,
                column: "ConcurrencyStamp",
                value: "0bbee4bf-3927-4681-94ff-e14eebe44c29");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "ef8e8a21-9d49-42f5-bfcb-eba3d02aaece");
        }
    }
}
