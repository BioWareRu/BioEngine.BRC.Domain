using System.Linq;
using BioEngine.BRC.Common.Components;

namespace BioEngine.BRC.Common.Entities.Blocks
{
    [Entity("galleryblock")]
    public class GalleryBlock : ContentBlock<GalleryBlockData>
    {
        public override string TypeTitle=> "Галерея";
        public override string TypeIcon => "collections";

        public override string ToString()
        {
            return $"Галерея: {string.Join(", ", Data.Pictures.Select(p => p.FileName))}";
        }
    }

    public class GalleryBlockData : ContentBlockData
    {
        public StorageItem[] Pictures { get; set; } = new StorageItem[0];
    }
}
