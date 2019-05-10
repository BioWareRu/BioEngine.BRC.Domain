using System.ComponentModel.DataAnnotations.Schema;
using BioEngine.Core.DB;
using BioEngine.Core.Entities;

namespace BioEngine.BRC.Domain.Entities
{
    [TypedEntity("topic")]
    public class Topic : Section<TopicData>
    {
        public override string TypeTitle { get; set; } = "Тема";
        [NotMapped] public override string PublicUrl => $"/topics/{Url}/about.html";
        [NotMapped] public override string PostsUrl => $"/topics/{Url}/posts.html";
    }

    public class TopicData : ITypedData
    {
    }
}
