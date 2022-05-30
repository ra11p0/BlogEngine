using BlogEngine.ViewModels.Post;
using DatabaseAccess;
using DatabaseAccess.DbModels;
using Logic.Services.AddPostService;
using Logic.Services.GetPostService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.Controllers
{
    public class PostController : Controller
    {
        private readonly BlogDbContext _context;
        private readonly UserManager<User> _userManager;

        public PostController(BlogDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index(int postId)
        {
            var post = new GetPostService(_context).GetPostById(postId);
            return View(new IndexViewModel()
            {
                Post = post
            });
        }

        public IActionResult Create(int owningBlogId)
        {
            return View(new CreateViewModel()
            {
                OwningBlogId = owningBlogId
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var postId = new AddPostService(_context)
                    .AddPost(model.Title, model.PostText, model.OwningBlogId, user.Id);
                return RedirectToAction("Index", "Post", postId);
            }
            return View();
        }
    }
}
