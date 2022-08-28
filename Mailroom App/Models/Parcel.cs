

namespace Mailroom_App.Models
{
    public class Parcel
    {
        //public int Id { get; set; }  //AutoInc Key & Entry Number
        public string ParcelNumber { get; set; } //ex: LLNNNNNNLL


        public string Recipient { get; set; } //ex: John Smith


        public string Destination { get; set; } //ex: 2 letter country code like CA, EE, FL etc.


        public decimal Weight { get; set; } //ex: 1.234 (max 3 decimal places) (likely in KG/Lbs or something)


        public decimal Price { get; set; } //ex: 149.99 (max 2 decimal places) (likely in USD/EUR or something)


        public bool IsLetter { get; set; } //Define whether this is a letter or a parcel
    }
}
