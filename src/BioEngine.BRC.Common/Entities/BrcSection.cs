using BioEngine.BRC.Common.Entities.Abstractions;

namespace BioEngine.BRC.Common.Entities
{
    public abstract class BrcSection<TData> : Section<TData> where TData : BrcSectionData, new()
    {
    }

    public abstract class BrcSectionData : ITypedData
    {
        public virtual StorageItem? HeaderPicture { get; set; }
        public virtual string Hashtag { get; set; }
    }
}
