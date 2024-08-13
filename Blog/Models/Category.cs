using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("category")]
    public class Category
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("is_active", TypeName = "char(1)")]
        public char IsActive { get; set; }

        [Column("created_time")]
        public DateTime CreatedTime { get; set; }

        [Column("updated_time")]
        public DateTime? UpdatedTime { get; set; }

        public ICollection<Article>? Articles { get; set; }

    }
}