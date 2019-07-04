﻿// <auto-generated />
using System;
using BioEngine.Core.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BioEngine.BRC.Migrations.Migrations
{
    [DbContext(typeof(BioContext))]
    partial class BioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0-preview5.19227.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BioEngine.Core.Entities.ContentBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContentId");

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<int>("Position");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator<string>("Type").HasValue("ContentBlock");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.ContentItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorId")
                        .IsRequired();

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset?>("DatePublished");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<bool>("IsPublished");

                    b.Property<Guid[]>("SectionIds");

                    b.Property<Guid[]>("SiteIds");

                    b.Property<Guid[]>("TagIds");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("Type")
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

                    b.ToTable("Content");

                    b.HasDiscriminator<string>("Type").HasValue("ContentItem");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.ContentVersion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChangeAuthorId");

                    b.Property<Guid>("ContentId");

                    b.Property<string>("Data")
                        .HasColumnType("jsonb");

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.HasKey("Id");

                    b.ToTable("ContentVersions");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<string>("Items")
                        .HasColumnType("jsonb");

                    b.Property<Guid[]>("SiteIds");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.PropertiesRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<Guid>("EntityId");

                    b.Property<string>("EntityType");

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

                    b.Property<bool>("IsPublished");

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

                    b.Property<DateTimeOffset>("DateUpdated");

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

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<string>("FileName");

                    b.Property<string>("FilePath");

                    b.Property<long>("FileSize");

                    b.Property<string>("Hash");

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

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("BioEngine.Extra.Ads.Entities.Ad", b =>
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

                    b.ToTable("Ads");
                });

            modelBuilder.Entity("BioEngine.Extra.ContentTemplates.Entities.ContentItemTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorId")
                        .IsRequired();

                    b.Property<string>("ContentType")
                        .IsRequired();

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<Guid[]>("SectionIds")
                        .IsRequired();

                    b.Property<Guid[]>("TagIds")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ContentItemTemplates");
                });

            modelBuilder.Entity("BioEngine.Extra.Facebook.Entities.FacebookPublishRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContentId");

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<string>("PostId")
                        .IsRequired();

                    b.Property<Guid[]>("SiteIds");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("FacebookPublishRecord");
                });

            modelBuilder.Entity("BioEngine.Extra.IPB.Entities.IPBComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorId")
                        .IsRequired();

                    b.Property<Guid>("ContentId");

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<int>("PostId");

                    b.Property<Guid[]>("SiteIds")
                        .IsRequired();

                    b.Property<int>("TopicId");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.ToTable("IPBComment");
                });

            modelBuilder.Entity("BioEngine.Extra.IPB.Publishing.IPBPublishRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContentId");

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<int>("PostId");

                    b.Property<Guid[]>("SiteIds");

                    b.Property<int>("TopicId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("IPBPublishRecord");
                });

            modelBuilder.Entity("BioEngine.Extra.Twitter.TwitterPublishRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContentId");

                    b.Property<DateTimeOffset>("DateAdded");

                    b.Property<DateTimeOffset>("DateUpdated");

                    b.Property<Guid[]>("SiteIds");

                    b.Property<long>("TweetId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("TwitterPublishRecord");
                });

            modelBuilder.Entity("BioEngine.BRC.Domain.Entities.Blocks.TwitchBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("twitchblock");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.CutBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("cutblock");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.FileBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("fileblock");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.GalleryBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("galleryblock");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.IframeBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("iframeblock");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.PictureBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("pictureblock");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.QuoteBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("quoteblock");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.TextBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("textblock");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.TwitterBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("twitterblock");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.Blocks.YoutubeBlock", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentBlock");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("ContentBlocks");

                    b.HasDiscriminator().HasValue("youtubeblock");
                });

            modelBuilder.Entity("BioEngine.Core.Pages.Entities.Page", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentItem");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Content");

                    b.HasDiscriminator().HasValue("pagecontentitem");
                });

            modelBuilder.Entity("BioEngine.Core.Posts.Entities.Post", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.ContentItem");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Content");

                    b.HasDiscriminator().HasValue("postcontentitem");
                });

            modelBuilder.Entity("BioEngine.BRC.Domain.Entities.Developer", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.Section");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Sections");

                    b.HasDiscriminator().HasValue("developersection");
                });

            modelBuilder.Entity("BioEngine.BRC.Domain.Entities.Game", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.Section");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Sections");

                    b.HasDiscriminator().HasValue("gamesection");
                });

            modelBuilder.Entity("BioEngine.BRC.Domain.Entities.Topic", b =>
                {
                    b.HasBaseType("BioEngine.Core.Entities.Section");

                    b.Property<string>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("jsonb");

                    b.ToTable("Sections");

                    b.HasDiscriminator().HasValue("topicsection");
                });

            modelBuilder.Entity("BioEngine.Core.Entities.ContentBlock", b =>
                {
                    b.HasOne("BioEngine.Core.Entities.ContentItem", null)
                        .WithMany("Blocks")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BioEngine.Core.Entities.Section", null)
                        .WithMany("Blocks")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BioEngine.Extra.Ads.Entities.Ad", null)
                        .WithMany("Blocks")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BioEngine.Extra.IPB.Entities.IPBComment", b =>
                {
                    b.HasOne("BioEngine.Core.Entities.ContentItem", "ContentItem")
                        .WithMany()
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
