using Microsoft.AspNetCore.Mvc;

namespace Mailroom_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelController : ControllerBase
    {

        //Define the data context in which we'll be accessing the DB
        private readonly DataContext _context;
        public ParcelController(DataContext context)
        {
            _context = context;
        }

        //Get all parcels from the DB into a list and return it
        [HttpGet]
        public async Task<ActionResult<List<Models.Parcel>>> Get()
        {
            return Ok(await _context.Parcels.ToListAsync());
        }

        //Get a single parcel by it's ParcelNumber value and return it
        [HttpGet("{ParcelNo}")]
        public async Task<ActionResult<Models.Parcel>> Get(string ParcelNo)
        {
            var parcels = await _context.Parcels.ToListAsync();
            var thisParcel = parcels.FindIndex(po => po.ParcelNumber == ParcelNo);
            if (thisParcel == -1) //Index result of list will return -1 if not found, so we can throw an error.
            {
                return BadRequest("Parcel Number not found.");
            }
            return Ok(parcels[thisParcel]);
        }

        //Add a parcel into the database
        [HttpPost]
        public async Task<ActionResult<List<Models.Parcel>>> AddParcel(Models.Parcel parcel)
        {
            _context.Parcels.Add(parcel);
            await _context.SaveChangesAsync();
            return Ok(await _context.Parcels.ToListAsync());
        }

        //Edit a parcel within the database, and don't update the values that are empty or 0, so you can edit only certain aspects if necessary.
        [HttpPut]
        public async Task<ActionResult<List<Models.Parcel>>> UpdateParcel(Models.Parcel parcel)
        {
            var parcels = await _context.Parcels.ToListAsync();
            var thisParcel = parcels.Find(po => po.ParcelNumber == parcel.ParcelNumber);
            if (thisParcel == null)
            {
                return BadRequest("Parcel Number not found.");
            }

            //if values are not empty or zero, we will update them within the list and return all parcels.
            if (parcel.Destination != string.Empty)
            {
                thisParcel.Destination = parcel.Destination;
            }
            if (parcel.Recipient != String.Empty)
            {
                thisParcel.Recipient = parcel.Recipient;
            }
            if (parcel.Price != decimal.Zero)
            {
                thisParcel.Price = parcel.Price;
            }
            if (parcel.Weight != decimal.Zero)
            {
                thisParcel.Weight = parcel.Weight;
            }
            
            await _context.SaveChangesAsync();
            return Ok(await _context.Parcels.ToListAsync());
        }

        //Delete a parcel from the database by a given ParcelNumber
        [HttpDelete("{ParcelNo}")]
        public async Task<ActionResult<List<Models.Parcel>>> Delete(string ParcelNo)
        {
            var parcels = await _context.Parcels.ToListAsync();
            var thisParcel = parcels.FindIndex(po => po.ParcelNumber == ParcelNo);
            if (thisParcel == -1)
            {
                return BadRequest("Parcel Number not found.");
            }
            //parcels.Remove(parcels[thisParcel]);
            _context.Parcels.Remove(_context.Parcels.Find(ParcelNo));
            await _context.SaveChangesAsync();
            return Ok(await _context.Parcels.ToListAsync());
        }
    }
}
