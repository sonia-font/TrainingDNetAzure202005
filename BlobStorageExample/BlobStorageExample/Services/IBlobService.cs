using System.Collections.Generic;
using System.Threading.Tasks;
using BlobInfo = BlobStorageExample.Models.BlobInfo;

namespace BlobStorageExample.Services
{
    public interface IBlobService
    {
        public Task<BlobInfo> GetBlobAsync(string name);

        public Task<IEnumerable<string>> ListBlobsAsync();

        public Task UploadFileBlobAsync(string filePath, string fileName);

        public Task UploadContentBlobAsync(string filePath, string fileName);

        public Task DeleteBlobAsync(string blobName);
    }
}
