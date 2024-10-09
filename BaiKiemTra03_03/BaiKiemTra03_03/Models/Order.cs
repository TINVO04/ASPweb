using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiKiemTra03_03.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Không Được Để Trống!")]
        [Display(Name = "Ngày Đặt")]
        public DateTime NgayDat { get; set; }

        [Required(ErrorMessage = "Không Được Để Trống!")]
        [Display(Name = "Tổng Giá Trị")]
        public double TongGia { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        [ValidateNever]
        public Supplier Supplier { get; set; }

        [Required(ErrorMessage = "Tình Trạng Đơn Hàng không được để trống!")]
        [Display(Name = "Tình Trạng Đơn Hàng")]
        public string OrderStatus { get; set; }
    }
}
