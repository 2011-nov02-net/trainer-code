using System.Linq;
using KitchenService.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace KitchenService.Api.Controllers
{
    [Route("api/appliances/fridge")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        private readonly Fridge _fridge;

        public FridgeController(Fridge fridge)
        {
            _fridge = fridge;
        }

        // GET /api/appliances/fridge
        [HttpGet]
        public IActionResult Get()
        {
            var appliance = new Appliance { Id = _fridge.Id, Name = _fridge.Name };
            return Ok(appliance);
        }

        // GET /api/appliances/fridge/contents
        [HttpGet("contents")]
        public IActionResult GetContents()
        {
            return Ok(_fridge.Contents);
        }

        // POST /api/appliances/fridge/contents
        [HttpPost("contents")]
        public IActionResult PostContents(FridgeItem item)
        {
            _fridge.AddItem(item);
            return CreatedAtAction(
                actionName: nameof(GetContentsById),
                routeValues: new { item.Id },
                value: item);
            // if there was a validation error we caught here...
            //ModelState.AddModelError(nameof(item.Id))
            //return BadRequest(;
        }

        // GET /api/appliances/fridge/contents/5
        [HttpGet("contents/{id}")]
        public IActionResult GetContentsById(int id)
        {
            if (_fridge.Contents.FirstOrDefault(x => x.Id == id) is FridgeItem item)
            {
                return Ok(item);
            }
            return NotFound(); // 404, when the requested URL doesn't correspond to an existing resource.
        }
    }
}
