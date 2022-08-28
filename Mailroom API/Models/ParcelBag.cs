using System.ComponentModel.DataAnnotations;

namespace Mailroom_API.Models
{
    public class ParcelBag
    {
        [Key]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Bag Number must be 1 to 15 characters in length.")]
        public string BagNo { get; set; } //Max 15 characters, no special symbols, unique in DB.
        public ICollection<string> ParcelNos { get; set; }
    }
}
//Bags with parcels and letters share the same numbers, so the same bag number can’t be assigned to bag with parcels and bag with letters.