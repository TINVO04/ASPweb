using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemTra01.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Dangky(TaiKhoanViewModel taikhoan)
        {
            if (ModelState.IsValid)
            {
                // Xử lý logic đăng ký (ví dụ lưu vào database)
                TempData["SuccessMessage"] = "Đăng ký thành công!";
                return RedirectToAction("Index");
            }
            else
            {
                // In ra các lỗi để kiểm tra
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage); // Bạn có thể log lỗi ra console hoặc dùng các phương pháp khác để kiểm tra lỗi
                }
                TempData["ErrorMessage"] = "Có lỗi xảy ra, vui lòng kiểm tra lại thông tin nhập.";
            }

            return View(taikhoan);
        }
    }
}
