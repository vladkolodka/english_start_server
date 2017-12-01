using System;
using System.ComponentModel.DataAnnotations;

namespace EnglishStartServer.Database.Models
{
    public class ApplicationUserDictionary
    {
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Guid DictionaryId { get; set; }
        public Dictionary Dictionary { get; set; }

        public bool IsArchived { get; set; } = false;
        public bool IsStudied { get; set; } = false;

        [Required]
        public bool IsOwner { get; set; } = false;
    }
}