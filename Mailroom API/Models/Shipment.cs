using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mailroom_API.Models
{
    public enum Airport //Only 3 allowed values. Can be expanded by adding to this list, or could link to a DB table which contains allowed values as well.
    {
        TLL,
        HEL,
        RIX
    }

    public class Shipment
    {
        [Key]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Shipment Number must be exactly 10 characters in format XXX-XXXXXX")]
        [Required]
        [RegularExpression(@"^[A-Z0-9]{3}-[A-Z0-9]{6}$", ErrorMessage = "Format must be XXX-XXXXXX (Letters/Numbers allowed)")]
        public string ShipmentNo { get; set; } //ex: XXX-XXXXX (X is letter or number, and is unique in DB


        [Required]
        //[RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Format must be LLL")] //Since this is an enum, we'll actually just use integers.
        public Airport Airport { get; set; }

        
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Flight Number must be exactly 6 characters in format LLNNNN")]
        [Required]
        [RegularExpression(@"^[A-Z]{2}[0-9]{4}$", ErrorMessage = "Format must be LLNNNN")]
        public string FlightNo { get; set; } //ex: LLNNNN


        [Required]
        public DateTime FlightDate { get; set; } //Can't be in by past the moment of finalizing shipment


        //BagList can't be required, as it needs to be created first. For this reason, we will allow it to be left empty until we add bags to it.
        //Once we've added all the bags, we can set the below IsFinalized flag to true, whereby it will no longer be editable.
        public List<string> BagList { get; set; } = new(); //Can't be in by past the moment of finalizing shipment. Will contain a collection of Bag Numbers, which can then be looked up via the Bag models.
        
        
        [Required]
        [DefaultValue(false)]
        public bool IsFinalized { get; set; } = false; //Decides whether the shipment is finalized or not. Editing won't be allowed if set to true.
    }
}