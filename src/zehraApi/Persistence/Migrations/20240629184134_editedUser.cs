using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class editedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("60de87a3-825c-4ce6-8ff5-799ce7679498"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1a4775dc-610d-487c-83eb-e017780aaa04"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Photo", "UpdatedDate" },
                values: new object[] { new Guid("da3d1347-23d8-4ce0-b701-dc89b35396d5"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "info@serdarsevimli.com", null, null, new byte[] { 12, 139, 30, 167, 164, 192, 201, 88, 120, 81, 212, 11, 52, 100, 42, 54, 191, 104, 153, 185, 3, 245, 90, 172, 18, 15, 33, 253, 35, 86, 86, 217, 239, 6, 84, 233, 38, 47, 198, 162, 209, 109, 49, 108, 103, 19, 61, 234, 35, 198, 224, 54, 36, 133, 42, 84, 153, 223, 197, 222, 89, 87, 35, 120 }, new byte[] { 12, 92, 133, 30, 146, 231, 69, 153, 32, 98, 254, 169, 74, 233, 45, 157, 21, 74, 202, 63, 100, 129, 215, 4, 192, 81, 96, 181, 195, 240, 7, 244, 37, 162, 145, 203, 3, 200, 66, 200, 211, 167, 167, 105, 215, 217, 65, 76, 221, 135, 45, 144, 217, 147, 3, 156, 203, 30, 170, 155, 130, 46, 177, 31, 204, 206, 69, 152, 87, 107, 110, 117, 241, 105, 131, 144, 69, 193, 110, 175, 148, 126, 87, 64, 241, 115, 152, 125, 29, 9, 124, 180, 44, 41, 137, 209, 190, 119, 170, 96, 122, 217, 224, 26, 65, 4, 204, 1, 14, 155, 190, 148, 202, 207, 119, 57, 201, 156, 163, 50, 191, 156, 145, 120, 153, 223, 19, 28 }, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d41661b4-5498-44cc-bb64-feac7ae8db1f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("da3d1347-23d8-4ce0-b701-dc89b35396d5") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d41661b4-5498-44cc-bb64-feac7ae8db1f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("da3d1347-23d8-4ce0-b701-dc89b35396d5"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "Photo", "UpdatedDate" },
                values: new object[] { new Guid("1a4775dc-610d-487c-83eb-e017780aaa04"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "info@serdarsevimli.com", new byte[] { 85, 86, 108, 62, 194, 25, 235, 206, 236, 28, 3, 13, 133, 14, 45, 17, 238, 83, 102, 198, 111, 67, 181, 228, 46, 49, 62, 64, 39, 199, 100, 121, 244, 34, 230, 188, 173, 169, 63, 254, 108, 139, 62, 248, 51, 102, 46, 191, 138, 177, 108, 54, 125, 38, 194, 131, 151, 174, 135, 204, 209, 5, 40, 90 }, new byte[] { 238, 155, 109, 247, 123, 169, 16, 238, 185, 163, 140, 75, 250, 221, 92, 75, 180, 9, 167, 73, 226, 38, 61, 48, 157, 51, 28, 24, 214, 69, 155, 238, 76, 15, 49, 254, 65, 130, 170, 249, 1, 199, 69, 220, 227, 242, 196, 20, 1, 183, 85, 96, 193, 138, 255, 100, 101, 189, 64, 138, 179, 213, 215, 188, 145, 52, 79, 164, 171, 202, 152, 76, 138, 223, 234, 46, 27, 135, 87, 231, 59, 176, 67, 69, 239, 58, 110, 151, 144, 63, 28, 75, 198, 146, 237, 139, 76, 56, 248, 108, 52, 145, 130, 219, 148, 92, 113, 5, 247, 183, 201, 177, 23, 204, 56, 116, 33, 87, 81, 234, 224, 21, 228, 202, 101, 119, 249, 90 }, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("60de87a3-825c-4ce6-8ff5-799ce7679498"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("1a4775dc-610d-487c-83eb-e017780aaa04") });
        }
    }
}
