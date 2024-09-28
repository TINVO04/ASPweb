using BaiKiemTra02.Data;
using Microsoft.AspNetCore.Mvc;
using BaiKiemTra02.Models;
using BaiKiemTra02.Data;
using BaiKiemTra02.Data.Migrations;
using LopHoc = BaiKiemTra02.Models.LopHoc;
namespace BaiKiemTra02.Controllers
{
	public class LopHocController : Controller
	{
		private readonly ApplicationDbContext _db;
		public LopHocController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			var lophoc = _db.LopHoc.ToList();
			ViewBag.LopHoc = lophoc;
			return View();
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(LopHoc lophoc)
		{
			// Thêm thông tin vào bảng TheLoai
			if (ModelState.IsValid)
			{
				_db.LopHoc.Add(lophoc);
				// Lưu lại
				_db.SaveChanges();
				//Chuyen trang ve index
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
			var theloai = _db.LopHoc.Find(id);
			return View(theloai);
		}
		[HttpPost]
		public IActionResult Edit(LopHoc lophoc)
		{
			// Thêm thông tin vào bảng TheLoai
			if (ModelState.IsValid)
			{
				_db.LopHoc.Update(lophoc);
				// Lưu lại
				_db.SaveChanges();
				//Chuyen trang ve index
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
			var lophoc = _db.LopHoc.Find(id);
			return View(lophoc);
		}
		[HttpPost]
		public IActionResult DeleteConfirm(int id)
		{
			var lophoc = _db.LopHoc.Find(id);
			// Thêm thông tin vào bảng TheLoai
			if (lophoc == null)
            {
                return NotFound();
			}
			_db.LopHoc.Remove(lophoc);
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
			var lophoc = _db.LopHoc.Find(id);
			if (lophoc == null)
			{
				return NotFound();
			}
			return View(lophoc);
		}
	}
}