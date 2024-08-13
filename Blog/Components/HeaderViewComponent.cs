using System.Security.Claims;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public HeaderViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            ClaimsPrincipal user = HttpContext.User;
            var userName = _userManager.GetUserName(user);
            return View(new HeaderVM
            {
                IsLogin = !string.IsNullOrEmpty(userName),
                Username = userName
            });
        }
    }
}