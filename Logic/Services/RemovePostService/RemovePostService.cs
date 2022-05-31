using DatabaseAccess;

namespace Logic.Services.RemovePostService
{
    public interface IRemovePostService
    {
        void RemovePostById(string ownerId, int postId);
    }
    public class RemovePostService :ServiceTemplate, IRemovePostService
    {
        public void RemovePostById(string ownerId, int postId)
        {
            var post = Context.Posts.Single(e => e.PostId == postId & e.OwnerId == ownerId);
            post.IsDeleted = true;
            Context.SaveChanges();
        }

        public RemovePostService(BlogDbContext context) : base(context)
        {
        }
    }
}
