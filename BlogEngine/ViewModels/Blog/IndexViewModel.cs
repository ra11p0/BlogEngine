namespace BlogEngine.ViewModels.Blog
{
    public class IndexViewModel
    {
        public DatabaseAccess.DbModels.Blog Blog { get; set; }
        public bool Editable { get; set; } = false;
    }
}
