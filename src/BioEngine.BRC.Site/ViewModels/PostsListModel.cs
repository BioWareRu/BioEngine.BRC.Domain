using BioEngine.Core.Entities;
using BioEngine.Posts.Entities;
using BioEngine.Core.Site.Model;

namespace BioEngine.BRC.Site.ViewModels
{
    public class PostsListModel : ListViewModel<Post>
    {
        public StorageItem Logo { get; }
        public StorageItem LogoSmall { get; }

        public PostsListModel(PageViewModelContext context, Post[] items, int totalItems, int page, int itemsPerPage,
            StorageItem logo, StorageItem logoSmall) :
            base(context, items, totalItems, page, itemsPerPage)
        {
            Logo = logo;
            LogoSmall = logoSmall;
        }
    }
}
