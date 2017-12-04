using System;
using System.Collections.Generic;
using System.Linq;
using EnglishStartServer.Database.Models;
using EnglishStartServer.Dto.InformationBlocks;

// TODO models validation

namespace EnglishStartServer.Dto
{
    public static class Extensions
    {
        // requires external data
        public static DictionaryModel ToDto(this Dictionary d, bool learningStatus)
        {
            return new DictionaryModel
            {
                Id = d.Id,
                Name = d.Name,
                DateCreated = d.DateCreated,
                ImageUrl = d.ImageId.ToString(),
                SourceLanguage = d.SourceLanguage?.Name,
                IsPublic = d.IsPublic,
                LearningStatus = learningStatus
            };
        }

        public static Dictionary ToEntity(this DictionaryModel d, Language sourceLanguage)
        {
            // TODO image
            return new Dictionary
            {
                Name = d.Name,
                SourceLanguage = sourceLanguage,
                Words = d.Words.ToEntity(),
                IsPublic = d.IsPublic
            };
        }

        public static WordModel ToDto(this Word w, int stage)
        {
            return new WordModel
            {
                Id = w.Id,
                Original = w.Original,
                Translation = w.Translation,
                ImageUrl = w.ImageId.ToString(),
                DictionaryId = w.DictionaryId,
                Stage = stage
            };
        }

        public static Word ToEntity(this WordModel w)
        {
            // TODO image
            return new Word
            {
                Original = w.Original,
                Translation = w.Translation
            };
        }

        public static List<WordModel> ToDto(this IEnumerable<Word> words, Dictionary<Guid, int> stages)
        {
            return words.Select(w => w.ToDto(stages[w.Id])).ToList();
        }

        public static List<WordModel> ToDto(this IEnumerable<Word> words, int stage)
        {
            return words.Select(w => w.ToDto(stage)).ToList();
        }

        public static List<Word> ToEntity(this IEnumerable<WordModel> words)
        {
            return words.Select(w => w.ToEntity()).ToList();
        }

        public static UserModel ToDto(this ApplicationUser u)
        {
            return new UserModel
            {
                Id = u.Id,
                Login = u.UserName
            };
        }

        public static CourseModel ToDto(this Course c)
        {
            return new CourseModel
            {
                Id = c.Id,
                Name = c.Name,
                DateCreated = c.DateCreated,
                Description = c.Description,
                DiffictlyLevel = c.DiffictlyLevel
            };
        }

        public static Course ToEntity(this CourseModel c)
        {
            return new Course
            {
                Name = c.Name,
                Description = c.Description,
                DiffictlyLevel = c.DiffictlyLevel
            };
        }

        public static ArticleModel ToDto(this Article a, IEnumerable<InformationBlock> infos)
        {
            return new ArticleModel
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                DateCreated = a.DateCreated,
                CourseId = a.CourseId,
                InformationBlocks = infos.ToDto()
            };
        }

        public static List<InformationBlockModel> ToDto(this IEnumerable<InformationBlock> infos)
        {
            return infos.Select(b => b.ToDto()).ToList();
        }

        public static InformationBlockModel ToDto(this InformationBlock b)
        {
            switch (b)
            {
                case TextInformationBlock bl:
                    return new TextInformationBlockModel
                    {
                        Text = bl.Text
                    };

                case VideoInformationBlock bl:
                    return new VideoInformationBlockModel
                    {
                        Url = bl.Url
                    };
                case ImageInformationBlock bl:
                    return new ImageInformationBlockModel
                    {
                        Name = bl.FileId.ToString()
                    };
                default:
                    return new InformationBlockModel();
            }
        }

        public static Article ToEntity(this ArticleModel a)
        {
            return new Article
            {
                Name = a.Name,
                Description = a.Description,
                InformationBlocks = a.InformationBlocks.ToEntity()
            };
        }

        public static List<InformationBlock> ToEntity(this List<InformationBlockModel> blocks)
        {
            return blocks.Select(b => b.ToEntity()).ToList();
        }

        public static InformationBlock ToEntity(this InformationBlockModel block)
        {


            return null;
        }
    }
}