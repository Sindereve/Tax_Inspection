   M S B A M L   `   `   `  ����E  AInspection, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Inspection.PageAppInspection.PageApp  5      "    Inspection.PageApp.searchINN   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Inspection.PageApp     5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ] YXceed.Wpf.Toolkit.NET5, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        N� Title$  
searchТIN��5      .��5      �� .��5      �  � ColumnDefinitions 5   
   �� 5      $��80 �6   �� 5      �� 5      $��80 �6   .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��1��6   .��5      ��  �� Orientation$ Vertical=�6   .+�5      �� $	��100��6   $��5q�6*   $ Vertical=�65   .+�5      �� $��Center=�6!   $��Center=�6>   .+�5      %  Xceed.Wpf.Toolkit.MaskedTextBox  -   5          Name$ innValue��5   -      Mask$ 000000000000��6?    �� TextAlignment$ Center=�5   -   $��20(�5   -   $	��140��6;   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ ИНН��5   -   &   FloatingHintHorizontalAlignment$ Center=�5   -      
IsFloating$
 True��5   -    %  !MaterialDesignFloatingHintTextBox#��[  5    -   5!      �� 5#      .+�5$      �� -   5        	 ��Name$	 searchOb��5$   !   $	��100��5%      $��1��6*   $��Center=�5&      $	��Top=�6A   $��0,10,0,0q�5'      $��30��6/   
������ .��5(      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 Magnify=�66    � Triggers 5)      :� 5*   "    :� RoutedEvent$ Button.Click��6/   .[�5+   &   �� .��5,   *   �� .��5-   .   ��  �� TargetProperty$1 +(Button.Background).(SolidColorBrush.Color)�6=   	 �� To
 Tomato6�    g� Duration$ 0:0:0.8D�6�   �� 5.   .   $1 +(Button.Background).(SolidColorBrush.Color)�6=    Transparent6�    g� 	BeginTime	 0:0:16�   $ 0:0:0.1D�6�   5/   +   50   '   51   #   53      54      56      '  !MaterialDesignThemes.Wpf.Snackbar  58      -   5          Name$ errorMessage��58   *   $��20(�6@      IsActive$ False��6N      MessageF  @MaterialDesignThemes.Wpf.Converters.SnackbarMessageTypeConverter$&  ИНН не существует 6_     5:      -   5          Name$ resultSearch��5<   &   $��30,10,30,50q�5:   &   $��5q�6;     MaterialDesignOutlinedCard#��[ 5;   &   $y�Hidden=�5<   <   .��5=      �� $ Vertical=�6!   .+�5>      (  "MaterialDesignThemes.Wpf.ColorZone  $��6q�67      Mode$ SecondaryMid=�6C   $}�False��5?   7   
�������.��5A   "   �  5C   &   �� 5D   *   $	��90* �6;   �� 5E   *   $	��10* �6;   .+�5H   &   �� -   5         ��Name$ 
nameObject��5H   @   $��0��60   $��60(�5I   +   $	��140��69   $��0��5J   +   $��
16,16,16,4q�5K   +    $  MaterialDesignHeadline5TextBlock#��[ 5L   +   $.��(Имя/Название компании��5M   +   �� 5O   &   -   5        $	 deletOb��5O   -   
���\\��$��1��5Q   -   $��Удалить��5R   -   $	��Top=�6?   $��Right=�6W   5S   #   5T      �� 5W      .+�5Y      9�   MaterialDesignExpander#���  6'   $��Stretch=�5Z   '   $��30(�5[   '   ��5]   "   �� 5^   &   $#��Основные данные��60   $��40(�6G   .��5a   "   �� -   5         ��Name$ mainObj��5a   -   $y�Visible=�6>   .+�5c   &   �  5e   *   �� 5f   .   �� 5g   .   .+�5j   *   �� $��0��65   $ Vertical=�6E   .+�5l   .   �� -   5        $ birthdayPeople��5l   9   $ 
Horizontal=�6Q   .+�5m   2   �� $��16,0,0,0q�5n   ?   $��30(�5o   ?   $
��Left=�6M   $��Center=�5p   ?      MaterialDesignBody2TextBlock#��[ 5q   ?   $ ��Дата рождения:��5r   ?   (  "System.Windows.Controls.DatePicker  5t   2   -	   5          Name$ birthdayPeopleBox��5t   =   ${�False��5u   A   $��20(�5v   A   $	��140��6O   $��5q�5w   A    $  MaterialDesignOutlinedDatePicker#��[ 5x   A    � Language$ Ru-ru�5y   A   5z   /   �� 5|   .   -
   5        $ chiefCompani��5|   9   $ 
Horizontal=�6O   .+�5}   2   �� -   5        $ chiefCompaniName��5}   <   $��16,0,0,0q�5~   ?   $��30(�5   ?   $
��Left=�6M   $��Center=�5�   ?   #��[ 5�   ?   $"��Руководит(-ель):��5�   ?   �� 5�   2   -   5         ��Name$ chiefCompaniBox��5�   :   $��20(�5�   =   $	��140��6K   $��5q�5�   =   ${�False��5�   =    ! MaterialDesignOutlinedTextBox#��[ 5�   =   5�   /   �� 5�   .   -   5        $ telephon��5�   9   $ 
Horizontal=�6K   .+�5�   2   �� $��16,0,0,0q�5�   ?   $��30(�5�   ?   $
��Left=�6M   $��Center=�5�   ?   #��[ 5�   ?   $"��Номер телефона:��5�   ?     5�   2   -   5        $ telephonBox��5�   E   $ +7 (000) 000-00-00��6Z   $��5q�5�   I   $��25(�6T   $	��140��6b   ${�False��5�   I   #��[ 5�   I   5�   /   5�   +   �� 5�   *   $��1��65   $ Vertical=�6E   .+�5�   .   �� -   5        $ address��5�   :   $ 
Horizontal=�6K   .+�5�   2   �� $��16,0,0,0q�5�   ?   $��30(�5�   ?   $
��Left=�6M   $��Center=�5�   ?   #��[ 5�   ?   $��Адрес:��5�   ?   �� 5�   2   -   5        $ 
addressBox��5�   :   $��20(�5�   =   $	��140��6K   $��5q�5�   =   ${�False��5�   >   #��[ 5�   =   5�   /   �� 5�   .   -   5        $ chiefNewCompani��5�   9   $y�	Collapsed=�6R   $ 
Horizontal=�6i   .+�5�   2   �� -   5        $ chiefNewCompaniText��5�   <   $��16,0,0,0q�5�   ?   $��30(�5�   ?   $
��Left=�6M   $��Center=�5�   ?   #��[ 5�   ?   $3��-ИНН нового руководителя:��5�   ?     5�   2   -   5        $ chiefNewCompaniBox��5�   E   $ 000000000000��5�   I   $��5q�5�   I   $��25(�6T   $	��140��6b   #��[ 5�   I   5�   /   �� 5�   .   -   5        $ email��5�   :   $ 
Horizontal=�6I   .+�5�   2   �� $��16,0,0,0q�5�   ?   $��30(�5�   ?   $
��Left=�6M   $��Center=�5�   ?   #��[ 5�   ?   $��email:��5�   ?   �� 5�   2   -   5        $ emailBox��5�   :   $��20(�5�   =   $	��140��6K   $��5q�5�   =   ${�False��5�   >   #��[ 5�   =   $ Ru-ru�5�   =   5�   /   5�   +   5�   '   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� -   5         ��Name$ updateCheckBox��5�   3   -	  'MaterialDesignThemes.Wpf.CheckBoxAssist 	  CheckBoxSize$ 30Q�5�   7   $#��Изменить данные��5�   7   $��	15,0,0,20q�5�   3     MaterialDesignCheckBox#��[ 5�   7   �� 5�   *   -   5        $	 updateButton��5�   1   $y�	Collapsed=�5�   5   $��40,0,0,0q�5�   5   $��Сохранить��5�   5   $��20(�6I   $
��Left=�5�   5     MaterialDesignPaperButton#��[ 5�   5    � ToolTip$. (MaterialDesignFlatSecondaryLightBgButton��5�   5   {�5�   5   �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window5�   5   5�   '   5�   #   5�      �� 5�      $��1��6%   
���   �60   9� 5�      -   5          9�Name$  properyExpander��5�   '   $��Stretch=�6@   $��30(�5�   '   ! 9� 
IsExpanded$
! true��65   ��5�   "   �� 5�   &   $��Недвижимость��60   $��40(�6D   .��5�   "   �� -   5        $ propertyObj��5�   -   $y�Visible=�6B   $��0,0,0,20q�6W   .+�5�   &   �� -   5        $ propertyCount��5�   0   $��10,0,0,5q�5�   0   $��Right=�5�   0   $��20(�5�   0   $(��"Кол. недвижимости: ��5�   0   &
   System.Windows.Controls.DataGrid
  5�   &   -   5        " 
 Name$" propertyDataGrid��5�   /   $��10q�5�   -    	 PrimaryHueDarkBrush#��� 	 5�   -   -  'MaterialDesignThemes.Wpf.DataGridAssist#   SelectedCellBorderBrush
# �<��$ 
  
IsReadOnly$
$ True��5�   -   % 
  SelectionMode$% Extended=�5�   -   & 
  SelectionUnit$
& Cell=�6F   '   CellPadding$' 4 2 2 2q�5�   -   (   ColumnHeaderPadding$( 4 2 2 2q�5�   -   ) 
  CanUserAddRows$) False��5�   -   * 
  CanUserSortColumns$* False��5   -   5  #   5     �� 5     $��1��6%   
���   �60   9� 5     -   5        $  transportExpander��5  '   $��Stretch=�6B   $
! True��6`   $��30(�5  )   ��5	  "   �� 5
  &   $��Транспорт��60   $��40(�6A   .��5  "   �� -   5        $ transportObj��5  -   $y�Visible=�6C   $��0,0,0,20q�6X   .+�5  &   �� -   5        $ transportCount��5  0   $��10,0,0,5q�5  0   $��Right=�5  0   $��20(�5  0   $$��Кол. транспорта: ��5  0   
  5  &   -   5        $" transportDataGrid��5  /   $��10q�5  1   #��� 	 5  1   
# �<��$
$ True��5  1   $% Extended=�5  1   $
& Cell=�6J   $' 4 2 2 2q�5  1   $( 4 2 2 2q�5  1   $) False��5  1   $* False��5  1   5  #   5      �� 5"     $��1��6%   
���   �60   9� 5$     -    5        $  taxExpander��5$  '   $��Stretch=�6<   $��30(�5%  )   $
! true��67   ��5'  "   �� 5(  &   $��Налоги��60   $��40(�6>   .��5+  "   �� -!   5        $ taxObj��5+  -   $y�Visible=�6=   $��0,0,0,20q�6R   .+�5-  &   �� -"   5        $ taxCount��5-  0   $��10,0,0,5q�5.  0   $��Right=�5/  0   $��20(�50  0   $(��"Кол. недвижимости: ��51  0   
  53  &   -#   5        $" taxDataGrid��53  /   $��10q�54  1   #��� 	 55  1   
# �<��$
$ True��57  1   $% Extended=�58  1   $
& Cell=�6J   $' 4 2 2 2q�59  1   $( 4 2 2 2q�5:  1   $) False��5;  1   $* False��5<  1   5=  #   5>     5@     5E     5G     5I     5J     5K     5L     5M     