using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BEN_NGAN_HANG
{
    public class CREATE
    {
        public static void Create_cert()
        {
            string opensslPath = "openssl"; // Đường dẫn tới chương trình openssl
            string command = "req -new -x509 -sha256 -key private-key.pem -out certificate.crt";

            string outputFolderPath = "C:\\Users\\ADMIN\\Documents\\MMH\\DO_AN_MAT_MA_HOC_1\\BEN_BAN\\Signature"; // Đường dẫn tới thư mục đầu ra

            // Tạo đối tượng ProcessStartInfo để cấu hình câu lệnh OpenSSL
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = opensslPath;
            startInfo.Arguments = command;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;

            // Tạo đối tượng Process để thực thi câu lệnh
            Process process = new Process();
            process.StartInfo = startInfo;

            // Bắt đầu thực thi câu lệnh
            process.Start();

            // Đọc đầu ra từ câu lệnh
            string output = process.StandardOutput.ReadToEnd();

            // Chờ quá trình hoàn thành
            process.WaitForExit();

            // Kiểm tra mã thoát của quy trình (0 là thành công)
            int exitCode = process.ExitCode;
            MessageBox.Show("Exit code: " + exitCode);

            // Tạo đường dẫn tới tệp tin đầu ra
            string outputFilePath = System.IO.Path.Combine(outputFolderPath, "output.txt");

            // Lưu đầu ra vào tệp tin
            System.IO.File.WriteAllText(outputFilePath, output);

            MessageBox.Show("Output saved to: " + outputFilePath);
        }
    }
}
