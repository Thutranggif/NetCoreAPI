using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC.Models.Entities
{
    public class PhieuNhap
    {
        [Key]
        public int MaPN { get; set; }

        [Display(Name = "Ngày nhập")]
        public DateTime NgayNhap { get; set; } = DateTime.Now;

        [Display(Name = "Nhà cung cấp")]
        public int MaNCC { get; set; }

        [ForeignKey("MaNCC")]
        public virtual NhaCungCap? NhaCungCap { get; set; }

        // Danh sách chi tiết các thiết bị trong phiếu nhập này
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();
    }
}