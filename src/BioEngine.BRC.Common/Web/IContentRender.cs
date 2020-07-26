using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities.Abstractions;

namespace BioEngine.BRC.Common.Web
{
    public interface IContentRender
    {
        Task<string> RenderHtmlAsync(IContentEntity contentEntity, Entities.Site site,
            ContentEntityViewMode mode = ContentEntityViewMode.List);
    }
}
