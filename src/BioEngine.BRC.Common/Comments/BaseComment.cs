using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Entities.Abstractions;
using BioEngine.BRC.Common.Users;
using JetBrains.Annotations;

namespace BioEngine.BRC.Common.Comments
{
    [UsedImplicitly]
    public abstract class BaseComment : BaseEntity, IRoutable
    {
        [Required] public string ContentType { get; set; }
        [Required] public Guid ContentId { get; set; }
        [Required] public string AuthorId { get; set; }
        [Required] public Guid[] SiteIds { get; set; } = new Guid[0];
        public Guid? ReplyTo { get; set; }
        public string? Text { get; set; }

        [NotMapped] public IUser? Author { get; set; }

        [NotMapped] public IContentItem ContentItem { get; set; }
        [NotMapped] public string PublicRouteName { get; set; } = BioEngineCommentsRoutes.Comment;
        [NotMapped] public string Url { get; set; }
    }
}
