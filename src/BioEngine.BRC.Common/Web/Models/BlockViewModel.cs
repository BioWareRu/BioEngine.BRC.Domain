using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Entities.Abstractions;

namespace BioEngine.BRC.Common.Web.Models
{
    public struct BlockViewModel<T, TData> where T : ContentBlock<TData> where TData : ContentBlockData, new()
    {
        public BlockViewModel(T block, IContentEntity contentEntity, Entities.Site site)
        {
            Block = block;
            ContentEntity = contentEntity;
            Site = site;
        }

        public T Block { get; set; }
        public IContentEntity ContentEntity { get; set; }
        public Entities.Site Site { get; set; }
    }
}
