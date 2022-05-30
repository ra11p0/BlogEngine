namespace DatabaseAccess.DbModels
{
    public class Comment : Rateable
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public DateTime Created { get; set; }
        public DateTime EditedDate { get; set; }
        public User Owner { get; set; }
    }
}
