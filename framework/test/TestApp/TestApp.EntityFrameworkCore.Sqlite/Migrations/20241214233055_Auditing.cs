﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace TestApp.EntityFrameworkCore.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class Auditing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastActiveTime",
                table: "People",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 14, 15, 30, 54, 757, DateTimeKind.Local).AddTicks(8001),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2024, 12, 14, 14, 41, 44, 848, DateTimeKind.Local).AddTicks(924));

            migrationBuilder.AlterColumn<DateTime>(
                name: "HasDefaultValue",
                table: "People",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 14, 15, 30, 54, 758, DateTimeKind.Local).AddTicks(9096),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2024, 12, 14, 14, 41, 44, 849, DateTimeKind.Local).AddTicks(1732));

            migrationBuilder.CreateTable(
                name: "AbpAuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ApplicationName = table.Column<String>(type: "TEXT", maxLength: 96, nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    UserName = table.Column<String>(type: "TEXT", maxLength: 256, nullable: true),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true),
                    TenantName = table.Column<String>(type: "TEXT", maxLength: 64, nullable: true),
                    ImpersonatorUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ImpersonatorUserName = table.Column<String>(type: "TEXT", maxLength: 256, nullable: true),
                    ImpersonatorTenantId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ImpersonatorTenantName = table.Column<String>(type: "TEXT", maxLength: 64, nullable: true),
                    ExecutionTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExecutionDuration = table.Column<Int32>(type: "INTEGER", nullable: false),
                    ClientIpAddress = table.Column<String>(type: "TEXT", maxLength: 64, nullable: true),
                    ClientName = table.Column<String>(type: "TEXT", maxLength: 128, nullable: true),
                    ClientId = table.Column<String>(type: "TEXT", maxLength: 64, nullable: true),
                    CorrelationId = table.Column<String>(type: "TEXT", maxLength: 64, nullable: true),
                    BrowserInfo = table.Column<String>(type: "TEXT", maxLength: 512, nullable: true),
                    HttpMethod = table.Column<String>(type: "TEXT", maxLength: 16, nullable: true),
                    Url = table.Column<String>(type: "TEXT", maxLength: 256, nullable: true),
                    Exceptions = table.Column<String>(type: "TEXT", nullable: true),
                    Comments = table.Column<String>(type: "TEXT", maxLength: 256, nullable: true),
                    HttpStatusCode = table.Column<Int32>(type: "INTEGER", nullable: true),
                    ExtraProperties = table.Column<String>(type: "TEXT", nullable: false),
                    ConcurrencyStamp = table.Column<String>(type: "TEXT", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpAuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpAuditLogActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true),
                    AuditLogId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServiceName = table.Column<String>(type: "TEXT", maxLength: 256, nullable: true),
                    MethodName = table.Column<String>(type: "TEXT", maxLength: 128, nullable: true),
                    Parameters = table.Column<String>(type: "TEXT", maxLength: 2000, nullable: true),
                    ExecutionTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExecutionDuration = table.Column<Int32>(type: "INTEGER", nullable: false),
                    ExtraProperties = table.Column<String>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpAuditLogActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpAuditLogActions_AbpAuditLogs_AuditLogId",
                        column: x => x.AuditLogId,
                        principalTable: "AbpAuditLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpEntityChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AuditLogId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ChangeTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ChangeType = table.Column<Byte>(type: "INTEGER", nullable: false),
                    EntityTenantId = table.Column<Guid>(type: "TEXT", nullable: true),
                    EntityId = table.Column<String>(type: "TEXT", maxLength: 128, nullable: true),
                    EntityTypeFullName = table.Column<String>(type: "TEXT", maxLength: 128, nullable: false),
                    ExtraProperties = table.Column<String>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpEntityChanges_AbpAuditLogs_AuditLogId",
                        column: x => x.AuditLogId,
                        principalTable: "AbpAuditLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpEntityPropertyChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: true),
                    EntityChangeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    NewValue = table.Column<String>(type: "TEXT", maxLength: 512, nullable: true),
                    OriginalValue = table.Column<String>(type: "TEXT", maxLength: 512, nullable: true),
                    PropertyName = table.Column<String>(type: "TEXT", maxLength: 128, nullable: false),
                    PropertyTypeFullName = table.Column<String>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityPropertyChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpEntityPropertyChanges_AbpEntityChanges_EntityChangeId",
                        column: x => x.EntityChangeId,
                        principalTable: "AbpEntityChanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogActions_AuditLogId",
                table: "AbpAuditLogActions",
                column: "AuditLogId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogActions_TenantId_ServiceName_MethodName_ExecutionTime",
                table: "AbpAuditLogActions",
                columns: new[] { "TenantId", "ServiceName", "MethodName", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_TenantId_ExecutionTime",
                table: "AbpAuditLogs",
                columns: new[] { "TenantId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_TenantId_UserId_ExecutionTime",
                table: "AbpAuditLogs",
                columns: new[] { "TenantId", "UserId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChanges_AuditLogId",
                table: "AbpEntityChanges",
                column: "AuditLogId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChanges_TenantId_EntityTypeFullName_EntityId",
                table: "AbpEntityChanges",
                columns: new[] { "TenantId", "EntityTypeFullName", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityPropertyChanges_EntityChangeId",
                table: "AbpEntityPropertyChanges",
                column: "EntityChangeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpAuditLogActions");

            migrationBuilder.DropTable(
                name: "AbpEntityPropertyChanges");

            migrationBuilder.DropTable(
                name: "AbpEntityChanges");

            migrationBuilder.DropTable(
                name: "AbpAuditLogs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastActiveTime",
                table: "People",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 14, 14, 41, 44, 848, DateTimeKind.Local).AddTicks(924),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2024, 12, 14, 15, 30, 54, 757, DateTimeKind.Local).AddTicks(8001));

            migrationBuilder.AlterColumn<DateTime>(
                name: "HasDefaultValue",
                table: "People",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 14, 14, 41, 44, 849, DateTimeKind.Local).AddTicks(1732),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2024, 12, 14, 15, 30, 54, 758, DateTimeKind.Local).AddTicks(9096));
        }
    }
}
