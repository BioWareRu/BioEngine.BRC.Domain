using BioEngine.BRC.Common.Social;

namespace BioEngine.BRC.Common.Twitter
{
    public class TwitterConfig : IContentPublisherConfig
    {
        public TwitterConfig(string consumerKey, string consumerSecret, string accessToken,
            string accessTokenSecret)
        {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
        }

        public string ConsumerKey { get; }
        public string ConsumerSecret { get; }
        public string AccessToken { get; }
        public string AccessTokenSecret { get; }
    }
}
