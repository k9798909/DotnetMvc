
using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "此欄位為必填。")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "此欄位為必填。")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "僅允許數字和英文字符。")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "此欄位為必填。")]
        [EmailAddress(ErrorMessage = "電子信箱格式錯誤。")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "此欄位為必填。")]
        [RegularExpression(@"(?=.*[a-zA-Z]).+", ErrorMessage = "密碼至少需要一個英文字。")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "此欄位為必填。")]
        [Compare("Password", ErrorMessage = "密碼確認與密碼不符。")]
        public string? ConfirmPassword { get; set; }
    }
}