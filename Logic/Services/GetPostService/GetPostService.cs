using DatabaseAccess;
using DatabaseAccess.DbModels;

namespace Logic.Services.GetPostService
{
    public interface IGetPostService
    {
        Post GetPostById(int id);
    }
    public class GetPostService :ServiceTemplate, IGetPostService
    {
        public Post GetPostById(int id)
        {
            return Context.Posts.First(e => e.PostId == id);
        }

        public GetPostService(BlogDbContext context) : base(context)
        {
        }
    }
}
