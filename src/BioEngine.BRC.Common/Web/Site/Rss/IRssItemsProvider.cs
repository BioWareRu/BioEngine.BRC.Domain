using System.Collections.Generic;
using System.Threading.Tasks;
using cloudscribe.Syndication.Models.Rss;

namespace BioEngine.BRC.Common.Web.Site.Rss
{
    public interface IRssItemsProvider
    {
        Task<IEnumerable<RssItem>> GetItemsAsync(Entities.Site site, int count);
    }
}
