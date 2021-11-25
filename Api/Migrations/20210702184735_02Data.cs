using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class _02Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Travel",
                columns: new[] { "Id", "Date", "DateRegister", "Destiny" },
                values: new object[,]
                {
                    { new Guid("f417b5c0-5d27-413e-a6af-36e5db077890"), new DateTime(2021, 7, 2, 15, 47, 35, 320, DateTimeKind.Local).AddTicks(195), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1011), "Rio de Janeiro" },
                    { new Guid("224ee90c-027e-4533-8507-2e0b9cde0125"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1586), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1587), "Porto Alegre" },
                    { new Guid("fa14e6d6-c0f8-4cc8-9a0b-fc468f75a5cd"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1577), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1579), "Boston" },
                    { new Guid("fc682837-233e-4f6f-ae9c-79bdb53f530b"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1569), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1570), "Hamburgo" },
                    { new Guid("4d69ee14-6e0f-4ad6-9c56-e63cfdd3b41c"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1560), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1561), "Berlim" },
                    { new Guid("1cefe41b-7433-4395-9c23-7bb8d44e3aff"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1551), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1552), "Munique" },
                    { new Guid("59122d88-e508-4340-9409-c8b2cea65c7e"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1542), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1543), "Lisboa" },
                    { new Guid("25cc01c5-20d0-45a7-b76c-182c6fdad6d8"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1533), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1534), "Porto" },
                    { new Guid("3d670312-4950-4f68-8c43-0246837f330a"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1524), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1525), "Barcelona" },
                    { new Guid("ed83637d-75d7-47e7-abb5-9a010fd6eae6"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1515), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1516), "Valencia" },
                    { new Guid("3bf2c14b-44d3-4212-aaf3-bf8ff8cc15df"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1506), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1507), "Madrid" },
                    { new Guid("9f28b968-f19c-4f3c-9781-badea1739a2e"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1595), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1596), "Tokio" },
                    { new Guid("39eb5302-2139-4be7-be42-66ec34b6bea8"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1497), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1499), "Liverpool" },
                    { new Guid("9d315805-5a98-4bbd-808a-fe52deca0ca3"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1479), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1481), "Londres" },
                    { new Guid("42c98e99-d212-4d15-a005-d924d90b7831"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1470), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1472), "Nova York" },
                    { new Guid("2f8694d7-8f4d-455b-a78c-e4e249099169"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1461), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1463), "Cancum" },
                    { new Guid("dba4343a-c5b6-444c-a504-1f21a5db5dc7"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1452), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1454), "Turim" },
                    { new Guid("bb74cc0e-017d-4ead-84ce-5565603ec085"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1444), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1445), "Roma" },
                    { new Guid("8cd16bf1-e31e-4125-a960-a7ab0b055415"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1435), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1436), "Milão" },
                    { new Guid("de9d286a-23b8-4bbc-9ee6-b3736a1f638d"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1426), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1427), "Florianopolis" },
                    { new Guid("7d430870-4c50-4975-a286-bf34d12e91c7"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1417), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1418), "São Paulo" },
                    { new Guid("646d4da0-e6ff-405d-8eb4-4a5beacf89fc"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1407), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1409), "Maceio" },
                    { new Guid("fed72eff-29f9-4361-84a0-835cbac75662"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1380), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1392), "Natal" },
                    { new Guid("d109b4c1-e18e-4b1e-b535-11d06b65ca23"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1488), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1490), "Manchester" },
                    { new Guid("d415069d-cefc-4cde-ad0c-9151127f37f0"), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1604), new DateTime(2021, 7, 2, 15, 47, 35, 323, DateTimeKind.Local).AddTicks(1605), "Moscow" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("1cefe41b-7433-4395-9c23-7bb8d44e3aff"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("224ee90c-027e-4533-8507-2e0b9cde0125"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("25cc01c5-20d0-45a7-b76c-182c6fdad6d8"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("2f8694d7-8f4d-455b-a78c-e4e249099169"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("39eb5302-2139-4be7-be42-66ec34b6bea8"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("3bf2c14b-44d3-4212-aaf3-bf8ff8cc15df"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("3d670312-4950-4f68-8c43-0246837f330a"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("42c98e99-d212-4d15-a005-d924d90b7831"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("4d69ee14-6e0f-4ad6-9c56-e63cfdd3b41c"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("59122d88-e508-4340-9409-c8b2cea65c7e"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("646d4da0-e6ff-405d-8eb4-4a5beacf89fc"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("7d430870-4c50-4975-a286-bf34d12e91c7"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("8cd16bf1-e31e-4125-a960-a7ab0b055415"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("9d315805-5a98-4bbd-808a-fe52deca0ca3"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("9f28b968-f19c-4f3c-9781-badea1739a2e"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("bb74cc0e-017d-4ead-84ce-5565603ec085"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("d109b4c1-e18e-4b1e-b535-11d06b65ca23"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("d415069d-cefc-4cde-ad0c-9151127f37f0"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("dba4343a-c5b6-444c-a504-1f21a5db5dc7"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("de9d286a-23b8-4bbc-9ee6-b3736a1f638d"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("ed83637d-75d7-47e7-abb5-9a010fd6eae6"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("f417b5c0-5d27-413e-a6af-36e5db077890"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("fa14e6d6-c0f8-4cc8-9a0b-fc468f75a5cd"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("fc682837-233e-4f6f-ae9c-79bdb53f530b"));

            migrationBuilder.DeleteData(
                table: "Travel",
                keyColumn: "Id",
                keyValue: new Guid("fed72eff-29f9-4361-84a0-835cbac75662"));
        }
    }
}
