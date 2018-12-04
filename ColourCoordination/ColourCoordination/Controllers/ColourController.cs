using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ColourCoordination.Models;

namespace ColourCoordination.Controllers
{
    public class ColourController : Controller
    {
        [HttpGet]
        [Route("set-shirt")]
        public IActionResult GetSetShirtColor()
        {

        }

        [HttpPost]
        [Route("set-shirt")]
        public IActionResult PostSetShirtColor(Outfit outfit)
        {

        }

        [HttpGet]
        [Route("set-pants")]
        public IActionResult GetSetPantsColor()
        {

        }

        [HttpPost]
        [Route("set-pants")]
        public IActionResult PostSetPantsColor(Outfit outfit)
        {

        }

        [HttpGet]
        [Route("set-shoes")]
        public IActionResult GetSetShoeColor()
        {

        }

        [HttpPost]
        [Route("set-shoes")]
        public IActionResult PostSetShoeColor(Outfit outfit)
        {

        }
    }

    public class Outfit
    {
        public string ShirtColor { get; set; }
        public string PantsColor { get; set; }
        public string ShoeColor { get; set; }
    }

}
