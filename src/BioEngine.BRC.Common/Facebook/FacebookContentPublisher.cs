using System;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Entities.Abstractions;
using BioEngine.BRC.Common.Facebook.Entities;
using BioEngine.BRC.Common.Facebook.Service;
using BioEngine.BRC.Common.Routing;
using BioEngine.BRC.Common.Social;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace BioEngine.BRC.Common.Facebook
{
    public class FacebookContentPublisher : BaseContentPublisher<FacebookConfig, FacebookPublishRecord>
    {
        private readonly FacebookService _facebookService;
        private readonly LinkGenerator _linkGenerator;

        public FacebookContentPublisher(FacebookService facebookService, BioContext dbContext,
            ILogger<FacebookContentPublisher> logger, LinkGenerator linkGenerator) : base(dbContext, logger)
        {
            _facebookService = facebookService;
            _linkGenerator = linkGenerator;
        }

        protected override async Task<FacebookPublishRecord> DoPublishAsync(FacebookPublishRecord record,
            IContentItem entity, Site site,
            FacebookConfig config)
        {
            var postId = await _facebookService.PostLinkAsync(_linkGenerator.GeneratePublicUrl(entity, site),
                config);
            if (string.IsNullOrEmpty(postId))
            {
                throw new Exception($"Can't create facebook post for item {entity.Title} ({entity.Id.ToString()})");
            }

            record.PostId = postId;

            return record;
        }

        protected override async Task<bool> DoDeleteAsync(FacebookPublishRecord record, FacebookConfig config)
        {
            var deleted = await _facebookService.DeletePostAsync(record.PostId, config);
            if (deleted)
            {
                return true;
            }

            throw new Exception("Can't delete content post from Facebook");
        }
    }
}
