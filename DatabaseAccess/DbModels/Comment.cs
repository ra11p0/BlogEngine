namespace DatabaseAccess.DbModels
{
    public class Comment : IRateable, ICommendable
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public DateTime Created { get; set; }
        public DateTime EditedDate { get; set; }
        public string OwnerId { get; set; }
        public ICollection<Rate> Rates { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
