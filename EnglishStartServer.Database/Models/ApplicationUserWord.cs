using System;

namespace EnglishStartServer.Database.Models
{
    public class ApplicationUserWord
    {
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Guid WordId { get; set; }
        public Word Word { get; set; }
        public int Stage { get; set; } = 0;
    }
}