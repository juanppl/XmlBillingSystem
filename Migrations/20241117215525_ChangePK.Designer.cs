﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XmlBillingSystem.BillDbContext;

#nullable disable

namespace XmlBillingSystem.Migrations
{
    [DbContext(typeof(BillContext))]
    [Migration("20241117215525_ChangePK")]
    partial class ChangePK
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("XmlBillingSystem.BillDbContext.Models.Bill", b =>
                {
                    b.Property<int>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BILL_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("DATE");

                    b.Property<string>("ReferenceNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("REFERENCE_NUMBER");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal")
                        .HasColumnName("TOTAL_AMOUNT");

                    b.HasKey("BillId")
                        .HasName("PK_BILL");

                    b.HasIndex("CustomerId");

                    b.ToTable("BILL", (string)null);
                });

            modelBuilder.Entity("XmlBillingSystem.BillDbContext.Models.BillItem", b =>
                {
                    b.Property<int>("BillItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillItemId"));

                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal")
                        .HasColumnName("PRICE");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("QUANTITY");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("STOCK");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal")
                        .HasColumnName("SUB_TOTAL");

                    b.HasKey("BillItemId")
                        .HasName("PK_BILL_ITEM");

                    b.HasIndex("BillId");

                    b.HasIndex("ProductId");

                    b.ToTable("BILL_ITEM", (string)null);
                });

            modelBuilder.Entity("XmlBillingSystem.BillDbContext.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CATEGORY_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NAME");

                    b.HasKey("CategoryId")
                        .HasName("PK_CATEGORY");

                    b.ToTable("CATEGORY", (string)null);
                });

            modelBuilder.Entity("XmlBillingSystem.BillDbContext.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CUSTOMER_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ADDRESS");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LAST_NAME");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NAME");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("PHONE");

                    b.HasKey("CustomerId")
                        .HasName("PK_CUSTOMER");

                    b.ToTable("CUSTOMER", (string)null);
                });

            modelBuilder.Entity("XmlBillingSystem.BillDbContext.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CATEGORY_ID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IS_ACTIVE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NAME");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("PRICE");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("STOCK");

                    b.Property<double>("Tax")
                        .HasColumnType("float")
                        .HasColumnName("TAX");

                    b.HasKey("ProductId")
                        .HasName("PK_PRODUCT");

                    b.HasIndex("CategoryId");

                    b.ToTable("PRODUCT", (string)null);
                });

            modelBuilder.Entity("XmlBillingSystem.BillDbContext.Models.Bill", b =>
                {
                    b.HasOne("XmlBillingSystem.BillDbContext.Models.Customer", "Customer")
                        .WithMany("Bills")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_CUSTOMER_BILLS");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("XmlBillingSystem.BillDbContext.Models.BillItem", b =>
                {
                    b.HasOne("XmlBillingSystem.BillDbContext.Models.Bill", "Bill")
                        .WithMany("BillItems")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_BILL_ITEM_BILL");

                    b.HasOne("XmlBillingSystem.BillDbContext.Models.Product", "Product")
                        .WithMany("BillItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_BILL_ITEM_PRODUCT");

                    b.Navigation("Bill");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("XmlBillingSystem.BillDbContext.Models.Product", b =>
                {
                    b.HasOne("XmlBillingSystem.BillDbContext.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_PRODUCT_CATEGORY");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("XmlBillingSystem.BillDbContext.Models.Bill", b =>
                {
                    b.Navigation("BillItems");
                });

            modelBuilder.Entity("XmlBillingSystem.BillDbContext.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("XmlBillingSystem.BillDbContext.Models.Customer", b =>
                {
                    b.Navigation("Bills");
                });

            modelBuilder.Entity("XmlBillingSystem.BillDbContext.Models.Product", b =>
                {
                    b.Navigation("BillItems");
                });
#pragma warning restore 612, 618
        }
    }
}
