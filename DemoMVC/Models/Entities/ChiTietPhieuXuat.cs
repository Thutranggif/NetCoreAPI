using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC.Models.Entities
{
    public class ChiTietPhieuXuat
    {
        [Key]
        public int MaCTPX { get; set; }

        // Khóa ngoại liên kết tới Phiếu xuất
        public int MaPX { get; set; }
        [ForeignKey("MaPX")]
        public virtual PhieuXuat? PhieuXuat { get; set; }

        // Khóa ngoại liên kết tới Thiết bị
        [Display(Name = "Thiết bị")]
        public int MaTB { get; set; }
        [ForeignKey("MaTB")]
        public virtual ThietBi? ThietBi { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Số lượng xuất phải lớn hơn 0")]
        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }

        [Display(Name = "Đơn giá xuất")]
        public decimal DonGiaXuat { get; set; }

        // Thuộc tính tính toán nhanh (không lưu xuống Database)
        [NotMapped]
        public decimal ThanhTien => SoLuong * DonGiaXuat;
    }
}