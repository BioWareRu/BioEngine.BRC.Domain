using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BioEngine.BRC.Common.Components;

namespace BioEngine.BRC.Common.Entities
{
    [Table("Tags")]
    [Entity("tag")]
    public class Tag : BaseEntity
    {
        [Required]
        public string Title { get; set; }
    }
}
