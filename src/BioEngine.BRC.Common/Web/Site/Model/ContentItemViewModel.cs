using System;
using BioEngine.BRC.Common.Entities.Abstractions;

namespace BioEngine.BRC.Common.Web.Site.Model
{
    public class ContentItemViewModel : EntityViewModel<IContentItem>
    {
        public int CommentsCount { get; }
        public Uri CommentsUri { get; }

        public ContentItemViewModel(PageViewModelContext context, IContentItem entity, int commentsCount,
            Uri commentsUri,
            ContentEntityViewMode mode = ContentEntityViewMode.List) :
            base(context, entity, mode)
        {
            CommentsCount = commentsCount;
            CommentsUri = commentsUri;
        }
    }
}
