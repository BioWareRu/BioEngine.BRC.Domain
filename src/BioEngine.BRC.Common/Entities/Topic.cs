﻿using System.ComponentModel.DataAnnotations.Schema;
using BioEngine.BRC.Common.Components;

namespace BioEngine.BRC.Common.Entities
{
    [Entity("topicsection")]
    public class Topic : BrcSection<TopicData>
    {
        public override string? TypeTitle { get; set; } = "Тема";
        [NotMapped] public override string PublicRouteName { get; set; } = BrcDomainRoutes.TopicPublic;
    }

    public class TopicData : BrcSectionData
    {
    }
}