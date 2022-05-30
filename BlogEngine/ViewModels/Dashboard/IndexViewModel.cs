namespace BlogEngine.ViewModels.Dashboard
{
    public class IndexViewModel
    {
        public IEnumerable<DatabaseAccess.DbModels.Blog> Blogs { get; set; }
    }
}
