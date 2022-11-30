﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetEvent.Server.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NetEvent.Server.Migrations.Psql
{
    [DbContext(typeof(PsqlApplicationDbContext))]
    [Migration("20221129191007_AddEventFormat")]
    partial class AddEventFormat
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "Admin.Users.Read",
                            ClaimValue = "",
                            RoleId = "admin"
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "Admin.Users.Write",
                            ClaimValue = "",
                            RoleId = "admin"
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "Admin.Roles.Read",
                            ClaimValue = "",
                            RoleId = "admin"
                        },
                        new
                        {
                            Id = 4,
                            ClaimType = "Admin.Roles.Write",
                            ClaimValue = "",
                            RoleId = "admin"
                        },
                        new
                        {
                            Id = 5,
                            ClaimType = "Admin.System.Read",
                            ClaimValue = "",
                            RoleId = "admin"
                        },
                        new
                        {
                            Id = 6,
                            ClaimType = "Admin.System.Write",
                            ClaimValue = "",
                            RoleId = "admin"
                        },
                        new
                        {
                            Id = 7,
                            ClaimType = "Admin.Images.Read",
                            ClaimValue = "",
                            RoleId = "admin"
                        },
                        new
                        {
                            Id = 8,
                            ClaimType = "Admin.Images.Edit",
                            ClaimValue = "",
                            RoleId = "admin"
                        },
                        new
                        {
                            Id = 9,
                            ClaimType = "Admin.Events.Read",
                            ClaimValue = "",
                            RoleId = "admin"
                        },
                        new
                        {
                            Id = 10,
                            ClaimType = "Admin.Events.Edit",
                            ClaimValue = "",
                            RoleId = "admin"
                        },
                        new
                        {
                            Id = 11,
                            ClaimType = "Admin.Venues.Read",
                            ClaimValue = "",
                            RoleId = "admin"
                        },
                        new
                        {
                            Id = 12,
                            ClaimType = "Admin.Venues.Edit",
                            ClaimValue = "",
                            RoleId = "admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "BAFC89CF-4F3E-4595-8256-CCA19C260FBD",
                            RoleId = "admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("NetEvent.Server.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Role", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "user",
                            IsDefault = true,
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "orga",
                            IsDefault = false,
                            Name = "Orga",
                            NormalizedName = "ORGA"
                        },
                        new
                        {
                            Id = "admin",
                            IsDefault = false,
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("NetEvent.Server.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("bytea");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "BAFC89CF-4F3E-4595-8256-CCA19C260FBD",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ad7c3278-025a-4e2d-88a9-552e00f40e13",
                            Email = "admin@admin.de",
                            EmailConfirmed = true,
                            FirstName = "Admin",
                            LastName = "istrator",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.DE",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEAP/L7N9GLytqJf80BBxBLQ5UWeehMBsWdxgyzw5ml6bCGaRSEnO5AOFcVd3xfZCDA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5ea9e243-c62f-4766-a4a7-897d6fc87352",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("NetEvent.Server.Models.EmailTemplate", b =>
                {
                    b.Property<string>("TemplateId")
                        .HasColumnType("text");

                    b.Property<string>("ContentTemplate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SubjectTemplate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TemplateId");

                    b.ToTable("EmailTemplates", (string)null);

                    b.HasData(
                        new
                        {
                            TemplateId = "UserEmailConfirmEmailTemplate",
                            ContentTemplate = "<h1>@Model.TemplateVariables[\"firstName\"], welcome to NetEvent.</h1>\n<p> Please confirm your E-Mail by clicking on the following link:</p><a href=\"@Model.TemplateVariables[\"confirmUrl\"]\">@Model.TemplateVariables[\"confirmUrl\"]</a>   ",
                            SubjectTemplate = "@Model.TemplateVariables[\"firstName\"], please confirm your E-Mail address."
                        });
                });

            modelBuilder.Entity("NetEvent.Server.Models.Event", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .HasColumnType("text");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<long?>("VenueId")
                        .HasColumnType("bigint");

                    b.Property<int>("Visibility")
                        .HasColumnType("integer");

                    b.Property<int>("eventFormat")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.HasIndex("VenueId");

                    b.ToTable("Events", (string)null);
                });

            modelBuilder.Entity("NetEvent.Server.Models.SystemImage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<byte[]>("Data")
                        .HasColumnType("bytea");

                    b.Property<string>("Extension")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UploadTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("SystemImages", (string)null);
                });

            modelBuilder.Entity("NetEvent.Server.Models.SystemSettingValue", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("text");

                    b.Property<string>("SerializedValue")
                        .HasColumnType("text");

                    b.HasKey("Key");

                    b.ToTable("SystemSettings", (string)null);

                    b.HasData(
                        new
                        {
                            Key = "OrganizationName",
                            SerializedValue = "NetEvent"
                        },
                        new
                        {
                            Key = "DataCultureInfo",
                            SerializedValue = "en-US"
                        },
                        new
                        {
                            Key = "Favicon",
                            SerializedValue = ""
                        },
                        new
                        {
                            Key = "Logo",
                            SerializedValue = ""
                        },
                        new
                        {
                            Key = "AboutUs",
                            SerializedValue = ""
                        },
                        new
                        {
                            Key = "LegalNotice",
                            SerializedValue = ""
                        },
                        new
                        {
                            Key = "PrivacyPolicy",
                            SerializedValue = ""
                        },
                        new
                        {
                            Key = "PrimaryColor",
                            SerializedValue = ""
                        },
                        new
                        {
                            Key = "PrimaryTextColor",
                            SerializedValue = ""
                        },
                        new
                        {
                            Key = "SecondaryColor",
                            SerializedValue = ""
                        },
                        new
                        {
                            Key = "SecondaryTextColor",
                            SerializedValue = ""
                        },
                        new
                        {
                            Key = "Background",
                            SerializedValue = ""
                        },
                        new
                        {
                            Key = "AppbarBackground",
                            SerializedValue = ""
                        },
                        new
                        {
                            Key = "AppbarText",
                            SerializedValue = ""
                        },
                        new
                        {
                            Key = "CustomCss",
                            SerializedValue = ""
                        },
                        new
                        {
                            Key = "Standard",
                            SerializedValue = "True"
                        },
                        new
                        {
                            Key = "Steam",
                            SerializedValue = "False"
                        });
                });

            modelBuilder.Entity("NetEvent.Server.Models.Venue", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long?>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Venues", (string)null);
                });

            modelBuilder.Entity("NetEvent.Shared.Dto.ThemeDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ThemeData")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Themes", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("NetEvent.Server.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NetEvent.Server.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NetEvent.Server.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("NetEvent.Server.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetEvent.Server.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("NetEvent.Server.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NetEvent.Server.Models.Event", b =>
                {
                    b.HasOne("NetEvent.Server.Models.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId");

                    b.Navigation("Venue");
                });
#pragma warning restore 612, 618
        }
    }
}
