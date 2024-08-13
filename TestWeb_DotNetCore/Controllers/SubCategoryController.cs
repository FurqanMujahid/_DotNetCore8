using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;
using System.Collections.Generic;
using TestWeb_DotNetCore.Data;
using TestWeb_DotNetCore.Models;

namespace TestWeb_DotNetCore.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly AppDBContext _db;

        public SubCategoryController(AppDBContext db)
        {
            _db = db;
        }
        public IActionResult GetSubCategories(int categoryId)
        {
            var subCategories = _db.SubCategories
                .Where(s => s.CategoryId == categoryId)
                .ToList();
            return Json(subCategories);
        }


        public IActionResult Index()
        {
            IEnumerable<SubCategory> subCategories = _db.SubCategories;
            return View(subCategories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SubCategory obj)
        {
            if (ModelState.IsValid)
            {
                _db.SubCategories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Sub Category created successfully";
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
            var found = _db.SubCategories.Find(id);
            if (found == null)
            {
                return NotFound();
            }
            return View(found);
        }
        [HttpPost]
        public IActionResult Edit(int? id, SubCategory obj)
        {
            {
                var subcategory = _db.SubCategories.FirstOrDefault(c => c.SubCategoryId == id);
                if (subcategory != null)
                {
                    subcategory.SubCategoryName = obj.SubCategoryName;
                    subcategory.Description = obj.Description;
                    _db.SaveChanges();
                    TempData["success"] = "Sub Category updated successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Sub Category not found");
                }
            }
            return View(obj);
        }


        public IActionResult Delete(int id)
        {
            var subCategory = _db.SubCategories.FirstOrDefault(c => c.SubCategoryId == id);
            if (subCategory == null)
            {
                return NotFound();
            }
            return View(subCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int id)
        {
            var subCategory = _db.SubCategories.FirstOrDefault(c => c.SubCategoryId == id);
            if (subCategory == null)
            {
                return NotFound();
            }

            _db.SubCategories.Remove(subCategory);
            _db.SaveChanges();
            TempData["success"] = "Sub Category deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
