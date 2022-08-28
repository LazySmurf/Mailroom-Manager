using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mailroom_API.Models
{
    public class Parcel
    {
        //public int Id { get; set; }  //AutoInc Key & Entry Number
        [Key]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Parcel Number must be 10 characters in format LLNNNNNNLL.")]
        [Required]
        [RegularExpression(@"^[A-Z]{2}[0-9]{6}[A-Z]{2}$", ErrorMessage = "Format must be LLNNNNNNLL ([L]etters/[N]umbers)")]
        public string ParcelNumber { get; set; } //ex: LLNNNNNNLL


        [StringLength(100, MinimumLength = 1, ErrorMessage = "Recipient must contain between 1 and 100 characters.")]
        [Required]
        [RegularExpression(@"^[A-Za-z0-9]{1}[A-Za-z0-9\s]{0,99}$", ErrorMessage = "Recipient must be between 1 and 100 characters, start with a letter or number, and contain only letters, numbers, and spaces thereafter.")]
        public string Recipient { get; set; } //ex: John Smith


        [StringLength(2, MinimumLength = 2, ErrorMessage = "Destination must be exactly 2 characters in the format of a Country Code.")]
        [Required]
        [RegularExpression(@"^[A-Z]{2}$", ErrorMessage = "Format must be LL (Country Code)")]
        public string Destination { get; set; } //ex: 2 letter country code like CA, EE, FL etc.


        [Column(TypeName = "decimal(20,3)")] //Sets the DB precision to 20 characters, 3 of which are after decimal place.
        [Required]
        [RegularExpression(@"^[0-9]{1,10}.[0-9]{0,3}$", ErrorMessage = "Format must be a whole number, or a decimal number with 3 or less characters after the decimal.")]
        public decimal Weight { get; set; } //ex: 1.234 (max 3 decimal places) (likely in KG/Lbs or something)


        [Column(TypeName = "decimal(20,2)")]//Sets the DB precision to 20 characters, 2 of which are after decimal place.
        [Required]
        [RegularExpression(@"^[0-9]{1,10}.[0-9]{0,2}$", ErrorMessage = "Format must be a whole number, or a decimal number with 2 or less characters after the decimal.")]
        public decimal Price { get; set; } //ex: 149.99 (max 2 decimal places) (likely in USD/EUR or something)


        [Required]
        public bool IsLetter { get; set; } //Define whether this is a letter or a parcel
    }
}
