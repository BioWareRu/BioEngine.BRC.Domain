using System.Collections.Generic;
using BioEngine.BRC.Common.Social;

namespace BioEngine.BRC.Common.Twitter
{
    public class TwitterPublishConfig : IContentPublisherConfig
    {
        public TwitterConfig Config { get; }
        public List<string> Tags { get; }

        public TwitterPublishConfig(TwitterConfig config, List<string> tags)
        {
            Config = config;
            Tags = tags;
        }
    }
}
