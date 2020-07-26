using System.ComponentModel.DataAnnotations;
using BioEngine.BRC.Common.Comments;
using BioEngine.BRC.Common.Components;

namespace BioEngine.BRC.Common.IPB.Entities
{
    [Entity("ipbcomments")]
    public class IPBComment : BaseComment
    {
        [Required] public int PostId { get; set; }
        [Required] public int TopicId { get; set; }
    }
}
