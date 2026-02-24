using System.Collections.Generic;

namespace CodeFirstNewDatabaseSample.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
