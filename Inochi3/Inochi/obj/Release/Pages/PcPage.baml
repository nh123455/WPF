   M S B A M L   `   `   `  ���� A  =Inochi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Inochi.PagesInochi.Pages      Inochi.Pages.PcPage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     c _MahApps.Metro.IconPacks.Core, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   <d2http://schemas.microsoft.com/expression/blend/2008   (localclr-namespace:Inochi.Pages     N� Title$  PcPage�� � 	Resources    SortableButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value   SortableColumnHeaderTemplate	 �� Orientation
 ��Name��%�  &	        &	 4    7   �� " ��.���  � �� �#F7F6F4��  � ��
 �������  � ��$ 0q���  � ��
 �   ���  � ��$ 2q���  � �� �� " ��.R��� #��z��#��z��#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ���  � ��
 �������  � ��
 ������� .R��� $	 
Horizontal=�.+��� $�� ��$��Center=�$��0,0,5,0q��� $
 btnSort��-   $��⇅ Sort��$��60��$��30��8��  .����  �� CornerRadius$ 5�����#f7f6f4._��  � RowDefinitions �� $��60 ��� $��* ��� $��* �.+�� $��0�� � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� -   $
 btnLayDuLieuFtp��$��1��  	addButton#��[ $��0 0 10 1q�.���� $	 
Horizontal=�.+�.  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ Download=�$��Center=�$��Stretch=�$��11��$��11��$��0 0 8 0q��� -    ��Name$ nameButtonLayDuLieuFtp��$ ��Lấy dữ liệu từ FTP���� -   $
 btnDeleteFTP��$��2��#��[ $��0 0 10 1q�.���� $	 
Horizontal=�.+�  $ Delete=�$��Center=�$��Stretch=�$��11��$��11��$��0 0 8 0q��� $��Xóa dữ liệu FTP���� -   $
 btnDownLoadFile��$��3��#��[ $��0 0 10 1q�.���� $	 
Horizontal=�.+�  $ DownloadBox=�$��Center=�$��Stretch=�$��11��$��11��$��0 0 8 0q��� $��Tải về máy���� -   $
 btnDeleteAllExcel��$��4��#��[ $��0 0 10 1q�.���� $	 
Horizontal=�.+�  $ Delete=�$��Center=�$��Stretch=�$��11��$��11��$��0 0 8 0q��� $ ��Xóa toàn bộ file Excel���� $��1��
�������$��1q�$ 10�� �� Padding$ 5 5 5 5q�$��	10 0 10 0q�._��  �� $
��auto ��� $��* �.+�&   System.Windows.Controls.DataGrid  -     Name$ excelsDataGridLocal��  DataGridStyle1#���    DataGridCellStyle1   	CellStyle# �    DataGridColumnHeaderStyle1   ColumnHeaderStyle# �    DataGridRowStyle1   RowStyle# �  $��3��   
IsReadOnly .  J� 	AllowDrop .    Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ #��   
IsReadOnly .    CanUserResize .     Width5  /System.Windows.Controls.DataGridLengthConverter$ 60    CellTemplate �� .R��� ���� *STT+ � ToolTip �� *STT+  -   	excelPath��$
 Name�� . $ *  �� .R��� $	 
Horizontal=�.+��� $��WordEllipsis=�$��Center=�$��Center=�$��0 0 0 1q����� *
FileName+ �� *
FileName+  $ Date modified��$	 160  �� .R��� ���� *LastModified+ �� *LastModified+  $
 Type��$ 90  �� .R��� ���� *	Extension+ �� *	Extension+  $ Size(KB)��$	 100  �� .R��� ���� *
FileSize+ �� *
FileSize+   . $	 127    HeaderTemplate# [  �� .R��� $	 
Horizontal=�.+��� $
 btnDownLoad��-	     gridRemoveDownLoad#��[ .��  $ Download=�  gridButtonIcon#��[ �� $
 btnExcelDetails��-
    	 gridEditButton2#��[	 .��  $ MicrosoftExcel=�#��[ �� $
 btnDeleteExcel��-    
 gridRemoveButton#��[
 .��  $ DeleteOutline=�#��[ �� $��2��
�������$��1q�$ 10��$ 5 5 5 5q�$��
10 10 10 0q�._��  �� $
��auto ��� $��* �.+��� -   $ txtFileName��$�� ��$��10(�$
��Bold"�$��0��$��Center=�$	��Top=�  -   $ dtExcelDtLocal��   AutoGenerateColumns . $��2��#���  # �  # �  # �  $��0 30 0 0q�$��Stretch=�$��Stretch=� . � -     �Name$  progressBar��! � Minimum$! 0Q�" � Maximum$	" 100Q�# � Value$# 20Q�$ � IsIndeterminate$ . $y�	Collapsed=�$��Center=�$��Center=�$	��200��$��30��