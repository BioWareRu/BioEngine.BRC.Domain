using BioEngine.Core.Entities;
using BioEngine.Core.Interfaces;

namespace BioEngine.BRC.Domain.Entities
{
    [TypedEntity(3)]
    public class Topic : Section<TopicData>
    {
    }

    public class TopicData : TypedData
    {
    }
}