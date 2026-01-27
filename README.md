Nguyễn Thị Thu Trang -2221050805_BTH4
1 Tìm hiểu về ViewBag trong MVC
ViewBag trong ASP.NET MVC là một thuộc tính kiểu dynamic (động) được sử dụng để truyền dữ liệu từ Controller sang View mà không cần ép kiểu, giúp code gọn gàng hơn. Nó là một wrapper bao quanh ViewData, hoạt động trong phạm vi một request và tự động xóa sau khi View được render. 
Đặc điểm chính của ViewBag:
Kiểu dữ liệu: Sử dụng dynamic trong C# 4.0 trở lên.
Cú pháp: Đơn giản, ví dụ: ViewBag.Title = "Trang chủ";.
ViewData mối liên hệ: ViewBag thực chất là vỏ bọc của ViewData, dữ liệu được lưu ở cả hai nơi.
Phạm vi (Scope): Chỉ tồn tại trong phạm vi của một HTTP Request (giống ViewData).
Ưu điểm: Không cần ép kiểu khi đọc dữ liệu trong View (ví dụ: var name = ViewBag.Name;).
Nhược điểm: Không kiểm tra kiểu dữ liệu lúc biên dịch (compile-time), có thể gây lỗi runtime nếu sai tên thuộc tính. 
Vd:

public IActionResult Index()
{
    ViewBag.Message = "Chào mừng bạn đến với ASP.NET MVC!";
    ViewBag.CurrentTime = DateTime.Now;
    return View();
}

2.Tìm hiểu về gửi nhận dữ liệu giữa View và Controller thông qua Submit form.