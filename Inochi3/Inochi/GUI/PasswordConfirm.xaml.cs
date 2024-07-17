using Inochi.BUS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UIKitTutorials;

namespace Inochi.GUI
{
    /// <summary>
    /// Interaction logic for PasswordConfirm.xaml
    /// </summary>
    public partial class PasswordConfirm : Window
    {
        string ftpServerOutput = "";
        string ftpUsername = "";
        string ftpPassword = "";
        baseBUS bBUS = new baseBUS();
        public PasswordConfirm()
        {
            InitializeComponent();
            this.Loaded += PasswordConfirm_Loaded;
        }

        private void PasswordConfirm_Loaded(object sender, RoutedEventArgs e)
        {
            LoadThongTin();
        }
        public void LoadThongTin()
        {
            try
            {
                if (File.Exists(@"Config\Config.ini"))
                {
                    IniParserBUS par = new IniParserBUS(@"Config\Config.ini");

                    string[] a = par.GetSetting("FTPCONFIG", "FTPOUTPUT").Split(',');
                    ftpServerOutput = bBUS.Decrypt(Convert.ToString(a[0].Replace(" ", "")));

                    a = par.GetSetting("FTPCONFIG", "USER").Split(',');
                    ftpUsername = bBUS.Decrypt(Convert.ToString(a[0].Replace(" ", "")));

                    a = par.GetSetting("FTPCONFIG", "PASS").Split(',');
                    ftpPassword = bBUS.Decrypt(Convert.ToString(a[0].Replace(" ", "")));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPass.Password)) return;
            if (txtPass.Password == "70222555")
            {
                DeleteAllFilesInFolderOnFTP(ftpServerOutput, ftpUsername, ftpPassword);
                this.Close();
            }
            else
            {
                MessageBox.Show("Mật không chính xác", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        static void DeleteAllFilesInFolderOnFTP(string folderUri, string ftpUsername, string ftpPassword)
        {
            try
            {
                // Tạo yêu cầu FTP
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(folderUri);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails; // Lấy thông tin chi tiết của các tệp trong thư mục

                // Thiết lập thông tin đăng nhập
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

                // Gửi yêu cầu và nhận phản hồi
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                // Đọc thông tin chi tiết của các tệp và xóa chúng
                string line = "";
                //while (!string.IsNullOrEmpty(line))
                //{
                //    string[] tokens = line.Split(' ');
                //    string fileName = tokens[tokens.Length - 1].Trim(); // Lấy tên tệp từ dòng thông tin chi tiết
                //    if (fileName != "." && fileName != "..") // Bỏ qua các thư mục cha và hiện tại
                //    {
                //        DeleteFileOnFTP(folderUri + Uri.EscapeUriString(fileName), ftpUsername, ftpPassword);
                //    }
                //    line = reader.ReadLine();
                //}
                while ((line = reader.ReadLine()) != null)
                {
                    // Kiểm tra và chỉ thêm các tệp (không phải thư mục)
                    if (!line.StartsWith("d")) // Ký tự đầu tiên không phải là 'd' cho thư mục
                    {
                        string[] details = line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
                        if (details.Length >= 9)
                        {
                            //files.Add(details[8]);
                            DeleteFileOnFTP(folderUri + Uri.EscapeUriString(details[8]), ftpUsername, ftpPassword);
                        }
                    }
                }
                // Đóng các luồng
                reader.Close();
                response.Close();
                MessageBox.Show("Xóa file thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        static void DeleteFileOnFTP(string fileUri, string ftpUsername, string ftpPassword)
        {
            try
            {
                // Tạo yêu cầu FTP
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(fileUri);
                request.Method = WebRequestMethods.Ftp.DeleteFile; // Xóa tệp

                // Thiết lập thông tin đăng nhập
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

                // Gửi yêu cầu và nhận phản hồi
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Console.WriteLine("File deleted: " + fileUri);

                // Đóng phản hồi
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void tblPass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPass.Focus();
        }

        private void txtPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPass.Password) && txtPass.Password.Length > 0)
                tblPass.Visibility = Visibility.Collapsed;
            else
                tblPass.Visibility = Visibility.Visible;
        }
    }
}
