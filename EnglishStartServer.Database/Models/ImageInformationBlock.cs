using System;
using EnglishStartServer.Database.Enums;

namespace EnglishStartServer.Database.Models
{
    public class ImageInformationBlock : InformationBlock
    {
        public Guid FileId { get; set; }
        public File File { get; set; }

        public override InformationBlockType BlockType { get; set; } = InformationBlockType.Image;
    }
}