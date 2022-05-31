using DatabaseAccess;
using DatabaseAccess.DbModels;

namespace Logic.Services.AddCommentService
{
    public interface IAddCommentService
    {
        void AddComment(ICommendable commendable, string commentText, string authorId);
    }
    public class AddCommentService : ServiceTemplate, IAddCommentService
    {
        public void AddComment(ICommendable commendable, string commentText, string authorId)
        {
            var entity = Context.Entry(commendable);
            entity.Collection(e=>e.Comments).Load();
            Comment comment = new()
            {
                CommentText = commentText,
                Created = DateTime.Now,
                OwnerId = authorId
            };
            entity.Entity.Comments.Add(comment);
            Context.SaveChanges();
        }

        public AddCommentService(BlogDbContext context) : base(context)
        {
        }
    }
}
