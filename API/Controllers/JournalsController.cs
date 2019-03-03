using EDGM.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace EDGM.Controllers
{
    [Route("api")]
    public class JournalsController : Controller
    {
        //-----------------------------------------------
        private DataContext db;
        public JournalsController(DataContext context)
        {
            this.db = context;
        }
        //--------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------
        [HttpGet("journal/{JournalId}")]
        public IActionResult List(int JournalId)
        {
            Result result = new Result();
            //-----------------------------------------------
            Journal journal = db.Journals
                                .Include(j => j.JournalStarSystems)
                                .ThenInclude(js => js.StarSystem)
                                .FirstOrDefault(j => j.Id == JournalId);
            //-----------------------------------------------
            if (journal != null) {
                result.SetSuccess("Journal retireved successfully.", journal);
            } else
            {
                result.SetFailure("Journal not found.");
            }
            //-----------------------------------------------
            return Ok(result);
        }

        //--------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------
        [HttpPost("journals")]
        public IActionResult Create([FromBody] Journal journal)
        {
            Result result = new Result();
            //-----------------------------------------------
            db.Journals.Add(journal);
            db.SaveChanges();
            //-----------------------------------------------   
            result.SetSuccess("Journal retireved successfully.", journal); 
            //-----------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------
        [HttpPut("journal/{JournalId}")]
        public IActionResult Update(int JournalId, [FromBody] Journal journal)
        {
            Result result = new Result();
            //-----------------------------------------------
            int count = db.Journals.Count(j => j.Id==JournalId);
            if (count == 1)
            {

                EntityEntry dbEnitityEntry = db.Entry(journal);
                if (dbEnitityEntry.State == EntityState.Detached)
                {
                    db.Journals.Attach(journal);
                }
                dbEnitityEntry.State = EntityState.Modified;
                db.SaveChanges();
                result.SetSuccess("Journal updated successfully.", journal);
            }
            else
            {
                result.SetFailure("Journal not found.");

            }
            //-----------------------------------------------
            return Ok(result);
        }
        //--------------------------------------------------------------------------------------
    }
}
