using System.ComponentModel.DataAnnotations;

namespace EnglishStartServer.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}