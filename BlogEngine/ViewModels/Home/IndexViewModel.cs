namespace BlogEngine.ViewModels.Home
{
    public class IndexViewModel
    {
        public IEnumerable<DatabaseAccess.DbModels.Blog> Blogs { get; set; }
    }
}
