using System;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Entities.Abstractions;
using BioEngine.BRC.Common.Web.Site.Model;

namespace BioEngine.BRC.Common.Posts.Site
{
    public class PostViewModel : EntityViewModel<Post>
    {
        public int CommentsCount { get; }
        public Uri CommentsUri { get; }

        public PostViewModel(PageViewModelContext context, Post entity, int commentsCount,
            Uri commentsUri,
            ContentEntityViewMode mode = ContentEntityViewMode.List) :
            base(context, entity, mode)
        {
            CommentsCount = commentsCount;
            CommentsUri = commentsUri;
        }
    }
}
