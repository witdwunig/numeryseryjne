   M S B A M L   `   `   `  ����K  GnumeryseryjneWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SerialTrackSerialTrack  5   	       SerialTrack.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SerialTrack     5   	     � Title$  SerialTrack��5   	   $	��600��6   $	��450��6*   ���#f5f7fa.��5      � $��20q�6    � RowDefinitions 5      �� 5      $
��Auto �6   �� 5      $��* �6   .+�5      �� $��0��6    �� Orientation$ Vertical=�6   $��0 0 0 20q�63   $	��Top=�6E   $��Center=�6]   .+�5      �� $��Wygeneruj numer seryjny��6   $��20(�6.   $
��Bold"�6<   $��0 0 20 0q�6N   $��Center=�6`   $��Center=�6{   �� 5      $��Nazwa produktu��6   $
��Bold"�6$   $��0,0,0,5q�66   $��Center=�6G   �� 5      -   5        $��ProductNameTextBox��5      $	��300��6'   $��30��63   $��	0,0,10,10q�6?   $��Center=�6R   $��Center=�6m   �� 5      -   5        $��Generuj��5      $	��120��6   $��35��6*   ���#4CAF50
�������$
��Bold"�6^   $��Center=�6p   $��Center=�6�   6�   �� 5      -   5         ��Name$
 Refr��5      $��Odswierz��6$   $	��120��67   $��35��6C   ���#4CAF50
�������$
��Bold"�6w   $��Center=�6�   $��Center=�6�    J� RenderTransformOrigin$ 0.512,1.228&�6�   5      �� 5      $��1��6   $	��Top=�6   $��Center=�64   .+�5"      �� $ 
Horizontal=�6   $��Center=�6)   $��0,0,0,20q�6F   .+�5#      �� -   5        $��Pokaż filtry��5#      $��84��6$   $
��24.5��6/   ���#2196F3
�������$
��10,0q�6�   �� 5$      $��Filtruj��6   $��84��6   $
��24.5��6*   ���#2196F3
�������$
��10,0q�6`   5%      �� 5(      -   5         ��Name$ FiltersPanel��5(      $ Vertical=�6&   $��Center=�6=   $��0,0,0,10q�6Z   $y�	Collapsed=�6l   .+�5*      �� $ 
Horizontal=�6   $��Center=�6*   $��0,0,0,10q�6G   .+�5+      �� $��Serial Number:��6   $��Center=�6&   $	��120��6A   $��Right=�6M   �� 5,      $	��200��6   $��30��6   $
��10,0q�6'    � ToolTip$ Filter by Serial Number��65   $��Center=�6W   $��5q�6r   ���#f3f3f3���#ddd$��1q�6�   5-      �� 50      $ 
Horizontal=�6   $��Center=�6*   $��0,0,0,10q�6G   .+�51      �� $��Product Name:��6   $��Center=�6%   $	��120��6@   $��Right=�6L   �� 52      $	��200��6   $��30��6   $
��10,0q�6'   $ Filter by Product Name��65   $��Center=�6V   $��5q�6q   ���#f3f3f3���#ddd$��1q�6�   53      �� 56      $ 
Horizontal=�6   $��Center=�6*   $��0,0,0,10q�6G   .+�57      �� $��Date Generated:��6   $��Center=�6'   $	��120��6B   $��Right=�6N   (  "System.Windows.Controls.DatePicker  58      $	��200��6   $��30��6   $
��10,0q�6*   $��Center=�68   $��5q�6S   ���#f3f3f3���#ddd$��1q�6�   59      5:      &   System.Windows.Controls.DataGrid  5=      -   5        $��SerialDataGrid��5=   i      AutoGenerateColumns$ False��6   $	��400��6*      HeadersVisibility$ Column=�67   	   CanUserAddRows$	 False��6R   
   GridLinesVisibility$
 
Horizontal=�5>      
�������$��1q�6K   ���#ddd$��0 0 0 20q�6r   $	��Top=�5?       � 	Resources 5@      )  #System.Windows.Controls.DataGridRow �� 
TargetType �� Property �� Value*  $System.Windows.Controls.DataGridCell��%�  '        '  �     �� 5A      "  6   .�5B      ��  � ��
 �����6%   �� 5C       � �� �#ddd6&   �� 5D       � ��$ 1q�6*   �� 5E       � ��$ 40��6!   �� 5F       � ��$ 5q�6!   5G      �� 5H      "  6   .�5I      ��  � ��$
 10,5q�6"   �� 5J       � �� �#ddd6&   �� 5K       � ��$ 0,1,0,1q�6*   �� 5L       � ��
 �����6%   5M      5N         Columns 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q      ,  &System.Windows.Controls.DataGridColumn   Header$ Numer Seryjny��6      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *SerialNumber+   	CellStyle 5R      �� 5S   	   "  6   .�5T   
   ��  � ��$
 Bold"�6'   �� 5U   
    � �� �#3336'   �� 5V   
    � �� �#f3f3f36'   �� 5W   
    � ��$
 10,5q�6$   5X   
   5Z        5[      $ Nazwa Produktu��6   $ * 6R    62   �� *ProductName+ 5\      �� 5]   	   "  6   .�5^   
   ��  � ��$ Normal"�6'   �� 5_   
    � �� �#3336'   �� 5`   
    � ��
 �����6'   �� 5a   
    � ��$
 10,5q�6$   5b   
   5d        5e      $ Data Wygenerowania��6   $ * 6X    66   �� *DateGenerated+ 5f      �� 5g   	   "  6   .�5h   
   ��  � ��$ Normal"�6'   �� 5i   
    � �� �#3336'   �� 5j   
    � ��
 �����6'   �� 5k   
    � ��$
 10,5q�6$   5l   
   5n      5p      5q      5r      5s      