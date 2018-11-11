using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

namespace MyApp.Controllers {

    [Route("api/[controller]")]
    public class ActorsController : Controller {

        private IConfiguration _configuration;
        private sakilaContext dbContext;

        public ActorsController(IConfiguration configuration) {
            _configuration = configuration;
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            dbContext = sakilaContextFactory.Create(connectionString);
        }

        // GET api/actors
        [HttpGet]
        public ActionResult Get() {
            return Ok(dbContext.Actor.ToArray());
        }

        // GET api/actors/101
        [HttpGet("{id}")]
        public ActionResult Get(int id) {
            var actor = dbContext.Actor.SingleOrDefault(a => a.ActorId == id);
            if (actor != null) {
                return Ok(actor);
            } else {
                return NotFound();
            }
        }

        // POST api/actors
        [HttpPost]
        public ActionResult Post([FromBody]Actor actor) {
            if (!ModelState.IsValid)
                return BadRequest();

            dbContext.Actor.Add(actor);
            dbContext.SaveChanges();
            return Created("api/actors", actor);
        }

        // PUT api/actors/101
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Actor actor) {
            var target = dbContext.Actor.SingleOrDefault(a => a.ActorId == id);
            if (target != null && ModelState.IsValid) {
                actor.LastUpdate = DateTimeOffset.Now;
                dbContext.Entry(target).CurrentValues.SetValues(actor);
                dbContext.SaveChanges();
                return Ok();
            } else {
                return BadRequest();
            }
        }

        // DELETE api/actors/101
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            var actor = dbContext.Actor.SingleOrDefault(a => a.ActorId == id);
            if (actor != null) {
                dbContext.Actor.Remove(actor);
                dbContext.SaveChanges();
                return Ok();
            } else {
                return NotFound();
            }
        }
    }
}