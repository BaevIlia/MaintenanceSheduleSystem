﻿// <auto-generated />
using System;
using MaintenanceSheduleSystem.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MaintenanceSheduleSystem.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.EquipmentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Article")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<bool>("IsInStock")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StoragePlace")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.InstructionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AreaId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EquipmentListId")
                        .HasColumnType("uuid");

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TypeOfWork")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Handbooks");
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.InstructionEquipmentEntity", b =>
                {
                    b.Property<Guid>("EquipmentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("HandbookId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EquipmentsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("HandbooksId")
                        .HasColumnType("uuid");

                    b.HasKey("EquipmentId", "HandbookId");

                    b.HasIndex("EquipmentsId");

                    b.HasIndex("HandbooksId");

                    b.ToTable("HandbookEquipment");
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.MachineAreaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AreaDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AreaName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("InstructionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MachineId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.ToTable("MachineAreas");
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.MachineEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.OrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AreaId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BeginWorkDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CompliteDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DeadlineDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("MachineId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ServicemanName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TypeOfWork")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.OrderEquipmentEntity", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EquipmentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EquipmentsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrdersId")
                        .HasColumnType("uuid");

                    b.HasKey("OrderId", "EquipmentId");

                    b.HasIndex("EquipmentsId");

                    b.HasIndex("OrdersId");

                    b.ToTable("OrderEquipment");
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsSacked")
                        .HasColumnType("boolean");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Email", "HashedPassword")
                        .IsUnique();

                    b.ToTable("Users");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.AdministratorEntity", b =>
                {
                    b.HasBaseType("MaintenanceSheduleSystem.Persistence.Entities.UserEntity");

                    b.Property<string>("SigningKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("Administrators");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dac5f915-53bb-4056-bde6-f4987056c1e7"),
                            Email = "test@domain.ru",
                            FullName = "surname name lastname",
                            HashedPassword = "$2a$11$rFu15a3nlKXtN1uRT08pNeskp0DTOiX5RKAwVMlxF/fvXHOffrQqi",
                            IsSacked = false,
                            Role = 1,
                            SigningKey = ""
                        });
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.PlannerEngineerEntity", b =>
                {
                    b.HasBaseType("MaintenanceSheduleSystem.Persistence.Entities.UserEntity");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("PlannerEngineers");
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.ServicemanEntity", b =>
                {
                    b.HasBaseType("MaintenanceSheduleSystem.Persistence.Entities.UserEntity");

                    b.ToTable("Servicemen");
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.InstructionEntity", b =>
                {
                    b.HasOne("MaintenanceSheduleSystem.Persistence.Entities.MachineAreaEntity", "MachineArea")
                        .WithMany("Instructions")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MachineArea");
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.InstructionEquipmentEntity", b =>
                {
                    b.HasOne("MaintenanceSheduleSystem.Persistence.Entities.EquipmentEntity", null)
                        .WithMany()
                        .HasForeignKey("EquipmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaintenanceSheduleSystem.Persistence.Entities.InstructionEntity", null)
                        .WithMany()
                        .HasForeignKey("HandbooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.MachineAreaEntity", b =>
                {
                    b.HasOne("MaintenanceSheduleSystem.Persistence.Entities.MachineEntity", "Machine")
                        .WithMany("MachineAreas")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.OrderEntity", b =>
                {
                    b.HasOne("MaintenanceSheduleSystem.Persistence.Entities.MachineAreaEntity", "MachineArea")
                        .WithMany("Orders")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaintenanceSheduleSystem.Persistence.Entities.ServicemanEntity", "Serviceman")
                        .WithMany("Orders")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MachineArea");

                    b.Navigation("Serviceman");
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.OrderEquipmentEntity", b =>
                {
                    b.HasOne("MaintenanceSheduleSystem.Persistence.Entities.EquipmentEntity", null)
                        .WithMany()
                        .HasForeignKey("EquipmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaintenanceSheduleSystem.Persistence.Entities.OrderEntity", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.AdministratorEntity", b =>
                {
                    b.HasOne("MaintenanceSheduleSystem.Persistence.Entities.UserEntity", null)
                        .WithOne()
                        .HasForeignKey("MaintenanceSheduleSystem.Persistence.Entities.AdministratorEntity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.PlannerEngineerEntity", b =>
                {
                    b.HasOne("MaintenanceSheduleSystem.Persistence.Entities.UserEntity", null)
                        .WithOne()
                        .HasForeignKey("MaintenanceSheduleSystem.Persistence.Entities.PlannerEngineerEntity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.ServicemanEntity", b =>
                {
                    b.HasOne("MaintenanceSheduleSystem.Persistence.Entities.UserEntity", null)
                        .WithOne()
                        .HasForeignKey("MaintenanceSheduleSystem.Persistence.Entities.ServicemanEntity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.MachineAreaEntity", b =>
                {
                    b.Navigation("Instructions");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.MachineEntity", b =>
                {
                    b.Navigation("MachineAreas");
                });

            modelBuilder.Entity("MaintenanceSheduleSystem.Persistence.Entities.ServicemanEntity", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
