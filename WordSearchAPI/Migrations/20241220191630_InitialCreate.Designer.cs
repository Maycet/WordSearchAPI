﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WordSearchAPI.Data;

#nullable disable

namespace WordSearchAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241220191630_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("WordSearchAPI.Models.WordSearchLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Result")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SearchedWord")
                        .HasColumnType("longtext");

                    b.Property<string>("WordSearchContent")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("WordSearchLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
