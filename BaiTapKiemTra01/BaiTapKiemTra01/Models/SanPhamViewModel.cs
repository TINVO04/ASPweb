using System;
using System.ComponentModel.DataAnnotations;

namespace BaiTapKiemTra01.Models
{
    public class SanPhamViewModel
    {
        [Required]
        public string TenSanPham { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal GiaBan { get; set; }

        public string AnhMoTa { get; set; }  // URL của ảnh
    }
}
