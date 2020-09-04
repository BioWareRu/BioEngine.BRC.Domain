using BioEngine.BRC.Common.Components;

namespace BioEngine.BRC.Common.Entities.Blocks
{
    [Entity("youtubeblock")]
    public class YoutubeBlock : ContentBlock<YoutubeBlockData>
    {
        public override string TypeTitle => "Youtube";
        public override string TypeIcon => "video_library";

        public override string ToString()
        {
            return $"Youtube: {Data.YoutubeId}";
        }
    }

    public class YoutubeBlockData : ContentBlockData
    {
        public string YoutubeId { get; set; } = "";
    }
}
