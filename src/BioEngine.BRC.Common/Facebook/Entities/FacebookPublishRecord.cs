using System.ComponentModel.DataAnnotations;
using BioEngine.BRC.Common.Components;
using BioEngine.BRC.Common.Social;

namespace BioEngine.BRC.Common.Facebook.Entities
{
    [Entity("facebookpublishrecord")]
    public class FacebookPublishRecord : BasePublishRecord
    {
        [Required] public string PostId { get; set; }
    }
}
