using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Inochi.DTO
{
    public class FileDetail
    {
        public Int32 STT { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileSize { get; set; }
        public string LastModified { get; set; }
        public bool IsSelected { get; set; }
        public Brush BgColor { get; set; }
        public string Extension { get; set; }
    }
}
