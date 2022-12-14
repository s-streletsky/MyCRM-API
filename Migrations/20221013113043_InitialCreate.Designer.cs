// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCRM_API.Db;

#nullable disable

namespace MyCRM_API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221013113043_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("MyCRM_API.Models.Entities.ClientEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nickname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ShippingMethodId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("ShippingMethodId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("MyCRM_API.Models.Entities.CountryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("MyCRM_API.Models.Entities.CurrencyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("MyCRM_API.Models.Entities.ExchangeRateEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<float>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("ExchangeRates");
                });

            modelBuilder.Entity("MyCRM_API.Models.Entities.ManufacturerEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("MyCRM_API.Models.Entities.OrderEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<int>("StatusId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("StatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MyCRM_API.Models.Entities.OrderItemEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float?>("Discount")
                        .HasColumnType("REAL");

                    b.Property<float?>("ExchangeRate")
                        .HasColumnType("REAL");

                    b.Property<float?>("Expenses")
                        .HasColumnType("REAL");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("Price")
                        .HasColumnType("REAL");

                    b.Property<float?>("Profit")
                        .HasColumnType("REAL");

                    b.Property<float>("Quantity")
                        .HasColumnType("REAL");

                    b.Property<int>("StockItemId")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("Total")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("StockItemId");

                    b.ToTable("OrdersItems");
                });

            modelBuilder.Entity("MyCRM_API.Models.Entities.OrderStatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses");
                });

            modelBuilder.Entity("MyCRM_API.Models.Entities.PaymentEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Amount")
                        .HasColumnType("REAL");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("OrderId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("MyCRM_API.Models.Entities.ShippingMethodEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ShippingMethods");
                });

            modelBuilder.Entity("MyCRM_API.Models.Entities.StockArrivalEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<float>("Quantity")
                        .HasColumnType("REAL");

                    b.Property<int>("StockItemId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StockItemId");

                    b.ToTable("StockArrivals");
                });

            modelBuilder.Entity("MyCRM_API.Models.Entities.StockItemEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CurrencyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ManufacturerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<float>("PurchasePrice")
                        .HasColumnType("REAL");

                    b.Property<float>("RetailPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("StockItems");
                });

            modelBuilder.Entity("MyCRM_API.Models.Entities.ClientEntity", b =>
                {
                    b.HasOne("MyCRM_API.Models.Entities.CountryEntity", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("MyCRM_API.Models.Entities.ShippingMethodEntity", "ShippingMethod")
                        .WithMany()
                        .HasForeignKey("ShippingMethodId");

                    b.Navigation("Country");

                    b.Navigation("ShippingMethod");
                });

            modelBuilder.Entity("MyCRM_API.Models.Entities.ExchangeRateEntity", b =>
                {
                    b.HasOne("MyCRM_API.Models.Entities.CurrencyEntity", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("MyCRM_API.Models.Entities.OrderEntity", b =>
                {
                    b.HasOne("MyCRM_API.Models.Entities.ClientEntity", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCRM_API.Models.Entities.OrderStatusEntity", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("MyCRM_API.Models.Entities.OrderItemEntity", b =>
                {
                    b.HasOne("MyCRM_API.Models.Entities.OrderEntity", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCRM_API.Models.Entities.StockItemEntity", "StockItem")
                        .WithMany()
                        .HasForeignKey("StockItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("StockItem");
                });

            modelBuilder.Entity("MyCRM_API.Models.Entities.PaymentEntity", b =>
                {
                    b.HasOne("MyCRM_API.Models.Entities.ClientEntity", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCRM_API.Models.Entities.OrderEntity", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.Navigation("Client");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MyCRM_API.Models.Entities.StockArrivalEntity", b =>
                {
                    b.HasOne("MyCRM_API.Models.Entities.StockItemEntity", "StockItem")
                        .WithMany()
                        .HasForeignKey("StockItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StockItem");
                });

            modelBuilder.Entity("MyCRM_API.Models.Entities.StockItemEntity", b =>
                {
                    b.HasOne("MyCRM_API.Models.Entities.CurrencyEntity", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.HasOne("MyCRM_API.Models.Entities.ManufacturerEntity", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId");

                    b.Navigation("Currency");

                    b.Navigation("Manufacturer");
                });
#pragma warning restore 612, 618
        }
    }
}
