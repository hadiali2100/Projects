using System.ComponentModel.DataAnnotations;

namespace HadflixWeb.Models
{
    public class Category
    {
        [Key]
        public long CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public long DisplayOrder { get; set; }
        public DateTime ModificationDate { get; set; } = DateTime.Now;
    }
}
