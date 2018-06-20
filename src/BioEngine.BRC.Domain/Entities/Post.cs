using BioEngine.Core.Entities;
using BioEngine.Core.Interfaces;

namespace BioEngine.BRC.Domain.Entities
{
    [TypedEntity(1)]
    public class Post : ContentItem<PostData>
    {
    }

    public class PostData : TypedData
    {
        public string MainText { get; set; }
        public string ExtendedText { get; set; }
    }
}