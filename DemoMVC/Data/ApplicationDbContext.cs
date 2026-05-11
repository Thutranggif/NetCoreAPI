using DemoMVC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set;}
        public DbSet<KhachHang> KhachHangs { get; set;}
        public DbSet<DonHang> DonHangs { get; set;}
        public DbSet<SanPham> SanPhams { get; set;}
        public  DbSet<NhaCungCap> NhaCungCaps { get; set;}
         public  DbSet<LoaiThietBi> LoaiThietBis { get; set;}
          public  DbSet<ThietBi> ThietBis { get; set;}
           public  DbSet<PhieuNhap> PhieuNhaps { get; set;}
            public  DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set;}
            public DbSet<PhieuXuat> PhieuXuats {get; set;}
            public DbSet<ChiTietPhieuXuat> ChiTietPhieuXuats {get; set;}
    }
}
