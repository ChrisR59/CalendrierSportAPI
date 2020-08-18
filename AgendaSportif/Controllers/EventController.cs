using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaSportif.Models;
using AgendaSportif.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaSportif.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private DataDbContext data;

        public EventController(DataDbContext _data)
        {
            data = _data;
        }

        // GET: api/Event
        [Route("/GetAll")]
        [HttpGet]
        public ActionResult GetAll()
        {//Fonctionne
            return Ok(data.Events.ToList());
        }

        // GET: api/Event/5
        [Route("/GetByMonth")]
        [HttpGet("{date}", Name = "Get")]
        public ActionResult GetMonth(DateTime date)
        {
            return Ok(data.Events.Where(d => d.DateEvent > date || d.DateEvent < date));
        }

        // POST: api/Event
        [Route("/AddDates")]
        [HttpPost]
        public ActionResult Post([FromBody] Event events)
        {
            //Enregistrement d'un entré
            Event e = data.Events.Last();
            events.Id = e.Id;
            data.Events.Add(events);

            if (data.SaveChanges() > 0)
            {
                return Ok(new { error = false, EventId = e.Id });
            }
            else
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/ApiWithActions/5
        [Route("/Delete/{id}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {//Fonctionne
            Event e = data.Events.Find(id);

            if (e != null)
            {
                data.Events.Remove(e);

                if (data.SaveChanges() >= 1)
                    return Ok(new { error = false, EventId = id, message = "element supprimé" });
                else
                    return StatusCode(500);
            }
            else
                return NotFound();
        }
    }
}