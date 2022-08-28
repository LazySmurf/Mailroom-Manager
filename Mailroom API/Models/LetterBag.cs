using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mailroom_API.Models
{
    public class LetterBag
    {
        [Key]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Bag Number must be 1 to 15 characters in length.")]
        [RegularExpression(@"^[A-Z0-9]{1,15}$", ErrorMessage = "Bag Number must be 1 to 15 characters in length.")]
        public string BagNo { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int LetterCount { get; set; }


        [Column(TypeName = "decimal(20,3)")]
        public decimal Weight { get; set; }


        [Column(TypeName = "decimal(20,2)")]

        public decimal Price { get; set; }


        public ICollection<string> ParcelList { get; set; }
    }
}
