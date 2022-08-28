using Mailroom_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Mailroom_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {

        //Define the data context in which we'll be accessing the DB
        private readonly DataContext _context;
        public ShipmentController(DataContext context)
        {
            _context = context;
        }

        //Get all Shipment from the DB into a list and return it
        [HttpGet]
        public async Task<ActionResult<List<Models.Shipment>>> Get()
        {
            return Ok(await _context.Shipments.ToListAsync());
        }

        //Get a single Shipment by it's BagNumber value and return it
        [HttpGet("{ShipmentNo}")]
        public async Task<ActionResult<Models.Shipment>> Get(string ShipmentNo)
        {
            var shipment = await _context.Shipments.ToListAsync();
            var thisShipment = shipment.FindIndex(lb => lb.ShipmentNo == ShipmentNo);
            if (thisShipment == -1) //Index result of list will return -1 if not found, so we can throw an error.
            {
                return BadRequest("Shipment Number not found.");
            }
            return Ok(shipment[thisShipment]);
        }

        //Add a Shipment into the database
        [HttpPost]
        public async Task<ActionResult<List<Models.Shipment>>> AddShipment(Models.Shipment shipment)
        {
            _context.Shipments.Add(shipment);
            await _context.SaveChangesAsync();
            return Ok(await _context.Shipments.ToListAsync());
        }

        //Edit a Shipment within the database, and don't update the values that are empty or 0, so you can edit only certain aspects if necessary.
        [HttpPut]
        public async Task<ActionResult<List<Models.Parcel>>> UpdateShipment(Models.Shipment shipment)
        {
            var shipments = await _context.Shipments.ToListAsync();
            var thisShipment = shipments.Find(sn => sn.ShipmentNo == shipment.ShipmentNo);
            if (thisShipment == null)
            {
                return BadRequest("Shipment Number not found.");
            }
            if (thisShipment.IsFinalized == true)
            { //In the case that the shipment is finalized, we will disallow editing of it.
                return BadRequest("Shipment is finalized and cannot be edited.");
            }

            //Get the number of items in the Airports enum dynamically since this list could be expanded in the future to contain more airports.
            int NumAirports = Enum.GetNames(typeof(Airport)).Length;
            //Check that the value passed for the Airport property is greater than 0 (since that's the start of the list) and less
            //than the number of values in the Airport enum (since the count should be one greater than the amount of items in the list,
            //since the list begins at 0)
            if ((int)shipment.Airport < NumAirports && (int)shipment.Airport > 0)
            {
                thisShipment.Airport = shipment.Airport;
            }
            if (shipment.FlightNo != String.Empty)
            {
                thisShipment.FlightNo = shipment.FlightNo;
            }
            if (shipment.FlightDate.ToString() != String.Empty)
            {
                thisShipment.FlightDate = DateTime.Parse(shipment.FlightDate.ToString());
            }
            if (thisShipment.IsFinalized.ToString() != String.Empty)
            {
                thisShipment.IsFinalized = shipment.IsFinalized; //In case this value is blank when passed, we won't update it.
            }
            thisShipment.BagList = shipment.BagList;
            //thisShipment.BagList.AddRange(shipment.BagList);

            await _context.SaveChangesAsync();
            return Ok(await _context.Shipments.ToListAsync());
        }

        //Delete a Shipment from the database by a given ParcelNumber
        [HttpDelete("{ShipmentNo}")]
        public async Task<ActionResult<List<Models.Shipment>>> DeleteShipment(string ShipmentNo)
        {
            var shipments = await _context.Shipments.ToListAsync();
            var thisShipment = shipments.FindIndex(sn => sn.ShipmentNo == ShipmentNo);
            if (thisShipment == -1)
            {
                return BadRequest("Shipment Number not found.");
            }
            _context.Shipments.Remove(_context.Shipments.Find(ShipmentNo));
            await _context.SaveChangesAsync();
            return Ok(await _context.Shipments.ToListAsync());
        }

    }
}
