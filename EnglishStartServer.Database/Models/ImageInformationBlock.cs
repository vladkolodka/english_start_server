using System;

namespace EnglishStartServer.Database.Models
{
    public class ImageInformationBlock : InformationBlock
    {
        public Guid FileId { get; set; }
        public File File { get; set; }
    }
}