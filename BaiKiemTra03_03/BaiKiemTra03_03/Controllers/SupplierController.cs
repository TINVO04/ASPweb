using BaiKiemTra03_03.Data;
using BaiKiemTra03_03.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTra03_03.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SupplierController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var supplier = _db.Supplier.ToList();
            ViewBag.Supplier = supplier;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

		[HttpPost]
		public IActionResult Create(Supplier supplier)
		{
			if (ModelState.IsValid)
			{
				//Them thong tin vao table the loai
				_db.Supplier.Add(supplier);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			if (id == 0)
			{
				return NotFound();
			}
			var supplier = _db.Supplier.Find(id);
			return View(supplier);

		}

		[HttpPost]
		public IActionResult Edit(Supplier supplier)
		{
			if (ModelState.IsValid)
			{
				_db.Supplier.Update(supplier);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}


		[HttpGet]
		public IActionResult Delete(int id)
		{
			if (id == 0)
			{
				return NotFound();
			}
			var supplier = _db.Supplier.Find(id);
			return View(supplier);
		}

		[HttpPost]
		public IActionResult DeleteConfirm(int id)
		{
			var supplier = _db.Supplier.Find(id);
			if (supplier == null)
			{
				return NotFound();
			}
			_db.Supplier.Remove(supplier);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var supplier = _db.Supplier.Find(id);

            if (supplier == null)
            {
                return NotFound();
            }
            ViewBag.Title = "Chi Tiết Nhà Cung Cấp";
            return View(supplier);
        }

		[HttpGet]
		public IActionResult Search(string searchString)
		{
			if (!string.IsNullOrEmpty(searchString))
			{
				var supplier = _db.Supplier
				.Where(tl => tl.Name.Contains(searchString))
					.ToList();

				ViewBag.SearchString = searchString;
				ViewBag.Supplier = supplier;
			}
			else
			{
				var supplier = _db.Supplier.ToList();
				ViewBag.Supplier = supplier;
			}
			return View("Index");
		}
	}
}
