using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaSportif.Models;
using AgendaSportif.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


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
        {
            return Ok(data.Events.ToList());
        }

        // POST: api/EventSearch
        [Route("/GetSearch/{search}")]
        [HttpPost]
        public ActionResult GetSearch(string search)
        {
            return Ok(data.Events.Where(t => t.Title.Contains(search)));
        }

        // POST: api/Event
        [Route("/AddDates")]
        [HttpPost]
        public ActionResult Post([FromBody] Event events)
        {
            data.Events.Add(events);

            if (data.SaveChanges() > 0)
                return Ok(new { error = false });
            else
                return StatusCode(500);
        }

        //PUT : api/EditDate/5
        [Route("/EditDate/{id}")]
        [HttpPut]
        public ActionResult Put([FromBody] Event e)
        {
            Event e2 = data.Events.Find(e.Id);
            if (e2 != null)
            {
                e2.Id = (e.Id != 0) ? e.Id : e2.Id;
                e2.Title = (e.Title != null) ? e.Title : e2.Title;
                e2.Start = (e.Start != null) ? e.Start : e2.Start;

                if (data.SaveChanges() >= 1)
                    return Ok(new { message = "Event modifié", error = false, EventId = e.Id });
                else
                    return Ok(new { message = "erreur serveur", error = true });
            }
            else
                return NotFound();
        }

        // DELETE: api/ApiWithActions/5
        [Route("/Delete/{id}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
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