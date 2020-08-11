﻿// <auto-generated />
using System;
using System.Collections.Generic;
using BioEngine.BRC.Common;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Entities.Blocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BioEngine.BRC.Common.Migrations
{
    [DbContext(typeof(BioContext))]
    partial class BioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Ad", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DatePublished")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean");

                    b.Property<Guid[]>("SiteIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SiteIds");

                    b.ToTable("Ads");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.ContentBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ContentId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator<string>("Type").HasValue("ContentBlock");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<List<MenuItem>>("Items")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<Guid[]>("SiteIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Page", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DatePublished")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean");

                    b.Property<Guid[]>("SiteIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IsPublished");

                    b.HasIndex("SiteIds");

                    b.HasIndex("Url")
                        .IsUnique();

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DatePublished")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean");

                    b.Property<Guid[]>("SectionIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<Guid[]>("SiteIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<Guid[]>("TagIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IsPublished");

                    b.HasIndex("SectionIds");

                    b.HasIndex("SiteIds");

                    b.HasIndex("TagIds");

                    b.HasIndex("Url")
                        .IsUnique();

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.PostTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid[]>("SectionIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<Guid[]>("TagIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PostTemplates");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.PostVersion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ChangeAuthorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ContentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("PostVersions");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.PropertiesRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uuid");

                    b.Property<string>("EntityType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("SiteId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Section", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DatePublished")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.Property<Guid[]>("SiteIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IsPublished");

                    b.HasIndex("SiteIds");

                    b.HasIndex("Type");

                    b.HasIndex("Url");

                    b.ToTable("Sections");

                    b.HasDiscriminator<string>("Type").HasValue("Section");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.StorageItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .HasColumnType("text");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("StorageItems");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Facebook.Entities.FacebookPublishRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ContentId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PostId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid[]>("SiteIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SiteIds");

                    b.ToTable("FacebookPublishRecord");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.IPB.Entities.IPBComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ContentId")
                        .HasColumnType("uuid");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<Guid?>("ReplyTo")
                        .HasColumnType("uuid");

                    b.Property<Guid[]>("SiteIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<int>("TopicId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("IPBComment");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.IPB.Publishing.IPBPublishRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ContentId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<Guid[]>("SiteIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<int>("TopicId")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("IPBPublishRecord");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Twitter.TwitterPublishRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ContentId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid[]>("SiteIds")
                        .IsRequired()
                        .HasColumnType("uuid[]");

                    b.Property<long>("TweetId")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SiteIds");

                    b.ToTable("TwitterPublishRecord");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Blocks.CutBlock", b =>
                {
                    b.HasBaseType("BioEngine.BRC.Common.Entities.ContentBlock");

                    b.Property<CutBlockData>("Data")
                        .IsRequired()
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("cutblock");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Blocks.FileBlock", b =>
                {
                    b.HasBaseType("BioEngine.BRC.Common.Entities.ContentBlock");

                    b.Property<FileBlockData>("Data")
                        .IsRequired()
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("fileblock");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Blocks.GalleryBlock", b =>
                {
                    b.HasBaseType("BioEngine.BRC.Common.Entities.ContentBlock");

                    b.Property<GalleryBlockData>("Data")
                        .IsRequired()
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("galleryblock");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Blocks.IframeBlock", b =>
                {
                    b.HasBaseType("BioEngine.BRC.Common.Entities.ContentBlock");

                    b.Property<IframeBlockData>("Data")
                        .IsRequired()
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("iframeblock");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Blocks.PictureBlock", b =>
                {
                    b.HasBaseType("BioEngine.BRC.Common.Entities.ContentBlock");

                    b.Property<PictureBlockData>("Data")
                        .IsRequired()
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("pictureblock");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Blocks.QuoteBlock", b =>
                {
                    b.HasBaseType("BioEngine.BRC.Common.Entities.ContentBlock");

                    b.Property<QuoteBlockData>("Data")
                        .IsRequired()
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("quoteblock");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Blocks.TextBlock", b =>
                {
                    b.HasBaseType("BioEngine.BRC.Common.Entities.ContentBlock");

                    b.Property<TextBlockData>("Data")
                        .IsRequired()
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("textblock");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Blocks.TwitchBlock", b =>
                {
                    b.HasBaseType("BioEngine.BRC.Common.Entities.ContentBlock");

                    b.Property<TwitchBlockData>("Data")
                        .IsRequired()
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("twitchblock");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Blocks.TwitterBlock", b =>
                {
                    b.HasBaseType("BioEngine.BRC.Common.Entities.ContentBlock");

                    b.Property<TwitterBlockData>("Data")
                        .IsRequired()
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("twitterblock");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Blocks.YoutubeBlock", b =>
                {
                    b.HasBaseType("BioEngine.BRC.Common.Entities.ContentBlock");

                    b.Property<YoutubeBlockData>("Data")
                        .IsRequired()
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("youtubeblock");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Developer", b =>
                {
                    b.HasBaseType("BioEngine.BRC.Common.Entities.Section");

                    b.Property<DeveloperData>("Data")
                        .IsRequired()
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Sections");

                    b.HasDiscriminator().HasValue("developersection");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Game", b =>
                {
                    b.HasBaseType("BioEngine.BRC.Common.Entities.Section");

                    b.Property<GameData>("Data")
                        .IsRequired()
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Sections");

                    b.HasDiscriminator().HasValue("gamesection");
                });

            modelBuilder.Entity("BioEngine.BRC.Common.Entities.Topic", b =>
                {
                    b.HasBaseType("BioEngine.BRC.Common.Entities.Section");

                    b.Property<TopicData>("Data")
                        .IsRequired()
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Sections");

                    b.HasDiscriminator().HasValue("topicsection");
                });
#pragma warning restore 612, 618
        }
    }
}