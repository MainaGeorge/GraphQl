using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommanderGQL.Migrations
{
    public partial class SeedingCommandData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "Id", "CommandLineSnippet", "HowTo", "PlatformId" },
                values: new object[,]
                {
                    { 1, "dotnet new solution -n {name}", "create a new solution", 1 },
                    { 2, "mkdir {name}", "create a new folder", 2 },
                    { 3, "docker container ls --all", "list all containers", 3 },
                    { 4, "Get-Process -Name {name}", "how to get a process by name", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Commands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Commands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Commands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Commands",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
