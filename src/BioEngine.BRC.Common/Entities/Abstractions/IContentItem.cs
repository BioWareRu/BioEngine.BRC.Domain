using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BioEngine.BRC.Common.Entities.Abstractions
{
    public interface IContentItem : IContentEntity, ISectionEntity
    {
        [NotMapped] List<Section> Sections { get; set; }
    }
}
