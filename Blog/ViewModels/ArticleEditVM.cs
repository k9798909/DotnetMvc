
using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class ArticleEditVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "此欄位為必填。")]
        [StringLength(maximumLength: 80, ErrorMessage = "不得超過80字。")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "此欄位為必填。")]
        public string? CategoryId { get; set; }
        [Required(ErrorMessage = "此欄位為必填。")]
        public string? Content { get; set; }
    }
}