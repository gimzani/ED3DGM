using EDGM.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace EDGM.Controllers
{
    [Route("api")]
    public class CategoriesController : Controller
    {
        //-----------------------------------------------
        private DataContext db;
        public CategoriesController(DataContext context)
        {
            this.db = context;
        }
        //--------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------
        [HttpGet("categories/{CategoryName}")]
        public IActionResult List(string CategoryName)
        {
            Result result = new Result();
            //-----------------------------------------------
            Category category = db.Categories
                                .Include(c => c.ColorLabels)
                                .FirstOrDefault(c => c.Name == CategoryName);
            //-----------------------------------------------
            if (category != null)
            {
                result.SetSuccess("Category retireved successfully.", category);
            }
            else
            {
                result.SetFailure("Category not found.");
            }
            //-----------------------------------------------
            return Ok(result);
        }

    }
}
