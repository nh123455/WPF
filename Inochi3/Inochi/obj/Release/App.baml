   M S B A M L   `   `   `  ���� b  ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes  
 Inochi   
Inochi.App   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     c _MahApps.Metro.IconPacks.Core, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=5.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a:Icon-http://metro.mahapps.com/winfx/xaml/iconpacks   YthemeKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2     �� 	Resources   �� MergedDictionaries �� Source   ColumnHeaderGripperStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Padding   OptionMark.Static.Background �� Color  OptionMark.Static.Border  OptionMark.Static.Glyph # OptionMark.MouseOver.Background  OptionMark.MouseOver.Border  OptionMark.MouseOver.Glyph ! OptionMark.Pressed.Background  OptionMark.Pressed.Border 	 OptionMark.Pressed.Glyph "
 OptionMark.Disabled.Background  OptionMark.Disabled.Border  OptionMark.Disabled.Glyph  CheckBoxStyle1	 �Name
 J� SnapsToDevicePixels � ColumnDefinitions ��Name �� CornerRadius F�Name J� Opacity �� Stretch ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName �� 
ResourceId �� TypeInTargetAssembly&   System.Windows.Controls.DataGrid �Name � Points  DataGridStyle15  /System.Windows.Controls.DataGridLengthConverter ��Name � RowDefinitions   SelectAllCommand7  1System.Windows.Controls.DataGridHeadersVisibility
   All �� ConverterParameter!    HeadersVisibilityConverter! �� 	Converter" �� RelativeSource# �� AncestorTypeG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter$  Name%   Column& ��Name' �� CanContentScroll( ��Name) �� ScrollableHeight* � Maximum+ �� Orientation, �� ViewportHeight- �� ViewportSize*. �� #ComputedVerticalScrollBarVisibility/ � Value0 �� Mode1 �� Mode2 �� ScrollableWidth3 �� ViewportWidth,4 �� %ComputedHorizontalScrollBarVisibility5 �� Triggers6 ]� 
Conditions7 �� Property8 �� Value  DataGridCellStyle1*  $System.Windows.Controls.DataGridCell  DataGridColumnHeaderStyle1=  7System.Windows.Controls.Primitives.DataGridColumnHeader3   -Microsoft.Windows.Themes.DataGridHeaderBorder9   	IsPressed: J� IsMouseOver;   	IsHovered<   CanUserSort=   IsClickable>   SortDirection?   SortDirection@   SeparatorVisibilityA   SeparatorVisibilityB   SeparatorBrushC   SeparatorBrushD n�Name  DataGridRowStyle1)  #System.Windows.Controls.DataGridRow?	  9System.Windows.Controls.Primitives.SelectiveScrollingGrid?
  9System.Windows.Controls.Primitives.DataGridCellsPresenterE   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenterF   DetailsVisibility$G 	  SelectiveScrollingOrientation;  5System.Windows.Controls.SelectiveScrollingOrientationH   Vertical#I   RowDetailsScrollingConverter:  4System.Windows.Controls.Primitives.DataGridRowHeader
J   Row  gridEditButton  gridEditButton2  gridRemoveButtonK �� BasedOn  gridButtonIcon.  (MahApps.Metro.IconPacks.PackIconMaterial  gridRemoveDownLoad  	addButton  txtHint  textBox  
mainButton  	titleText  	menuTitle  menuButton2  menuButtonIcon2  menuButtonText   whiteBorder ! 
titleText2 " secondaryText # searchTextBox��  �� $ Themes/LightTheme.xaml?��� $ Assets/Icons/Icons.xaml?��� $ Styles/MainStyle.xaml?�%�'  &	        &	 �     &	 �     &	 �     &	 �     &	 �     &	 �     &	 
    &	     &		 4    &	
 I    &	 ^    &	 s    &	 �    7  7  7  7  7  7  7 
 7  7  7  7  7 	 7 	 (�� �    $" DataGridSelectAllButtonStyle��"  )&	 /	    &	 U    &	     7   7   &	 �    &	     &	 [    &	 �    7  &	 �    &	     7  &	     &	 w    &	     &	 �    &	 �    &	 &     &	 �     &	 �!    &	 �"    &	  #    &	! u#    &	" �#    &	# "$    �� " n�.���  � ��$ 8����  � ��
 ���� ��  �@�Cursor$ SizeWE����  � �� �� " n�.R��� #��z��# z���� $ 	#FFFFFFFF���� $ 	#FF707070���� $ 	#FF212121���� $ 	#FFF3F9FF���� $ 	#FF5593FF���� $ 	#FF212121���� $ 	#FFD9ECFF���� $ 	#FF3C77DD���� $ 	#FF212121���� $ 	#FFE6E6E6���� $ 	#FFBCBCBC���� $ 	#FF707070���� " ��.���  �@�FocusVisualStyle Z� ��  � ��8   ��  � �� �#dae2ea��  � ��# � ����  � ��$ 1q���  � �� �� " ��.R�� $	 templateRoot��
������ 
 .  �� $
��Auto ��� $��* �.+��� $ checkBoxBorder��$ 3��$ 1q�#��z��#��z��#��z��#��z��$��1q�#��z��._�� $	 markGrid��.+�F� $ 
optionMark��Y�����4� �� Ѽ�G dԊ Ѩ�D dԊ �    ^>O ��z r�5 ��@ ��\ 
ܺ��� @�j�  �>��4� �� 8�� $��1q�$ 0Q�$
 None=��� $ indeterminateMark��8�� $��2q�$ 0Q��� $ contentPresenter��$��1��|�.  #��z��#��z����. #
 z
 #��z�� P�  � �� . . ���  Z�  �@�FocusVisualStyle��  � ��$ 4,-1,0,0q�P�  �@J�IsMouseOver . . ��� $ checkBoxBorder��8   � ���� $ checkBoxBorder�� � �� �#9575cd�� $ 
optionMark��8   � ���� $ indeterminateMark��8   � ��P�  � {� .  . ��� $ checkBoxBorder��8   � ���� $ checkBoxBorder��8   � ���� $ 
optionMark��8   � ���� $ indeterminateMark��8 	  � ��P�  � �� . . ��� $ checkBoxBorder��8 
  � ���� $ checkBoxBorder�� � �� �#9575cd�� $ 
optionMark��8   � ���� $ indeterminateMark��8   � ��P�  �@d�	IsChecked$
 trueY�. ��� $ 
optionMark�� �@J�Opacity$ 1Q��� $ indeterminateMark�� �@J�Opacity$ 0Q�P�  Z�  �@d�	IsChecked. ��� $ 
optionMark�� �@J�Opacity$ 0Q��� $ indeterminateMark�� �@J�Opacity$ 1Q��� " ��.���  � �� �� " ��.R�� .+��� $ Border��#��� ��
 . � $ Arrow��
���   �$��Right=�$��8,8,3,3q�$
 0.15Q� �   ��� ��� ��� ��� $ Uniform=�$��Bottom=� P�  �@J�IsMouseOver . . ��� $ Border��# � �� � ��P�  � �� . . ��� $ Border��# � �� � ��P�  � {� .  . ��� $ Arrow�� � y�$ 	Collapsed=��� "  .���  � ��
 ���� ��  � �� �#222528��  � ��$ 0q���   �@ RowDetailsVisibilityMode$ VisibleWhenSelected=���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  �@ AutoGenerateColumns .  ��  �@ HeadersVisibility$ Column=���  � ��$ 0 10 0 0q���  �@ SelectionMode$ Single=���  �@ SelectionUnit$ FullRow=���  �@ CanUserAddRows .  ��  �@ CanUserDeleteRows .  ��  �@ CanUserResizeRows .  ��  �@ CanUserReorderColumns .  ��  � ��$ 12(���  �@ ColumnWidth$ * ��  �@ GridLinesVisibility$
 None=���  � �� �� "  .R��� #��z��#��z��#��z��# z��
 . ._��� $ DG_ScrollViewer��|�.  ���� " ��.R��  �� $
��Auto ��� $��* ��� $
��Auto � �� $
��Auto ��� $��* ��� $
��Auto �.+��� #��Z |�.  ��C� *�� $" DataGridSelectAllButtonStyle��"  +y��� *HeadersVisibility+# Z #! Z  " �� "#  ���� *CellsPanelHorizontalOffset+" �� "#    $!$ PART_ColumnHeadersPresenter��$��1��y��� *HeadersVisibility+# Z% #! Z  " �� "#  �� $!& PART_ScrollContentPresenter��#' z��$��2��$��1���� $( PART_VerticalScrollBar��$��2��#* z) $+ Vertical=�$��1��#- z, #y�z. / �� *VerticalOffset+$0 OneWay=�" �� $1 TemplatedParent=�� $��1��$��2�� �� ���� **(NonFrozenColumnsViewportHorizontalOffset+" �� "#  �� $��* �.+��� $( PART_HorizontalScrollBar��$��1��#* z2 $+ 
Horizontal=�#- z3 #y�z4 / �� *HorizontalOffset+$0 OneWay=�" �� $1 TemplatedParent=�.���� #
 z
 5 ]� 6 �� 7 �@��
IsGrouping8 . �� "7 �@%�IsVirtualizingWhenGrouping8 .  ./���  � �� .  �� "  .���  � ��
 ���� ��  � ��$ Center=���  �@�FocusVisualStyle Z� ��  � ��$
 15 0q���  � �� �� "  .R��� #��z��$��0q�
 . ._��� #
 z
 �� "  .���  � ��$ Center=���  � ��
 ���� ��  � ��
 �   ���  � ��$ 
15 0 15 10q���  � ��$ 15(���  � ��$
 Bold"���  � �� �� "  .R�� .+�  #��z��#��z��#��z��#9 z��#; z: #= z< # z��#? z> #A z@ #C zB ._��� #��z����. #
 z
 #��z��n� $D PART_LeftHeaderGripper��$
��Left=�8��  n� $D PART_RightHeaderGripper��$��Right=�8�� �� "  .���  � ��
 �������  � ��$ 0 4 0 0q���  �@J�SnapsToDevicePixels . ��  �@=�ErrorTemplate Z� ��  �@ ValidationErrorTemplate �� .R��� 
���  ��$��2,0,0,0q�$��!��$��Center=���  � �� �� "  .R��� $ 
DGR_Border��$	 0 8q�#��z��$��0q�$ 5��
 . ._�	   �� $
��Auto ��� $��* � �� $��* ��� $
��Auto �.+�
  $��1��#��zE #
 z
   $��1��$��1��#y�zF G �� *AreRowDetailsFrozen+# ZH #! ZI " �� "#    $��2��$G Vertical=�y��� *HeadersVisibility+# ZJ #! Z  " �� "#  5 P�  �@J�IsMouseOver . . ���  � �� �#FB6161P�  �@ 
IsSelected . . ���  � �� �#FB6161]� 6 �� 7 �@ 
IsSelected8 . �� 7 �@��IsSelectionActive8 .  ./���  � �� �#dfdfdf�� " ��.���  � �� �#217346��  � �� �#217346��  � �� �#ffffff��  �@�FocusVisualStyle Z� ��  � ��$ Center=���  � �� �� " ��.R��� #��z��$ 5��$ 5q�$��1q�#��z��._��� $��Center=�$��Center=�5 P�  �@J�IsMouseOver . . ���  � �� �#5cff8d�� " ��.���  � �� �#217346��  � �� �#217346��  � �� �#ffffff��  �@�FocusVisualStyle Z� ��  � ��$ Center=���  � �� �� " ��.R��� #��z��$ 5��$ 5q�$��1q�#��z��$��0 0 5 0q�._��� $��Center=�$��Center=�5 P�  �@J�IsMouseOver . . ���  � �� �#5cff8d�� " ��8K   .���  � �� �#d32f2f��  � �� �#b71c1c��  � �� �� " ��.R��� #��z��$ 5��$ 5q�$��1q�#��z��$��0 0 5 0q�._��� $��Center=�$��Center=�5 P�  �@J�IsMouseOver . . ���  � �� �#f44336�� "  .���  � ��$ 12����  � ��$ 12����  � ��$ Center=��� " ��8K   .���  � ��
 ��  ���  � ��
 ��  ���  � �� �� " ��.R��� #��z��$ 5��$ 5q�$��1q�#��z��$��0 0 5 0q�._��� $��Center=�$��Center=�5 P�  �@J�IsMouseOver . . ���  � �� �#437ff7�� " ��.���  � �� �#3B69E3��  � �� �#ffffff��  �@�FocusVisualStyle Z� ��  � ��$ 35����  � ��$ 0 20 0 0q���  � ��$ 13(���  � �� �� " ��.R��� #��z��$ 7��._��� $��Center=�$��Center=�5 P�  �@J�IsMouseOver . . ���  � �� �#FB6161��  � �� �#ffffff�� " ��.���  � ��$ 14(���  � ��$ 1����  �@K�ZIndex$ 14����  � ��$ 10 0 0 0q���  � �� �#acb0af��  � ��
 ���� �� " ��.���  � ��$ 14(���  � ��$ 1����  � ��$ 10 0 0 0q���  � ��
 �   ���  � ��
 ���� ��  � ��$ 0q��� " ��.���  � ��$ 20(���  � ��$	 200����  � ��$ 60����  � ��$
 Bold"���  � �� �#1877F2��  � �� �#FDFEFE��  �@�FocusVisualStyle Z� ��  � �� �� " ��.R��� #��z��$ 25��$��1q����#49B7A3$ 15q�._��� $��Center=�$��Center=�5 P�  �@J�IsMouseOver . . ���  � �� �#339685��  � ��
 �����P�  �@J�IsMouseCaptured . . ���  � �� �#2d7a1c��  � ��
 ������� " ��.���  � ��$ 30(���  � ��$
 Bold"���  �@��TextAlignment$ Center=���  � �� �#ffffff�� " ��.���  � �� �#ffffff��  � ��$ 16(���  � ��$ SemiBold"���  � ��$ 
40 30 0 15q��� " ��.���  � ��
 ���� ��  � �� �#fed6ce��  � ��$ 45����  �@�FocusVisualStyle Z� ��  � ��$ 	15 0 15 5q���  � �� �� " ��.R��� #��z��$ 10��._��� $��Stretch=�$��Center=�5 P�  �@J�IsMouseOver . . ���  � �� �#f7f6f4��  � �� �#fb7657�� "  .���  � ��$ 25 0 0 0q���  � ��$ 18����  � ��$ 18����  � �� �� *
Foreground+" �� *FindAncestor+"# ���� " ��.���  � ��$ 20 0 0 2q���  � ��$ 14(���  � �� �� *
Foreground+" �� *FindAncestor+"# ���� " ��.���  � �� �#ffffff��  �@��CornerRadius$ 15����  �@��Padding$ 20q��� " ��.���  � ��$ 20(���  � ��$
 Bold"���  � �� �#083353�� " ��.���  � ��$ 12(���  � ��$	 0 5q���  � �� �#b7b7b7�� " ��.���  � �� �#f7f6f4��  � �� �#a0a0a0��  � ��$ 0q���  � ��$ 12(���  � ��$ 15 13 40 13q���  � ��$ Center=���  � �� �� " ��.R��� $ border��$ 10��#��z��#��z��#��z��
 . ._��� $ PART_ContentHost��|�.  $��Hidden=�$��Hidden=� P�  �@J�IsMouseOver . . ��� $ border�� � �� �#d9d9d9P�  �@J�IsKeyboardFocused . . ��� $ border�� � �� �#d9d9d9