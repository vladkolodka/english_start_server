using System;
using System.ComponentModel.DataAnnotations;

namespace EnglishStartServer.Database.Models
{
    public class ImageInformationBlock : InformationBlock
    {
        public Guid FileId { get; set; }
        public File File { get; set; }
    }
}