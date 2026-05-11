using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC.Models.Entities
{
    public class ThietBi
    {
        [Key]
        public int MaTB { get; set; }

        [Required]
        [Display(Name = "Tên thiết bị")]
        public string? TenTB { get; set; }

        [Display(Name = "Số lượng tồn")]
        public int SoLuongTon { get; set; } = 0; // Mặc định bằng 0

        [Display(Name = "Đơn giá niêm yết")]
        public decimal Gia { get; set; }

        // Khóa ngoại liên kết với LoaiThietBi
        [Display(Name = "Loại thiết bị")]
        public int MaLoai { get; set; }

        [ForeignKey("MaLoai")]
        public virtual LoaiThietBi? LoaiThietBi { get; set; }
    }
}