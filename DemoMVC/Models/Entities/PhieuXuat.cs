using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC.Models.Entities
{
    public class PhieuXuat
    {
        [Key]
        public int MaPX { get; set; }

        [Display(Name = "Ngày xuất")]
        public DateTime NgayXuat { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Vui lòng nhập tên khách hàng")]
        [Display(Name = "Tên khách hàng")]
        public string TenKhachHang { get; set; } = string.Empty;

        [Display(Name = "Ghi chú")]
        public string? GhiChu { get; set; }

        // Mối quan hệ: Một phiếu xuất có nhiều dòng chi tiết thiết bị
        public virtual ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; } = new List<ChiTietPhieuXuat>();
    }
}