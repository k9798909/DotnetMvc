
namespace Blog.ViewModels
{
    public class MemberArticleVM
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string CreatedTime { get; set; }
    }
}