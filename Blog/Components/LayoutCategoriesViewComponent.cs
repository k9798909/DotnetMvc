using Blog.Data;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Components
{
    public class LayoutCategoriesViewComponent : ViewComponent
    {
        private readonly BlogDbContext _dbContext;

        private readonly ILogger<LayoutCategoriesViewComponent> _logger;


        public LayoutCategoriesViewComponent(BlogDbContext blogContext, ILogger<LayoutCategoriesViewComponent> logger)
        {
            _dbContext = blogContext;
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                List<Category> categories = await _dbContext.Categories.ToListAsync();
                List<CategoryVM> categoryVMList = categories.Select(t => new CategoryVM { Id = t.Id, Name = t.Name }).ToList();
                return View(categoryVMList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching categories");
                return View(new List<CategoryVM>());
            }
        }
    }
}