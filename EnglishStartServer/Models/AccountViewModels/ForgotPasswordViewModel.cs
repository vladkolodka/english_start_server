using System.ComponentModel.DataAnnotations;

namespace EnglishStartServer.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}