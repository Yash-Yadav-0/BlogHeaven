﻿// <auto-generated />
using BlogHeaven.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlogHeaven.Migrations
{
    [DbContext(typeof(BlogHeavenContext))]
    [Migration("20240514101553_BlogHeaven")]
    partial class BlogHeaven
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BlogHeaven.Entities.Blog", b =>
                {
                    b.Property<int>("BloggerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BloggerId"));

                    b.Property<string>("BloggerDescription")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("BloggerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("BloggerId");

                    b.ToTable("Blogs");

                    b.HasData(
                        new
                        {
                            BloggerId = 1,
                            BloggerDescription = "Tech Enthusiast",
                            BloggerName = "Yash Yadav"
                        },
                        new
                        {
                            BloggerId = 2,
                            BloggerDescription = "Travel Explorer",
                            BloggerName = "Dipesh Shah"
                        });
                });

            modelBuilder.Entity("BlogHeaven.Entities.BlogsByBlogger", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BlogId"));

                    b.Property<string>("BlogDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BlogTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("BloggerId")
                        .HasColumnType("integer");

                    b.HasKey("BlogId");

                    b.HasIndex("BloggerId");

                    b.ToTable("BlogsByBlogger");

                    b.HasData(
                        new
                        {
                            BlogId = 3,
                            BlogDescription = "Nvidia is 2x faster then AMD.",
                            BlogTitle = "Nvidia Gpu",
                            BloggerId = 1
                        },
                        new
                        {
                            BlogId = 4,
                            BlogDescription = "Inter is expensive and uses more power.",
                            BlogTitle = "Intel Downfall",
                            BloggerId = 1
                        },
                        new
                        {
                            BlogId = 5,
                            BlogDescription = "Discovering the less-explored wonders of Southeast Asia.",
                            BlogTitle = "Hidden Gems in Southeast Asia",
                            BloggerId = 2
                        });
                });

            modelBuilder.Entity("BlogHeaven.Entities.BlogsByBlogger", b =>
                {
                    b.HasOne("BlogHeaven.Entities.Blog", "Blog")
                        .WithMany("BlogsByBlogger")
                        .HasForeignKey("BloggerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("BlogHeaven.Entities.Blog", b =>
                {
                    b.Navigation("BlogsByBlogger");
                });
#pragma warning restore 612, 618
        }
    }
}
