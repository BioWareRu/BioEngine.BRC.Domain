using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BioEngine.BRC.Common.Components;

namespace BioEngine.BRC.Common.Entities
{
    [Entity("propertiesrecord")]
    public class PropertiesRecord : BaseEntity
    {
        [Required] public string Key { get; set; } = "";
        public string EntityType { get; set; } = "";
        public Guid EntityId { get; set; }
        public Guid? SiteId { get; set; }

        [Column(TypeName = "jsonb")]
        [Required]
        public string Data { get; set; } = "";
    }
}
