using EDGM.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EDGM.Controllers
{
    [Route("api")]
    public class StarSystemController : Controller
    {
        //-----------------------------------------------
        private DataContext db;
        public StarSystemController(DataContext context) {
            this.db = context;
        }
        //--------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------
        [HttpGet("starsystems/{JournalId}")]
        public IActionResult List(int JournalId)
        {
            Result result = new Result();
            //-----------------------------------------------
            Journal journal = db.Journals
                                .Include(j => j.JournalStarSystems)
                                .ThenInclude(js => js.StarSystem)
                                .FirstOrDefault(j => j.Id == JournalId);
            //-----------------------------------------------
            if (journal != null)
            {
                result.SetSuccess("Journal retireved successfully.", journal);
            }
            else
            {
                result.SetFailure("Journal not found.");
            }
            //-----------------------------------------------
            return Ok(result);
        }

        //--------------------------------------------------------------------------------------  add star system
        [HttpPost("starsystems")]
        public IActionResult Post([FromBody] StarInfo starInfo)
        {
            Result result = new Result();
            //-----------------------------------------------
            StarSystem starSystem = new StarSystem(starInfo);
            int count = db.StarSystems.Count(s => s.Name == starInfo.name);
            //-----------------------------------------------
            if (count == 0)
            {
                db.StarSystems.Add(starSystem);
                db.SaveChanges();
                result.SetSuccess("StarSystem " + starSystem.Name + " created successfully.", starSystem);
            }
            else
            {
                result.SetFailure("StarSystem already exists.");
            }
            //-----------------------------------------------
            return Ok(result);

        }
        //--------------------------------------------------------------------------------------  add star system and add to journal
        [HttpPost("starsystems/{JournalId}")]
        public IActionResult Post(int JournalId, [FromBody] StarInfo starInfo)
        {
            Result result = new Result();
            //-----------------------------------------------
            StarSystem starSystem = new StarSystem(starInfo);
            int count = db.StarSystems.Count(s => s.Name == starInfo.name);
            //-----------------------------------------------
            if (count == 0)
            {
                db.StarSystems.Add(starSystem);
                db.SaveChanges();

                db.JournalStarSystems.Add(new JournalStarSystem() { JournalId = JournalId, StarSystemId = starSystem.Id });
                db.SaveChanges();

                result.SetSuccess("StarSystem " + starSystem.Name + " created successfully and added to journal.", starSystem);
            }
            else
            {
                result.SetFailure("StarSystem already exists.");
            }
            //-----------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------------------
        [HttpDelete("starsystems/{StarSystemId}")]
        public IActionResult Delete(int StarSystemId)
        {
            Result result = new Result();
            //-----------------------------------------------
            StarSystem starSystem = db.StarSystems.FirstOrDefault(s => s.Id == StarSystemId);
            List<JournalStarSystem> journalStarSystems = db.JournalStarSystems.Where(s => s.StarSystemId == StarSystemId).ToList();
            //-----------------------------------------------
            if (starSystem != null)
            {

                foreach(JournalStarSystem jss in journalStarSystems)
                {
                    db.JournalStarSystems.Remove(jss);
                }
                db.SaveChanges();

                db.StarSystems.Remove(starSystem);
                db.SaveChanges();
                result.SetSuccess("StarSystem " + starSystem.Name + " deleted.", starSystem);      
            }
            else
            {
                result.SetFailure("StarSystem not found.");
            }
            //-----------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------------------

    }
}
