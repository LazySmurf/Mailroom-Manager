using System.Collections.Generic;

namespace Mailroom_App.Models
{
    public class LetterBag
    {
        public string BagNo { get; set; }


        public int LetterCount { get; set; }


        public decimal Weight { get; set; }


        public decimal Price { get; set; }


        public ICollection<string> ParcelList { get; set; }
    }
}
