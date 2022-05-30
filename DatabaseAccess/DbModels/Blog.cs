namespace DatabaseAccess.DbModels
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public string Description { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public User Owner { get; set; }
        public int Views => Posts.Select(e => e.Views).Sum();
    }
}
