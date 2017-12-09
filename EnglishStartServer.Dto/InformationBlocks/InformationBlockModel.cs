using System;
using EnglishStartServer.Database.Enums;

namespace EnglishStartServer.Dto.InformationBlocks
{
    public class InformationBlockModel
    {
        public Guid Id { get; set; }
        public virtual InformationBlockType Type { get; set; }
        public int SequentialNumber { get; set; } = 0;
    }
}