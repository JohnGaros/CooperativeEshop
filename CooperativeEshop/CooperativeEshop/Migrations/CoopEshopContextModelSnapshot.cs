﻿// <auto-generated />
using CooperativeEshop.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CooperativeEshop.Migrations
{
    [DbContext(typeof(CoopEshopContext))]
    partial class CoopEshopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CooperativeEshop.Core.Domain.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<decimal>("AccountBalance");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.Cart", b =>
                {
                    b.Property<int>("CartID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerID")
                        .IsRequired();

                    b.HasKey("CartID");

                    b.HasIndex("CustomerID")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.CartItem", b =>
                {
                    b.Property<int>("CartItemID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CartID");

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime?>("DateRemoved");

                    b.Property<int>("ProductID");

                    b.Property<int>("QuantityInCart");

                    b.Property<string>("SellerID");

                    b.Property<decimal>("UnitPrice");

                    b.Property<bool>("WishListed");

                    b.HasKey("CartItemID");

                    b.HasIndex("CartID");

                    b.HasIndex("ProductID");

                    b.HasIndex("SellerID");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.CommunicationChannel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TypeID");

                    b.HasKey("ID");

                    b.HasIndex("TypeID");

                    b.ToTable("CommunicationChannels");
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.CommunicationChannelType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("ID");

                    b.ToTable("CommunicationChannelTypes");
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.Email", b =>
                {
                    b.Property<int>("CommChannelID");

                    b.Property<string>("EmailAddress");

                    b.HasKey("CommChannelID");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.Individual", b =>
                {
                    b.Property<string>("UserID");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("UserID");

                    b.ToTable("Individuals");
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.InventoryItem", b =>
                {
                    b.Property<int>("IneventoryItemID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("GoLive");

                    b.Property<int>("ProductID");

                    b.Property<string>("SellerId")
                        .IsRequired();

                    b.Property<int>("StockQuantity");

                    b.Property<string>("UserID");

                    b.HasKey("IneventoryItemID");

                    b.HasIndex("ProductID");

                    b.HasIndex("SellerId");

                    b.ToTable("InventoryItems");
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CartID");

                    b.Property<DateTime>("OrderDate");

                    b.HasKey("OrderID");

                    b.HasIndex("CartID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.Organization", b =>
                {
                    b.Property<string>("UserID");

                    b.Property<string>("OrganizationName");

                    b.HasKey("UserID");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.Phone", b =>
                {
                    b.Property<int>("CommChannelID");

                    b.Property<int>("AreaCode");

                    b.Property<int>("CountryCode");

                    b.Property<int>("PhoneNumber");

                    b.HasKey("CommChannelID");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.PhysicalAddress", b =>
                {
                    b.Property<int>("CommChannelID");

                    b.Property<string>("City");

                    b.Property<string>("County");

                    b.Property<string>("Line1");

                    b.Property<string>("Line2");

                    b.Property<int>("Zip");

                    b.HasKey("CommChannelID");

                    b.ToTable("PhysicalAddresses");
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CoverFilePath");

                    b.Property<string>("Name");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.ProductCategory", b =>
                {
                    b.Property<int>("ProductCategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ProductCategoryID");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.ProductCategoryClassification", b =>
                {
                    b.Property<int>("CategoryID");

                    b.Property<int>("ProductID");

                    b.HasKey("CategoryID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("ProductCategoryClassifications");
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.ProductPriceComponents", b =>
                {
                    b.Property<int>("PriceComponentID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("BasePrice");

                    b.Property<DateTime>("FromDate");

                    b.Property<int?>("ProductID")
                        .IsRequired();

                    b.Property<decimal>("SalePrice");

                    b.Property<string>("SellerId")
                        .IsRequired();

                    b.Property<DateTime>("ThruDate");

                    b.HasKey("PriceComponentID");

                    b.HasIndex("ProductID");

                    b.HasIndex("SellerId");

                    b.ToTable("ProductPriceComponents");
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.UserCommunicationChannel", b =>
                {
                    b.Property<int>("CommChannelID");

                    b.Property<string>("UserID");

                    b.HasKey("CommChannelID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("UserCommunicationChannels");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.Cart", b =>
                {
                    b.HasOne("CooperativeEshop.Core.Domain.AppUser", "Customer")
                        .WithOne("Cart")
                        .HasForeignKey("CooperativeEshop.Core.Domain.Cart", "CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.CartItem", b =>
                {
                    b.HasOne("CooperativeEshop.Core.Domain.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CooperativeEshop.Core.Domain.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CooperativeEshop.Core.Domain.AppUser", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerID");
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.CommunicationChannel", b =>
                {
                    b.HasOne("CooperativeEshop.Core.Domain.CommunicationChannelType", "Type")
                        .WithMany("CommChannels")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.Email", b =>
                {
                    b.HasOne("CooperativeEshop.Core.Domain.CommunicationChannel", "CommChannel")
                        .WithOne("Email")
                        .HasForeignKey("CooperativeEshop.Core.Domain.Email", "CommChannelID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.Individual", b =>
                {
                    b.HasOne("CooperativeEshop.Core.Domain.AppUser", "User")
                        .WithOne("Individual")
                        .HasForeignKey("CooperativeEshop.Core.Domain.Individual", "UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.InventoryItem", b =>
                {
                    b.HasOne("CooperativeEshop.Core.Domain.Product", "Product")
                        .WithMany("InventoryItems")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CooperativeEshop.Core.Domain.AppUser", "Seller")
                        .WithMany("InventoryItems")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.Order", b =>
                {
                    b.HasOne("CooperativeEshop.Core.Domain.Cart", "Cart")
                        .WithMany("Orders")
                        .HasForeignKey("CartID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.Organization", b =>
                {
                    b.HasOne("CooperativeEshop.Core.Domain.AppUser", "User")
                        .WithOne("Organization")
                        .HasForeignKey("CooperativeEshop.Core.Domain.Organization", "UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.Phone", b =>
                {
                    b.HasOne("CooperativeEshop.Core.Domain.CommunicationChannel", "CommChannel")
                        .WithOne("Phone")
                        .HasForeignKey("CooperativeEshop.Core.Domain.Phone", "CommChannelID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.PhysicalAddress", b =>
                {
                    b.HasOne("CooperativeEshop.Core.Domain.CommunicationChannel", "CommChannel")
                        .WithOne("PhysicalAddress")
                        .HasForeignKey("CooperativeEshop.Core.Domain.PhysicalAddress", "CommChannelID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.ProductCategoryClassification", b =>
                {
                    b.HasOne("CooperativeEshop.Core.Domain.ProductCategory", "Category")
                        .WithMany("ProductCategoryClassifications")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CooperativeEshop.Core.Domain.Product", "Product")
                        .WithMany("ProductCategoryClassifications")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.ProductPriceComponents", b =>
                {
                    b.HasOne("CooperativeEshop.Core.Domain.Product", "Product")
                        .WithMany("SellerProduct")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CooperativeEshop.Core.Domain.AppUser", "Seller")
                        .WithMany("SellerPrices")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CooperativeEshop.Core.Domain.UserCommunicationChannel", b =>
                {
                    b.HasOne("CooperativeEshop.Core.Domain.CommunicationChannel", "CommChannel")
                        .WithMany("UserCommunicationChannels")
                        .HasForeignKey("CommChannelID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CooperativeEshop.Core.Domain.AppUser", "User")
                        .WithMany("UserCommunicationChannels")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CooperativeEshop.Core.Domain.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CooperativeEshop.Core.Domain.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CooperativeEshop.Core.Domain.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CooperativeEshop.Core.Domain.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
