using Mailroom_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mailroom_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LetterBagController : Controller
    {
        //Define the data context in which we'll be accessing the DB
        private readonly DataContext _context;
        public LetterBagController(DataContext context)
        {
            _context = context;
        }

        //Get all LetterBags from the DB into a list and return it
        [HttpGet]
        public async Task<ActionResult<List<Models.LetterBag>>> Get()
        {
            return Ok(await _context.LetterBags.ToListAsync());
        }

        //Get a single LetterBag by it's BagNumber value and return it
        [HttpGet("{BagNo}")]
        public async Task<ActionResult<Models.LetterBag>> Get(string BagNo)
        {
            var bags = await _context.LetterBags.ToListAsync();
            var thisBag = bags.FindIndex(lb => lb.BagNo == BagNo);
            if (thisBag == -1) //Index result of list will return -1 if not found, so we can throw an error.
            {
                return BadRequest("Bag Number not found.");
            }
            return Ok(bags[thisBag]);
        }

        //Add a LetterBag into the database
        [HttpPost]
        public async Task<ActionResult<List<Models.LetterBag>>> AddBag(Models.LetterBag LBag)
        {
            var lBags = await _context.LetterBags.ToListAsync(); //Get a list of letter bags
            var pBags = await _context.ParcelBags.ToListAsync(); //Get a list of parcel bags

            //Check each type of bag independently so we can return a more relevant error.
            var checkLBag = lBags.FindIndex(lb => lb.BagNo == LBag.BagNo); //Check that a letter bag doesn't already exist
            if (checkLBag != -1)
            {
                return BadRequest("Letter Bag with this bag number already exists!");
            }
            var checkPBag = pBags.FindIndex(pb => pb.BagNo == LBag.BagNo); //Check that a parcel bag doesn't already exist
            if (checkPBag != -1)
            {
                return BadRequest("Parcel Bag with this bag number already exists!");
            }

            _context.LetterBags.Add(LBag);
            await _context.SaveChangesAsync();
            return Ok(await _context.LetterBags.ToListAsync());
        }

        //Edit a LetterBag within the database, and don't update the values that are empty or 0, so you can edit only certain aspects if necessary.
        [HttpPut]
        public async Task<ActionResult<List<Models.LetterBag>>> UpdateBag(Models.LetterBag letterbag)
        {
            var lbags = await _context.LetterBags.ToListAsync();
            var thisLBag = lbags.Find(bn => bn.BagNo == letterbag.BagNo);
            if (thisLBag == null)
            {
                return BadRequest("Bag Number not found.");
            }
            //if values are not empty or zero, we will update them within the list and return all Bags.
            thisLBag.LetterCount = letterbag.LetterCount;
            thisLBag.Weight = letterbag.Weight;
            thisLBag.Price = letterbag.Price;
            //Don't check if this is empty since it's allowed to be. (Bag can be created before parcels are added to it.)
            thisLBag.ParcelList = letterbag.ParcelList;
            await _context.SaveChangesAsync();
            return Ok(await _context.LetterBags.ToListAsync());
        }

        //Delete a LetterBag from the database by a given BagNo
        [HttpDelete("{BagNo}")]
        public async Task<ActionResult<List<Models.LetterBag>>> DeleteBag(string BagNo)
        {
            var lbags = await _context.LetterBags.ToListAsync();
            var thisLBag = lbags.FindIndex(bn => bn.BagNo == BagNo);
            if (thisLBag == -1)
            {
                return BadRequest("Bag Number not found.");
            }
            //lbags.Remove(lbags[thisLBag]);
            _context.LetterBags.Remove(_context.LetterBags.Find(BagNo));
            await _context.SaveChangesAsync();
            return Ok(_context.LetterBags);
        }
    }
}
