using System.ComponentModel.DataAnnotations;

namespace EnglishStartServer.Database.Models
{
    public class TextInformationBlock : InformationBlock
    {
        [Required]
        public string Text { get; set; }
    }
}