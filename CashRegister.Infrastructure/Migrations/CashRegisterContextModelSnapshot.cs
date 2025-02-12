﻿// <auto-generated />
using System;
using CashRegister.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CashRegister.Infrastructure.Migrations
{
    [DbContext(typeof(CashRegisterContext))]
    partial class CashRegisterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("CashRegister.Core.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("CashRegister.Core.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PayementMethod")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("CashRegister.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdTax")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdTax");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("CashRegister.Core.Entities.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("CashRegister.Core.Entities.StockMovement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdStock")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<uint>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdStock");

                    b.ToTable("StockMovement");
                });

            modelBuilder.Entity("CashRegister.Core.Entities.Tax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TaxCoefficient")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tax");
                });

            modelBuilder.Entity("CashRegister.Core.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdProduct")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdTax")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TaxValue")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdProduct");

                    b.HasIndex("IdTax");

                    b.HasIndex("PaymentId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("ProductStockMovement", b =>
                {
                    b.Property<int>("ProductsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StockMovementsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductsId", "StockMovementsId");

                    b.HasIndex("StockMovementsId");

                    b.ToTable("ProductStockMovement");
                });

            modelBuilder.Entity("CashRegister.Core.Entities.Product", b =>
                {
                    b.HasOne("CashRegister.Core.Entities.Tax", "Tax")
                        .WithMany()
                        .HasForeignKey("IdTax")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tax");
                });

            modelBuilder.Entity("CashRegister.Core.Entities.StockMovement", b =>
                {
                    b.HasOne("CashRegister.Core.Entities.Stock", "Stock")
                        .WithMany("StockMovements")
                        .HasForeignKey("IdStock")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("CashRegister.Core.Entities.Transaction", b =>
                {
                    b.HasOne("CashRegister.Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CashRegister.Core.Entities.Tax", "Tax")
                        .WithMany()
                        .HasForeignKey("IdTax")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CashRegister.Core.Entities.Payment", null)
                        .WithMany("Transactions")
                        .HasForeignKey("PaymentId");

                    b.Navigation("Product");

                    b.Navigation("Tax");
                });

            modelBuilder.Entity("ProductStockMovement", b =>
                {
                    b.HasOne("CashRegister.Core.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CashRegister.Core.Entities.StockMovement", null)
                        .WithMany()
                        .HasForeignKey("StockMovementsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CashRegister.Core.Entities.Payment", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("CashRegister.Core.Entities.Stock", b =>
                {
                    b.Navigation("StockMovements");
                });
#pragma warning restore 612, 618
        }
    }
}
