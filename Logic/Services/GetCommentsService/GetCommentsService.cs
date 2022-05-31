
using DatabaseAccess;
using DatabaseAccess.DbModels;
using Logic.Dtos;
using Logic.Dtos.Extensions;

namespace Logic.Services.GetCommentsService
{
    public interface IGetCommentsService
    {
        IEnumerable<Comment> GetCommentsOf(ICommendable commendable);
        IEnumerable<CommentViewModelDto> GetCommentsDtosOf(ICommendable commendable);
    }
    public class GetCommentsService:ServiceTemplate, IGetCommentsService
    {
        public GetCommentsService(BlogDbContext context) : base(context)
        {
        }

        public IEnumerable<Comment> GetCommentsOf(ICommendable commendable)
        {
            var entity = Context.Entry(commendable);
            entity.Collection(e=>e.Comments).Load();
            foreach (var comment in entity.Entity.Comments)
            {
                yield return comment;
            }
        }

        public IEnumerable<CommentViewModelDto> GetCommentsDtosOf(ICommendable commendable)
        {
            return GetCommentsOf(commendable).ParseToDtoEnumerable(Context);
        }
    }
}
