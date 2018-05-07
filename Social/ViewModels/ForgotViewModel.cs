using System.ComponentModel.DataAnnotations;

namespace Social.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

}