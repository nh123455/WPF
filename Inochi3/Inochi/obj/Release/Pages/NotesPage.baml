   M S B A M L   `   `   `  ���� A  =Inochi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:UIKitTutorials.PagesUIKitTutorials.Pages  $    UIKitTutorials.Pages.NotesPage   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     c _MahApps.Metro.IconPacks.Core, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   <d2http://schemas.microsoft.com/expression/blend/2008   0local"clr-namespace:UIKitTutorials.Pages     N� Title$  	NotesPage��.����  �� CornerRadius$ 5��   SecundaryBackgroundColor#���   ._��� $	��Top=�.+��� $��Setting app�����#1877F2  	titleText#��[ $��0 0 0 20q��� $��1q����#acb0af$��70 15q�$ 5��$	��450��._�� $
��7 9 q� � ColumnDefinitions �� $
��auto ��� $��3* ��� $
��301* �.+��� $��/Images/http.png��$��30���� -    ��Name$ tblInput��$��Link folder Input��  txtHint#��[ $��2��$��7,0,0,10q��� -    ��Name$ txtInput��  textBox#��[ $��2��$��7,3,0,5q� �� TextAlignment$
 Left=��� $��1q����#acb0af$��70 15q�$ 5��$	��450��._�� $
��7 9 q� �� $
��auto ��� $��3* ��� $
��301* �.+��� $��/Images/http.png��$��30���� -   $ 	tblOutput��$��Link folder Output��#��[ $��2��$��7,0,0,0q��� -   $ 	txtOutput��#��[ $��2��$��7,3,0,5q��� $��1q����#acb0af$��70 15q�$ 5��$	��450��._�� $
��7 9 q� �� $
��auto ��� $��3* ��� $
��301* �.+��� $��/Images/people.png��$��30���� -   $ tblUser��$��Username��#��[ $��2��$��7,0,0,0q��� -   $ txtUser��#��[ $��2��$��7,3,0,5q��� $��1q����#acb0af$
��70 7q�$ 5��$	��450��._�� $
��7 9 q� �� $
��auto ��� $
��109* ��� $
��195* �.+��� $��/Images/pass.png��$��30���� -   $ tblPass��$��Password��#��[ $��2��$��1��$��10,0,0,0q�G� -    G�Name$ txtPass��#��[ $��2��$��1��$��7,3,0,5q�� $	��450��$��0 15 0 0q� �� $��* ��� $��* �.+��� -	    ��Name$ btnImportExcel��$��0��$��Import Excel��  
mainButton#��[ $
��Left=��� -
   $ btnSaveSetting��$��1��$��Save setting��#��[ $��Right=�