using BioEngine.Core.Entities;
using BioEngine.Core.Interfaces;
using BioEngine.Core.Storage;
using BioEngine.BRC.Domain.Core;

namespace BioEngine.BRC.Domain.Entities
{
    [TypedEntity(BRCContentTypes.TypeFile)]
    public class File : ContentItem<FileData>
    {
        public override string TypeTitle { get; set; } = "Файл";
    }

    public class FileData : TypedData
    {
        public string Text { get; set; }
        public StorageItem File { get; set; }
    }
}