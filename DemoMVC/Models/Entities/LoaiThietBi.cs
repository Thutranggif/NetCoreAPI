using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models.Entities
{
    public class LoaiThietBi
    {
        [Key]
        public int MaLoai { get; set; }

        [Required(ErrorMessage = "Tên loại không được để trống")]
        [Display(Name = "Tên loại thiết bị")]
        public string? TenLoai { get; set; }

        // Quan hệ: Một loại có nhiều thiết bị
        public virtual ICollection<ThietBi>? ThietBis { get; set; }
    }
}