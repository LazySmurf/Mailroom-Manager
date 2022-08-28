using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Mailroom_App.Models
{

    public enum Airport //Only 3 allowed values. Can be expanded by adding to this list, or could link to a DB table which contains allowed values as well.
    {
        TLL,
        HEL,
        RIX
    }

    public class Shipment
    {
        public string ShipmentNo { get; set; } //ex: XXX-XXXXX (X is letter or number, and is unique in DB


        public Airport Airport { get; set; }


        public string FlightNo { get; set; } //ex: LLNNNN


        public DateTime FlightDate { get; set; } //Can't be in by past the moment of finalizing shipment


        //BagList can't be required, as it needs to be created first. For this reason, we will allow it to be left empty until we add bags to it.
        //Once we've added all the bags, we can set the below IsFinalized flag to true, whereby it will no longer be editable.
        public List<string> BagList { get; set; } //Can't be in by past the moment of finalizing shipment. Will contain a collection of Bag Numbers, which can then be looked up via the Bag models.
        
        
        [DefaultValue(false)]
        public bool IsFinalized { get; set; } = false; //Decides whether the shipment is finalized or not. Editing won't be allowed if set to true.
    }
}