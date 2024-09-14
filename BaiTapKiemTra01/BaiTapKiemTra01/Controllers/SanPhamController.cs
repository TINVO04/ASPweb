using Microsoft.AspNetCore.Mvc;
using BaiTapKiemTra01.Models;

namespace BaiTapKiemTra01.Controllers
{
    public class SanPhamController : Controller
    {
        public IActionResult BaiTap2()
        {
            var sanpham = new SanPhamViewModel
            {
                TenSanPham = "Tên sản phẩm",
                GiaBan = 1000000M,  // Ví dụ giá bán là 1.000.000 VND
                AnhMoTa = "~/about-img.png"  // URL của ảnh mô tả
            };

            return View(sanpham);
        }
    }
}
