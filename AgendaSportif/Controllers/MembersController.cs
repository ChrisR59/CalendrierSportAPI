using AgendaSportif.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaSportif.Controllers
{
    public class MembersController : Controller
    {
        private DataDbContext data;

        public EventController(DataDbContext _data)
        {
            data = _data;
        }

        // POST: api/Event
        [Route("/AddMembers")]
        [HttpPost]
        public ActionResult Post([FromBody] Members members)
        {
            data.Members.Add(members);

            if (data.SaveChanges() > 0)
                return Ok(new { error = false });
            else
                return StatusCode(500);
        }
    }
}
