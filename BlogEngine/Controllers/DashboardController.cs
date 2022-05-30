using BlogEngine.ViewModels.Dashboard;
using DatabaseAccess;
using DatabaseAccess.DbModels;
using Logic.Services.GetBlogsService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Controllers
{
    public class DashboardController : Controller
    {
        private readonly BlogDbContext _context;
        private readonly UserManager<User> _userManager;

        public DashboardController(BlogDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var blogs = new GetBlogsService(_context).GetBlogsByUser(user);
            return View(new IndexViewModel()
            {
                Blogs = blogs
            });
        }
    }
}
