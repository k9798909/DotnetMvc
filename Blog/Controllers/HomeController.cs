using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Blog.ViewModels;
using Microsoft.EntityFrameworkCore;
using Blog.Data;

namespace Blog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BlogDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, BlogDbContext dbContext)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var randomArticles = await _dbContext.Articles
            .Take(2)
            .Include(a => a.Category)
            .Include(a => a.Author)
            .Select(a => new HomeArticleVM
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content,
                CreatedTime = a.CreatedTime.ToLocalTime().ToString("yyyy年MM月dd日"),
                CategoryName = a.Category!.Name,
                AuthorName = a.Author!.Name,
            })
            .ToListAsync();

        var latestArticles = await _dbContext.Articles
            .OrderBy(a => a.CreatedTime)
            .Take(3)
            .Include(a => a.Category)
            .Include(a => a.Author)
            .Select(a => new HomeArticleVM
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content,
                CreatedTime = a.CreatedTime.ToLocalTime().ToString("yyyy年MM月dd日"),
                CategoryName = a.Category!.Name,
                AuthorName = a.Author!.Name,
            }).ToListAsync();

        return View(new HomeVM
        {
            RandomArticles = randomArticles,
            LatestArticles = latestArticles
        });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
