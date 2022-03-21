using System.ComponentModel.DataAnnotations;

namespace ShaktiMan_Super_Mart.Models
{
    public class Product
    {
        [Required(ErrorMessage ="Id cannot be blank")]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minimum 3 characters required")]
        public string Name { get; set; }

        [Required]
        [Range(0,5000,ErrorMessage ="Price should be between 0 and 5000")]
        public double Price { get; set; }
    }
}
