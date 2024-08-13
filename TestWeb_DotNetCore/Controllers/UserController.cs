using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWeb_DotNetCore.Data;

namespace TestWeb_DotNetCore.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDBContext _db;

        public UserController(AppDBContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> SelectCategory()
        {
            var categories = await _db.Categories.ToListAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> GetSubCategories(int id)
        {
            var subCategories = await _db.SubCategories
                                          .Where(sc => sc.CategoryId == id)
                                          .ToListAsync();
            return Json(subCategories);
        }

    }
}
