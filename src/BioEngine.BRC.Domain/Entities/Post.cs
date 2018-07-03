using BioEngine.Core.Entities;
using BioEngine.Core.Interfaces;

namespace BioEngine.BRC.Domain.Entities
{
    [TypedEntity(1)]
    public class Post : ContentItem<PostData>
    {
        public override string TypeTitle { get; set; } = "Пост";
    }

    public class PostData : TypedData
    {
        public string Text { get; set; }
    }
}