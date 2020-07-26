using System.ComponentModel.DataAnnotations;
using BioEngine.BRC.Common.Components;
using BioEngine.BRC.Common.Entities.Abstractions;

namespace BioEngine.BRC.Common.Entities
{
    [Entity("site")]
    public class Site : BaseEntity, IBioEntity
    {
        [Required] public string Url { get; set; }

        [Required] public string Title { get; set; }
    }
}
