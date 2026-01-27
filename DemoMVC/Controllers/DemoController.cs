using Microsoft.AspNetCore.Mvc;

namespace MyMvcProject.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            // Thay đổi thông tin của bạn tại đây
            ViewBag.Message = "Hello Nguyễn Thị Thu Trang - MSV: 2221050805";
            return View();
        }
    }
}