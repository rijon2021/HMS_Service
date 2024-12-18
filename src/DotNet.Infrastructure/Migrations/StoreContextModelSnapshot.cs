﻿// <auto-generated />
using System;
using DotNet.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Store.Infrastructure.Migrations
{
    [DbContext(typeof(DotNetContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.Attachments", b =>
                {
                    b.Property<int>("AttachmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttachmentID"));

                    b.Property<int>("AttachementTypeID")
                        .HasColumnType("int");

                    b.Property<string>("AttachmentLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AttachmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileFormat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReferenceID")
                        .HasColumnType("int");

                    b.Property<int?>("ReferenceType")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AttachmentID");

                    b.ToTable("Attachments", "com");
                });

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.Designation", b =>
                {
                    b.Property<int>("DesignationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DesignationID"));

                    b.Property<string>("DesignationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DesignationNameBangla")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("OrderNo")
                        .HasColumnType("int");

                    b.HasKey("DesignationID");

                    b.ToTable("Designations", "core");
                });

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.GlobalSetting", b =>
                {
                    b.Property<int>("GlobalSettingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GlobalSettingID"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GlobalSettingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.Property<string>("ValueInString")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GlobalSettingID");

                    b.ToTable("GlobalSettings", "core");
                });

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.HMS.Bed", b =>
                {
                    b.Property<int>("BedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BedId"));

                    b.Property<string>("BedNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAssigned")
                        .HasColumnType("bit");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BedId");

                    b.HasIndex("RoomId");

                    b.ToTable("Beds", "core");
                });

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.HMS.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BranchId"));

                    b.Property<string>("BranchCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HostelId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BranchId");

                    b.HasIndex("HostelId");

                    b.ToTable("Branches", "core");
                });

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.HMS.Hostel", b =>
                {
                    b.Property<int>("HostelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HostelId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Amenities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EstablishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HostelManager")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HostelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalBranches")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HostelId");

                    b.ToTable("Hostels", "core");
                });

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.HMS.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoomCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RoomId");

                    b.HasIndex("BranchId");

                    b.ToTable("Rooms", "core");
                });

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.NotificationArea", b =>
                {
                    b.Property<int>("NotificationAreaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationAreaID"));

                    b.Property<int>("ExpireTime")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("NotificationAreaName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotificationBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NotificationType")
                        .HasColumnType("int");

                    b.HasKey("NotificationAreaID");

                    b.ToTable("NotificationAreas", "core");
                });

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.Organization", b =>
                {
                    b.Property<int>("OrganizationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrganizationID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ContactPersonID")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("OrganizationLogo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("OrganizationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationNameBangla")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationShortName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationType")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationUserID")
                        .HasColumnType("int");

                    b.Property<string>("PrivateURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProductLogo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrganizationID");

                    b.ToTable("Organizations", "com");
                });

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.Permission", b =>
                {
                    b.Property<int>("PermissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PermissionID"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IconName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<int>("OrderNo")
                        .HasColumnType("int");

                    b.Property<int?>("ParentPermissionID")
                        .HasColumnType("int");

                    b.Property<string>("PermissionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PermissionType")
                        .HasColumnType("int");

                    b.Property<string>("RoutePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PermissionID");

                    b.ToTable("Permissions", "core");
                });

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.PermissionUserRoleMap", b =>
                {
                    b.Property<int>("PermissionUserRoleMapID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PermissionUserRoleMapID"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.Property<int>("PermissionID")
                        .HasColumnType("int");

                    b.Property<int>("UserRoleID")
                        .HasColumnType("int");

                    b.HasKey("PermissionUserRoleMapID");

                    b.ToTable("PermissionUserRoleMaps", "core");
                });

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.SMSNotification", b =>
                {
                    b.Property<int>("SMSNotificationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SMSNotificationID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DeliveryStatus")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ExpireDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("MessageBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NotificationAreaID")
                        .HasColumnType("int");

                    b.Property<string>("OTP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientMobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReponseMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SendingStatus")
                        .HasColumnType("bit");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("SMSNotificationID");

                    b.ToTable("SMSNotifications", "core");
                });

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.UserRole", b =>
                {
                    b.Property<int>("UserRoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserRoleID"));

                    b.Property<bool?>("AllowLocalMedia")
                        .HasColumnType("bit");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDataRestricted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderNo")
                        .HasColumnType("int");

                    b.Property<string>("UserRoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserRoleID");

                    b.ToTable("UserRoles", "com");
                });

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.Users", b =>
                {
                    b.Property<int>("UserAutoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserAutoID"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("CanChangeOwnPassword")
                        .HasColumnType("bit");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<int?>("DesignationID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Is2FAauthenticationEnabled")
                        .HasColumnType("bit");

                    b.Property<double?>("LastLatitude")
                        .HasColumnType("float");

                    b.Property<double?>("LastLongitude")
                        .HasColumnType("float");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("MobileVerification")
                        .HasColumnType("bit");

                    b.Property<string>("NID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PasswordExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Signature")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFullNameBangla")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("UserImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("UserRoleID")
                        .HasColumnType("int");

                    b.Property<int>("UserTypeID")
                        .HasColumnType("int");

                    b.HasKey("UserAutoID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.HMS.Bed", b =>
                {
                    b.HasOne("DotNet.ApplicationCore.Entities.HMS.Room", "Room")
                        .WithMany("Beds")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.HMS.Branch", b =>
                {
                    b.HasOne("DotNet.ApplicationCore.Entities.HMS.Hostel", "Hostel")
                        .WithMany("Branches")
                        .HasForeignKey("HostelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hostel");
                });

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.HMS.Room", b =>
                {
                    b.HasOne("DotNet.ApplicationCore.Entities.HMS.Branch", "Branch")
                        .WithMany("Rooms")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.HMS.Branch", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.HMS.Hostel", b =>
                {
                    b.Navigation("Branches");
                });

            modelBuilder.Entity("DotNet.ApplicationCore.Entities.HMS.Room", b =>
                {
                    b.Navigation("Beds");
                });
#pragma warning restore 612, 618
        }
    }
}
