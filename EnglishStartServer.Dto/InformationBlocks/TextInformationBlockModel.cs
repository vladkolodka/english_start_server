using EnglishStartServer.Database.Enums;

namespace EnglishStartServer.Dto.InformationBlocks
{
    public class TextInformationBlockModel : InformationBlockModel
    {
        public string Text { get; set; }

        public override InformationBlockType Type { get; set; } = InformationBlockType.Text;
    }
}