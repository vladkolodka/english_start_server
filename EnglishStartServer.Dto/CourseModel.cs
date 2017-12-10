using System;

namespace EnglishStartServer.Dto
{
    public class CourseModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int DiffictlyLevel { get; set; }
        public DateTime DateCreated { get; set; }

        public bool IsAdded { get; set; }
        public bool IsStudied { get; set; }
    }
}