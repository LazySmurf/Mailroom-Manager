using Mailroom_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mailroom_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelBagController : Controller
    {
        //Define the data context in which we'll be accessing the DB
        private readonly DataContext _context;
        public ParcelBagController(DataContext context)
        {
            _context = context;
        }

        //Get all ParcelBags from the DB into a list and return it
        [HttpGet]
        public async Task<ActionResult<List<Models.ParcelBag>>> Get()
        {
            return Ok(await _context.ParcelBags.ToListAsync());
        }

        //Get a single ParcelBag by it's BagNumber value and return it
        [HttpGet("{BagNo}")]
        public async Task<ActionResult<Models.ParcelBag>> Get(string BagNo)
        {
            var bags = await _context.ParcelBags.ToListAsync();
            var thisBag = bags.FindIndex(pb => pb.BagNo == BagNo);
            if (thisBag == -1) //Index result of list will return -1 if not found, so we can throw an error.
            {
                return BadRequest("Bag Number not found.");
            }
            return Ok(bags[thisBag]);
        }



        //Add a ParcelBag into the database
        [HttpPost]
        public async Task<ActionResult<List<Models.ParcelBag>>> AddBag(Models.ParcelBag PBag)
        {
            var lBags = await _context.LetterBags.ToListAsync(); //Get a list of letter bags
            var pBags = await _context.ParcelBags.ToListAsync(); //Get a list of parcel bags

            //Check each type of bag independently so we can return a more relevant error.
            var checkLBag = lBags.FindIndex(lb => lb.BagNo == PBag.BagNo); //Check that a letter bag doesn't already exist
            if (checkLBag != -1)
            {
                return BadRequest("Letter Bag with this bag number already exists!");
            }
            var checkPBag = pBags.FindIndex(pb => pb.BagNo == PBag.BagNo); //Check that a parcel bag doesn't already exist
            if (checkPBag != -1)
            {
                return BadRequest("Parcel Bag with this bag number already exists!");
            }

            _context.ParcelBags.Add(PBag);
            await _context.SaveChangesAsync();
            return Ok(await _context.ParcelBags.ToListAsync());
        }

        //Edit a ParcelBag within the database
        [HttpPut]
        public async Task<ActionResult<List<Models.ParcelBag>>> UpdateBag(Models.ParcelBag parcelbag)
        {
            var pbags = await _context.ParcelBags.ToListAsync();
            var thisPBag = pbags.Find(bn => bn.BagNo == parcelbag.BagNo);
            if (thisPBag == null)
            {
                return BadRequest("Parcel Number not found.");
            }
            
            thisPBag.ParcelNos = parcelbag.ParcelNos;
            await _context.SaveChangesAsync();
            return Ok(await _context.ParcelBags.ToListAsync());
        }

        //Delete a ParcelBag from the database by a given BagNo
        [HttpDelete("{BagNo}")]
        public async Task<ActionResult<List<Models.ParcelBag>>> DeleteBag(string BagNo)
        {
            var bags = await _context.ParcelBags.ToListAsync();
            var thisBag = bags.FindIndex(pb => pb.BagNo == BagNo);
            if (thisBag == -1) //Index result of list will return -1 if not found, so we can throw an error.
            {
                return BadRequest("Bag Number not found.");
            }
            _context.ParcelBags.Remove(_context.ParcelBags.Find(BagNo));
            await _context.SaveChangesAsync();
            return Ok(_context.ParcelBags);
        }
    }
}
