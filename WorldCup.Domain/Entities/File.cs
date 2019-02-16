using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WorldCup.Domain.Entities
{
    public class File
    {
        public string ContainerName { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public Stream BinaryContent { get; set; }

        public File()
        {

        }

        public File(string containerName, string fileName, 
                    string contentType, Stream binaryContent)
        {
            ContainerName = containerName;
            FileName = fileName;
            ContentType = contentType;
            BinaryContent = binaryContent;
        }
    }
}
