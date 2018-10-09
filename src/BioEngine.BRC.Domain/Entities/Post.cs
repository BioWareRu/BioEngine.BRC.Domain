using BioEngine.Core.Entities;
using BioEngine.Core.Interfaces;
using BioEngine.BRC.Domain.Core;

namespace BioEngine.BRC.Domain.Entities
{
    [TypedEntity(BRCContentTypes.TypePost)]
    public class Post : ContentItem<PostData>
    {
        public override string TypeTitle { get; set; } = "Пост";
    }

    public class PostData : TypedData
    {
        public string Text { get; set; }
    }
}