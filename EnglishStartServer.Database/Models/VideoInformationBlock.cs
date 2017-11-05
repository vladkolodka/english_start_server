using System.ComponentModel.DataAnnotations;

namespace EnglishStartServer.Database.Models
{
    public class VideoInformationBlock : InformationBlock
    {
        [Required]
        public string Url { get; set; }
    }
}