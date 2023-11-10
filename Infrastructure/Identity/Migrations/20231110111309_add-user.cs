using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class adduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4036c5b7-101c-4a8d-bbe6-cb816039b8d6", 0, "0e327e19-3771-4283-8fb3-9a97121dcf3f", "Bob", "Bob@test.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEKXyJrMq0+FaW4IIsHrbL4P9CNB12RUdFXIUZjvX3YzUqr1ZQJ+pxjSpJNrM644haQ==", null, false, "b9e8efc6-5f48-4030-bdf8-6c9810402a06", false, "Bob@test.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4036c5b7-101c-4a8d-bbe6-cb816039b8d6");
        }
    }
}
