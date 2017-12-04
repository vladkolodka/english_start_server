using EnglishStartServer.Database.Enums;

namespace EnglishStartServer.Dto.InformationBlocks
{
    public class ImageInformationBlockModel : InformationBlockModel
    {
        public override InformationBlockType Type { get; set; } = InformationBlockType.Image;
        public string Name { get; set; }
    }
}