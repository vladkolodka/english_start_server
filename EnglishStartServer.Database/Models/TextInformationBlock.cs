﻿using System.ComponentModel.DataAnnotations;
using EnglishStartServer.Database.Enums;

namespace EnglishStartServer.Database.Models
{
    public class TextInformationBlock : InformationBlock
    {
        [Required]
        public string Text { get; set; }

        public override InformationBlockType BlockType { get; set; } = InformationBlockType.Text;
    }
}