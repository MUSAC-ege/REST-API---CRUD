﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderAPI.Models;

#nullable disable

namespace OrderAPI.Migrations
{
    [DbContext(typeof(OrderContext))]
    [Migration("20241112130247_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrderAPI.Models.Message", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("channelCode")
                        .HasColumnType("int");

                    b.Property<DateOnly>("date")
                        .HasColumnType("date");

                    b.Property<string>("message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("orderId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            id = 1,
                            channelCode = 1,
                            date = new DateOnly(2024, 12, 1),
                            message = "EMAIL kanalından mesaj gönderildi",
                            orderId = 1,
                            userId = 1
                        },
                        new
                        {
                            id = 2,
                            channelCode = 1,
                            date = new DateOnly(2024, 12, 1),
                            message = "EMAIL kanalından mesaj gönderildi",
                            orderId = 2,
                            userId = 1
                        },
                        new
                        {
                            id = 3,
                            channelCode = 2,
                            date = new DateOnly(2024, 12, 1),
                            message = "SMS kanalından mesaj gönderildi",
                            orderId = 2,
                            userId = 1
                        },
                        new
                        {
                            id = 4,
                            channelCode = 1,
                            date = new DateOnly(2024, 12, 1),
                            message = "EMAIL kanalından mesaj gönderildi",
                            orderId = 3,
                            userId = 2
                        },
                        new
                        {
                            id = 5,
                            channelCode = 3,
                            date = new DateOnly(2024, 12, 1),
                            message = "PUSH kanalından mesaj gönderildi",
                            orderId = 4,
                            userId = 2
                        });
                });

            modelBuilder.Entity("OrderAPI.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("date")
                        .HasColumnType("date");

                    b.Property<int>("day")
                        .HasColumnType("int");

                    b.Property<bool>("emailChannel")
                        .HasColumnType("bit");

                    b.Property<bool>("pushChannel")
                        .HasColumnType("bit");

                    b.Property<bool>("smsChannel")
                        .HasColumnType("bit");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            id = 1,
                            amount = 500m,
                            date = new DateOnly(2024, 12, 1),
                            day = 1,
                            emailChannel = true,
                            pushChannel = false,
                            smsChannel = false,
                            status = 1,
                            userId = 1
                        },
                        new
                        {
                            id = 2,
                            amount = 99999m,
                            date = new DateOnly(2024, 12, 1),
                            day = 28,
                            emailChannel = true,
                            pushChannel = false,
                            smsChannel = true,
                            status = 0,
                            userId = 1
                        },
                        new
                        {
                            id = 3,
                            amount = 5000m,
                            date = new DateOnly(2024, 12, 1),
                            day = 1,
                            emailChannel = true,
                            pushChannel = false,
                            smsChannel = false,
                            status = 0,
                            userId = 2
                        },
                        new
                        {
                            id = 4,
                            amount = 500m,
                            date = new DateOnly(2024, 12, 1),
                            day = 28,
                            emailChannel = false,
                            pushChannel = true,
                            smsChannel = false,
                            status = 0,
                            userId = 2
                        });
                });

            modelBuilder.Entity("OrderAPI.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userRole")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "Musa",
                            userRole = 1
                        },
                        new
                        {
                            id = 2,
                            name = "Erhan",
                            userRole = 1
                        },
                        new
                        {
                            id = 3,
                            name = "Hilal",
                            userRole = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
