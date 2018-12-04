using ColourCoordination.Models;
using Microsoft.AspNetCore.Mvc;

namespace ColourCoordination.Controllers
{
    public class ColourController : Controller
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        [Route("set-shirt")]
        public IActionResult GetSetShirtColor()
        {
            return View("SetShirtColour");
        }

        [HttpPost]
        [Route("set-shirt")]
        public IActionResult PostSetShirtColor(Outfit outfit)
        {
            return View("SetShirtColour", outfit);
        }

        [HttpGet]
        [Route("set-pants")]
        public IActionResult GetSetPantsColor()
        {
            return View("SetPantsColour");
        }

        [HttpPost]
        [Route("set-pants")]
        public IActionResult PostSetPantsColor(Outfit outfit)
        {
            return View("SetPantsColour", outfit);
        }

        [HttpGet]
        [Route("set-shoes")]
        public IActionResult GetSetShoeColor()
        {
            return View("SetShoesColour");
        }

        [HttpPost]
        [Route("set-shoes")]
        public IActionResult PostSetShoeColor(Outfit outfit)
        {
            return View("SetShoesColour", outfit);
        }
    }
}
