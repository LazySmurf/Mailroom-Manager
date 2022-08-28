using Mailroom_App.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mailroom_App.Methods
{
    /*
    * This class is designed to perform a single delete on a given item.
    * 
    * Create a new instance of the Delete class, then call the method for what you're trying to delete
    * by passing to the method the object to delete's primary key. There's a unique method for each type of
    * object, as each object requires it's own URI to be called, and unique error messages if something goes wrong.
    */
    public class Delete
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public async void Shipment(string ShipNo)
        {
            var response = await _httpClient.DeleteAsync(Settings.Default.API_Server + Global.ShipmentsURI + "/" + ShipNo);
            if (!response.IsSuccessStatusCode)
            {
                DisplayError("Shipment", response);
            }
        }

        public async void LetterBag(string BagNo)
        {
            var response = await _httpClient.DeleteAsync(Settings.Default.API_Server + Global.LBagsURI + "/" + BagNo);
            if (!response.IsSuccessStatusCode)
            {
                DisplayError("Letter Bag", response);
            }
        }

        public async void ParcelBag(string BagNo)
        {
            var response = await _httpClient.DeleteAsync(Settings.Default.API_Server + Global.PBagsURI + "/" + BagNo);
            if (!response.IsSuccessStatusCode)
            {
                DisplayError("Parcel Bag", response);
            }
        }

        public async void Parcel(string ParcelNo)
        {
            var response = await _httpClient.DeleteAsync(Settings.Default.API_Server + Global.ParcelsURI + "/" + ParcelNo);
            if (!response.IsSuccessStatusCode)
            {
                DisplayError("Parcel", response);
            }
        }

        private void DisplayError(string ThisName, HttpResponseMessage response)
        {
            MessageBox.Show("There was an error deleting this " + ThisName + ".\n\nStatus Code:\n" + response.StatusCode, ThisName + " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
