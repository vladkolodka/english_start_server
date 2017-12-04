using System.ComponentModel.DataAnnotations;
using EnglishStartServer.Database.Enums;

namespace EnglishStartServer.Database.Models
{
    public class VideoInformationBlock : InformationBlock
    {
        [Required]
        public string Url { get; set; }

        public override InformationBlockType BlockType { get; set; } = InformationBlockType.Video;
    }
}