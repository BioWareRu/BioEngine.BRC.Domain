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
    [Migration("20190503121845_add_Comments")]
    partial class add_Comments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BioEngine.Core.Comments.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<Guid>("ContentId");

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<bool>("IsPublished");

                    b.Property<Guid[]>("SiteIds")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.ContentBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContentId");

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<bool>("IsPublished");

                    b.Property<int>("Position");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator<string>("Type").HasValue("ContentBlock");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Items")
                        .HasColumnType("jsonb");

                    b.Property<Guid>("SiteId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Page", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<bool>("IsPublished");

                    b.Property<Guid[]>("SiteIds");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<bool>("IsPinned");

                    b.Property<bool>("IsPublished");

                    b.Property<Guid[]>("SectionIds");

                    b.Property<Guid[]>("SiteIds");

                    b.Property<Guid[]>("TagIds");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("IsPublished");

                    b.HasIndex("SectionIds");

                    b.HasIndex("SiteIds");

                    b.HasIndex("TagIds");

                    b.HasIndex("Url")
                        .IsUnique();

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.PostVersion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChangeAuthorId");

                    b.Property<string>("Data")
                        .HasColumnType("jsonb");

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<bool>("IsPublished");

                    b.Property<Guid>("PostId");

                    b.HasKey("Id");

                    b.ToTable("PostVersions");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.PropertiesRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<Guid>("EntityId");

                    b.Property<string>("EntityType");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Key")
                        .IsRequired();

                    b.Property<Guid?>("SiteId");

                    b.HasKey("Id");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Section", b =>
                {
                    b.Property<Guid>("Id")
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

                    b.Property<Guid?>("ParentId");

                    b.Property<Guid[]>("SiteIds");

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
                    b.Property<Guid>("Id")
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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<string>("FileName");

                    b.Property<string>("FilePath");

                    b.Property<long>("FileSize");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Path");

                    b.Property<string>("PictureInfo")
                        .HasColumnType("jsonb");

                    b.Property<string>("PublicUri");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("StorageItems");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("BioEngine.BRC.Domain.Entities.Blocks.TwitchBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("twitch");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.CutBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("cut");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.FileBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("file");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.GalleryBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("gallery");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.IframeBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("iframe");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.QuoteBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("quote");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.TextBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("text");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.TwitterBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("twitter");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.YoutubeBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("youtube");
                });

            modelBuilder.Entity("BioEngine.BRC.Domain.Entities.Developer", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.Section");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Sections");

                    b.HasDiscriminator().HasValue("developer");
                });

            modelBuilder.Entity("BioEngine.BRC.Domain.Entities.Game", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.Section");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Sections");

                    b.HasDiscriminator().HasValue("game");
                });

            modelBuilder.Entity("BioEngine.BRC.Domain.Entities.Topic", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.Section");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Sections");

                    b.HasDiscriminator().HasValue("topic");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.ContentBlock", b =>
                {
                    b.HasOne("BioEngine.Core.Entities.Page", "Page")
                        .WithMany("Blocks")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BioEngine.Core.Entities.Post", "Post")
                        .WithMany("Blocks")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BioEngine.Core.Entities.Section", "Section")
                        .WithMany("Blocks")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
