namespace Blog.ViewModels
{
    public class HomeVM
    {   
        public List<HomeArticleVM>? RandomArticles { get; set; }
        public List<HomeArticleVM>? LatestArticles { get; set; }
    }

    public class HomeArticleVM
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required string CategoryName { get; set; }
        public required string AuthorName { get; set; }
        public required string CreatedTime { get; set; }
    }
}