//This Main.cs file is responsible for the core program logic.
//For UI and Startup logic, see the Init.cs file. (View Code, not designer.)
//Rtf.cs contains the custom RTF Builder, as well as the RtfBuilder strings for displaying info in the details panels.

using Mailroom_App.Properties;
using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Emit;
using System.Linq;
using System.Threading;

namespace Mailroom_App
{

    public partial class MailroomForm : Form
    {

        //Define our HttpClient which we can use throughout the class to access the API.
        private static readonly HttpClient _httpClient = new HttpClient();

        //Create an async task which can get all shipments on a background thread and display their ShipmentNo in the Shipments List.
        public async Task GetShipments()
        {
            try
            {
                string result = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.ShipmentsURI);
                List<Models.Shipment> json = JsonConvert.DeserializeObject<List<Models.Shipment>>(result);

                //ForEach item in the list, add that item to the listbox. If that item is finalized, also display a checkmark next to it.
                json.ForEach(shipment => ShipmentsListBox.Items.Add(shipment.IsFinalized ? shipment.ShipmentNo + " ✅" : shipment.ShipmentNo));

                //If no error is thrown while attempting to connect to the API server, we can show the add shipments button.
                AddShipmentBtn.Visible = true;
            }
            catch (Exception ex)
            {
                API_Error();
                ServerConfig serverConfig = new ServerConfig();
                serverConfig.ShowDialog(this);
                //throw;
            }
        }

        //When a shipment from the list is selected, display that shipment's info in the associated Details panel.
        private async void ShipmentsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeleteShipmentBtn.Visible = true;
            EditShipmentsBtn.Visible = true;
            //AddShipmentBtn.Visible = true; //Since the AddShipment button should be displayed even if there are no shipments, we'll always show it.
            DeselectShipmentBtn.Visible = true;
            LBagsListBox.ClearSelected();
            PBagsListBox.ClearSelected();
            LBagsListBox.Items.Clear();
            PBagsListBox.Items.Clear();
            ParcelsListBox.Items.Clear();

            //If a list item is selected, we will query that list item and display it's info.
            if (ShipmentsListBox.SelectedItem != null) {
                //Check if the selected item contains a checkmark, and if it does, remove it from the SelectedItem variable so we can continue to display it in the list, but still correctly access the Shipment object
                //We will also disable the Edit button if the shipment is finalized, as it cannot be edited once it's finalized.
                string SelectedItem = ShipmentsListBox.SelectedItem.ToString();
                if (SelectedItem.Contains(" ✅"))
                {
                    SelectedItem = ShipmentsListBox.SelectedItem.ToString().Substring(0, ShipmentsListBox.SelectedItem.ToString().Length - 2);
                    //If the selected shipment is finalized, we can't edit it or it's contents, so we will disable those buttons.
                    //Shipment Btns
                    EditShipmentsBtn.Enabled = false;
                    //LBag Btns
                    AddLBagBtn.Enabled = false;
                    EditLBagBtn.Enabled = false;
                    DeleteLBagBtn.Enabled = false;
                    //PBag Btns
                    AddPBagBtn.Enabled = false;
                    EditPBagBtn.Enabled = false;
                    DeleteLBagBtn.Enabled = false;
                    //Parcel Btns
                    AddParcelBtn.Enabled = false;
                    EditParcelBtn.Enabled = false;
                    DeleteParcelBtn.Enabled = false;
                }
                else
                {
                    //If it's not finalized, we'll ensure those buttons are enabled.
                    //Shipment Btns
                    EditShipmentsBtn.Enabled = true;
                    //LBag Btns
                    AddLBagBtn.Enabled = true;
                    EditLBagBtn.Enabled = true;
                    DeleteLBagBtn.Enabled = true;
                    //PBag Btns
                    AddPBagBtn.Enabled = true;
                    EditPBagBtn.Enabled = true;
                    DeleteLBagBtn.Enabled = true;
                    //Parcel Btns
                    AddParcelBtn.Enabled = true;
                    EditParcelBtn.Enabled = true;
                    DeleteParcelBtn.Enabled = true;
                }
                
                string result = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.ShipmentsURI + "/" + SelectedItem);
                Models.Shipment json = JsonConvert.DeserializeObject<Models.Shipment>(result);

                GenerateShipmentsRTB(json); //When we select a shippment, we will generate the text for the Shipments Details box.

                //Get each bag within the shipment
                foreach (string bag in json.BagList)
                {
                    try //Try and check the current bag against the LetterBag table and display it in the LetterBag List if it exists.
                    {
                        string lbagresult = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.LBagsURI + "/" + bag);
                        Models.LetterBag lBagJson = JsonConvert.DeserializeObject<Models.LetterBag>(lbagresult);
                        if (lBagJson != null)
                        {
                            LBagsListBox.Items.Add(lBagJson.BagNo.ToString());
                        }
                    }
                    catch (HttpRequestException ex) //If there isn't a LetterBag with the given BagNo,
                    {
                        try //Try and find the bag inside the ParcelBag table instead, then display it within the ParcelBag list.
                        {
                            string pbagresult = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.PBagsURI + "/" + bag);
                            Models.ParcelBag pBagJson = JsonConvert.DeserializeObject<Models.ParcelBag>(pbagresult);
                            if (pBagJson != null)
                            {
                                PBagsListBox.Items.Add(pBagJson.BagNo.ToString());
                            }
                        }
                        catch (HttpRequestException exx) //If the bag wasn't found in either list, then the bag doesn't exist. Throw an error.
                        {
                            MessageBox.Show("There was an error with a bag in the selected shipment.\nA bag within this shipment does not exist.\n\nPlease contact your database administrator to rectify this issue.", "Shipment Item Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //throw; //Don't actually throw either of the exceptions, though, or else the program will crash.
                        }
                        //throw;
                    }
                }
                //Show the add buttons for the Bags, so we can add some bags to the shipment as well.
                AddLBagBtn.Visible = true;
                AddPBagBtn.Visible = true;
            } else { //If no list item is selected (because we cleared a previous selection) then we will display nothing in the Details box.
                //Hide the details about any Shipment info that doesn't need to be displayed.
                ShipmentsRTB.Rtf = null;
                DeleteShipmentBtn.Visible = false;
                EditShipmentsBtn.Visible = false;
                DeselectShipmentBtn.Visible = false;
                //If no Shipment is selected, we want to make sure to hide the Add buttons as well, because we can't add to anything if nothing is selected for which to add.
                AddLBagBtn.Visible = false;
                AddPBagBtn.Visible = false;
                AddParcelBtn.Visible = false;
            }
        }

        //When a LetterBag from the list is selected, display that LetterBag's info in the associated Details panel.
        private async void LBagsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParcelsListBox.ClearSelected();
            ParcelsListBox.Items.Clear();

            //If a list item is selected, we will query that list item and display it's info.
            if (LBagsListBox.SelectedItem != null)
            {
                string result = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.LBagsURI + "/" + LBagsListBox.SelectedItem.ToString());
                Models.LetterBag json = JsonConvert.DeserializeObject<Models.LetterBag>(result);

                var list = new List<string>();
                GenerateLBagsRTB(json);
                if (json.ParcelList != null)
                {
                    list = json.ParcelList.ToList<string>();
                }

                foreach (string parcel in list)
                {
                    try
                    {
                        string parcelresult = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.ParcelsURI + "/" + parcel);
                        Models.Parcel parcelJson = JsonConvert.DeserializeObject<Models.Parcel>(parcelresult);
                        if (parcelJson != null)
                        {
                            ParcelsListBox.Items.Add(parcelJson.ParcelNumber.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was an error with a parcel in the selected bag.\nA parcel within this bag does not exist.\n\nPlease contact your database administrator to rectify this issue.", "Bag Item Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //throw;
                    }
                }

                DeleteLBagBtn.Visible = true;
                EditLBagBtn.Visible = true;
                AddLBagBtn.Visible = true;
                DeselectLBagBtn.Visible = true;
                AddParcelBtn.Visible = true;
                PBagsListBox.ClearSelected();
            } else { //If no list item is selected...
                LBagsRTB.Rtf = null;
                DeleteLBagBtn.Visible = false;
                EditLBagBtn.Visible = false;
                DeselectLBagBtn.Visible = false;
                if (PBagsListBox.SelectedItem == null) { AddParcelBtn.Visible = false; }
            }
        }

        //When a ParcelBag is selected, display info in the Details panel
        private async void PBagsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParcelsListBox.ClearSelected();
            ParcelsListBox.Items.Clear();

            //If a list item is selected, we will query that list item and display it's info.
            if (PBagsListBox.SelectedItem != null)
            {
                string result = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.PBagsURI + "/" + PBagsListBox.SelectedItem.ToString());
                Models.ParcelBag json = JsonConvert.DeserializeObject<Models.ParcelBag>(result);

                var list = new List<string>();
                GeneratePBagsRTB(json);
                if (json.ParcelNos != null)
                {
                    list = json.ParcelNos.ToList<string>();
                }

                foreach (string parcel in list)
                {
                    try
                    {
                        string parcelresult = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.ParcelsURI + "/" + parcel);
                        Models.Parcel parcelJson = JsonConvert.DeserializeObject<Models.Parcel>(parcelresult);
                        if (parcelJson != null)
                        {
                            ParcelsListBox.Items.Add(parcelJson.ParcelNumber.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was an error with a parcel in the selected bag.\nA parcel within this bag does not exist.\n\nPlease contact your database administrator to rectify this issue.", "Bag Item Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //throw;
                    }
                }

                DeletePBagBtn.Visible = true;
                EditPBagBtn.Visible = true;
                AddPBagBtn.Visible = true;
                DeselectPBagBtn.Visible = true;
                AddParcelBtn.Visible = true;
                LBagsListBox.ClearSelected();
            }
            else
            { //If no list item is selected...
                PBagsRTB.Rtf = null;
                DeletePBagBtn.Visible = false;
                EditPBagBtn.Visible = false;
                DeselectPBagBtn.Visible = false;
                if (LBagsListBox.SelectedItem == null) { AddParcelBtn.Visible = false; }
            }
        }

        //If a list item is selected, we will query it and show its info
        private async void ParcelsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If a list item is selected, we will query that list item and display it's info.
            if (ParcelsListBox.SelectedItem != null)
            {
                string result = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.ParcelsURI + "/" + ParcelsListBox.SelectedItem.ToString());
                Models.Parcel json = JsonConvert.DeserializeObject<Models.Parcel>(result);

                GenerateParcelRTB(json);

                DeleteParcelBtn.Visible = true;
                EditParcelBtn.Visible = true;
                AddParcelBtn.Visible = true;
                DeselectParcelBtn.Visible = true;
            }
            else
            { //If no list item is selected...
                ParcelsRTB.Rtf = null;
                DeleteParcelBtn.Visible = false;
                EditParcelBtn.Visible = false;
                DeselectParcelBtn.Visible = false;
            }
        }



        //Some UI functionality related to core program logic

        //This deselects all list boxes; useful while testing. However, by deselecting a shipment, the same should be achieved.
        private void deselectAllBtn_Click(object sender, EventArgs e)
        {
            ShipmentsListBox.ClearSelected();
            LBagsListBox.ClearSelected();
            PBagsListBox.ClearSelected();
            ParcelsListBox.ClearSelected();
        }


        //Set Deselect buttons to set their respective list's selected index to -1, effectively removing any selection.
        //The logic of each ListBox should then handle the behaviour of the corresponding ListBoxes.
        private void DeselectShipmentBtn_Click(object sender, EventArgs e)
        {
            ShipmentsListBox.ClearSelected();
        }

        private void DeselectLBagBtn_Click(object sender, EventArgs e)
        {
            LBagsListBox.ClearSelected();
        }

        private void DeselectPBagBtn_Click(object sender, EventArgs e)
        {
            PBagsListBox.ClearSelected();
        }

        private void DeselectParcelBtn_Click(object sender, EventArgs e)
        {
            ParcelsListBox.ClearSelected();
        }

        //Shipment Controls
        private async void AddShipmentBtn_Click(object sender, EventArgs e)
        {
            Add.AddShipmentForm addShipment = new Add.AddShipmentForm();
            var result = addShipment.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                bool DidUpdate = addShipment.DoUpdate;
                string AddedShipment = addShipment.ShipmentNumber;
                if (DidUpdate)
                {
                    ShipmentsListBox.ClearSelected();
                    ShipmentsListBox.Items.Clear();
                    await GetShipments();
                    ShipmentsListBox.SelectedItem = AddedShipment;
                }
            }

        }

        private async void EditShipmentsBtn_Click(object sender, EventArgs e)
        {
            Edit.EditShipmentForm editShipment = new Edit.EditShipmentForm();
            editShipment.ShipNo = ShipmentsListBox.SelectedItem.ToString();
            var result = editShipment.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                
                bool DidUpdate = editShipment.DoUpdate;
                string EditedShipment = editShipment.ShipNo;
                if (DidUpdate)
                {
                    ShipmentsListBox.ClearSelected();
                    ShipmentsListBox.Items.Clear();
                    await GetShipments();
                    ShipmentsListBox.SelectedItem = EditedShipment;
                }
            }
        }

        private async void DeleteShipmentBtn_Click(object sender, EventArgs e)
        {
            string SelectedItem = ShipmentsListBox.SelectedItem.ToString();
            if (SelectedItem.Contains(" ✅"))
            {
                SelectedItem = ShipmentsListBox.SelectedItem.ToString().Substring(0, ShipmentsListBox.SelectedItem.ToString().Length - 2);
            }
            Delete.DelShipmentForm delShipment = new Delete.DelShipmentForm();
            delShipment.ShipNo = SelectedItem;
            var result = delShipment.ShowDialog(this);
            if (result == DialogResult.OK)
            {

                bool DidUpdate = delShipment.DoUpdate;
                if (DidUpdate)
                {
                    ShipmentsListBox.ClearSelected();
                    ShipmentsListBox.Items.Clear();
                    await GetShipments();
                }
            }
        }

        //Letter Bag controls
        private async void AddLBagBtn_Click(object sender, EventArgs e)
        {
            Add.AddLBagForm addLBag = new Add.AddLBagForm();
            addLBag.ShipmentNumber = ShipmentsListBox.SelectedItem.ToString();
            var result = addLBag.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                bool DidUpdate = addLBag.DoUpdate;
                string AddedBag = addLBag.BagNumber;
                if (DidUpdate)
                {
                    LBagsListBox.ClearSelected();
                    LBagsListBox.Items.Clear();
                    var CurrShipment = ShipmentsListBox.SelectedItem;
                    ShipmentsListBox.ClearSelected();
                    ShipmentsListBox.SelectedItem = CurrShipment; //Set the selected shipment, deselect it, then reselect it, to re-call the API to get the new list
                    LBagsListBox.SelectedItem = AddedBag;
                }
            }
        }

        private void DeleteLBagBtn_Click(object sender, EventArgs e)
        {
            Delete.DelLBagForm deleteLBag = new Delete.DelLBagForm();
            deleteLBag.BagNumber = LBagsListBox.SelectedItem.ToString();
            deleteLBag.ShipmentNumber = ShipmentsListBox.SelectedItem.ToString();
            var result = deleteLBag.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                bool DidUpdate = deleteLBag.DoUpdate;
                string removedBag = deleteLBag.BagNumber;
                string shipmentNo = deleteLBag.ShipmentNumber;
                if (DidUpdate)
                {
                    LBagsListBox.ClearSelected();
                    LBagsListBox.Items.Clear();
                    var CurrShipment = ShipmentsListBox.SelectedItem;
                    ShipmentsListBox.ClearSelected();
                    ShipmentsListBox.SelectedItem = CurrShipment;
                }
            }
        }

        //Parcel Bag controls
        private void AddPBagBtn_Click(object sender, EventArgs e)
        {
            Add.AddPBagForm addPBag = new Add.AddPBagForm();
            addPBag.ShipmentNumber = ShipmentsListBox.SelectedItem.ToString();
            var result = addPBag.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                bool DidUpdate = addPBag.DoUpdate;
                string AddedBag = addPBag.BagNumber;
                if (DidUpdate)
                {
                    PBagsListBox.ClearSelected();
                    PBagsListBox.Items.Clear();
                    var CurrShipment = ShipmentsListBox.SelectedItem;
                    ShipmentsListBox.ClearSelected();
                    ShipmentsListBox.SelectedItem = CurrShipment; //Set the selected shipment, deselect it, then reselect it, to re-call the API to get the new list
                    PBagsListBox.SelectedItem = AddedBag;
                }
            }
        }

        private void DeletePBagBtn_Click(object sender, EventArgs e)
        {
            Delete.DelPBagForm deletePBag = new Delete.DelPBagForm();
            deletePBag.BagNumber = PBagsListBox.SelectedItem.ToString();
            deletePBag.ShipmentNumber = ShipmentsListBox.SelectedItem.ToString();
            var result = deletePBag.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                bool DidUpdate = deletePBag.DoUpdate;
                string removedBag = deletePBag.BagNumber;
                string shipmentNo = deletePBag.ShipmentNumber;
                if (DidUpdate)
                {
                    PBagsListBox.ClearSelected();
                    PBagsListBox.Items.Clear();
                    var CurrShipment = ShipmentsListBox.SelectedItem;
                    ShipmentsListBox.ClearSelected();
                    ShipmentsListBox.SelectedItem = CurrShipment;
                }
            }
        }

        //Parcel Controls
        private void AddParcelBtn_Click(object sender, EventArgs e)
        {
            Add.AddParcelForm addParcel = new Add.AddParcelForm();
            if (LBagsListBox.SelectedItem != null && PBagsListBox.SelectedItem == null)
            {
                addParcel.IsLBag = true;
                addParcel.BagNumber = LBagsListBox.SelectedItem.ToString();
            }
            else if (PBagsListBox.SelectedItem != null && LBagsListBox.SelectedItem == null)
            {
                addParcel.IsLBag = false;
                addParcel.BagNumber = PBagsListBox.SelectedItem.ToString();
            } else { MessageBox.Show("There was an error determining the selected bag type.", "Bag Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } //Just in case! Should never throw, though.
            var result = addParcel.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                bool DidUpdate = addParcel.DoUpdate;
                string AddedParcel = addParcel.ParcelNumber;
                if (DidUpdate)
                {
                    if (addParcel.IsLBag)
                    {
                        ParcelsListBox.ClearSelected();
                        ParcelsListBox.Items.Clear();
                        var CurrLBag = LBagsListBox.SelectedItem;
                        LBagsListBox.ClearSelected();
                        LBagsListBox.SelectedItem = CurrLBag;
                        ParcelsListBox.SelectedItem = AddedParcel;
                    } else
                    {
                        ParcelsListBox.ClearSelected();
                        ParcelsListBox.Items.Clear();
                        var CurrPBag = PBagsListBox.SelectedItem;
                        PBagsListBox.ClearSelected();
                        PBagsListBox.SelectedItem = CurrPBag;
                        ParcelsListBox.SelectedItem = AddedParcel;
                    }
                }
            }
        }

        private void EditParcelBtn_Click(object sender, EventArgs e)
        {
            Edit.EditParcelForm editParcel = new Edit.EditParcelForm();
            if (LBagsListBox.SelectedItem != null && PBagsListBox.SelectedItem == null)
            {
                editParcel.IsLBag = true;
                editParcel.BagNumber = LBagsListBox.SelectedItem.ToString();
            }
            else if (PBagsListBox.SelectedItem != null && LBagsListBox.SelectedItem == null)
            {
                editParcel.IsLBag = false;
                editParcel.BagNumber = PBagsListBox.SelectedItem.ToString();
            }
            else { MessageBox.Show("There was an error determining the selected bag type.", "Bag Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } //Just in case! Should never throw, though.
            editParcel.ParcelNumber = ParcelsListBox.SelectedItem.ToString();
            var result = editParcel.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                bool DidUpdate = editParcel.DoUpdate;
                string AddedParcel = editParcel.ParcelNumber;
                if (DidUpdate)
                {
                    if (editParcel.IsLBag)
                    {
                        ParcelsListBox.ClearSelected();
                        ParcelsListBox.Items.Clear();
                        var CurrLBag = LBagsListBox.SelectedItem;
                        LBagsListBox.ClearSelected();
                        LBagsListBox.SelectedItem = CurrLBag;
                        ParcelsListBox.SelectedItem = AddedParcel;
                    }
                    else
                    {
                        ParcelsListBox.ClearSelected();
                        ParcelsListBox.Items.Clear();
                        var CurrPBag = PBagsListBox.SelectedItem;
                        PBagsListBox.ClearSelected();
                        PBagsListBox.SelectedItem = CurrPBag;
                        ParcelsListBox.SelectedItem = AddedParcel;
                    }
                }
            }
        }

        private void DeleteParcelBtn_Click(object sender, EventArgs e)
        {
            Delete.DelParcelForm delParcel = new Delete.DelParcelForm();
            if (LBagsListBox.SelectedItem != null && PBagsListBox.SelectedItem == null)
            {
                delParcel.IsLBag = true;
                delParcel.BagNumber = LBagsListBox.SelectedItem.ToString();
            }
            else if (PBagsListBox.SelectedItem != null && LBagsListBox.SelectedItem == null)
            {
                delParcel.IsLBag = false;
                delParcel.BagNumber = PBagsListBox.SelectedItem.ToString();
            }
            delParcel.ParcelNumber = ParcelsListBox.SelectedItem.ToString();
            var result = delParcel.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                bool DidUpdate = delParcel.DoUpdate;
                string AddedParcel = delParcel.ParcelNumber;
                if (DidUpdate)
                {
                    if (delParcel.IsLBag)
                    {
                        ParcelsListBox.ClearSelected();
                        ParcelsListBox.Items.Clear();
                        var CurrLBag = LBagsListBox.SelectedItem;
                        LBagsListBox.ClearSelected();
                        LBagsListBox.SelectedItem = CurrLBag;
                        ParcelsListBox.SelectedItem = AddedParcel;
                    }
                    else
                    {
                        ParcelsListBox.ClearSelected();
                        ParcelsListBox.Items.Clear();
                        var CurrPBag = PBagsListBox.SelectedItem;
                        PBagsListBox.ClearSelected();
                        PBagsListBox.SelectedItem = CurrPBag;
                        ParcelsListBox.SelectedItem = AddedParcel;
                    }
                }
            }
        }
    }

    //Set some global variables which we can access throughout the namespace.
    public static class Global
    {
        //Set the URIs for each of the API routes
        //Since the API Server is dynamic, we can access it using Settings.Default.API_Server and append these URIs to it.
        //Ex: Settings.Default.API_Server + Global.ParcelsURI
        public const string ShipmentsURI = "/api/Shipment";
        public const string PBagsURI = "/api/ParcelBag";
        public const string LBagsURI = "/api/LetterBag";
        public const string ParcelsURI = "/api/Parcel";
    }
}
