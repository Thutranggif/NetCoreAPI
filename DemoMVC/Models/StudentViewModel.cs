namespace DemoMVC.Models
{
    public class StudentViewModel
    {
        public string StudentCode { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string FacultyName { get; set; }  = default!; // Lấy tên khoa thay vì mã khoa
    }
}