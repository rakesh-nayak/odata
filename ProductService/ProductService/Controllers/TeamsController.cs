using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace ProductService.Controllers
{
    public class TeamsController : ODataController
    {
        InMemoryContext db = InMemoryContext.Instance;

        [EnableQuery]
        public IQueryable<Team> Get()
        {
            return db.Teams.AsQueryable();
        }
        [EnableQuery]
        public SingleResult<Team> Get([FromODataUri] int key)
        {
            IQueryable<Team> result = db.Teams.Where(p => p.Id == key).AsQueryable();
            return SingleResult.Create(result);
        }
        public IHttpActionResult Post(Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Teams.Add(team);
            return Created(team);
        }
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Team> team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = db.Teams.SingleOrDefault(x=> x.Id == key);
            if (entity == null)
            {
                return NotFound();
            }
            team.Patch(entity);
            return Updated(entity);
        }
        public IHttpActionResult Put([FromODataUri] int key, Team update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
                return BadRequest();
            }
            return Updated(update);
        }
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            var team = db.Teams.SingleOrDefault(x => x.Id == key);
            if (team == null)
            {
                return NotFound();
            }
            db.Teams.Remove(team);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
