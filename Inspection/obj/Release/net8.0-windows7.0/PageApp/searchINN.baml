   M S B A M L   `   `   `  ���� E  AInspection, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Inspection.PageAppInspection.PageApp  "    Inspection.PageApp.searchINN   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:Inspection.PageApp     _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  ] YXceed.Wpf.Toolkit.NET5, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    N� Title$  
searchТIN��.���� .���  � ColumnDefinitions �� $��80 ��� �� $��80 �.+�#  MaterialDesignThemes.Wpf.Card  $��1��.����  �� Orientation$ Vertical=�.+��� $	��100��$��5q�$ Vertical=�.+��� $��Center=�$��Center=�.+�%  Xceed.Wpf.Toolkit.MaskedTextBox  -     Name$ innValue��   Mask$ 000000000000�� �� TextAlignment$ Center=�$��20(�$	��140��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ ИНН��&   FloatingHintHorizontalAlignment$ Center=�   
IsFloating$
 True�� %  !MaterialDesignFloatingHintTextBox#��[  �� .+��� -   	 ��Name$	 searchOb��$	��100��$��1��$��Center=�$	��Top=�$��0,10,0,0q�$��30��
������ .��'  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 Magnify=� � Triggers :�  :� RoutedEvent$ Button.Click��.[��� .���� .����  �� TargetProperty$1 +(Button.Background).(SolidColorBrush.Color)�	 �� To
 Tomato g� Duration$ 0:0:0.8D��� $1 +(Button.Background).(SolidColorBrush.Color)� Transparent g� 	BeginTime	 0:0:1$ 0:0:0.1D�'  !MaterialDesignThemes.Wpf.Snackbar  -     Name$ errorMessage��$��20(�   IsActive$ False��   MessageF  @MaterialDesignThemes.Wpf.Converters.SnackbarMessageTypeConverter$&  ИНН не существует   -     Name$ resultSearch��$��30,10,30,50q�$��5q�  MaterialDesignOutlinedCard#��[ $y�Hidden=�.���� $ Vertical=�.+�(  "MaterialDesignThemes.Wpf.ColorZone  $��6q�   Mode$ SecondaryMid=�$}�False��
�������.���  �� $	��90* ��� $	��10* �.+��� -    ��Name$ 
nameObject��$��0��$��60(�$	��140��$��0��$��
16,16,16,4q� $  MaterialDesignHeadline5TextBlock#��[ $.��(Имя/Название компании���� -   $	 deletOb��
���\\��$��1��$��Удалить��$	��Top=�$��Right=��� .+�9�   MaterialDesignExpander#���  $��Stretch=�$��30(����� $#��Основные данные��$��40(�.���� -    ��Name$ mainObj��$y�Visible=�.+��  �� �� .+��� $��0��$ Vertical=�.+��� -   $ birthdayPeople��$ 
Horizontal=�.+��� $��16,0,0,0q�$��30(�$
��Left=�$��Center=�   MaterialDesignBody2TextBlock#��[ $ ��Дата рождения:��(  "System.Windows.Controls.DatePicker  -	     Name$ birthdayPeopleBox��${�False��$��20(�$	��140��$��5q� $  MaterialDesignOutlinedDatePicker#��[  � Language$ Ru-ru��� -
   $ chiefCompani��$ 
Horizontal=�.+��� -   $ chiefCompaniName��$��16,0,0,0q�$��30(�$
��Left=�$��Center=�#��[ $"��Руководит(-ель):���� -    ��Name$ chiefCompaniBox��$��20(�$	��140��$��5q�${�False�� ! MaterialDesignOutlinedTextBox#��[ �� -   $ telephon��$ 
Horizontal=�.+��� $��16,0,0,0q�$��30(�$
��Left=�$��Center=�#��[ $"��Номер телефона:��  -   $ telephonBox��$ +7 (000) 000-00-00��$��5q�$��25(�$	��140��${�False��#��[ �� $��1��$ Vertical=�.+��� -   $ address��$ 
Horizontal=�.+��� $��16,0,0,0q�$��30(�$
��Left=�$��Center=�#��[ $��Адрес:���� -   $ 
addressBox��$��20(�$	��140��$��5q�${�False��#��[ �� -   $ chiefNewCompani��$y�	Collapsed=�$ 
Horizontal=�.+��� -   $ chiefNewCompaniText��$��16,0,0,0q�$��30(�$
��Left=�$��Center=�#��[ $3��-ИНН нового руководителя:��  -   $ chiefNewCompaniBox��$ 000000000000��$��5q�$��25(�$	��140��#��[ �� -   $ email��$ 
Horizontal=�.+��� $��16,0,0,0q�$��30(�$
��Left=�$��Center=�#��[ $��email:���� -   $ emailBox��$��20(�$	��140��$��5q�${�False��#��[ $ Ru-ru��� $ 
Horizontal=�.+��� -    ��Name$ updateCheckBox��-	  'MaterialDesignThemes.Wpf.CheckBoxAssist 	  CheckBoxSize$ 30Q�$#��Изменить данные��$��	15,0,0,20q�  MaterialDesignCheckBox#��[ �� -   $	 updateButton��$y�	Collapsed=�$��40,0,0,0q�$��Сохранить��$��20(�$
��Left=�  MaterialDesignPaperButton#��[  � ToolTip$. (MaterialDesignFlatSecondaryLightBgButton��{��� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window�� $��1��
���   �9� -     9�Name$  properyExpander��$��Stretch=�$��30(�! 9� 
IsExpanded$
! true������ $��Недвижимость��$��40(�.���� -   $ propertyObj��$y�Visible=�$��0,0,0,20q�.+��� -   $ propertyCount��$��10,0,0,5q�$��Right=�$��20(�$(��"Кол. недвижимости: ��&
   System.Windows.Controls.DataGrid
  -   " 
 Name$" propertyDataGrid��$��10q� 	 PrimaryHueDarkBrush#��� 	 -  'MaterialDesignThemes.Wpf.DataGridAssist#   SelectedCellBorderBrush
# �<��$ 
  
IsReadOnly$
$ True��% 
  SelectionMode$% Extended=�& 
  SelectionUnit$
& Cell=�'   CellPadding$' 4 2 2 2q�(   ColumnHeaderPadding$( 4 2 2 2q�) 
  CanUserAddRows$) False��* 
  CanUserSortColumns$* False���� $��1��
���   �9� -   $  transportExpander��$��Stretch=�$
! True��$��30(����� $��Транспорт��$��40(�.���� -   $ transportObj��$y�Visible=�$��0,0,0,20q�.+��� -   $ transportCount��$��10,0,0,5q�$��Right=�$��20(�$$��Кол. транспорта: ��
  -   $" transportDataGrid��$��10q�#��� 	 
# �<��$
$ True��$% Extended=�$
& Cell=�$' 4 2 2 2q�$( 4 2 2 2q�$) False��$* False���� $��1��
���   �9� -    $  taxExpander��$��Stretch=�$��30(�$
! true������ $��Налоги��$��40(�.���� -!   $ taxObj��$y�Visible=�$��0,0,0,20q�.+��� -"   $ taxCount��$��10,0,0,5q�$��Right=�$��20(�$(��"Кол. недвижимости: ��
  -#   $" taxDataGrid��$��10q�#��� 	 
# �<��$
$ True��$% Extended=�$
& Cell=�$' 4 2 2 2q�$( 4 2 2 2q�$) False��$* False��