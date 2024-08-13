
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Blog.Models
{
    [Table("AspNetUsers")]
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public required string Name { get; set; }

        public ICollection<Article>? Articles { get; set; }
    }
}