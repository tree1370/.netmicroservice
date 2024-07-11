using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOT.Identity.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshTokenTime",
                table: "UserRefreshTokens");

            migrationBuilder.RenameColumn(
                name: "RegisterDate",
                schema: "User",
                table: "users",
                newName: "UserNameInfo_BirthDate_Miladi");

            migrationBuilder.RenameColumn(
                name: "LastLoginDate",
                schema: "User",
                table: "users",
                newName: "RegisterDate_Miladi");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "UserRefreshTokens",
                newName: "ExpireDate_Miladi");

            migrationBuilder.RenameColumn(
                name: "PermissionFlag",
                table: "Permission",
                newName: "ActionName");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "User",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<int>(
                name: "AttempCount",
                schema: "User",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsLock",
                schema: "User",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastLoginDate_Ghamari",
                schema: "User",
                table: "users",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDate_Miladi",
                schema: "User",
                table: "users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastLoginDate_Shamsi",
                schema: "User",
                table: "users",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LockExpireDate_Ghamari",
                schema: "User",
                table: "users",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LockExpireDate_Miladi",
                schema: "User",
                table: "users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LockExpireDate_Shamsi",
                schema: "User",
                table: "users",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LockReason_Id",
                schema: "User",
                table: "users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogInType",
                schema: "User",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RegisterDate_Ghamari",
                schema: "User",
                table: "users",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegisterDate_Shamsi",
                schema: "User",
                table: "users",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserNameInfo_BirthDate_Ghamari",
                schema: "User",
                table: "users",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserNameInfo_BirthDate_Shamsi",
                schema: "User",
                table: "users",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserNameInfo_Gender",
                schema: "User",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreateDate_Ghamari",
                table: "UserRefreshTokens",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate_Miladi",
                table: "UserRefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateDate_Shamsi",
                table: "UserRefreshTokens",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExpireDate_Ghamari",
                table: "UserRefreshTokens",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExpireDate_Shamsi",
                table: "UserRefreshTokens",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreateLog_Date_Ghamari",
                table: "Role",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateLog_Date_Miladi",
                table: "Role",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateLog_Date_Shamsi",
                table: "Role",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CreateLog_UserId",
                table: "Role",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "DeleteLog_Date_Ghamari",
                table: "Role",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteLog_Date_Miladi",
                table: "Role",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteLog_Date_Shamsi",
                table: "Role",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DeleteLog_IsDeleted",
                table: "Role",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteLog_UserId",
                table: "Role",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "TypeAccess",
                table: "Role",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreateLog_Date_Ghamari",
                table: "Permission",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateLog_Date_Miladi",
                table: "Permission",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateLog_Date_Shamsi",
                table: "Permission",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CreateLog_UserId",
                table: "Permission",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "DeleteLog_Date_Ghamari",
                table: "Permission",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteLog_Date_Miladi",
                table: "Permission",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeleteLog_Date_Shamsi",
                table: "Permission",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DeleteLog_IsDeleted",
                table: "Permission",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteLog_UserId",
                table: "Permission",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ChangeLockReasons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(1080)", maxLength: 1080, nullable: false),
                    IsLockType = table.Column<bool>(type: "bit", nullable: false),
                    DeleteLog_IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteLog_UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    DeleteLog_Date_Miladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteLog_Date_Shamsi = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    DeleteLog_Date_Ghamari = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    CreateLog_UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateLog_Date_Miladi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateLog_Date_Shamsi = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    CreateLog_Date_Ghamari = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeLockReasons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_LockReason_Id",
                schema: "User",
                table: "users",
                column: "LockReason_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_ChangeLockReasons_LockReason_Id",
                schema: "User",
                table: "users",
                column: "LockReason_Id",
                principalTable: "ChangeLockReasons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_ChangeLockReasons_LockReason_Id",
                schema: "User",
                table: "users");

            migrationBuilder.DropTable(
                name: "ChangeLockReasons");

            migrationBuilder.DropIndex(
                name: "IX_users_LockReason_Id",
                schema: "User",
                table: "users");

            migrationBuilder.DropColumn(
                name: "AttempCount",
                schema: "User",
                table: "users");

            migrationBuilder.DropColumn(
                name: "IsLock",
                schema: "User",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LastLoginDate_Ghamari",
                schema: "User",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LastLoginDate_Miladi",
                schema: "User",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LastLoginDate_Shamsi",
                schema: "User",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LockExpireDate_Ghamari",
                schema: "User",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LockExpireDate_Miladi",
                schema: "User",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LockExpireDate_Shamsi",
                schema: "User",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LockReason_Id",
                schema: "User",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LogInType",
                schema: "User",
                table: "users");

            migrationBuilder.DropColumn(
                name: "RegisterDate_Ghamari",
                schema: "User",
                table: "users");

            migrationBuilder.DropColumn(
                name: "RegisterDate_Shamsi",
                schema: "User",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserNameInfo_BirthDate_Ghamari",
                schema: "User",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserNameInfo_BirthDate_Shamsi",
                schema: "User",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserNameInfo_Gender",
                schema: "User",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CreateDate_Ghamari",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "CreateDate_Miladi",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "CreateDate_Shamsi",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "ExpireDate_Ghamari",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "ExpireDate_Shamsi",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "CreateLog_Date_Ghamari",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreateLog_Date_Miladi",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreateLog_Date_Shamsi",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreateLog_UserId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "DeleteLog_Date_Ghamari",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "DeleteLog_Date_Miladi",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "DeleteLog_Date_Shamsi",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "DeleteLog_IsDeleted",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "DeleteLog_UserId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "TypeAccess",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "CreateLog_Date_Ghamari",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "CreateLog_Date_Miladi",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "CreateLog_Date_Shamsi",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "CreateLog_UserId",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "DeleteLog_Date_Ghamari",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "DeleteLog_Date_Miladi",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "DeleteLog_Date_Shamsi",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "DeleteLog_IsDeleted",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "DeleteLog_UserId",
                table: "Permission");

            migrationBuilder.RenameColumn(
                name: "UserNameInfo_BirthDate_Miladi",
                schema: "User",
                table: "users",
                newName: "RegisterDate");

            migrationBuilder.RenameColumn(
                name: "RegisterDate_Miladi",
                schema: "User",
                table: "users",
                newName: "LastLoginDate");

            migrationBuilder.RenameColumn(
                name: "ExpireDate_Miladi",
                table: "UserRefreshTokens",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ActionName",
                table: "Permission",
                newName: "PermissionFlag");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "User",
                table: "users",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "RefreshTokenTime",
                table: "UserRefreshTokens",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
