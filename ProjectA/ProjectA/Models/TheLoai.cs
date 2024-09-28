using System.ComponentModel.DataAnnotations;


namespace ProjectA.Models
{
    public class TheLoai
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Không được để tróng tên thể loại")]
        [Display(Name ="Thể Loại")]
        public string Name { get; set; }
		[Required(ErrorMessage = "Không đúng định dạng ngày")]
		[Display(Name = "Ngày Tạo")]
		public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
