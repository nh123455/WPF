   M S B A M L   `   `   `  ����A  =Inochi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:UIKitTutorialsUIKitTutorials  5   	       UIKitTutorials.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _MahApps.Metro.IconPacks.Core, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   <d2http://schemas.microsoft.com/expression/blend/2008   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   *localclr-namespace:UIKitTutorials   5   	   -   5        $
��home��5        � Title$  
MainWindow��5	   	   $	��780��6   $
��1280��6)    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�6.   
������  � AllowsTransparency .  � 
ResizeMode$ NoResize=�5   	    � WindowState$ 	Maximized=�6    � 	Resources 5         boolToVisConv��%   &	        �� 5   
   6'   5      .��5�      �� -   5         �� CornerRadius$ 25��5�       �� Padding$ 20q�6   ���#f7f6f4._�5�   
   � 	 � ColumnDefinitions	 5�      �� 5�      $	��200 �6#   �� 5�      $��21 �6#   �� 5�      $
��215* �6#   �� 5�      $
��197* �6#   �� 5�      $
��608* �6#   
 � RowDefinitions
 5�      �� 5�      $��30 �6    �� 5�      $��* �6    .+�5�      �� $��4��6   $��Right=�6)   $��Center=�6E   $��30��6`    �� Orientation$ 
Horizontal=�6l   $��RightToLeft=�6�   .+�5�      �� -   5         ��Name$ btnClose��5�        IconButtonsStyle#��[ 6+    	 close#���  6U   
 � Tag$ IsCloseButton��6�   �� 5�      -   5        $ 
btnRestore��5�      $	��5,0q�6-   ��5�      �� 5�       �� 
TargetType" ��6     �� BasedOn# [ 6=   .�5�      ��  �� Property � ��  maximize �� Value# �  68    �� Triggers 5�      �� 5�   "    �� Binding 6.   ��  �� ElementName$
 home�� �� Path$ WindowState� �� Value 	Maximized6e   .a�5�   &   ��  � ��  restore# �  6@   5�   #   5�      5�      �� 5�      -   5        $ btnMinimize��5�      #���  6.     minimize#���  6Y   6~   5�      �� 5�      $��2��6   $ 25��6&   $��1��68   ��5�      �� 5�      .��5�      �  � Color$ #3369E8��6'    � Offset$ 0Q�67   � 5�      $ #fb6161��6'   $	 0.8Q�67   5�      ._�5�      � 
 5�      �� 5�      $
��Auto �6(   �� 5�      $��* �6(   .+�5�      �� $��0��6!   .+�5�      �� $ 
Horizontal=�6%   $��Center=�6>   $��
0 30 50 10q�6[   .+�5�      � .+�5�   "   �� ���#ffffff$��35��6>   $��35��6I   $ 50��6U   �� 5�   "   $��35��6)   $��35��64   ���#ffffff$��3q�6V   $ 50��6j   $��Right=�6|   $��0,4,0.2,4.2q�6�    J� Effect 5�   &   3  -System.Windows.Media.Effects.DropShadowEffect  5�   *      
BlurRadius$ 10Q�6;      Opacity$	 0.3Q�6K   ._�5�   &   �� $��30��6,   $��30��67   $��/Images/delfi.png��6C   5�   #   5�      �� 5�      $��Delfi��6(   ���#ffffff$��30(�6J   $��10 0 0 3q�6X    5�   "     5�   &   $ 10Q�67   $	 0.3Q�6G   5�      5�      5�      �� 5�      $��1��6#   $
��Auto=�60   .��5�      �� .+�5�      �� $
��Main��6(     	menuTitle#��[ 64   �� 5�      -   5        $ btnDashboard��5�   t     menuButton2#��[ 6%   ���#f7f6f4���#fb7657.��5�   "   �� $ 
Horizontal=�6-   .+�5�   &   .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Home=�6<     menuButtonIcon2#��[ 6H   �� 5�   &   $��	Dashboard��60    	 menuButtonText#��[	 6A   5�   #   5�      �� 5�      $	��FTP��6(   #��[ 63   �� 5�      -   5        $ btn_FTPServer��5�   J   #��[ 6%   .��5�   "   �� $ 
Horizontal=�6-   .+�5�   &     $ Folder=�6<   #��[ 6J   �� 5�   &   $��
FTP Server��60   #��[	 6B   5�   #   5�      �� 5�      $��Local��6(   #��[ 65   �� 5�      -   5        $ btnLocal��5�   J   #��[ 6%   .��5�   "   �� $ 
Horizontal=�6-   .+�5�   &     $ DesktopClassic=�6<   #��[ 6R   �� 5�   &   $��Local��60   $
��Wrap=�6=   #��[	 6R   5�   #   5�      �� 5�      $��Hệ thống��6(   #��[ 68   �� 5�      -	   5        $ btnSettings��5�   J   #��[ 6%   .��5�   "   �� $ 
Horizontal=�6-   .+�5�   &     $ ApplicationSettings=�6<   #��[ 6W   �� 5�   &   $��Settings��60   #��[	 6@   5�   #   5�      �� 5�      -
   5        $ btnExit��5�   J   #��[ 6%   .��5�   "   �� $ 
Horizontal=�6-   .+�5�   &     $ Logout=�6<   #��[ 6J   �� 5�   &   $��Thoát��60   #��[	 6=   5�   #   5�      5�      5�      5�      5�      �� 5�      $��2��6   $��1��6%   $��3��62   ._�5�       � -   5          �Name$ PagesNavigation��5�        � NavigationUIVisibility$ Hidden=�61   ���#f7f6f45�      5      5     5     5     