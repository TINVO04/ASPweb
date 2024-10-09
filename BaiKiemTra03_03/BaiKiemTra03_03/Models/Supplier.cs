using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_03.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Không Được Để Trống Name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Không Được Để Trống Address!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Không Được Để Trống PhoneNumber!")]
        public int PhoneNumber { get; set; }
		[Required(ErrorMessage = "Không Được Để Trống Email!")]
        public string Email { get; set; }
    }
}
