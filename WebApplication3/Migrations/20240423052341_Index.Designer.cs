﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication3.Models;

#nullable disable

namespace WebApplication3.Migrations
{
    [DbContext(typeof(BankContext))]
    [Migration("20240423052341_Index")]
    partial class Index
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("WebApplication3.Models.BankBranch", b =>
                {
                    b.Property<int>("BankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BranchManager")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LocationURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BankId");

                    b.ToTable("BankBranches");

                    b.HasData(
                        new
                        {
                            BankId = 1,
                            BranchManager = "Ali Mansor",
                            EmployeeCount = 20,
                            LocationName = "KFH Auto",
                            LocationURL = "https://maps.app.goo.gl/cqEbKLSB8p88RLaP7"
                        });
                });

            modelBuilder.Entity("WebApplication3.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CivilId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("bankBranchBankId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("bankBranchBankId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WebApplication3.Models.Employee", b =>
                {
                    b.HasOne("WebApplication3.Models.BankBranch", "bankBranch")
                        .WithMany("Employees")
                        .HasForeignKey("bankBranchBankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bankBranch");
                });

            modelBuilder.Entity("WebApplication3.Models.BankBranch", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
