using System;
using System.Collections.Generic;
using EnglishStartServer.Database.Enums;
using EnglishStartServer.Dto.InformationBlocks;
using Newtonsoft.Json.Linq;

namespace EnglishStartServer.Dto.Helpers
{
    public class InformationBlockConverter : JsonCreationConverter<InformationBlockModel>
    {
        private readonly Dictionary<InformationBlockType, Type> _types = new Dictionary<InformationBlockType, Type>
        {
            {InformationBlockType.Text, typeof(TextInformationBlockModel)},
            {InformationBlockType.Image, typeof(ImageInformationBlockModel)},
            {InformationBlockType.Video, typeof(VideoInformationBlockModel)}
        };

        protected override InformationBlockModel Create(Type objectType, JObject jObject)
        {
            return (InformationBlockModel) jObject.ToObject(_types[Enum.Parse<InformationBlockType>(
                jObject.GetValue("type", StringComparison.InvariantCultureIgnoreCase).Value<string>(), true)]);
        }
    }
}