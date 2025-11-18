using DTO;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FormLogin());
            //Application.Run(new MainForm(new UserDTO { MSSV = "0000000000", HoTen = "Admin", TenDangNhap = "admin", MatKhau = "123456", Email = "admin@gmail.com", Role = "Quản trị", TrangThai = 1 }));
        }
    }
}