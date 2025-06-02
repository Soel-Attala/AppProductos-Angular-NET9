using System.ComponentModel.DataAnnotations;

namespace ProductApp.Models
{
    public class Products
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative number.")]
        public int stock { get; set; }

    }
}
