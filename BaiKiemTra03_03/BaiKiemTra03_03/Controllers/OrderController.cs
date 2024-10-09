using BaiKiemTra03_03.Data;
using BaiKiemTra03_03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemTra03_03.Controllers
{
	public class OrderController : Controller
	{

		public readonly ApplicationDbContext _db;
		public OrderController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			IEnumerable<Order> order = _db.Order.Include("Supplier").ToList();
			return View(order);
		}

		[HttpGet]
		public IActionResult Upsert(int id)
		{
			Order order = new Order();
			IEnumerable<SelectListItem> dssupplier = _db.Supplier.Select(
				item => new SelectListItem
				{
					Value = item.Id.ToString(),
					Text = item.Name
				}
				);
			ViewBag.DSSupplier = dssupplier;
			if (id == 0)
			{
				return View(order);
			}
			else
			{
				order = _db.Order.Include("Supplier").FirstOrDefault(od => od.Id == id);
				return View(order);
			}
		}

		[HttpPost]
		public IActionResult Upsert(Order order)
		{
			if (ModelState.IsValid)
			{
				if (order.Id == 0)
				{
					_db.Order.Add(order);
				}
				else
				{
					_db.Order.Update(order);
				}
				// Lưu lại
				_db.SaveChanges();
				//Chuyen trang ve index
				return RedirectToAction("Index");
			}
			return View();
		}

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var order = _db.Order.Find(id);
            if (order == null)
            {
                return Json(new { success = false, message = "Không tìm thấy đơn hàng!" });
            }

            _db.Order.Remove(order);
            _db.SaveChanges();
            return Json(new { success = true, message = "Xóa đơn hàng thành công!" });
        }

    }
}
