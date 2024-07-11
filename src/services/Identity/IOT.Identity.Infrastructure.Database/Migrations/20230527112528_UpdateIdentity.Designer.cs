﻿// <auto-generated />
using System;
using IOT.Identity.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IOT.Identity.Infrastructure.Database.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    [Migration("20230527112528_UpdateIdentity")]
    partial class UpdateIdentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IOT.Identity.Domain.Core.ChangeLockReason", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsLockType")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1080)
                        .HasColumnType("nvarchar(1080)");

                    b.HasKey("Id");

                    b.ToTable("ChangeLockReasons", (string)null);
                });

            modelBuilder.Entity("IOT.Identity.Domain.Core.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PermissionTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("IOT.Identity.Domain.Core.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeAccess")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("IOT.Identity.Domain.Core.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AttempCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLock")
                        .HasColumnType("bit");

                    b.Property<long?>("LockReason_Id")
                        .HasColumnType("bigint");

                    b.Property<int>("LogInType")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LockReason_Id");

                    b.ToTable("users", "User");
                });

            modelBuilder.Entity("IOT.Identity.Domain.Core.UserRefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserRefreshTokens", (string)null);
                });

            modelBuilder.Entity("IOT.Identity.Domain.Core.ChangeLockReason", b =>
                {
                    b.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.CreateLog", "CreateLog", b1 =>
                        {
                            b1.Property<long>("ChangeLockReasonId")
                                .HasColumnType("bigint");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("ChangeLockReasonId");

                            b1.ToTable("ChangeLockReasons");

                            b1.WithOwner()
                                .HasForeignKey("ChangeLockReasonId");

                            b1.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.DateTimeConvert", "Date", b2 =>
                                {
                                    b2.Property<long>("CreateLogChangeLockReasonId")
                                        .HasColumnType("bigint");

                                    b2.Property<string>("Ghamari")
                                        .IsRequired()
                                        .HasMaxLength(14)
                                        .HasColumnType("nvarchar(14)");

                                    b2.Property<DateTime?>("Miladi")
                                        .IsRequired()
                                        .HasColumnType("datetime2");

                                    b2.Property<string>("Shamsi")
                                        .IsRequired()
                                        .HasMaxLength(14)
                                        .HasColumnType("nvarchar(14)");

                                    b2.HasKey("CreateLogChangeLockReasonId");

                                    b2.ToTable("ChangeLockReasons");

                                    b2.WithOwner()
                                        .HasForeignKey("CreateLogChangeLockReasonId");
                                });

                            b1.Navigation("Date")
                                .IsRequired();
                        });

                    b.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.DeleteLog", "DeleteLog", b1 =>
                        {
                            b1.Property<long>("ChangeLockReasonId")
                                .HasColumnType("bigint");

                            b1.Property<bool>("IsDeleted")
                                .HasColumnType("bit");

                            b1.Property<Guid>("UserId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier")
                                .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                            b1.HasKey("ChangeLockReasonId");

                            b1.ToTable("ChangeLockReasons");

                            b1.WithOwner()
                                .HasForeignKey("ChangeLockReasonId");

                            b1.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.DateTimeConvert", "Date", b2 =>
                                {
                                    b2.Property<long>("DeleteLogChangeLockReasonId")
                                        .HasColumnType("bigint");

                                    b2.Property<string>("Ghamari")
                                        .HasMaxLength(14)
                                        .HasColumnType("nvarchar(14)");

                                    b2.Property<DateTime?>("Miladi")
                                        .HasColumnType("datetime2");

                                    b2.Property<string>("Shamsi")
                                        .HasMaxLength(14)
                                        .HasColumnType("nvarchar(14)");

                                    b2.HasKey("DeleteLogChangeLockReasonId");

                                    b2.ToTable("ChangeLockReasons");

                                    b2.WithOwner()
                                        .HasForeignKey("DeleteLogChangeLockReasonId");
                                });

                            b1.Navigation("Date")
                                .IsRequired();
                        });

                    b.Navigation("CreateLog")
                        .IsRequired();

                    b.Navigation("DeleteLog")
                        .IsRequired();
                });

            modelBuilder.Entity("IOT.Identity.Domain.Core.Permission", b =>
                {
                    b.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.CreateLog", "CreateLog", b1 =>
                        {
                            b1.Property<Guid>("PermissionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("PermissionId");

                            b1.ToTable("Permission");

                            b1.WithOwner()
                                .HasForeignKey("PermissionId");

                            b1.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.DateTimeConvert", "Date", b2 =>
                                {
                                    b2.Property<Guid>("CreateLogPermissionId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Ghamari")
                                        .IsRequired()
                                        .HasMaxLength(14)
                                        .HasColumnType("nvarchar(14)");

                                    b2.Property<DateTime?>("Miladi")
                                        .IsRequired()
                                        .HasColumnType("datetime2");

                                    b2.Property<string>("Shamsi")
                                        .IsRequired()
                                        .HasMaxLength(14)
                                        .HasColumnType("nvarchar(14)");

                                    b2.HasKey("CreateLogPermissionId");

                                    b2.ToTable("Permission");

                                    b2.WithOwner()
                                        .HasForeignKey("CreateLogPermissionId");
                                });

                            b1.Navigation("Date")
                                .IsRequired();
                        });

                    b.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.DeleteLog", "DeleteLog", b1 =>
                        {
                            b1.Property<Guid>("PermissionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("IsDeleted")
                                .HasColumnType("bit");

                            b1.Property<Guid>("UserId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier")
                                .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                            b1.HasKey("PermissionId");

                            b1.ToTable("Permission");

                            b1.WithOwner()
                                .HasForeignKey("PermissionId");

                            b1.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.DateTimeConvert", "Date", b2 =>
                                {
                                    b2.Property<Guid>("DeleteLogPermissionId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Ghamari")
                                        .HasMaxLength(14)
                                        .HasColumnType("nvarchar(14)");

                                    b2.Property<DateTime?>("Miladi")
                                        .HasColumnType("datetime2");

                                    b2.Property<string>("Shamsi")
                                        .HasMaxLength(14)
                                        .HasColumnType("nvarchar(14)");

                                    b2.HasKey("DeleteLogPermissionId");

                                    b2.ToTable("Permission");

                                    b2.WithOwner()
                                        .HasForeignKey("DeleteLogPermissionId");
                                });

                            b1.Navigation("Date")
                                .IsRequired();
                        });

                    b.Navigation("CreateLog")
                        .IsRequired();

                    b.Navigation("DeleteLog")
                        .IsRequired();
                });

            modelBuilder.Entity("IOT.Identity.Domain.Core.Role", b =>
                {
                    b.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.CreateLog", "CreateLog", b1 =>
                        {
                            b1.Property<Guid>("RoleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("RoleId");

                            b1.ToTable("Role");

                            b1.WithOwner()
                                .HasForeignKey("RoleId");

                            b1.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.DateTimeConvert", "Date", b2 =>
                                {
                                    b2.Property<Guid>("CreateLogRoleId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Ghamari")
                                        .IsRequired()
                                        .HasMaxLength(14)
                                        .HasColumnType("nvarchar(14)");

                                    b2.Property<DateTime?>("Miladi")
                                        .IsRequired()
                                        .HasColumnType("datetime2");

                                    b2.Property<string>("Shamsi")
                                        .IsRequired()
                                        .HasMaxLength(14)
                                        .HasColumnType("nvarchar(14)");

                                    b2.HasKey("CreateLogRoleId");

                                    b2.ToTable("Role");

                                    b2.WithOwner()
                                        .HasForeignKey("CreateLogRoleId");
                                });

                            b1.Navigation("Date")
                                .IsRequired();
                        });

                    b.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.DeleteLog", "DeleteLog", b1 =>
                        {
                            b1.Property<Guid>("RoleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("IsDeleted")
                                .HasColumnType("bit");

                            b1.Property<Guid>("UserId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier")
                                .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                            b1.HasKey("RoleId");

                            b1.ToTable("Role");

                            b1.WithOwner()
                                .HasForeignKey("RoleId");

                            b1.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.DateTimeConvert", "Date", b2 =>
                                {
                                    b2.Property<Guid>("DeleteLogRoleId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Ghamari")
                                        .HasMaxLength(14)
                                        .HasColumnType("nvarchar(14)");

                                    b2.Property<DateTime?>("Miladi")
                                        .HasColumnType("datetime2");

                                    b2.Property<string>("Shamsi")
                                        .HasMaxLength(14)
                                        .HasColumnType("nvarchar(14)");

                                    b2.HasKey("DeleteLogRoleId");

                                    b2.ToTable("Role");

                                    b2.WithOwner()
                                        .HasForeignKey("DeleteLogRoleId");
                                });

                            b1.Navigation("Date")
                                .IsRequired();
                        });

                    b.Navigation("CreateLog")
                        .IsRequired();

                    b.Navigation("DeleteLog")
                        .IsRequired();
                });

            modelBuilder.Entity("IOT.Identity.Domain.Core.User", b =>
                {
                    b.HasOne("IOT.Identity.Domain.Core.ChangeLockReason", "ChangeLockReason")
                        .WithMany()
                        .HasForeignKey("LockReason_Id");

                    b.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.HasKey("UserId");

                            b1.ToTable("users", "User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("CountryCode")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<string>("PhoneNumberWithOutCountryCode")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("nvarchar(128)");

                            b1.HasKey("UserId");

                            b1.ToTable("users", "User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.DateTimeConvert", "LastLoginDate", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Ghamari")
                                .HasMaxLength(14)
                                .HasColumnType("nvarchar(14)");

                            b1.Property<DateTime?>("Miladi")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Shamsi")
                                .HasMaxLength(14)
                                .HasColumnType("nvarchar(14)");

                            b1.HasKey("UserId");

                            b1.ToTable("users", "User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.DateTimeConvert", "LockExpireDate", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Ghamari")
                                .HasMaxLength(14)
                                .HasColumnType("nvarchar(14)");

                            b1.Property<DateTime?>("Miladi")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Shamsi")
                                .HasMaxLength(14)
                                .HasColumnType("nvarchar(14)");

                            b1.HasKey("UserId");

                            b1.ToTable("users", "User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.DateTimeConvert", "RegisterDate", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Ghamari")
                                .IsRequired()
                                .HasMaxLength(14)
                                .HasColumnType("nvarchar(14)");

                            b1.Property<DateTime?>("Miladi")
                                .IsRequired()
                                .HasColumnType("datetime2");

                            b1.Property<string>("Shamsi")
                                .IsRequired()
                                .HasMaxLength(14)
                                .HasColumnType("nvarchar(14)");

                            b1.HasKey("UserId");

                            b1.ToTable("users", "User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("IOT.Identity.Service.User.ValueObject.UserNameInfo", "UserNameInfo", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(120)
                                .HasColumnType("nvarchar(120)");

                            b1.Property<int>("Gender")
                                .HasColumnType("int");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(120)
                                .HasColumnType("nvarchar(120)");

                            b1.HasKey("UserId");

                            b1.ToTable("users", "User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.DateTimeConvert", "BirthDate", b2 =>
                                {
                                    b2.Property<Guid>("UserNameInfoUserId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Ghamari")
                                        .IsRequired()
                                        .HasMaxLength(14)
                                        .HasColumnType("nvarchar(14)");

                                    b2.Property<DateTime?>("Miladi")
                                        .IsRequired()
                                        .HasColumnType("datetime2");

                                    b2.Property<string>("Shamsi")
                                        .IsRequired()
                                        .HasMaxLength(14)
                                        .HasColumnType("nvarchar(14)");

                                    b2.HasKey("UserNameInfoUserId");

                                    b2.ToTable("users", "User");

                                    b2.WithOwner()
                                        .HasForeignKey("UserNameInfoUserId");
                                });

                            b1.Navigation("BirthDate")
                                .IsRequired();
                        });

                    b.Navigation("ChangeLockReason");

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("LastLoginDate")
                        .IsRequired();

                    b.Navigation("LockExpireDate")
                        .IsRequired();

                    b.Navigation("PhoneNumber")
                        .IsRequired();

                    b.Navigation("RegisterDate")
                        .IsRequired();

                    b.Navigation("UserNameInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("IOT.Identity.Domain.Core.UserRefreshToken", b =>
                {
                    b.HasOne("IOT.Identity.Domain.Core.User", "User")
                        .WithOne("RefreshToken")
                        .HasForeignKey("IOT.Identity.Domain.Core.UserRefreshToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.DateTimeConvert", "CreateDate", b1 =>
                        {
                            b1.Property<Guid>("UserRefreshTokenId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Ghamari")
                                .IsRequired()
                                .HasMaxLength(14)
                                .HasColumnType("nvarchar(14)");

                            b1.Property<DateTime?>("Miladi")
                                .IsRequired()
                                .HasColumnType("datetime2");

                            b1.Property<string>("Shamsi")
                                .IsRequired()
                                .HasMaxLength(14)
                                .HasColumnType("nvarchar(14)");

                            b1.HasKey("UserRefreshTokenId");

                            b1.ToTable("UserRefreshTokens");

                            b1.WithOwner()
                                .HasForeignKey("UserRefreshTokenId");
                        });

                    b.OwnsOne("Building.Blocks.Core.Domain.ValueObjects.DateTimeConvert", "ExpireDate", b1 =>
                        {
                            b1.Property<Guid>("UserRefreshTokenId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Ghamari")
                                .IsRequired()
                                .HasMaxLength(14)
                                .HasColumnType("nvarchar(14)");

                            b1.Property<DateTime?>("Miladi")
                                .IsRequired()
                                .HasColumnType("datetime2");

                            b1.Property<string>("Shamsi")
                                .IsRequired()
                                .HasMaxLength(14)
                                .HasColumnType("nvarchar(14)");

                            b1.HasKey("UserRefreshTokenId");

                            b1.ToTable("UserRefreshTokens");

                            b1.WithOwner()
                                .HasForeignKey("UserRefreshTokenId");
                        });

                    b.Navigation("CreateDate")
                        .IsRequired();

                    b.Navigation("ExpireDate")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("IOT.Identity.Domain.Core.User", b =>
                {
                    b.Navigation("RefreshToken")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
