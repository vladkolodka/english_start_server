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

        public static CourseModel ToDto(this Course c, bool? isStudied)
        {
            return new CourseModel
            {
                Id = c.Id,
                Name = c.Name,
                DateCreated = c.DateCreated,
                Description = c.Description,
                DiffictlyLevel = c.DiffictlyLevel,
                IsAdded = isStudied.HasValue,
                IsStudied = isStudied ?? false
            };
        }

        public static List<CourseModel> ToDto(this IEnumerable<Course> courses, IDictionary<Guid, bool> uc)
        {
            return courses.Select(c => c.ToDto(
                uc.ContainsKey(c.Id) ? uc[c.Id] : new bool?()
            )).ToList();
        }

        public static List<CourseModel> ToDto(this IEnumerable<ApplicationUserCourse> uc)
        {
            return uc.Select(c => c.Course.ToDto(c.IsStudied)).ToList();
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
                InformationBlocks = infos?.ToDto()
            };
        }

        public static List<ArticleModel> ToDto(this IEnumerable<Article> a)
        {
            return a.Select(ar => ar.ToDto(null)).ToList();
        }

        public static List<InformationBlockModel> ToDto(this IEnumerable<InformationBlock> infos)
        {
            return infos.Select(b => b.ToDto()).ToList();
        }

        public static InformationBlockModel ToDto(this InformationBlock b)
        {
            InformationBlockModel dto;

            switch (b)
            {
                case TextInformationBlock bl:
                    dto = new TextInformationBlockModel
                    {
                        Text = bl.Text
                    };
                    break;

                case VideoInformationBlock bl:
                    dto = new VideoInformationBlockModel
                    {
                        Url = bl.Url
                    };
                    break;
                case ImageInformationBlock bl:
                    dto = new ImageInformationBlockModel
                    {
                        Name = bl.FileId.ToString()
                    };
                    break;
                default:
                    dto = new InformationBlockModel();
                    break;
            }

            dto.SequentialNumber = b.SequentialNumber;
            dto.Id = b.Id;
            return dto;
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

        public static List<InformationBlock> ToEntity(this IEnumerable<InformationBlockModel> blocks)
        {
            return blocks.Select(b => b.ToEntity()).ToList();
        }

        public static InformationBlock ToEntity(this InformationBlockModel block)
        {
            InformationBlock model;

            // TODO image block file id
            switch (block)
            {
                case TextInformationBlockModel bl:
                    model = new TextInformationBlock
                    {
                        Text = bl.Text
                    };
                    break;

                case VideoInformationBlockModel bl:
                    model = new VideoInformationBlock
                    {
                        Url = bl.Url
                    };
                    break;
                case ImageInformationBlockModel _:
                    model = new ImageInformationBlock();
                    break;
                default:
                    model = new InformationBlock();
                    break;
            }

            model.SequentialNumber = block.SequentialNumber;
            return model;
        }

        public static void Update(this InformationBlock item, InformationBlockModel m)
        {
            switch (item)
            {
                case TextInformationBlock bl:
                {
                    var b = (TextInformationBlockModel) m;

                    bl.Text = b.Text;

                    break;
                }
                case ImageInformationBlock bl:
                {
                    var b = (ImageInformationBlockModel) m;

                    // TODO image

                    break;
                }
                case VideoInformationBlock bl:
                {
                    var b = (VideoInformationBlockModel) m;

                    bl.Url = b.Url;

                    break;
                }
            }

            item.SequentialNumber = m.SequentialNumber;
        }
    }
}