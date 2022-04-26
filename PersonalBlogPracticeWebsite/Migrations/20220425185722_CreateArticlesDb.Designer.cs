﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalBlogPracticeWebsite.Data;

#nullable disable

namespace PersonalBlogPracticeWebsite.Migrations
{
    [DbContext(typeof(ArticleDbContext))]
    [Migration("20220425185722_CreateArticlesDb")]
    partial class CreateArticlesDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("PersonalBlogPracticeWebsite.Data.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticleContentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticleInfoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ArticleContentId");

                    b.HasIndex("ArticleInfoId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("PersonalBlogPracticeWebsite.Data.ArticleContent", b =>
                {
                    b.Property<int>("ArticleContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("HtmlContent")
                        .HasColumnType("TEXT");

                    b.Property<string>("MarkDownContent")
                        .HasColumnType("TEXT");

                    b.Property<string>("MarkDownUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("ArticleContentId");

                    b.ToTable("ArticleContent");
                });

            modelBuilder.Entity("PersonalBlogPracticeWebsite.Data.ArticleInfo", b =>
                {
                    b.Property<int>("ArticleInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ArticleInfoId");

                    b.ToTable("ArticleInfo");
                });

            modelBuilder.Entity("PersonalBlogPracticeWebsite.Data.Article", b =>
                {
                    b.HasOne("PersonalBlogPracticeWebsite.Data.ArticleContent", "ArticleContent")
                        .WithMany()
                        .HasForeignKey("ArticleContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalBlogPracticeWebsite.Data.ArticleInfo", "ArticleInfo")
                        .WithMany()
                        .HasForeignKey("ArticleInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArticleContent");

                    b.Navigation("ArticleInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
