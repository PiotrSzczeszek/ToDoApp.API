using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApp.Data.Migrations
{
    public partial class UsersUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hash",
                schema: "ToDoApp",
                table: "User",
                newName: "Password");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AccountCreated",
                schema: "ToDoApp",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "NOW()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                schema: "ToDoApp",
                table: "User",
                newName: "Hash");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AccountCreated",
                schema: "ToDoApp",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
