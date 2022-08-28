using System.Collections.Generic;

namespace Mailroom_App.Models
{
    public class ParcelBag
    {
        public string BagNo { get; set; } //Max 15 characters, no special symbols, unique in DB.
        public ICollection<string> ParcelNos { get; set; }
    }
}
//Bags with parcels and letters share the same numbers, so the same bag number can’t be assigned to bag with parcels and bag with letters.