

using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "此欄位為必填。")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "此欄位為必填。")]
        public string? Password { get; set; }
        public bool IsRemberMe { get; set; }
    }
}