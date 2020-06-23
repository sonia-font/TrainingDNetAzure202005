using BlobStorageExample.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlobStorageExample.Models
{
    public class BlobInfo
    {
        public Stream Content { get; set; }
        public string ContentType { get; set; }

        public BlobInfo(Stream _content, string _contentType)
        {
            Content = _content;
            ContentType = _contentType;
        }
    }
}
