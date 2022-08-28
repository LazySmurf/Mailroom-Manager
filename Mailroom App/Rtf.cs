using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mailroom_App
{
    public partial class MailroomForm : Form
    {
        private void GenerateShipmentsRTB(Models.Shipment json)
        {
            //We will use the RtfBuilder custom class to construct the format for the Details panel's RTF Textbox.
            //It's possible to do this all on a single line, but RTF strings are hard to deal with, so we'll just use
            //the custom builder since it makes it easier to build the strings, and to see how they're built, and how
            //to edit them, when reading back code.
            RtfBuilder rtfBuilder = new RtfBuilder();
            rtfBuilder.AppendBold("Shipment #:\t");
            rtfBuilder.Append(json.ShipmentNo);
            rtfBuilder.AppendNewLine();
            rtfBuilder.AppendBold("Airport:\t\t");
            rtfBuilder.Append(json.Airport.ToString());
            rtfBuilder.AppendNewLine();
            rtfBuilder.AppendBold("Flight Number:\t");
            rtfBuilder.Append(json.FlightNo);
            rtfBuilder.AppendNewLine();
            rtfBuilder.AppendBold("Flight Date:\t");
            rtfBuilder.Append(json.FlightDate.ToString("dd/MM/yyyy @ H:mm:ss tt K"));
            rtfBuilder.AppendNewLine();
            rtfBuilder.AppendBold("Bag Count:\t");
            rtfBuilder.Append(json.BagList.Count.ToString());
            rtfBuilder.AppendNewLine();
            rtfBuilder.AppendBold("Is Finalized:\t");
            rtfBuilder.Append(json.IsFinalized ? "Yes" : "No");
            ShipmentsRTB.Rtf = rtfBuilder.ToRtf(); //After constructing the string to be used in the Details panel, we'll push it to the box.
        }

        private void GenerateLBagsRTB(Models.LetterBag json)
        {
            RtfBuilder rtfBuilder = new RtfBuilder();
            rtfBuilder.AppendBold("Bag #:\t");
            rtfBuilder.Append(json.BagNo);
            rtfBuilder.AppendNewLine();
            rtfBuilder.AppendBold("Letters:\t");
            rtfBuilder.Append(json.LetterCount.ToString());
            rtfBuilder.AppendNewLine();
            rtfBuilder.AppendBold("Weight:\t");
            rtfBuilder.Append(json.Weight.ToString());
            rtfBuilder.AppendNewLine();
            rtfBuilder.AppendBold("Price:\t");
            rtfBuilder.Append(json.Price.ToString());
            rtfBuilder.AppendNewLine();
            LBagsRTB.Rtf = rtfBuilder.ToRtf();
        }

        private void GeneratePBagsRTB(Models.ParcelBag json)
        {
            RtfBuilder rtfBuilder = new RtfBuilder();
            rtfBuilder.AppendBold("Bag #:\t");
            rtfBuilder.Append(json.BagNo);
            rtfBuilder.AppendNewLine();
            rtfBuilder.AppendBold("Parcels:\t");
            rtfBuilder.Append(json.ParcelNos.Count.ToString());
            PBagsRTB.Rtf = rtfBuilder.ToRtf();
        }

        private void GenerateParcelRTB(Models.Parcel json)
        {
            RtfBuilder rtfBuilder = new RtfBuilder();
            rtfBuilder.AppendBold("Parcel #:\t\t");
            rtfBuilder.Append(json.ParcelNumber);
            rtfBuilder.AppendNewLine();
            rtfBuilder.AppendBold("Recipient:\t");
            rtfBuilder.Append(json.Recipient);
            rtfBuilder.AppendNewLine();
            rtfBuilder.AppendBold("Destination:\t");
            rtfBuilder.Append(json.Destination);
            rtfBuilder.AppendNewLine();
            rtfBuilder.AppendBold("Weight:\t\t");
            rtfBuilder.Append(json.Weight.ToString());
            rtfBuilder.AppendNewLine();
            rtfBuilder.AppendBold("Price:\t\t");
            rtfBuilder.Append(json.Price.ToString());
            rtfBuilder.AppendNewLine();
            rtfBuilder.AppendBold("Is Letter:\t\t");
            rtfBuilder.Append(json.IsLetter ? "Yes" : "No");
            ParcelsRTB.Rtf = rtfBuilder.ToRtf();
        }

        //Custom RtfBuilder class for creating better looking formatted details for user
        class RtfBuilder
        {
            StringBuilder _builder = new StringBuilder();
            //AppendBold allows you to easily add Bold text. Any string passed will be encased in bold tags.
            public void AppendBold(string text)
            {
                _builder.Append(@"\b ");
                _builder.Append(text);
                _builder.Append(@"\b0 ");
            }
            //AppendItalic allows you to add Italic text.
            public void AppendItalic(string text)
            {
                _builder.Append(@"\i ");
                _builder.Append(text);
                _builder.Append(@"\i0 ");
            }
            //AppendBoldItalic allows you to add text which is both bold and italic.
            public void AppendBoldItalic(string text)
            {
                _builder.Append(@"\b\i ");
                _builder.Append(text);
                _builder.Append(@"\b0\i0 ");
            }
            //Append allows you to add regular, unformatted text.
            public void Append(string text)
            {
                _builder.Append(text);
            }
            //AppendLine allows you to add text, followed by a line break.
            public void AppendLine(string text)
            {
                _builder.Append(text);
                _builder.Append(@"\line");
            }
            //AppendNewLine allows you to simply insert a line break.
            public void AppendNewLine()
            {
                _builder.Append(@"\line");
            }
            //ToRtf constructs the Rtf formatted string into a string which can be passed to RichTextbox.Rtf
            //It adds the Rtf prefix and suffix to the rest of our constructed string for us.
            public string ToRtf()
            {
                return @"{\rtf1\ansi " + _builder.ToString() + @" }";
            }
            //With this method, it is easy to implement nicely formatted Text data.
        }
    }
}
