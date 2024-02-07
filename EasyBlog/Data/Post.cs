using System.ComponentModel.DataAnnotations;

namespace EasyBlog.Data
{
    public class Post
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; } = null!;

        [MaxLength(500)]
        public string Description { get; set; } = null!;

        [MaxLength(1000)]

        public string Content { get; set; } = null!;

        public string? Image { get; set; } 


        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!; 
    }
}
