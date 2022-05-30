using BlogEngine.ViewModels.Blog;
using DatabaseAccess;
using DatabaseAccess.DbModels;
using Logic.Services.CreateBlogService;
using Logic.Services.GetBlogService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogDbContext _context;
        private readonly UserManager<User> _userManager;

        public BlogController(BlogDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index(int blogId)
        {
            var blog = new GetBlogService(_context).GetBlog(blogId);
            return View(new IndexViewModel()
            {
                Blog = blog!
            });
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.GetUserAsync(HttpContext.User);
                int blogId =
                    new CreateBlogService(_context).CreateBlog(createViewModel.BlogName, createViewModel.Description,
                        user);
                return RedirectToAction("Index", new { blogId = blogId });
            }
            return View();
        }
    }
}
