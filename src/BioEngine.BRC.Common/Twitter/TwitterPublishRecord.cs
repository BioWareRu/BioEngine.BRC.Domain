using BioEngine.BRC.Common.Components;
using BioEngine.BRC.Common.Social;

namespace BioEngine.BRC.Common.Twitter
{
    [Entity("twitterpublishrecord")]
    public class TwitterPublishRecord : BasePublishRecord
    {
        public long TweetId { get; set; }
    }
}
