using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("article")]
    public class Article
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public required string Title { get; set; }

        [Column("content")]
        public required string Content { get; set; }

        [Column("author_id")]
        public required string AuthorId { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }

        [Column("created_time")]
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        [Column("updated_time")]
        public DateTime? UpdatedTime { get; set; }

        [Column("deleted_time")]
        public DateTime? DeletedTime { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public ApplicationUser? Author { get; set; }
    }
}