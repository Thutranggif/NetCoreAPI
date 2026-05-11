using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models.Entities
{
    public class NhaCungCap
    {
        [Key]
        public int MaNCC { get; set; }

        [Required(ErrorMessage = "Tên nhà cung cấp là bắt buộc")]
        [Display(Name = "Tên nhà cung cấp")]
        public string? TenNCC { get; set; }

        [Display(Name = "Địa chỉ")]
        public string? DiaChi { get; set; }

        [Display(Name = "Số điện thoại")]
        public string? SoDienThoai { get; set; }

        // Quan hệ: Một NCC có nhiều phiếu nhập
        public virtual ICollection<PhieuNhap>? PhieuNhaps { get; set; }
    }
}