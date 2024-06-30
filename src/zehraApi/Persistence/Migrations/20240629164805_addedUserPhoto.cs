using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedUserPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("85c2c049-9cc2-482a-894d-457a404d759d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5d14000-9851-45c9-a83f-613b7f886ab4"));

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "Photo", "UpdatedDate" },
                values: new object[] { new Guid("1a4775dc-610d-487c-83eb-e017780aaa04"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "info@serdarsevimli.com", new byte[] { 85, 86, 108, 62, 194, 25, 235, 206, 236, 28, 3, 13, 133, 14, 45, 17, 238, 83, 102, 198, 111, 67, 181, 228, 46, 49, 62, 64, 39, 199, 100, 121, 244, 34, 230, 188, 173, 169, 63, 254, 108, 139, 62, 248, 51, 102, 46, 191, 138, 177, 108, 54, 125, 38, 194, 131, 151, 174, 135, 204, 209, 5, 40, 90 }, new byte[] { 238, 155, 109, 247, 123, 169, 16, 238, 185, 163, 140, 75, 250, 221, 92, 75, 180, 9, 167, 73, 226, 38, 61, 48, 157, 51, 28, 24, 214, 69, 155, 238, 76, 15, 49, 254, 65, 130, 170, 249, 1, 199, 69, 220, 227, 242, 196, 20, 1, 183, 85, 96, 193, 138, 255, 100, 101, 189, 64, 138, 179, 213, 215, 188, 145, 52, 79, 164, 171, 202, 152, 76, 138, 223, 234, 46, 27, 135, 87, 231, 59, 176, 67, 69, 239, 58, 110, 151, 144, 63, 28, 75, 198, 146, 237, 139, 76, 56, 248, 108, 52, 145, 130, 219, 148, 92, 113, 5, 247, 183, 201, 177, 23, 204, 56, 116, 33, 87, 81, 234, 224, 21, 228, 202, 101, 119, 249, 90 }, null, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("60de87a3-825c-4ce6-8ff5-799ce7679498"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("1a4775dc-610d-487c-83eb-e017780aaa04") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("60de87a3-825c-4ce6-8ff5-799ce7679498"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1a4775dc-610d-487c-83eb-e017780aaa04"));

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("d5d14000-9851-45c9-a83f-613b7f886ab4"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "info@serdarsevimli.com", new byte[] { 68, 124, 227, 85, 57, 80, 169, 152, 126, 76, 87, 196, 94, 117, 80, 197, 135, 134, 142, 38, 91, 163, 51, 137, 62, 81, 28, 28, 245, 55, 246, 180, 51, 85, 32, 214, 34, 164, 167, 235, 21, 97, 178, 31, 58, 28, 250, 77, 43, 230, 18, 36, 227, 131, 239, 23, 166, 225, 222, 34, 67, 55, 220, 106 }, new byte[] { 146, 141, 237, 118, 130, 46, 234, 59, 116, 133, 224, 161, 193, 47, 133, 215, 145, 139, 91, 82, 189, 230, 241, 134, 166, 191, 92, 31, 162, 130, 61, 150, 75, 11, 56, 55, 51, 218, 163, 217, 58, 126, 230, 206, 128, 94, 149, 139, 31, 50, 116, 97, 36, 150, 188, 228, 252, 212, 178, 224, 211, 252, 187, 244, 195, 130, 118, 152, 134, 127, 215, 104, 58, 4, 148, 233, 66, 242, 222, 206, 158, 101, 237, 155, 145, 158, 225, 0, 94, 203, 233, 153, 124, 158, 130, 180, 190, 29, 93, 19, 198, 78, 220, 97, 35, 242, 115, 143, 59, 188, 92, 109, 209, 86, 229, 226, 28, 208, 195, 200, 103, 107, 247, 214, 195, 149, 182, 86 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("85c2c049-9cc2-482a-894d-457a404d759d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("d5d14000-9851-45c9-a83f-613b7f886ab4") });
        }
    }
}
