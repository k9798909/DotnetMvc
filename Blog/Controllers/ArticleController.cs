using System.Diagnostics;
using Blog.Data;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [Route("[controller]")]
    public class ArticleController : Controller
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly BlogDbContext _dbContext;

        public ArticleController(ILogger<ArticleController> logger, BlogDbContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        [HttpGet]
        [Route("{categoryId?}")]
        public async Task<IActionResult> Index(int categoryId)
        {
            var model = await _dbContext.Articles
                .Include(a => a.Category)
                .Include(a => a.Author)
                .Where(a => a.CategoryId == categoryId && a.DeletedTime == null)
                .Select(a => new ArticleVM
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    CreatedTime = a.CreatedTime.ToLocalTime().ToString("yyyy年MM月dd日"),
                    CategoryName = a.Category!.Name,
                    AuthorName = a.Author!.Name,
                }).ToListAsync();

            return View(model);
        }


        [HttpGet]
        [Route("Detail/{id?}")]
        public async Task<IActionResult> Detail(int id)
        {
            var model = await _dbContext.Articles
                .Where(t => t.Id == id && t.DeletedTime == null)
                .Include(a => a.Category)
                .Include(a => a.Author)
                .Select(a => new ArticleVM
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    CreatedTime = a.CreatedTime.ToLocalTime().ToString("yyyy年MM月dd日"),
                    CategoryName = a.Category!.Name,
                    AuthorName = a.Author!.Name,
                })
                .FirstAsync();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}