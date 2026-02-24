namespace CodeFirstNewDatabaseSample.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog? Blog { get; set; }
    }
}
