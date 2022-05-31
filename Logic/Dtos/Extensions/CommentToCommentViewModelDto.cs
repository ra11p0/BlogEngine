using DatabaseAccess;
using DatabaseAccess.DbModels;

namespace Logic.Dtos.Extensions
{
    public static class CommentToCommentViewModelDto
    {
        public static CommentViewModelDto ParseToDto(this Comment comment, BlogDbContext context)
        {
            var commentEntity = context.Entry(comment).Entity;
            var author = context.Users.First(e => e.Id == commentEntity.OwnerId);
            CommentViewModelDto dto = new CommentViewModelDto()
            {
                AuthorId = commentEntity.OwnerId,
                AuthorName = author.UserName,
                CommentId = commentEntity.CommentId,
                Content = commentEntity.CommentText
            };
            return dto;
        }

        public static IEnumerable<CommentViewModelDto> ParseToDtoEnumerable(this IEnumerable<Comment> comments,
            BlogDbContext context)
        {
            foreach (var comment in comments)
            {
                yield return comment.ParseToDto(context);
            }
        }
    }
}
