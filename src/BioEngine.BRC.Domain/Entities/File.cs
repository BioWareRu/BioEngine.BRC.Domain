using BioEngine.Core.Entities;
using BioEngine.Core.Interfaces;

namespace BioEngine.BRC.Domain.Entities
{
    [TypedEntity(2)]
    public class File : ContentItem<FileData>
    {
    }

    public class FileData : TypedData
    {
        public int Size { get; set; }
        public int DownloadsCount { get; set; }
    }
}