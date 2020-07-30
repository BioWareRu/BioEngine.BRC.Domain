using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sitko.Core.Storage;

namespace BioEngine.BRC.Common.Web.Api.Controllers
{
    public class StorageController : ApiController
    {
        public StorageController(BaseControllerContext context) : base(context)
        {
        }

        [HttpGet]
        public Task<IEnumerable<StorageNode>> ListAsync(string path = "/")
        {
            throw new NotImplementedException();
            //return Storage.ListItemsAsync(path, "storage");
        }

        [HttpPost("upload")]
        public async Task<StorageNode> UploadAsync([FromQuery] string name, [FromQuery] string path = "/")
        {
            var item = await Storage.SaveFileAsync(await GetBodyAsStreamAsync(), name, path);
            return new StorageNode(item);
        }

        [HttpDelete]
        public async Task<bool> DeleteAsync([FromQuery] string path)
        {
            var result = await Storage.DeleteFileAsync(path);
            return result;
        }
    }

    public class StorageNode
    {
        public StorageNode(string name, string path)
        {
            Name = name;
            Path = path.Trim('/');
            IsDirectory = true;
            Item = null;
        }

        public StorageNode(StorageItem item)
        {
            Name = item.FileName;
            IsDirectory = false;
            Item = item;
            Path = item.FilePath;
        }

        public StorageNode(StorageNode node, string root = "/")
        {
            Name = node.Name;
            IsDirectory = node.IsDirectory;
            Item = node.Item;
            Path = node.Path.Replace(root, "").Trim('/');
        }

        public string Name { get; }
        public string Path { get; }
        public bool IsDirectory { get; }
        public StorageItem? Item { get; }
        public List<StorageNode> Items { get; } = new List<StorageNode>();
    }
}
