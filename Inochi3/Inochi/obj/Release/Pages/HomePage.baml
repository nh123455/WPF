   M S B A M L   `   `   `  ���� A  =Inochi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:UIKitTutorials.PagesUIKitTutorials.Pages  #    UIKitTutorials.Pages.HomePage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     c _MahApps.Metro.IconPacks.Core, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   <d2http://schemas.microsoft.com/expression/blend/2008   0local"clr-namespace:UIKitTutorials.Pages     N� Title$  HomePage��.����  �� CornerRadius$ 5��   SecundaryBackgroundColor#���   ._��  � RowDefinitions �� $��60 ��� $��* ��� $��* �.+�� $��0�� � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� -    ��Name$ 
btnSyncFTP��$��1��  	addButton#��[ $��0 0 10 1q�$��Stretch=�.����  �� Orientation$ 
Horizontal=�.+�.  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ Update=�$��Center=�$��Center=�$��11��$��11��$��0 0 8 0q��� $��Đồng bộ FTP���� -   $ btnDeleteFileFTP��$��2��#��[ $��0 0 10 1q�.���� $ 
Horizontal=�.+�  $ DeleteEmpty=�$��Center=�$��Stretch=�$��11��$��11��$��0 0 8 0q��� $��Xóa dữ liệu FTP���� -   $ btnImportExcel��$��3��#��[ $��0 0 10 1q�.���� $ 
Horizontal=�.+�  $ 	FileExcel=�$��Center=�$��Stretch=�$��11��$��11��$��0 0 8 0q��� $��Import Excel���� -   $ btnDeleteAllExcel��$��4��#��[ $��0 0 10 1q�.���� $ 
Horizontal=�.+�  $ Delete=�$��Center=�$��Stretch=�$��11��$��11��$��0 0 8 0q��� $ ��Xóa toàn bộ file Excel���� $��1��
�������$��1q�$ 5�� �� Padding$ 5q�._��  �� $
��auto ��� $��* �.+�&   System.Windows.Controls.DataGrid  -     Name$ excelsDataGrid��  DataGridStyle1#���    DataGridCellStyle1	   	CellStyle#	 �    DataGridColumnHeaderStyle1
   ColumnHeaderStyle#
 �    DataGridRowStyle1   RowStyle# �  $��3��   
IsReadOnly .  J� 	AllowDrop .    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ #��   
IsReadOnly .    CanUserResize .     Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *STT+4  .System.Windows.Controls.DataGridTemplateColumn  -   	excelPath��$
 Name�� . $ *    CellTemplate �� .R��� $ 
Horizontal=�.+��� $��WordEllipsis=�$��Center=�$��Center=�
���   �$��0 0 0 1q����� *
FileName+  $ Date modified��$ *  �� *LastModified+  $
 Type��$ *  �� *	Extension+  $ Size(KB)��$ *  �� *
FileSize+   . $	 100  �� .R��� $ 
Horizontal=�.+��� $ btnDeleteExcel��-     gridRemoveButton#��[ .��  $ DeleteOutline=�  gridButtonIcon#��[ �� $ btnExcelDetails��-     gridEditButton#��[ .��  $ MicrosoftExcel=�#��[ �� $��2��
�������$��1q�$ 5��$ 5q�$��0 10 0 0q�._��  �� $
��auto ��� $��* �.+��� -	    ��Name$ txtFileName��$�� ��$��10(�$
��Bold"�$��0��$��Center=�$	��Top=�  -
   $ dataExcelDetails��   AutoGenerateColumns . $��2��#���  #	 �  #
 �  # �  $��0 30 0 0q�$��Center=�$��Center=� . 