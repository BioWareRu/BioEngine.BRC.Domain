using BioEngine.Core.Entities;
using BioEngine.Core.Interfaces;
using BioEngine.Core.Storage;

namespace BioEngine.BRC.Domain.Entities
{
    [TypedEntity(3)]
    public class Gallery : ContentItem<GalleryData>
    {
        public override string TypeTitle { get; set; } = "Галерея";
    }

    public class GalleryData : TypedData
    {
        public StorageItem[] Pictures { get; set; }
        public string Text { get; set; }
    }
}