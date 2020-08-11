using System;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Entities.Blocks;
using BioEngine.BRC.Common.Facebook.Entities;
using BioEngine.BRC.Common.IPB.Entities;
using BioEngine.BRC.Common.IPB.Publishing;
using BioEngine.BRC.Common.Properties;
using BioEngine.BRC.Common.Search;
using BioEngine.BRC.Common.Twitter;
using BioEngine.BRC.Common.Validation;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sitko.Core.App;
using Sitko.Core.Search;

namespace BioEngine.BRC.Common
{
    public class BrcDomainModule : BaseApplicationModule
    {
        public BrcDomainModule(BaseApplicationModuleConfig config, Application application) : base(config,
            application)
        {
        }

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            base.ConfigureServices(services, configuration, environment);
            services.AddScoped<PropertiesProvider>();
            services.RegisterSearchProvider<DevelopersSearchProvider, Developer, Guid>();
            services.RegisterSearchProvider<GamesSearchProvider, Game, Guid>();
            services.RegisterSearchProvider<TopicsSearchProvider, Topic, Guid>();
            services.RegisterSearchProvider<PostsSearchProvider, Post, Guid>();
            services.RegisterSearchProvider<PagesSearchProvider, Page, Guid>();

            var registrar = BRCDomainRegistrar.Instance(services);
            
            registrar.RegisterSiteEntity<Ad>();
            registrar.RegisterSiteEntity<Page>();
            registrar.RegisterContentItem<Post>();
            registrar.RegisterEntity<PostVersion>();

            registrar.RegisterEntity<PostTemplate>();
            registrar.RegisterSiteEntity<FacebookPublishRecord>();

            registrar.RegisterEntity<IPBPublishRecord>();
            registrar.RegisterEntity<IPBComment>();

            registrar.RegisterSiteEntity<TwitterPublishRecord>();

            registrar.RegisterSection<Developer, DeveloperData>();
            registrar.RegisterSection<Game, GameData>();
            registrar.RegisterSection<Topic, TopicData>();

            registrar.RegisterContentBlock<CutBlock, CutBlockData>();
            registrar.RegisterContentBlock<FileBlock, FileBlockData>();
            registrar.RegisterContentBlock<GalleryBlock, GalleryBlockData>();
            registrar.RegisterContentBlock<IframeBlock, IframeBlockData>();
            registrar.RegisterContentBlock<PictureBlock, PictureBlockData>();
            registrar.RegisterContentBlock<QuoteBlock, QuoteBlockData>();
            registrar.RegisterContentBlock<TextBlock, TextBlockData>();
            registrar.RegisterContentBlock<TwitterBlock, TwitterBlockData>();
            registrar.RegisterContentBlock<YoutubeBlock, YoutubeBlockData>();
            registrar.RegisterContentBlock<TwitchBlock, TwitchBlockData>();
        }
    }
}
