﻿#pragma checksum "..\..\..\Pages\FtpPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D6888989D2A17501587328C153AB4C7BA95A41DE4EEB9F2DD98D8E7A7D8585B1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Inochi.Pages;
using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Inochi.Pages {
    
    
    /// <summary>
    /// FtpPage
    /// </summary>
    public partial class FtpPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 27 "..\..\..\Pages\FtpPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSyncFTP;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Pages\FtpPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteFileFTP;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Pages\FtpPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnImportExcel;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Pages\FtpPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteAllExcel;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Pages\FtpPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid excelsDataGrid;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Pages\FtpPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn excelPath;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\Pages\FtpPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtFileName;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\Pages\FtpPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataExcelDetails;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Inochi;component/pages/ftppage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\FtpPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnSyncFTP = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Pages\FtpPage.xaml"
            this.btnSyncFTP.Click += new System.Windows.RoutedEventHandler(this.btnSyncFTP_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnDeleteFileFTP = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\Pages\FtpPage.xaml"
            this.btnDeleteFileFTP.Click += new System.Windows.RoutedEventHandler(this.btnDeleteFileFTP_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnImportExcel = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\Pages\FtpPage.xaml"
            this.btnImportExcel.Click += new System.Windows.RoutedEventHandler(this.btnImportExcel_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnDeleteAllExcel = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\Pages\FtpPage.xaml"
            this.btnDeleteAllExcel.Click += new System.Windows.RoutedEventHandler(this.btnDeleteAllExcel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.excelsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.excelPath = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 9:
            this.txtFileName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.dataExcelDetails = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 7:
            
            #line 113 "..\..\..\Pages\FtpPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnDeleteExcel_Click);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 116 "..\..\..\Pages\FtpPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnExcelDetails_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

