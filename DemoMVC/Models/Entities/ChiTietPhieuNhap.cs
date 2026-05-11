using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC.Models.Entities
{
    public class ChiTietPhieuNhap
    {
        [Key]
        public int MaCTPN { get; set; }

        public int MaPN { get; set; }
        [ForeignKey("MaPN")]
        public virtual PhieuNhap? PhieuNhap { get; set; }

        public int MaTB { get; set; }
        [ForeignKey("MaTB")]
        public virtual ThietBi? ThietBi { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int SoLuong { get; set; }

        public decimal DonGiaNhap { get; set; }
    }
}