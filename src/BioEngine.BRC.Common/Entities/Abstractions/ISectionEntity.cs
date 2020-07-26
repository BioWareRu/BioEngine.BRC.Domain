using System;
using System.Collections.Generic;
using Sitko.Core.Repository;

namespace BioEngine.BRC.Common.Entities.Abstractions
{
    public interface ISectionEntity : IEntity
    {
        Guid[] SectionIds { get; set; }
        Guid[] TagIds { get; set; }
        List<Tag> Tags { get; set; }
    }
}
