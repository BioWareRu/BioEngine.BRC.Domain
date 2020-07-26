using System;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Entities.Blocks;
using BioEngine.BRC.Common.Facebook.Entities;
using BioEngine.BRC.Common.IPB.Entities;
using BioEngine.BRC.Common.IPB.Publishing;
using BioEngine.BRC.Common.Twitter;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BioEngine.BRC.Common
{
    public class BioContext : DbContext

    {
        public BioContext(DbContextOptions<BioContext> options) : base(options)
        {
        }

        [UsedImplicitly] public DbSet<Site> Sites { get; set; }
        [UsedImplicitly] public DbSet<Tag> Tags { get; set; }
        [UsedImplicitly] public DbSet<Menu> Menus { get; set; }
        [UsedImplicitly] public DbSet<Section> Sections { get; set; }
        [UsedImplicitly] public DbSet<ContentBlock> Blocks { get; set; }
        [UsedImplicitly] public DbSet<StorageItem> StorageItems { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<PropertiesRecord> Properties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<StorageItem>().Property(i => i.PublicUri)
                .HasConversion(u => u.ToString(), s => new Uri(s));


            modelBuilder.Entity<Section>().HasIndex(s => s.SiteIds);
            modelBuilder.Entity<Section>().HasIndex(s => s.IsPublished);
            modelBuilder.Entity<Section>().HasIndex(s => s.Type);
            modelBuilder.Entity<Section>().HasIndex(s => s.Url);

            modelBuilder.RegisterSiteEntity<Ad>();
            
            modelBuilder.RegisterSiteEntity<Page>();
            modelBuilder.Entity<Page>().HasIndex(p => p.IsPublished);
            modelBuilder.Entity<Page>().HasIndex(p => p.Url).IsUnique();
            
            modelBuilder.RegisterContentItem<Post>();
            modelBuilder.RegisterEntity<PostVersion>();
            
            modelBuilder.RegisterEntity<PostTemplate>();
            modelBuilder.Entity<PostTemplate>().Property(c => c.Data).HasConversion(
                d => JsonConvert.SerializeObject(d,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        TypeNameHandling = TypeNameHandling.Auto
                    }),
                j => JsonConvert.DeserializeObject<PostTemplateData>(j,
                    new JsonSerializerSettings
                    {
                        MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                        TypeNameHandling = TypeNameHandling.Auto
                    }));
                    
            modelBuilder.RegisterSiteEntity<FacebookPublishRecord>();
            
            modelBuilder.RegisterEntity<IPBPublishRecord>();
            modelBuilder.RegisterEntity<IPBComment>();
            
            modelBuilder.RegisterSiteEntity<TwitterPublishRecord>();
            
            modelBuilder.RegisterSection<Developer, DeveloperData>();
            modelBuilder.RegisterSection<Game, GameData>();
            modelBuilder.RegisterSection<Topic, TopicData>();

            modelBuilder.RegisterContentBlock<CutBlock, CutBlockData>();
            modelBuilder.RegisterContentBlock<FileBlock, FileBlockData>();
            modelBuilder.RegisterContentBlock<GalleryBlock, GalleryBlockData>();
            modelBuilder.RegisterContentBlock<IframeBlock, IframeBlockData>();
            modelBuilder.RegisterContentBlock<PictureBlock, PictureBlockData>();
            modelBuilder.RegisterContentBlock<QuoteBlock, QuoteBlockData>();
            modelBuilder.RegisterContentBlock<TextBlock, TextBlockData>();
            modelBuilder.RegisterContentBlock<TwitterBlock, TwitterBlockData>();
            modelBuilder.RegisterContentBlock<YoutubeBlock, YoutubeBlockData>();
            modelBuilder.RegisterContentBlock<TwitchBlock, TwitchBlockData>();
        }
    }
}
