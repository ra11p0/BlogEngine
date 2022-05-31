using BlogEngine.ViewModels.Post;
using BlogEngine.ViewModels.Post.Partial;
using DatabaseAccess;
using DatabaseAccess.DbModels;
using Logic.Services.AddCommentService;
using Logic.Services.AddPostService;
using Logic.Services.GetCommentsService;
using Logic.Services.GetPostService;
using Logic.Services.RateService;
using Logic.Services.RemovePostService;
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
            var liked = new RateService(_context).GetLikedCount(post);
            var disliked = new RateService(_context).GetDislikedCount(post);
            var comments = new GetCommentsService(_context).GetCommentsDtosOf(post);
            return View(new IndexViewModel()
            {
                Post = post,
                Liked = liked,
                Disliked = disliked,
                CommentsDtos = comments
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
                var _postId = new AddPostService(_context)
                    .AddPost(model.Title, model.PostText, model.OwningBlogId, user.Id);
                return RedirectToAction("Index", new{postId = _postId});
            }
            return View(new CreateViewModel()
            {
                OwningBlogId = model.OwningBlogId
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Remove(int postId, int _blogId)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            new RemovePostService(_context).RemovePostById(user.Id, postId);
            return RedirectToAction("Index","Blog", new { blogId = _blogId });
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Rate(int _postId, Reactions reaction)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var post = new GetPostService(_context).GetPostById(_postId);
            new RateService(_context).Rate(post, reaction, user.Id);
            return RedirectToAction("Index", new { postId = _postId });
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Comment(CommentCreatorViewModel viewModel)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var post = new GetPostService(_context).GetPostById(viewModel.CommendableId);
            new AddCommentService(_context).AddComment(post, viewModel.CommentText, user.Id);
            return RedirectToAction("Index", new { postId = viewModel.CommendableId });
        }
    }
}
