using Inochi.BUS;
using Inochi.DTO;
using Inochi.GUI;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Table.PivotTable;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
    /// Lógica de interacción para SoundsPage.xaml
    /// </summary>
    public partial class PcPage : System.Windows.Controls.Page
    {
        private string[] validExcelExtensions = new string[] { ".xlsx", ".xls", ".xlsm", ".xlsb", ".csv" };
        string[] searchPatterns = new string[] { "*.xlsx" };
        string ftpServerOutput = "";
        string ftpUsername = "";
        string ftpPassword = "";
        // sort = 0: sort theo tên tăng dần
        // sort = 1: sort theo tên giảm dần
        // sort = 2: sort theo thời gian giảm dần
        // sort = 3: sort theo thời gian tăng dần
        int sort = 0;
        int dem = 0;
        baseBUS bBUS = new baseBUS();
        public PcPage()
        {
            InitializeComponent();
            this.Loaded += SoundsPage_Loaded;
        }

        private void SoundsPage_Loaded(object sender, RoutedEventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            sort = 0;
            LoadExcelFiles(sort);
            LoadThongTin();
        }

        #region Button

        #region *Button xóa toàn bộ file excel
        private void btnDeleteAllExcel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Bạn có chắc muốn xóa toàn bộ File Excel ở máy này?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                try
                {
                    string[] files = Directory.GetFiles(@"Excel_Local");
                    string[] filesTxt = Directory.GetFiles(@"TxtServertoExcel_Local");
                    foreach (string file in files)
                    {
                        File.Delete(file);
                    }
                    foreach (string file in filesTxt)
                    {
                        File.Delete(file);
                    }
                    LoadExcelFiles(sort);
                    dtExcelDtLocal.ItemsSource = null;
                    txtFileName.Text = string.Empty;
                    MessageBox.Show("Xóa toàn bộ tệp trong thư mục thành công.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        #endregion

        #region *Button download file từ FTP (1.Download file Txt lưu vào folder; 2.Convert sang file Excel; 3.Xóa file Txt)
        private void btnDownLoadFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string destinationFilePath = "";

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    FileName = "Lưu tất cả file trong Folder này",
                    DefaultExt = ".xlsx",
                    Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    destinationFilePath = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);
                }

                CopyAllFileFolderToFolder(@"Excel_Local", destinationFilePath);

                if (MessageBox.Show($"Download thành công, bạn muốn xóa File trên phần mềm?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    string[] files = Directory.GetFiles(@"Excel_Local");
                    foreach (string file in files)
                    {
                        File.Delete(file);
                    }
                    LoadExcelFiles(sort);
                    MessageBox.Show("Xóa File trên phần mềm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex) 
            { MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
        #endregion

        #region *Button lấy dữ liệu từ FTP
        private async void btnLayDuLieuFtp_Click(object sender, RoutedEventArgs e)
        {
            excelsDataGridLocal.ItemsSource = null;
            dtExcelDtLocal.ItemsSource = null;
            txtFileName.Text = string.Empty;

            try
            {
                // Tạo thư mục cục bộ nếu chưa tồn tại
                if (!Directory.Exists(@"TxtServertoExcel_Local"))
                {
                    Directory.CreateDirectory(@"TxtServertoExcel_Local");
                }

                // Tạo request để lấy danh sách file
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpServerOutput);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

                // Đọc danh sách file
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Tạo request để lấy thời gian sửa đổi cuối cùng của file
                        string remoteFile = ftpServerOutput + line;
                        DateTime lastModified = GetLastModifiedTime(remoteFile, ftpUsername, ftpPassword);

                        // Tạo request để download từng file
                        string localFile = System.IO.Path.Combine(@"TxtServertoExcel_Local", line);
                        FtpWebRequest downloadRequest = (FtpWebRequest)WebRequest.Create(remoteFile);
                        downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                        downloadRequest.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

                        using (FtpWebResponse downloadResponse = (FtpWebResponse)downloadRequest.GetResponse())
                        using (Stream downloadStream = downloadResponse.GetResponseStream())
                        using (FileStream localFileStream = new FileStream(localFile, FileMode.Create))
                        {
                            downloadStream.CopyTo(localFileStream);
                        }

                        // Thiết lập thời gian sửa đổi cuối cùng cho file đã tải về
                        File.SetLastWriteTime(localFile, lastModified);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            ConvertTxttoExcel();
            LoadExcelFiles(sort);
        }
        #endregion
        static DateTime GetLastModifiedTime(string ftpFilePath, string ftpUsername, string ftpPassword)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpFilePath);
            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
            request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                return response.LastModified;
            }
        }
        #region *Button download file từ FTP
        private void btnDownLoad_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button button)
            {
                var dataGridRow = FindAncestor<DataGridRow>(button);

                var fileDetails = dataGridRow.DataContext as FileDetail;
                if (fileDetails != null)
                {
                    string path = fileDetails.FilePath;
                    string fileName = fileDetails.FileName;

                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        FileName = fileName,
                        DefaultExt = ".xlsx",
                        Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
                    };

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        // Lấy đường dẫn đích do người dùng chọn
                        string destinationFilePath = saveFileDialog.FileName;

                        // Đường dẫn đầy đủ của file nguồn trong thư mục A
                        string sourceFilePath = System.IO.Path.Combine(@"Excel_Local", fileName);

                        try
                        {
                            // Kiểm tra xem file nguồn có tồn tại không
                            if (File.Exists(sourceFilePath))
                            {
                                // Di chuyển file đến đường dẫn đích và xóa file nguồn
                                File.Copy(sourceFilePath, destinationFilePath);
                                if (MessageBox.Show($"Download File thành công, bạn có muốn xóa ra khỏi danh sách", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                {
                                    File.Delete(path);
                                    LoadExcelFiles(sort);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Download file thất bại.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }

            }
        }
        #endregion

        #region *Button Load excel detail
        private void btnExcelDetails_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button button)
            {
                var dataGridRow = FindAncestor<DataGridRow>(button);

                var fileDetails = dataGridRow.DataContext as FileDetail;
                if (fileDetails != null)
                {
                    string path = fileDetails.FilePath;
                    string fileName = fileDetails.FileName;

                    txtFileName.Text = fileName;
                    System.Data.DataTable dataTable = ReadExcelFile(path);
                    dtExcelDtLocal.ItemsSource = dataTable.DefaultView;
                }
            }
        }
        #endregion

        #region *Button xóa file Excel
        private void btnDeleteExcel_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button button)
            {
                var dataGridRow = FindAncestor<DataGridRow>(button);

                var fileDetails = dataGridRow.DataContext as FileDetail;
                if (fileDetails != null)
                {
                    string path = fileDetails.FilePath;
                    string fileName = fileDetails.FileName;
                    if (MessageBox.Show($"Bạn muốn xóa File Excel: {fileName} ra khỏi danh sách", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            File.Delete(path);
                            LoadExcelFiles(sort);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }

                }

            }
        }
        #endregion

        #region *Button xóa FTP
        private void btnDeleteFTP_Click(object sender, RoutedEventArgs e)
        {
            //if (MessageBox.Show("Bạn có chắc muốn xóa toàn bộ file trên FTP", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            //{
            //    DeleteAllFilesInFolderOnFTP(ftpServerOutput, ftpUsername, ftpPassword);
            //}
            PasswordConfirm passwordConfirm = new PasswordConfirm();
            passwordConfirm.ShowDialog();
            
        }
        #endregion

        #endregion

        #region Lấy thông tin FTP
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
        #endregion

        #region Lấy thông tin toàn bộ file excel
        private void LoadExcelFiles(int sortType)
        {
            try
            {
                dem = 0;
                var fileList = new List<FileDetail>();

                foreach (var searchPattern in searchPatterns)
                {
                    var files = Directory.GetFiles(@"Excel_Local", searchPattern);
                    foreach (var file in files)
                    {
                        dem++;
                        FileInfo fileInfo = new FileInfo(file);
                        fileList.Add(new FileDetail
                        {
                            STT = dem,
                            FileName = fileInfo.Name,
                            FilePath = fileInfo.FullName,
                            FileSize = (fileInfo.Length / 1024).ToString("N0"), // Kích thước tệp tính bằng KB
                            LastModified = fileInfo.LastWriteTime.ToString("g"),
                            IsSelected = false, // Mặc định không được chọn
                            Extension = fileInfo.Extension
                        });
                    }
                }
                if (sortType == 0)
                {
                    fileList = fileList.OrderBy(f => f.FileName).ToList();
                }
                else if (sortType == 1)
                {
                    fileList = fileList.OrderByDescending(f => f.FileName).ToList();
                }
                else if (sortType == 2)
                {
                    fileList = fileList.OrderByDescending(f => DateTime.Parse(f.LastModified)).ToList();
                }
                else if (sortType == 3)
                {
                    fileList = fileList.OrderBy(f => DateTime.Parse(f.LastModified)).ToList();
                }

                //Cập nhật lại STT sau khi sort
                dem = 0;
                foreach (var file in fileList)
                {
                    file.STT = ++dem;
                }

                excelsDataGridLocal.ItemsSource = fileList;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error); }

        }
        #endregion

        #region Copy file từ phần mềm sang 1 folder người dùng chọn
        public void CopyAllFileFolderToFolder(string sourcePath, string destinationPath)
        {
            try
            {
                string[] files = Directory.GetFiles(sourcePath);

                // Copy each file to the destination directory
                foreach (string file in files)
                {
                    string fileName = System.IO.Path.GetFileName(file);
                    string destFile = System.IO.Path.Combine(destinationPath, fileName);
                    File.Copy(file, destFile, true); // true to overwrite existing files
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
        #endregion

        #region Convert Txt to Excel
        public void ConvertTxttoExcel()
        {
            var txtFiles = Directory.GetFiles(@"TxtServertoExcel_Local", "*.txt", SearchOption.AllDirectories);
            foreach (var txtFile in txtFiles)
            {
                try
                {
                    //Đọc từ file Txt sang DataTable
                    System.Data.DataTable dataTable = ReadTxtFile(txtFile);

                    //Lấy thời gian của file hiện tại
                    DateTime txtLastWriteTime = File.GetLastWriteTime(txtFile);

                    //Tạo 1 datatable mới để nhận dữ liệu đã xử lý
                    System.Data.DataTable resultData = new System.Data.DataTable();
                    resultData = GroupValue(dataTable);

                    if (resultData != null)
                    {
                        string excelFilePath = System.IO.Path.Combine(@"Excel_Local", System.IO.Path.GetFileNameWithoutExtension(txtFile) + ".xlsx");
                        WriteDataTableToExcel(resultData, excelFilePath);

                        //Set thời gian cho file Excel mới tạo
                        File.SetLastWriteTime(excelFilePath, txtLastWriteTime);

                        File.Delete(txtFile);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
        #endregion

        private System.Data.DataTable GroupValue(System.Data.DataTable dt)
        {
            try
            {
                // Sử dụng LINQ để gộp các hàng giống nhau và cộng cột số lượng
                var groupData = dt.AsEnumerable().GroupBy(row => new
                {
                    Col1 = row["Column1"],
                    Col2 = row["Column2"],
                    Col3 = row["Column3"],
                    Col4 = row["Column4"],
                    Col6 = row["Column6"],
                    Col7 = row["Column7"],
                    Col8 = row["Column8"]
                }).Select(g => new
                {
                    Col1 = g.Key.Col1,
                    Col2 = g.Key.Col2,
                    Col3 = g.Key.Col3,
                    Col4 = g.Key.Col4,
                    TotalQuantity = g.Sum(r =>
                    {
                        int quantity;
                        return int.TryParse(r.Field<string>("Column5"), out quantity) ? quantity : 0;
                    }),
                    Col6 = g.Key.Col6,
                    Col7 = g.Key.Col7,
                    Col8 = g.Key.Col8,

                });
                // Tạo DataTable mới để chứa kết quả
                System.Data.DataTable resultTable = dt.Clone();
                resultTable.Columns["Column5"].DataType = typeof(int);
                // Điền dữ liệu vào bảng kết quả
                foreach (var row in groupData)
                {
                    resultTable.Rows.Add(row.Col1, row.Col2, row.Col3, row.Col4, row.TotalQuantity, row.Col6, row.Col7, row.Col8);
                }
                return resultTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            
        }

        #region Đọc file Txt sang Table
        private System.Data.DataTable ReadTxtFile(string path)
        {
            var dataTable = new System.Data.DataTable();
            using (var reader = new StreamReader(path))
            {
                bool isFirstLine = true;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    if (isFirstLine)
                    {
                        // Thêm các cột vào DataTable với tên cột mặc định (Column1, Column2, ...)
                        for (int i = 0; i < values.Length; i++)
                        {
                            dataTable.Columns.Add($"Column{i + 1}");
                        }
                        isFirstLine = false;
                    }
                    dataTable.Rows.Add(values);                   
                }
            }                  
            return dataTable;
        }
        #endregion

        #region Chuyển dữ liệu từ Table sang file Excel
        private void WriteDataTableToExcel(System.Data.DataTable dataTable, string excelFilePath)
        {
            string linkExcelExample = "";
            var fileList = new List<FileDetail>();

            foreach (var searchPattern in searchPatterns)
            {
                var files = Directory.GetFiles(@"Excel_Example", searchPattern);
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    linkExcelExample = fileInfo.FullName;
                }
            }

            using (var package = new ExcelPackage(new FileInfo(linkExcelExample)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                // Kiểm tra số lượng cột của file txt và file Excel mẫu
                if (dataTable.Columns.Count != worksheet.Dimension.End.Column)
                {
                    MessageBox.Show("File FTP không khớp với file Excel mẫu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Bắt đầu ghi dữ liệu từ dòng thứ 2 (bỏ qua dòng tiêu đề)
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dataTable.Rows[i][j];
                    }
                }

                package.SaveAs(new FileInfo(excelFilePath));
            }
        }
        #endregion

        #region Đọc file excel
        private System.Data.DataTable ReadExcelFile(string path)
        {
            try
            {
                var dataTable = new System.Data.DataTable();
                using (var package = new ExcelPackage(new FileInfo(path)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        dataTable.Columns.Add(firstRowCell.Text);
                    }

                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                        var newRow = dataTable.NewRow();
                        foreach (var cell in row)
                        {
                            newRow[cell.Start.Column - 1] = cell.Text;
                        }
                        dataTable.Rows.Add(newRow);
                    }
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return new System.Data.DataTable();
            }
        }
        #endregion

        #region Kiếm tên Grid
        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            while (current != null)
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            return null;
        }
        #endregion       

        #region Kiểm tra xem phần mở rộng của file có nằm trong danh sách các phần mở rộng Excel hợp lệ hay không
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

        #region Đếm file Excel ở local
        public Int32 CountExcelFileInExcelExample()
        {
            try
            {
                var fileList = new List<FileDetail>();

                var files = Directory.GetFiles(@"Excel_Example", "*.xlsx"); 
                int a = files.Count();
                return files.Count();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
        }
        #endregion

        #region Xóa file FTP
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
        #endregion

        #region Tồng hợp hàm xóa FTP
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
                MessageBox.Show("Xóa file thành công","Thông báo",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        private void dtExcelDtLocal_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //if (e.Column is DataGridTextColumn textColumn)
            //{
            //    var binding = (textColumn.Binding as Binding)?.Path?.Path;

            //    var templateColumn = new DataGridTemplateColumn
            //    {
            //        Header = textColumn.Header,
            //        Width = textColumn.Width
            //    };

            //    var dataTemplate = new DataTemplate();
            //    var stackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            //    stackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);

            //    var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            //    textBlockFactory.SetBinding(TextBlock.TextProperty, new Binding(binding));
            //    textBlockFactory.SetBinding(TextBlock.ToolTipProperty, new Binding(binding));
            //    textBlockFactory.SetValue(TextBlock.TextTrimmingProperty, TextTrimming.WordEllipsis);
            //    textBlockFactory.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
            //    textBlockFactory.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Center);

            //    stackPanelFactory.AppendChild(textBlockFactory);
            //    dataTemplate.VisualTree = stackPanelFactory;

            //    templateColumn.CellTemplate = dataTemplate;
            //    e.Column = templateColumn;
            //}
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            if (sort == 0)
            {
                sort++;
            }
            else if (sort == 1)
            {
                sort++;
            }
            else if (sort == 2)
            {
                sort++;
            }
            else sort = 0;
            LoadExcelFiles(sort);
        }
    }
}
