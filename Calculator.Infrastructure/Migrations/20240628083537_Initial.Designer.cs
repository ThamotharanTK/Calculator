﻿// <auto-generated />
using System;
using Calculator.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Calculator.Infrastructure.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240628083537_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("Calculator.Domain.Entities.CalculatorHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ErrorMessage")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EvaluateAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Input")
                        .HasColumnType("TEXT");

                    b.Property<double>("Result")
                        .HasColumnType("REAL");

                    b.Property<bool>("Succeeded")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CalculatorHistories");
                });

            modelBuilder.Entity("Calculator.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "thamotharan.tk@gmail.com",
                            FirstName = "Thamotharan",
                            LastName = "G",
                            Password = "Password@123"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
