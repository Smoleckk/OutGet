﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OutGetDotNet.Data;

#nullable disable

namespace OutGetDotNet.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OutGetDotNet.Models.Locker", b =>
                {
                    b.Property<int>("LockerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LockerId"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LockerId");

                    b.ToTable("Lockers");
                });

            modelBuilder.Entity("OutGetDotNet.Models.Shipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("FromLockerId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReceiverId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("SenderId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ToLockerId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromLockerId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.HasIndex("ToLockerId");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("OutGetDotNet.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OutGetDotNet.Models.Shipment", b =>
                {
                    b.HasOne("OutGetDotNet.Models.Locker", "FromLocker")
                        .WithMany("FromLockerDelivery")
                        .HasForeignKey("FromLockerId")
                        .IsRequired();

                    b.HasOne("OutGetDotNet.Models.User", "Receiver")
                        .WithMany("ReceivedShipments")
                        .HasForeignKey("ReceiverId")
                        .IsRequired();

                    b.HasOne("OutGetDotNet.Models.User", "Sender")
                        .WithMany("SentShipments")
                        .HasForeignKey("SenderId")
                        .IsRequired();

                    b.HasOne("OutGetDotNet.Models.Locker", "ToLocker")
                        .WithMany("ToLockerDelivery")
                        .HasForeignKey("ToLockerId")
                        .IsRequired();

                    b.Navigation("FromLocker");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");

                    b.Navigation("ToLocker");
                });

            modelBuilder.Entity("OutGetDotNet.Models.Locker", b =>
                {
                    b.Navigation("FromLockerDelivery");

                    b.Navigation("ToLockerDelivery");
                });

            modelBuilder.Entity("OutGetDotNet.Models.User", b =>
                {
                    b.Navigation("ReceivedShipments");

                    b.Navigation("SentShipments");
                });
#pragma warning restore 612, 618
        }
    }
}
