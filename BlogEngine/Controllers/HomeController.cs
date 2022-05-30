using BlogEngine.ViewModels.Home;
using DatabaseAccess;
using Logic.Services.GetBlogsService;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogDbContext _context;

        public HomeController(BlogDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var blogs = new GetBlogsService(_context).GetTopBlogs(5);
            return View(new IndexViewModel()
            {
                Blogs = blogs
            });
        }
    }
}
