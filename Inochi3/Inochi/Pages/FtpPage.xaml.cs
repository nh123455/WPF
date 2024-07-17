using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExcelDataReader;
using Inochi.BUS;
using Inochi.DTO;
using Microsoft.Office.Interop;
using Microsoft.Win32;
using OfficeOpenXml;

namespace Inochi.Pages
{
    public partial class FtpPage : Page
    {
        baseBUS bBUS = new baseBUS();

        int dem = 0;
        public string[] validExcelExtensions = new string[] { ".xlsx", ".xls", ".xlsm", ".xlsb", ".csv" };
        string[] searchPatterns = new string[] { "*.xlsx", "*.xls", "*.xlsm", "*.xlsb", "*.csv" };

        string ftpServerInput = "";
        string ftpUsername = "";
        string ftpPassword = "";
        string folderDefault = @"Excel";
        string folderTxtDefault = @"ExcelLocalToTxt";

        public FtpPage()
        {
            InitializeComponent();
            this.Loaded += HomePage_Loaded;
        }

        private void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            excelsDataGrid.Drop += ExcelsDataGrid_Drop;
            
            LoadExcelFiles();
            LoadThongTin();
            //LoadFtpDirectories();
        }


        #region Button

        #region *Button Xóa từng file Excel
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
                    if (MessageBox.Show($"Bạn có chắc muốn xóa File Excel: {fileName} ra khỏi danh sách", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            File.Delete(path);
                            LoadExcelFiles();
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

        #region *Button load Excel Detail để xem detail file
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
                    DataTable dataTable = ReadExcelFile(path);
                    dataExcelDetails.ItemsSource = dataTable.DefaultView;
                }
            }
        }
        #endregion

        #region *Button Đồng bộ FTP có các chức năng (1.Chuyển file từ Excel to Txt; 2.Đầy file lên folder FTP)
        private void btnSyncFTP_Click(object sender, RoutedEventArgs e)
        {
            var excelFiles = Directory.GetFiles(@"Excel", "*.*", SearchOption.AllDirectories)
                                      .Where(s => s.EndsWith(".xls") || s.EndsWith(".xlsx") || s.EndsWith(".xlsm") || s.EndsWith(".xlsb") || s.EndsWith(".csv"));
            if(excelFiles.Count() == 0)
            {
                MessageBox.Show("Không có dữ liệu đồng bộ", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }    
            foreach (var excelFile in excelFiles)
            {
                try
                {
                    DataTable dataTable = ReadExcelFileConvert(excelFile);
                    if (dataTable != null)
                    {
                        string txtFilePath = System.IO.Path.Combine(@"ExcelLocalToTxt", System.IO.Path.GetFileNameWithoutExtension(excelFile) + ".txt");
                        WriteDataTableToTxt(dataTable, txtFilePath);
                        File.Delete(excelFile);
                        LoadExcelFiles();

                        dataExcelDetails.ItemsSource = null;
                        txtFileName.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            PushToFTP(ftpServerInput, ftpUsername, ftpPassword, @"ExcelLocalToTxt");
            MessageBox.Show("Đồng bộ thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        #endregion

        #region *Button xóa toàn bộ file excel có trong folder FTP
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
                //    //string[] tokens = line.Split(' ');
                //    //string fileName = tokens[tokens.Length - 1].Trim(); // Lấy tên tệp từ dòng thông tin chi tiết
                //    //if (fileName != "." && fileName != "..") // Bỏ qua các thư mục cha và hiện tại
                //    //{
                //    //    DeleteFileOnFTP(folderUri + Uri.EscapeUriString(fileName), ftpUsername, ftpPassword);
                //    //}
                //    //line = reader.ReadLine();

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
        public void LoadFtpDirectories()
        {
            string ftpAddress = "ftp://customize@srwin253.delfi.vn/Inochi_Input/";
            string username = "customize";
            string password = "delfi@chekin";

            List<string> directories = GetFtpFileList(ftpAddress, username, password);

            foreach (string dir in directories)
            {
                // Hiển thị danh sách thư mục trong ListBox (hoặc control khác)
                MessageBox.Show(dir);
            }
        }


        public List<string> GetFtpFileList(string ftpAddress, string username, string password)
        {
            List<string> files = new List<string>();

            try
            {
                // Tạo yêu cầu FTP
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpAddress);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                request.Credentials = new NetworkCredential(username, password);

                // Nhận phản hồi từ server
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Kiểm tra và chỉ thêm các tệp (không phải thư mục)
                        if (!line.StartsWith("d")) // Ký tự đầu tiên không phải là 'd' cho thư mục
                        {
                            string[] details = line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
                            if (details.Length >= 9)
                            {
                                files.Add(details[8]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return files;
        }


        #endregion

        #region *Button xóa file folder FTP
        private void btnDeleteFileFTP_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc muốn xóa toàn bộ file trên FTP", "Thông báo", MessageBoxButton.YesNo,MessageBoxImage.Information)== MessageBoxResult.Yes)
            {
                DeleteAllFilesInFolderOnFTP(ftpServerInput, ftpUsername, ftpPassword);
            }    
            
        }
        #endregion

        #region *Button xóa toàn bộ file Excel trên máy tính
        private void btnDeleteAllExcel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Bạn có chắc muốn xóa toàn bộ File Excel ở máy này?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                try
                {
                    string[] files = Directory.GetFiles(@"Excel");
                    string[] filesTxt = Directory.GetFiles(@"ExcelLocalToTxt");
                    foreach (string file in files)
                    {
                        File.Delete(file);
                    }
                    foreach (string file in filesTxt)
                    {
                        File.Delete(file);
                    }
                    LoadExcelFiles();
                    dataExcelDetails.ItemsSource = null;
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
                        // Kiểm tra xem file có phải là một tệp Excel hợp lệ không
                        if (IsExcelFile(selectedFilePath))
                        {
                            // Kiểm tra xem file đã tồn tại trong thư mục Excel hay chưa
                            string destinationFile = System.IO.Path.Combine(@"Excel", System.IO.Path.GetFileName(selectedFilePath));
                            if (!File.Exists(destinationFile))
                            {
                                // Di chuyển file vào thư mục Excel
                                File.Copy(selectedFilePath, destinationFile);
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
                    LoadExcelFiles();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error); };

        }
        #endregion

        #endregion

        #region Load thông tin FTP
        public void LoadThongTin()
        {
            try
            {
                if (File.Exists(@"Config\Config.ini"))
                {
                    IniParserBUS par = new IniParserBUS(@"Config\Config.ini");

                    string[] a = par.GetSetting("FTPCONFIG", "FTPINPUT").Split(',');
                    ftpServerInput = bBUS.Decrypt(Convert.ToString(a[0].Replace(" ", "")));

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

        #region Sự kiện kéo thả file vào Grid
        private void ExcelsDataGrid_Drop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);

                    foreach (string file in droppedFiles)
                    {
                        // Kiểm tra xem file có phải là một file Excel hợp lệ không
                        if (IsExcelFile(file))
                        {
                            // Kiểm tra xem file đã tồn tại trong thư mục Excel hay chưa
                            string destinationFile = System.IO.Path.Combine(@"Excel", System.IO.Path.GetFileName(file));
                            if (!File.Exists(destinationFile))
                            {
                                // Di chuyển file vào thư mục Excel
                                File.Copy(file, destinationFile);
                            }
                            else
                            {
                                MessageBox.Show($"File {System.IO.Path.GetFileName(file)} đã tồn tại.","Thông Báo",MessageBoxButton.OK,MessageBoxImage.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"File {System.IO.Path.GetFileName(file)} không phải là một tệp Excel hợp lệ.","Thông Báo",MessageBoxButton.OK,MessageBoxImage.Warning);
                        }
                    }

                    // Reload danh sách file Excel sau khi di chuyển
                    LoadExcelFiles();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Thông báo",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            
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

        #region Load Excel vào Grid bằng đường dẫn
        public void LoadExcelWithPath(string path)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(path, 0, true, 5, "", "", true,
                    Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                Microsoft.Office.Interop.Excel.Worksheet excelSheet =(Microsoft.Office.Interop.Excel.Worksheet) excelBook.Worksheets.get_Item(1);

                Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;

                string strCellData = "";
                double douCellData;
                int rowCnt = 0;
                int colCnt = 0;

                DataTable dt = new DataTable();
                for(colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++) 
                {
                    string strColumn = "";
                    strColumn = (string)(excelRange.Cells[1, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                    dt.Columns.Add(strColumn, typeof(string));
                }
                for(rowCnt = 2; rowCnt <= excelRange.Rows.Count; rowCnt++)
                {
                    string strData = "";
                    for(colCnt = 1; colCnt<=excelRange.Columns.Count;colCnt++)
                    {
                        try
                        {
                            strCellData = (string)(excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                            strData += strCellData + "|";
                    }
                        catch (Exception)
                        {
                            douCellData = (excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                            strData += douCellData.ToString() + "|";
                        }
                    }
                    strData = strData.Remove(strData.Length - 1, 1);
                    dt.Rows.Add(strData.Split('|'));                   
                }
                dataExcelDetails.ItemsSource = dt.DefaultView;
                excelBook.Close(true, null, null);
                excelApp.Quit();


            }
            catch
            (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region Load toàn bộ File Excel không có điều kiện lọc
        private void LoadExcelFiles()
        {
            try
            {
                dem = 0;              
                var fileList = new List<FileDetail>();
                foreach (var searchPattern in searchPatterns)
                {
                    var files = Directory.GetFiles(@"Excel", searchPattern);
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

                excelsDataGrid.ItemsSource = fileList;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error); }
            
        }
        #endregion

        #region Đọc file Excel
        private DataTable ReadExcelFile(string path)
        {
            try
            {
                var dataTable = new DataTable();
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return new DataTable();
            }         
        }
        #endregion

        #region Tìm tên file excel 
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

        #region Đọc file Excel
        private DataTable ReadExcelFileConvert(string path)
        {
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader = null;

                if (path.EndsWith(".xls") || path.EndsWith(".xlsx") || path.EndsWith(".xlsm") || path.EndsWith(".xlsb"))
                {
                    reader = ExcelReaderFactory.CreateReader(stream);
                }
                else if (path.EndsWith(".csv"))
                {
                    using (var csvReader = new StreamReader(stream))
                    {
                        var dataTable = new DataTable();
                        bool isHeader = true;
                        while (!csvReader.EndOfStream)
                        {
                            var fields = csvReader.ReadLine().Split(',');
                            if (isHeader)
                            {
                                foreach (var field in fields)
                                {
                                    dataTable.Columns.Add(field);
                                }
                                isHeader = false;
                            }
                            else
                            {
                                dataTable.Rows.Add(fields);
                            }
                        }
                        return dataTable;
                    }
                }

                if (reader != null)
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                    });
                    return result.Tables[0];
                }

                return null;
            }
        }
        #endregion

        #region Viết dữ liệu từ Table sang file txt
        private void WriteDataTableToTxt(DataTable dataTable, string txtFilePath)
        {
            using (var writer = new StreamWriter(txtFilePath, false, Encoding.UTF8))
            {
                //// Ghi tiêu đề
                //for (int i = 0; i < dataTable.Columns.Count; i++)
                //{
                //    writer.Write(dataTable.Columns[i].ColumnName);
                //    if (i < dataTable.Columns.Count - 1)
                //    {
                //        writer.Write(";");
                //    }
                //}
                //writer.WriteLine();

                // Ghi các dòng dữ liệu
                foreach (DataRow row in dataTable.Rows)
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        string a = row[i].ToString();
                        writer.Write(row[i].ToString());
                        if (i < dataTable.Columns.Count - 1)
                        {
                            writer.Write(";");
                        }
                    }
                    writer.WriteLine();
                }
            }
        }
        #endregion

        #region Đẩy dữ liệu lên FTP
        static void PushToFTP(string ftpServer, string ftpUsername, string ftpPassword, string localFolderPath)
        {
            try
            {
                // Lấy danh sách tên các file trong thư mục cục bộ
                string[] files = Directory.GetFiles(localFolderPath);

                // Thực hiện kết nối FTP
                foreach (string file in files)
                {
                    using (WebClient client = new WebClient())
                    {
                        client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                        client.UploadFile(ftpServer + new FileInfo(file).Name, "STOR", file);
                        File.Delete(file);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        #endregion

        #region Hàm xử lý xóa file FTP
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


    }
}
