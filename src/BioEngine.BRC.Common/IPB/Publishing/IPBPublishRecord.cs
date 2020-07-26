using System.ComponentModel.DataAnnotations;
using BioEngine.BRC.Common.Components;
using BioEngine.BRC.Common.Social;

namespace BioEngine.BRC.Common.IPB.Publishing
{
    [Entity("ipbpublishrecord")]
    public class IPBPublishRecord : BasePublishRecord
    {
        [Required] public int TopicId { get; set; }
        [Required] public int PostId { get; set; }
    }
}
