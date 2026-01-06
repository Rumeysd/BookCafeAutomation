using System.ComponentModel.DataAnnotations;

namespace BookCafeAutomation.Categories
{
    public class CreateUpdateCategoryDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
    }
}