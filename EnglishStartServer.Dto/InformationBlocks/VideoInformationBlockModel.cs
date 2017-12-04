using EnglishStartServer.Database.Enums;

namespace EnglishStartServer.Dto.InformationBlocks
{
    public class VideoInformationBlockModel : InformationBlockModel
    {
        public string Url { get; set; }

        public override InformationBlockType Type { get; set; } = InformationBlockType.Video;
    }
}