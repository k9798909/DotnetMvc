using System.Diagnostics;
using Blog.Data;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class MemberArticleController : Controller
    {
        private readonly ILogger<MemberArticleController> _logger;

        private readonly BlogDbContext _dbContext;

        private readonly UserManager<ApplicationUser> _userManager;

        public MemberArticleController(ILogger<MemberArticleController> logger, BlogDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _dbContext = dbContext;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.GetUserAsync(HttpContext.User);
            var articles = await _dbContext.Articles.Where(t => t.AuthorId == users!.Id && t.DeletedTime == null).ToListAsync();
            var articlesVM = articles.Select(t => new MemberArticleVM
            {
                Id = t.Id,
                Title = t.Title,
                CreatedTime = t.CreatedTime.ToLocalTime().ToString("yyyy-MM-dd HH:mm"),
            });
            return View(articlesVM);
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {
            var model = new ArticleEditVM();
            return View("Edit", model);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var article = await _dbContext.Articles.Where(t => t.Id == id).FirstAsync();
            var articleVM = new ArticleEditVM()
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                CategoryId = article.CategoryId.ToString()
            };
            return View("Edit", articleVM);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> EditPost(ArticleEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            if (model.Id == 0)
            {
                var article = new Article
                {
                    Title = model.Title!,
                    Content = model.Content!,
                    CategoryId = int.Parse(model.CategoryId!),
                    AuthorId = _userManager.GetUserId(HttpContext.User)!,
                    CreatedTime = DateTime.UtcNow
                };
                _dbContext.Articles.Add(article);
            }
            else
            {
                var article = await _dbContext.Articles.Where(t => t.Id == model.Id).FirstAsync();
                article.Title = model.Title!;
                article.Content = model.Content!;
                article.CategoryId = int.Parse(model.CategoryId!);
                article.UpdatedTime = DateTime.UtcNow;
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "MemberArticle");
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> UpdateForDelete(IFormCollection form)
        {
            string id = form["DeleteId"]!;
            var article = await _dbContext.Articles.Where(t => t.Id == int.Parse(id)).FirstAsync();
            article.DeletedTime = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "MemberArticle");
        }

        [HttpGet]
        [Route("Categories")]
        public async Task<IActionResult> Categories()
        {
            List<Category> categories = await _dbContext.Categories.ToListAsync();
            List<CategoryVM> categoryVMList = categories.Select(t => new CategoryVM { Id = t.Id, Name = t.Name }).ToList();
            return Json(categoryVMList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}