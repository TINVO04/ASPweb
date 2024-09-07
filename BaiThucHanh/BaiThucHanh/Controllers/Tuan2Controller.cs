using Microsoft.AspNetCore.Mvc;

namespace BaiThucHanh.Controllers
{
    public class Tuan2Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Võ Văn Tín";
            ViewBag.Mssv = "1822040362";
            ViewBag.Nam = "2024";
            return View();
        }
        public IActionResult MayTinh(int a, int b, String pheptinh)
        {
            double ketQua = 0;
            switch (pheptinh)
            {
                case "cong":
                    ketQua = a + b;
                    break;
                case "tru":
                    ketQua = a - b;
                    break;
                case "nhan":
                    ketQua = a * b;
                    break;
                case "chia":
                    if (b == 0)
                    {
                        ViewBag.ErrorMessage = "Không thể chia cho 0 ";
                        return View("MayTinh");
                    }
                    ketQua = (double)a / b;
                    break;
                default:
                    ViewBag.ErrorMessage = "Phép tính không hợp lệ";
                    return View("MayTinh");
            }
            ViewBag.KetQua = ketQua;
            return View("MayTinh");
        }
    }
}
