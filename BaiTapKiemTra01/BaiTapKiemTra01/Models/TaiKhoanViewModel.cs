using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BaiTapKiemTra01.Models
{
    public class TaiKhoanViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Tên là bắt buộc")]
        public string Ten { get; set; }

        [Range(1, 100, ErrorMessage = "Tuổi người dùng là bắt buộc từ 1 đến 100")]
        public int Tuoi { get; set; }  // Đảm bảo rằng đây là `int` thay vì `string` để phù hợp với việc kiểm tra độ tuổi

        [Required(ErrorMessage = "Tên người dùng là bắt buộc")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        public string Password { get; set; }
    }
}
