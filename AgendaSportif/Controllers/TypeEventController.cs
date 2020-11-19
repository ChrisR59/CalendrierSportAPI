using AgendaSportif.Tools;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaSportif.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TypeEventController : Controller
    {
        private DataDbContext data;

        public TypeEventController(DataDbContext _data)
        {
            data = _data;
        }
        public IActionResult Index()
        {
            return View();
        }

        //POST: api/TypeEvent
        [Route("/TypeEvent")]
        [HttpPost]
        public ActionResult GetTypeEvent()
        {
            return Ok(data.TypeEvent.ToList());
        }
    }
}
