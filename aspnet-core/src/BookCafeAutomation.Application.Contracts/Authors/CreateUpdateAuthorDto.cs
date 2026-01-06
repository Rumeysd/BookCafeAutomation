using System.ComponentModel.DataAnnotations;

namespace BookCafeAutomation.Authors
{
    public class CreateUpdateAuthorDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public string ShortBio { get; set; }
    }
}