   M S B A M L   `   `   `  ���� A  =Inochi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:UIKitTutorialsUIKitTutorials      UIKitTutorials.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     c _MahApps.Metro.IconPacks.Core, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   <d2http://schemas.microsoft.com/expression/blend/2008   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   *localclr-namespace:UIKitTutorials   -   $
��home��  � Title$  
MainWindow��$	��780��$
��1280�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�
������  � AllowsTransparency .  � 
ResizeMode$ NoResize=� � WindowState$ 	Maximized=� � 	Resources    boolToVisConv��%   &	        �� .���� -    �� CornerRadius$ 25�� �� Padding$ 20q����#f7f6f4._�� 	 � ColumnDefinitions	 �� $	��200 ��� $��21 ��� $
��215* ��� $
��197* ��� $
��608* �
 � RowDefinitions
 �� $��30 ��� $��* �.+��� $��4��$��Right=�$��Center=�$��30�� �� Orientation$ 
Horizontal=�$��RightToLeft=�.+��� -    ��Name$ btnClose��  IconButtonsStyle#��[  	 close#���  
 � Tag$ IsCloseButton���� -   $ 
btnRestore��$	��5,0q�����  �� 
TargetType" �� �� BasedOn# [ .���  �� Property � ��  maximize �� Value# �   �� Triggers ��  �� Binding ��  �� ElementName$
 home�� �� Path$ WindowState� �� Value 	Maximized.a���  � ��  restore# �  �� -   $ btnMinimize��#���    minimize#���  �� $��2��$ 25��$��1������ .���  � Color$ #3369E8�� � Offset$ 0Q�� $ #fb6161��$	 0.8Q�._�� 
 �� $
��Auto ��� $��* �.+��� $��0��.+��� $ 
Horizontal=�$��Center=�$��
0 30 50 10q�.+�� .+��� ���#ffffff$��35��$��35��$ 50���� $��35��$��35�����#ffffff$��3q�$ 50��$��Right=�$��0,4,0.2,4.2q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   Opacity$	 0.3Q�._��� $��30��$��30��$��/Images/delfi.png���� $��Delfi�����#ffffff$��30(�$��10 0 0 3q�   $ 10Q�$	 0.3Q��� $��1��$
��Auto=�.���� .+��� $
��Main��  	menuTitle#��[ �� -   $ btnDashboard��  menuButton2#��[ ���#f7f6f4���#fb7657.���� $ 
Horizontal=�.+�.  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Home=�  menuButtonIcon2#��[ �� $��	Dashboard�� 	 menuButtonText#��[	 �� $	��FTP��#��[ �� -   $ btn_FTPServer��#��[ .���� $ 
Horizontal=�.+�  $ Folder=�#��[ �� $��
FTP Server��#��[	 �� $��Local��#��[ �� -   $ btnLocal��#��[ .���� $ 
Horizontal=�.+�  $ DesktopClassic=�#��[ �� $��Local��$
��Wrap=�#��[	 �� $��Hệ thống��#��[ �� -	   $ btnSettings��#��[ .���� $ 
Horizontal=�.+�  $ ApplicationSettings=�#��[ �� $��Settings��#��[	 �� -
   $ btnExit��#��[ .���� $ 
Horizontal=�.+�  $ Logout=�#��[ �� $��Thoát��#��[	 �� $��2��$��1��$��3��._� � -     �Name$ PagesNavigation��  � NavigationUIVisibility$ Hidden=����#f7f6f4