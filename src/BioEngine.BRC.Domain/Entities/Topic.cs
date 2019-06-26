using System.ComponentModel.DataAnnotations.Schema;
using BioEngine.Core.DB;

namespace BioEngine.BRC.Domain.Entities
{
    [Entity("topicsection")]
    public class Topic : BrcSection<TopicData>
    {
        public override string TypeTitle { get; set; } = "Тема";
        [NotMapped] public override string PublicRouteName { get; set; } = BrcDomainRoutes.TopicPublic;
    }

    public class TopicData : BrcSectionData
    {
    }
}
