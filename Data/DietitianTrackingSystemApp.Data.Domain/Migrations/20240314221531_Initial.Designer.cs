﻿// <auto-generated />
using System;
using DietitianTrackingSystemApp.Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DietitianTrackingSystemApp.Data.Domain.Migrations
{
    [DbContext(typeof(DietitianTrackingSystemDbContext))]
    [Migration("20240314221531_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DietitianTrackingSystemApp.Data.Domain.Entities.ClientChronicDisease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Atherosclerosis")
                        .HasColumnType("bit");

                    b.Property<bool>("BloodPressure")
                        .HasColumnType("bit");

                    b.Property<int>("ClientUserId")
                        .HasColumnType("int");

                    b.Property<bool>("Diabetes")
                        .HasColumnType("bit");

                    b.Property<bool>("HeartRhythmDisorder")
                        .HasColumnType("bit");

                    b.Property<bool>("HighCholesterol")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ClientUserId")
                        .IsUnique();

                    b.ToTable("ClientChronicDiseases");
                });

            modelBuilder.Entity("DietitianTrackingSystemApp.Data.Domain.Entities.ClientConsultant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientUserId")
                        .HasColumnType("int");

                    b.Property<int>("ConsultantUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConsultantUserId");

                    b.HasIndex("ClientUserId", "ConsultantUserId")
                        .IsUnique();

                    b.ToTable("ClientConsultants");
                });

            modelBuilder.Entity("DietitianTrackingSystemApp.Data.Domain.Entities.ClientDietTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientUserId")
                        .HasColumnType("int");

                    b.Property<int>("DietTemplateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndingDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("DietTemplateId");

                    b.HasIndex("ClientUserId", "DietTemplateId")
                        .IsUnique();

                    b.ToTable("ClientDietTemplates");
                });

            modelBuilder.Entity("DietitianTrackingSystemApp.Data.Domain.Entities.DietTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasColumnType("nText");

                    b.Property<string>("DietName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("DietTemplates");
                });

            modelBuilder.Entity("DietitianTrackingSystemApp.Data.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DietitianTrackingSystemApp.Data.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DietitianTrackingSystemApp.Data.Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("RoleId");

                    b.HasIndex("UpdatedBy");

                    b.HasIndex("UserId", "RoleId")
                        .IsUnique();

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("DietitianTrackingSystemApp.Data.Domain.Entities.ClientChronicDisease", b =>
                {
                    b.HasOne("DietitianTrackingSystemApp.Data.Domain.Entities.User", "ClientUser")
                        .WithMany("ClientChronicDiseases")
                        .HasForeignKey("ClientUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientUser");
                });

            modelBuilder.Entity("DietitianTrackingSystemApp.Data.Domain.Entities.ClientConsultant", b =>
                {
                    b.HasOne("DietitianTrackingSystemApp.Data.Domain.Entities.User", "ClientUser")
                        .WithMany("ClientUsers")
                        .HasForeignKey("ClientUserId")
                        .IsRequired();

                    b.HasOne("DietitianTrackingSystemApp.Data.Domain.Entities.User", "ConsultantUser")
                        .WithMany("ConsultantUsers")
                        .HasForeignKey("ConsultantUserId")
                        .IsRequired();

                    b.Navigation("ClientUser");

                    b.Navigation("ConsultantUser");
                });

            modelBuilder.Entity("DietitianTrackingSystemApp.Data.Domain.Entities.ClientDietTemplate", b =>
                {
                    b.HasOne("DietitianTrackingSystemApp.Data.Domain.Entities.User", "ClientUser")
                        .WithMany("ClientDietTemplates")
                        .HasForeignKey("ClientUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DietitianTrackingSystemApp.Data.Domain.Entities.DietTemplate", "DietTemplate")
                        .WithMany("ClientDietTemplates")
                        .HasForeignKey("DietTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientUser");

                    b.Navigation("DietTemplate");
                });

            modelBuilder.Entity("DietitianTrackingSystemApp.Data.Domain.Entities.Role", b =>
                {
                    b.HasOne("DietitianTrackingSystemApp.Data.Domain.Entities.User", "CreatedByNavigation")
                        .WithMany("RoleCreatedByNavigations")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("DietitianTrackingSystemApp.Data.Domain.Entities.User", "UpdatedByNavigation")
                        .WithMany("RoleUpdatedByNavigations")
                        .HasForeignKey("UpdatedBy");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("UpdatedByNavigation");
                });

            modelBuilder.Entity("DietitianTrackingSystemApp.Data.Domain.Entities.User", b =>
                {
                    b.HasOne("DietitianTrackingSystemApp.Data.Domain.Entities.User", "CreatedByNavigation")
                        .WithMany("InverseCreatedByNavigation")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("DietitianTrackingSystemApp.Data.Domain.Entities.User", "UpdatedByNavigation")
                        .WithMany("InverseUpdatedByNavigation")
                        .HasForeignKey("UpdatedBy");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("UpdatedByNavigation");
                });

            modelBuilder.Entity("DietitianTrackingSystemApp.Data.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("DietitianTrackingSystemApp.Data.Domain.Entities.User", "CreatedByNavigation")
                        .WithMany("UserRoleCreatedByNavigations")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("DietitianTrackingSystemApp.Data.Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DietitianTrackingSystemApp.Data.Domain.Entities.User", "UpdatedByNavigation")
                        .WithMany("UserRoleUpdatedByNavigations")
                        .HasForeignKey("UpdatedBy");

                    b.HasOne("DietitianTrackingSystemApp.Data.Domain.Entities.User", "User")
                        .WithMany("UserRoleUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("Role");

                    b.Navigation("UpdatedByNavigation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DietitianTrackingSystemApp.Data.Domain.Entities.DietTemplate", b =>
                {
                    b.Navigation("ClientDietTemplates");
                });

            modelBuilder.Entity("DietitianTrackingSystemApp.Data.Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("DietitianTrackingSystemApp.Data.Domain.Entities.User", b =>
                {
                    b.Navigation("ClientChronicDiseases");

                    b.Navigation("ClientDietTemplates");

                    b.Navigation("ClientUsers");

                    b.Navigation("ConsultantUsers");

                    b.Navigation("InverseCreatedByNavigation");

                    b.Navigation("InverseUpdatedByNavigation");

                    b.Navigation("RoleCreatedByNavigations");

                    b.Navigation("RoleUpdatedByNavigations");

                    b.Navigation("UserRoleCreatedByNavigations");

                    b.Navigation("UserRoleUpdatedByNavigations");

                    b.Navigation("UserRoleUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
