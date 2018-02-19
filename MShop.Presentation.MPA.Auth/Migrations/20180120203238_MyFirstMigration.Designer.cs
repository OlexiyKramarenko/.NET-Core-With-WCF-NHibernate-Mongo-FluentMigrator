﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MShop.DataLayer.EF;
using System;

namespace MShop.Presentation.MPA.Auth.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20180120203238_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("MShop.DataLayer.EF.Entities.Users.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

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

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Articles.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abstract");

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("Approved");

                    b.Property<string>("Body");

                    b.Property<int>("CategoryId");

                    b.Property<string>("City");

                    b.Property<bool>("CommentsEnabled");

                    b.Property<string>("Country");

                    b.Property<DateTime>("ExpireDate");

                    b.Property<bool>("Listed");

                    b.Property<bool>("OnlyForMembers");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("State");

                    b.Property<string>("Title");

                    b.Property<int>("TotalRating");

                    b.Property<int>("ViewCount");

                    b.Property<int>("Votes");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Articles.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<int>("Importance");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Articles.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<string>("AddedByEmail");

                    b.Property<string>("AddedByIp");

                    b.Property<DateTime>("AddedDate");

                    b.Property<int>("ArticleId");

                    b.Property<string>("Body");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Forums.Forum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<int>("Importance");

                    b.Property<bool>("Moderated");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Forums");
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Forums.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<string>("AddedByIP");

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("Approved");

                    b.Property<string>("Body");

                    b.Property<bool>("Closed");

                    b.Property<int>("ForumId");

                    b.Property<string>("LastPostBy");

                    b.Property<DateTime>("LastPostDate");

                    b.Property<int>("ParentPostId");

                    b.Property<int>("ReplyCount");

                    b.Property<string>("Title");

                    b.Property<int>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("ForumId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Newsletters.Newsletter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("HtmlBody");

                    b.Property<string>("PlainTextBody");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.ToTable("Newsletters");
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Polls.Poll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<DateTime?>("ArchivedDate");

                    b.Property<bool>("IsArchived");

                    b.Property<bool>("IsCurrent");

                    b.Property<string>("QuestionText");

                    b.Property<int>("Votes");

                    b.HasKey("Id");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Polls.PollOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("OptionText");

                    b.Property<double>("Percentage");

                    b.Property<int>("PollId");

                    b.Property<int>("Votes");

                    b.HasKey("Id");

                    b.HasIndex("PollId");

                    b.ToTable("PollOptions");
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Store.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<int>("Importance");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Store.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("CustomerEmail");

                    b.Property<string>("CustomerFax");

                    b.Property<string>("CustomerPhone");

                    b.Property<DateTime?>("ShippedDate");

                    b.Property<decimal>("Shipping");

                    b.Property<string>("ShippingCity");

                    b.Property<string>("ShippingCountry");

                    b.Property<string>("ShippingFirstName");

                    b.Property<string>("ShippingLastName");

                    b.Property<string>("ShippingMethod");

                    b.Property<string>("ShippingPostalCode");

                    b.Property<string>("ShippingState");

                    b.Property<string>("ShippingStreet");

                    b.Property<int>("StatusId");

                    b.Property<decimal>("SubTotal");

                    b.Property<string>("TrackingId");

                    b.Property<string>("TransactionId");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Store.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<string>("SKU");

                    b.Property<string>("Title");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Store.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses");
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Store.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Description");

                    b.Property<int>("DiscountPercentage");

                    b.Property<string>("FullImageUrl");

                    b.Property<string>("SKU");

                    b.Property<string>("SmallImageUrl");

                    b.Property<string>("Title");

                    b.Property<int>("TotalRating");

                    b.Property<decimal>("UnitPrice");

                    b.Property<int>("UnitsInStock");

                    b.Property<int>("Votes");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Store.ShippingMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddedBy");

                    b.Property<DateTime>("AddedDate");

                    b.Property<decimal>("Price");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("ShippingMethods");
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
                    b.HasOne("MShop.DataLayer.EF.Entities.Users.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MShop.DataLayer.EF.Entities.Users.ApplicationUser")
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

                    b.HasOne("MShop.DataLayer.EF.Entities.Users.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MShop.DataLayer.EF.Entities.Users.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Articles.Article", b =>
                {
                    b.HasOne("MShop.DataLayer.Entities.Articles.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Articles.Comment", b =>
                {
                    b.HasOne("MShop.DataLayer.Entities.Articles.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Forums.Post", b =>
                {
                    b.HasOne("MShop.DataLayer.Entities.Forums.Forum", "Forum")
                        .WithMany("Posts")
                        .HasForeignKey("ForumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Polls.PollOption", b =>
                {
                    b.HasOne("MShop.DataLayer.Entities.Polls.Poll", "Poll")
                        .WithMany("PollOptions")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Store.OrderItem", b =>
                {
                    b.HasOne("MShop.DataLayer.Entities.Store.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MShop.DataLayer.Entities.Store.Product", b =>
                {
                    b.HasOne("MShop.DataLayer.Entities.Store.Department", "Department")
                        .WithMany("Products")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
