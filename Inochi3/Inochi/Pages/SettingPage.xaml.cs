using Inochi.BUS;
using Inochi.DTO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Inochi.Pages.FtpPage;

namespace Inochi.Pages
{
    /// <summary>
    /// Lógica de interacción para NotesPage.xaml
    /// </summary>
    public partial class SettingPage : Page
    {

        private string[] validExcelExtensions = new string[] { ".xlsx", ".xls", ".xlsm", ".xlsb", ".csv" };
        baseBUS bBUS = new baseBUS();
        public SettingPage()
        {
            InitializeComponent();
            this.Loaded += NotesPage_Loaded;
        }

        private void NotesPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadThongTin();
        }

        #region Button
        #region *Butotn Lưu thông tin
        private void btnSaveSetting_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(@"Config\Config.ini"))
            {
                IniParserBUS par = new IniParserBUS(@"Config\Config.ini");
                par.AddSetting("FTPCONFIG", "FTPINPUT", bBUS.Encrypt(txtInput.Text.Trim()));
                par.AddSetting("FTPCONFIG", "FTPOUTPUT", bBUS.Encrypt(txtOutput.Text.Trim()));
                par.AddSetting("FTPCONFIG", "USER", bBUS.Encrypt(txtUser.Text.Trim()));
                par.AddSetting("FTPCONFIG", "PASS", bBUS.Encrypt(txtPass.Password.Trim()));

                par.SaveSettings();
                MessageBox.Show("Lưu thông tin thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion

        #region *Button Import excel
        private void btnImportExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files (*.xlsx, *.xls, *.xlsm, *.xlsb, *.csv)|*.xlsx;*.xls;*.xlsm;*.xlsb;*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = true; // Cho phép chọn nhiều file

                if (openFileDialog.ShowDialog() == true)
                {
                    string[] selectedFiles = openFileDialog.FileNames;

                    foreach (string selectedFilePath in selectedFiles)
                    {
                        if (CountExcelFileInExcelExample() > 0)
                        {
                            if (MessageBox.Show($"Trong Folder Excel mẫu có hơn 1 file, bạn có muốn xóa file trước đó?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    string[] files = Directory.GetFiles(@"Excel_Example");
                                    foreach (string file in files)
                                    {
                                        File.Delete(file);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Error deleting file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else return;
                        }

                        // Kiểm tra xem file có phải là một tệp Excel hợp lệ không
                        if (IsExcelFile(selectedFilePath))
                        {
                            // Kiểm tra xem file đã tồn tại trong thư mục Excel hay chưa
                            string destinationFile = System.IO.Path.Combine(@"Excel_Example", System.IO.Path.GetFileName(selectedFilePath));
                            if (!File.Exists(destinationFile))
                            {
                                // Di chuyển file vào thư mục Excel
                                File.Copy(selectedFilePath, destinationFile);
                                MessageBox.Show("Import file thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else
                            {
                                MessageBox.Show($"File {System.IO.Path.GetFileName(selectedFilePath)} đã tồn tại trong thư mục Excel.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"File {System.IO.Path.GetFileName(selectedFilePath)} không phải là một tệp Excel hợp lệ.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); };
        }
        #endregion
        #endregion

        #region Text FTP Input/Output/Username/Password
        private void tblInput_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtInput.Focus();
        }
        
        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInput.Text) && txtInput.Text.Length > 0)
                tblInput.Visibility = Visibility.Collapsed;
            else
                tblInput.Visibility = Visibility.Visible;
        }
        private void tblOutput_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtOutput.Focus();
        }

        private void txtOutput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOutput.Text) && txtOutput.Text.Length > 0)
                tblOutput.Visibility = Visibility.Collapsed;
            else
                tblOutput.Visibility = Visibility.Visible;
        }

        private void tblUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtUser.Focus();
        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUser.Text) && txtUser.Text.Length > 0)
                tblUser.Visibility = Visibility.Collapsed;
            else
                tblUser.Visibility = Visibility.Visible;
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
        #endregion       

        #region Lấy thông tin FTP file *.ini
        public void LoadThongTin()
        {
            if (File.Exists(@"Config\Config.ini"))
            {
                IniParserBUS par = new IniParserBUS(@"Config\Config.ini");

                string[] a = par.GetSetting("FTPCONFIG", "FTPINPUT").Split(',');
                txtInput.Text = bBUS.Decrypt(Convert.ToString(a[0].Replace(" ", "")));

                a = par.GetSetting("FTPCONFIG", "FTPOUTPUT").Split(',');
                txtOutput.Text = bBUS.Decrypt(Convert.ToString(a[0].Replace(" ", "")));

                a = par.GetSetting("FTPCONFIG", "USER").Split(',');
                txtUser.Text = bBUS.Decrypt(Convert.ToString(a[0].Replace(" ", "")));

                a = par.GetSetting("FTPCONFIG", "PASS").Split(',');
                txtPass.Password = bBUS.Decrypt(Convert.ToString(a[0].Replace(" ", "")));
            }
        }
        #endregion

        #region Kiểm tra có phải định dạng Excel không
        private bool IsExcelFile(string filePath)
        {
            string fileExtension = System.IO.Path.GetExtension(filePath).ToLower();
            foreach (string validExtension in validExcelExtensions)
            {
                if (fileExtension == validExtension)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Đếm file excel
        public Int32 CountExcelFileInExcelExample()
        {
            try
            {
                string[] searchPatterns = new string[] { "*.xlsx", "*.xls", "*.xlsm", "*.xlsb", "*.csv" };

                string folderPath = @"Excel_Example";
                var fileList = new List<FileDetail>();

                var files = Directory.GetFiles(folderPath, "*.xlsx");
                int a = files.Count();
                return files.Count();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        #endregion

        
    }
}
