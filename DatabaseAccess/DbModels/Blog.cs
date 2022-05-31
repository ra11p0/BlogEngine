namespace DatabaseAccess.DbModels
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public string Description { get; set; }
        public ICollection<Post> Posts { get; set; }
        public string OwnerId { get; set; }
        public int Views => Posts.Select(e => e.Views).Sum();
    }
}
