using System;
using BioEngine.BRC.Common.Entities;

namespace BioEngine.BRC.Common.Social
{
    public abstract class BasePublishRecord : BaseSiteEntity
    {
        public Guid ContentId { get; set; }
        public string Type { get; set; }
    }
}
