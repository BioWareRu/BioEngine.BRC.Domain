using BioEngine.Core.Entities;
using BioEngine.Core.Interfaces;
using BioEngine.Core.Storage;

namespace BioEngine.BRC.Domain.Entities
{
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