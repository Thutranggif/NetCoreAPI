using Microsoft.AspNetCore.Mvc;

namespace DemoWebMVC.Controllers
{
    public class Buoi4Controller : Controller
    {
        // ---------------------------------------------
        // BÀI 1: TÌM HIỂU VỀ VIEWBAG
        // ---------------------------------------------
        public IActionResult Index()
        {
            // Gửi dữ liệu từ Controller sang View
            ViewBag.Message = "Xin chào, đây là thông báo từ ViewBag!";
            ViewBag.HocVien = "Nguyễn Thị Thu Trang";
            
            return View(); 
        }

        // ---------------------------------------------
        // BÀI 2: GỬI DỮ LIỆU TỪ VIEW -> CONTROLLER
        // ---------------------------------------------
        
        // Action này để hiển thị cái Form nhập liệu
        public IActionResult GuiLoiChao()
        {
            return View();
        }

        // Action này để NHẬN dữ liệu khi bấm nút Gửi
        [HttpPost]
        public IActionResult GuiLoiChao(string hoTen) 
        {
            // Xử lý: Gửi thông báo kèm họ tên ngược lại View
            ViewBag.LoiChao = "Xin chào " + hoTen;

            return View();
        }
    }
}