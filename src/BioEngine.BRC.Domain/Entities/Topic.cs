using BioEngine.Core.Entities;

namespace BioEngine.BRC.Domain.Entities
{
    public class Topic : Section<TopicData>
    {
        public override string TypeTitle { get; set; } = "Тема";
    }

    public class TopicData : TypedData
    {
    }
}