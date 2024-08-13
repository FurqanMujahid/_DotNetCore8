//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using TestWeb_DotNetCore.Data;
//using TestWeb_DotNetCore.Models;
//using System.Threading.Tasks;

//namespace TestWeb_DotNetCore.Controllers
//{
//    public class OrderController : Controller
//    {
//        private readonly AppDBContext _db;

//        public OrderController(AppDBContext db)
//        {
//            _db = db;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Order(int subCategoryId)
//        {
//            var subCategory = await _db.SubCategories
//                .FirstOrDefaultAsync(sc => sc.SubCategoryId == subCategoryId);

//            if (subCategory == null)
//            {
//                return NotFound();
//            }

//            return View(subCategory);
//        }
//    }
//}


using Microsoft.AspNetCore.Mvc;

namespace TestWeb_DotNetCore.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Order()
        {
            return View();
        }
    }
}
