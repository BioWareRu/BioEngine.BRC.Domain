using System;

namespace BioEngine.BRC.Common.Entities.Abstractions
{
    public interface ISiteEntity : IBioEntity
    {
        Guid[] SiteIds { get; set; }
    }
}
