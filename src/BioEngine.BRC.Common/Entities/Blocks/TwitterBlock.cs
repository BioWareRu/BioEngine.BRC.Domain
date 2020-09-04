using BioEngine.BRC.Common.Components;

namespace BioEngine.BRC.Common.Entities.Blocks
{
    [Entity("twitterblock")]
    public class TwitterBlock : ContentBlock<TwitterBlockData>
    {
        public override string TypeTitle => "Twitter";
        public override string TypeIcon => "message";

        public override string ToString()
        {
            return $"Twitter: {Data.TweetId} by {Data.TweetAuthor}";
        }
    }

    public class TwitterBlockData : ContentBlockData
    {
        public string TweetId { get; set; } = "";
        public string TweetAuthor { get; set; } = "";
    }
}
