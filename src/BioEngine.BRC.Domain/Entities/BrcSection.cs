using BioEngine.Core.Abstractions;
using BioEngine.Core.Entities;

namespace BioEngine.BRC.Domain.Entities
{
    public abstract class BrcSection<TData> : Section<TData> where TData : BrcSectionData, new()
    {
    }

    public abstract class BrcSectionData : ITypedData
    {
        public virtual StorageItem HeaderPicture { get; set; }
        public virtual string Hashtag { get; set; }
    }
}
