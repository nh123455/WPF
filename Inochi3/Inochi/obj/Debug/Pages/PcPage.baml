   M S B A M L   `   `   `  ����A  =Inochi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Inochi.PagesInochi.Pages  5          Inochi.Pages.PcPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      c _MahApps.Metro.IconPacks.Core, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5      <d2http://schemas.microsoft.com/expression/blend/2008   5      (localclr-namespace:Inochi.Pages   5        N� Title$  PcPage��5
       � 	Resources 5         SortableButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value   SortableColumnHeaderTemplate	 �� Orientation
 ��Name��%<  &	        &	 .    7   �� 5   
   " ��6,   .�5      ��  � �� �#F7F6F46+   �� 5       � ��
 �����6,   �� 5       � ��$ 0q�60   �� 5       � ��
 �   �6+   �� 5       � ��$ 2q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��6K   #��z��6w   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5       �@J�IsMouseOver . . �5      ��  � ��
 �����63   �� 5       � ��
 �����63   5      5!      �� 5$   
   .R�5%      �� $	 
Horizontal=�6   .+�5&      �� $�� ��6   $��Center=�6$   $��0,0,5,0q�6?   �� 5'      $
 btnSort��6o   -   5        $��⇅ Sort��5'      $��60��6+   $��30��66   8��  6�   5(      5)      5*      .��5+      ��  �� CornerRadius$ 5��6   ���#f7f6f4._�5,   
   �  � RowDefinitions 5-      �� 5.      $��60 �6    �� 5/      $��* �6    �� 50      $��* �6    .+�52      � $��0��6    � ColumnDefinitions 53      �� 54      $��* �6'   �� 55      $��* �6'   �� 56      $��* �6'   �� 57      $��* �6'   �� 58      $��* �6'   .+�5:      �� -   5        $
 btnLayDuLieuFtp��5:      $��1��6P     	addButton#��[ 6`   $��0 0 10 1q�6�   .��5;      �� $	 
Horizontal=�6!   .+�5<      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ Download=�60   $��Center=�6@   $��Stretch=�6[   $��11��6y   $��11��6�   $��0 0 8 0q�6�   �� 5=      -   5         ��Name$ nameButtonLayDuLieuFtp��5=   $   $ ��Lấy dữ liệu từ FTP��6D   5>      5?      �� 5@      -   5        $
 btnDeleteFTP��5@      $��2��6J   #��[ 6Z   $��0 0 10 1q�6}   .��5A      �� $	 
Horizontal=�6!   .+�5B        $ Delete=�60   $��Center=�6>   $��Stretch=�6Y   $��11��6w   $��11��6�   $��0 0 8 0q�6�   �� 5C      $��Xóa dữ liệu FTP��6$   5D      5E      �� 5F      -   5        $
 btnDownLoadFile��5F      $��3��6P   #��[ 6`   $��0 0 10 1q�6�   .��5G      �� $	 
Horizontal=�6!   .+�5H        $ DownloadBox=�60   $��Center=�6C   $��Stretch=�6^   $��11��6|   $��11��6�   $��0 0 8 0q�6�   �� 5I      $��Tải về máy��6$   5J      5K      �� 5R      -   5        $
 btnDeleteAllExcel��5R      $��4��6T   #��[ 6d   $��0 0 10 1q�6�   .��5S      �� $	 
Horizontal=�6!   .+�5T        $ Delete=�60   $��Center=�6>   $��Stretch=�6Y   $��11��6w   $��11��6�   $��0 0 8 0q�6�   �� 5U      $ ��Xóa toàn bộ file Excel��6$   5V      5W      5X      �� 5Y      $��1��6   
�������$��1q�6:   $ 10��6N    �� Padding$ 5 5 5 5q�6`   $��	10 0 10 0q�6r   ._�5Z      �  5[      �� 5\      $
��auto �6(   �� 5]      $��* �6(   .+�5`      &   System.Windows.Controls.DataGrid  -   5          Name$ excelsDataGridLocal��5d   ,     DataGridStyle1#���  5`        DataGridCellStyle1   	CellStyle# �  5a        DataGridColumnHeaderStyle1   ColumnHeaderStyle# �  5b        DataGridRowStyle1   RowStyle# �  5c      $��3��5d         
IsReadOnly .  J� 	AllowDrop .    Columns 5g      4  .System.Windows.Controls.DataGridTemplateColumn  5h      ,  &System.Windows.Controls.DataGridColumn   Header$ #��65      
IsReadOnly .    CanUserResize .     Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6h      CellTemplate 5i   "   �� 5j   &   .R�5k   *   �� ��64   �� *STT+ � ToolTip 6I   �� *STT+5l   '   5n        5p      -   5        	excelPath��$
 Name��5p   H    . $ * 6h    5q   "   �� 5r   &   .R�5s   *   �� $	 
Horizontal=�65   .+�5t   .   �� $��WordEllipsis=�6R   $��Center=�6n   $��Center=�5u   8   $��0 0 0 1q�6U   ��5t   8   �� *
FileName+ 5u   f   �� *
FileName+5v   +   5w   '   5y        5{      $ Date modified��65   $	 160 6L    5|   "   �� 5}   &   .R�5~   *   �� ��64   �� *LastModified+ 6R   �� *LastModified+5   '   5�        5�      $
 Type��65   $ 90 6C    5�   "   �� 5�   &   .R�5�   *   �� ��64   �� *	Extension+ 6O   �� *	Extension+5�   '   5�        5�      $ Size(KB)��65   $	 100 6G    5�   "   �� 5�   &   .R�5�   *   �� ��64   �� *
FileSize+ 6N   �� *
FileSize+5�   '   5�        5�       . $	 127 6G      HeaderTemplate# [ 6S    5�   "   �� 5�   &   .R�5�   *   �� $	 
Horizontal=�65   .+�5�   .   �� $
 btnDownLoad��65   -	   5          gridRemoveDownLoad#��[ 5�   J   .��5�   2     $ Download=�6H     gridButtonIcon#��[ 6X   5�   /   �� 5�   .   $
 btnExcelDetails��65   -
   5         	 gridEditButton2#��[	 5�   N   .��5�   2     $ MicrosoftExcel=�6H   #��[ 6^   5�   /   �� 5�   .   $
 btnDeleteExcel��65   -   5         
 gridRemoveButton#��[
 5�   M   .��5�   2     $ DeleteOutline=�6H   #��[ 6]   5�   /   5�   +   5�   '   5�      5�      5�      5�      �� 5�      $��2��6   
�������$��1q�6:   $ 10��6N   $ 5 5 5 5q�6`   $��
10 10 10 0q�6r   ._�5�      �  5�      �� 5�      $
��auto �6(   �� 5�      $��* �6(   .+�5�      �� -   5        $ txtFileName��5�       $�� ��65   $��10(�5�   !   $
��Bold"�5�   !   $��0��5�   !   $��Center=�6.   $	��Top=�6K     5�      -   5        $ dtExcelDtLocal��5�         AutoGenerateColumns . $��2��6R   #���  5�   '   # �  5�   '   # �  5�   '   # �  5�   '   $��0 30 0 0q�5�   '   $��Stretch=�5�   '   $��Stretch=�5�   '    . 5�      � 5�      -   5          �Name$  progressBar��5�   "   ! � Minimum$! 0Q�67   " � Maximum$	" 100Q�6C   # � Value$# 20Q�6Q   $ � IsIndeterminate$ . $y�	Collapsed=�6s   $��Center=�5�   "   $��Center=�6?   $	��200��5�   *   $��30��66   5�      5�      5�      5�      5�      