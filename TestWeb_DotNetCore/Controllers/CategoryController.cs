using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWeb_DotNetCore.Data;
using TestWeb_DotNetCore.Models;

namespace TestWeb_DotNetCore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDBContext _db;
        public CategoryController(AppDBContext db)
        {
            _db = db;
        }

        public IActionResult GetCategories()
        {
            var categories = _db.Categories.ToList();
            return Json(categories);
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objectcategorylist = _db.Categories.ToList();
            return View(objectcategorylist);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Add DisplayOrder cannot match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var found = _db.Categories.Find(id);
            if (found == null)
            {
                return NotFound();
            }
            return View(found);
        }
        [HttpPost]
        public IActionResult Edit(int? id, Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "DisplayOrder cannot match the Name");
            }
            if (ModelState.IsValid)
            {
                var categoryFromDb = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
                if (categoryFromDb != null)
                {
                    categoryFromDb.Name = obj.Name;
                    categoryFromDb.DisplayOrder = obj.DisplayOrder;
                    _db.SaveChanges();
                    TempData["success"] = "Category updated successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Category not found");
                }
            }
            return View(obj);
        }


        public IActionResult Delete(int id)
        {
            var categoryFromDb = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int id)
        {
            var categoryFromDb = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(categoryFromDb);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            var category = await _db.Categories
                .Include(c => c.SubCategories)
                .FirstOrDefaultAsync(c => c.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

       
    }
}
