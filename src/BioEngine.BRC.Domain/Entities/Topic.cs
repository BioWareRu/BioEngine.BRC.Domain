using System.ComponentModel.DataAnnotations.Schema;
using BioEngine.Core.DB;
using BioEngine.Core.Entities;

namespace BioEngine.BRC.Domain.Entities
{
    [TypedEntity("topic")]
    public class Topic : Section<TopicData>
    {
        public override string TypeTitle { get; set; } = "Тема";
        [NotMapped] public override string PublicUrl => $"/topic/{Url}.html";
    }

    public class TopicData : ITypedData
    {
    }
}
