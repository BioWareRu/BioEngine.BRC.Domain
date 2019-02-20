﻿// <auto-generated />
using System;
using BioEngine.Core.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BioEngine.BRC.Domain.Migrations
{
    [DbContext(typeof(BioContext))]
    [Migration("20190220151856_storage_items_in_db")]
    partial class storage_items_in_db
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BioEngine.Core.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Items")
                        .HasColumnType("jsonb");

                    b.Property<int>("SiteId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<bool>("IsPublished");

                    b.Property<int[]>("SiteIds");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<bool>("IsPinned");

                    b.Property<bool>("IsPublished");

                    b.Property<int[]>("SectionIds");

                    b.Property<int[]>("SiteIds");

                    b.Property<int[]>("TagIds");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("IsPublished");

                    b.HasIndex("SectionIds");

                    b.HasIndex("SiteIds");

                    b.HasIndex("TagIds");

                    b.HasIndex("Url");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.PostBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Position");

                    b.Property<int>("PostId");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("PostBlocks");

                    b.HasDiscriminator<string>("Type").HasValue("PostBlock");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.PropertiesRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<string>("EntityId");

                    b.Property<string>("EntityType");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Key")
                        .IsRequired();

                    b.Property<int?>("SiteId");

                    b.HasKey("Id");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<string>("Hashtag")
                        .IsRequired();

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<string>("LogoSmall")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<int?>("ParentId");

                    b.Property<string>("ShortDescription")
                        .IsRequired();

                    b.Property<int[]>("SiteIds");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("IsPublished");

                    b.HasIndex("SiteIds");

                    b.HasIndex("Type");

                    b.HasIndex("Url");

                    b.ToTable("Sections");

                    b.HasDiscriminator<string>("Type").HasValue("Section");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Site", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.StorageItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<string>("FileName");

                    b.Property<string>("FilePath");

                    b.Property<long>("FileSize");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("PictureInfo")
                        .HasColumnType("jsonb");

                    b.Property<string>("PublicUri");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("StorageItems");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.CutBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.PostBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("PostBlocks");

                    b.HasDiscriminator().HasValue("BioEngine.Core.Entities.Blocks.CutBlock");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.FileBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.PostBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("PostBlocks");

                    b.HasDiscriminator().HasValue("BioEngine.Core.Entities.Blocks.FileBlock");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.GalleryBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.PostBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("PostBlocks");

                    b.HasDiscriminator().HasValue("BioEngine.Core.Entities.Blocks.GalleryBlock");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.TextBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.PostBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("PostBlocks");

                    b.HasDiscriminator().HasValue("BioEngine.Core.Entities.Blocks.TextBlock");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.TwitterBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.PostBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("PostBlocks");

                    b.HasDiscriminator().HasValue("BioEngine.Core.Entities.Blocks.TwitterBlock");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.YoutubeBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.PostBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("PostBlocks");

                    b.HasDiscriminator().HasValue("BioEngine.Core.Entities.Blocks.YoutubeBlock");
                });

            modelBuilder.Entity("BioEngine.BRC.Domain.Entities.Developer", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.Section");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Sections");

                    b.HasDiscriminator().HasValue("BioEngine.BRC.Domain.Entities.Developer");
                });

            modelBuilder.Entity("BioEngine.BRC.Domain.Entities.Game", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.Section");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Sections");

                    b.HasDiscriminator().HasValue("BioEngine.BRC.Domain.Entities.Game");
                });

            modelBuilder.Entity("BioEngine.BRC.Domain.Entities.Topic", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.Section");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Sections");

                    b.HasDiscriminator().HasValue("BioEngine.BRC.Domain.Entities.Topic");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.PostBlock", b =>
                {
                    b.HasOne("BioEngine.Core.Entities.Post", "Post")
                        .WithMany("Blocks")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
