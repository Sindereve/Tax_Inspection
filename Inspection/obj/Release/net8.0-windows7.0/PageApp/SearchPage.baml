   M S B A M L   `   `   `  ���� E  AInspection, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Inspection
Inspection  %clr-namespace:NumberBox	NumberBox  #    Inspection.PageApp.SearchPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:Inspection     -	behaviorsclr-namespace:NumberBox     _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� Title$  
SearchPage��.���  � ColumnDefinitions �� $��80 ��� �� $��80 �.+�#  MaterialDesignThemes.Wpf.Card  $��1��.����  �� Orientation$ Vertical=�.+�  $��0��$
��Auto��$
��Auto��.���� .+�9� $��1��$��Stretch=�-  'MaterialDesignThemes.Wpf.ExpanderAssist   ExpanderButtonPosition$ Start=����� $%��Настройки поиска��$��20(�$��Center=�.���� $��
24,8,24,16q�$ Vertical=�.+��  �� $	��15* ��� $	��85* �.+��� $��0��$��4q�$ Vertical=�.+�	� -    	�Name$ SettingAlternativePeople��$��4q�$��Физ. лицо�� d� 	IsChecked$
 TrueY� %  !MaterialDesignTabRadioButtonRight#��[  	� -   $ SettingAlternativeCompani��$��4q�$��Юр. лицо��$ FalseY�#��[  	� -   $  SettingAlternativeProperty��$��4q�$��Недвижимость��$ FalseY�#��[  	� -   $! SettingAlternativeTransport��$��4q�$
��ТС��$ FalseY�#��[  �� -    ��Name$ settingSearchPeople��$��1��$��4q�$ 
Horizontal=�$y�Visible=�.+��� $ Vertical=�$��3q�.+��� $(��"   Выводимые данные��$��20(��� -    ��Name$ PeopleBirtsdayEnable��$��Дата рождения��$ FalseY�$��20(��� -   $ PeopleaddressEnable��$��Прописка��$ FalseY�$��20(��� -   $ PeopleTelephoneEnable��$!��Номер телефона��$ FalseY�$��20(��� -	   $ PeopleEmailEnable��$��email��$ FalseY�$��20(��� $ Vertical=�$��3q�.+��� $�� ��$��20(��� -
   $ PeopleTaxEnable��$'��!Имеет задолжность��$ FalseY�$��20(��� -   $ PeopleIsСhiefEnable��$(��"Явл. руководителем��$ FalseY�$��20(��� $��3q�$ Vertical=�.+��� $%��Задолжность(тыс):��$��20(��� $ 
Horizontal=�.+��� $��	15,0,10,0q�$
��от��$��25(��� -    ��Name$ PeopleUpTaxTextBox��&    NumberBox.NumericTextBoxBehavior	   	IsNumeric$
	 True��$��20(�$	��120��$
��auto��${�False������ *	NumberBox+�� $ 
Horizontal=�$��0,20,0,0q�.+��� $��	15,0,10,0q�$
��до��$��25(��� -   $ PeopleDownTaxTextBox��$
	 True��$��20(�$	��120��$
��auto��${�False������ *	NumberBox+�� -   $ settingSearchCompani��$��1��$��4q�$ 
Horizontal=�$y�	Collapsed=�.+��� $ Vertical=�$��3q�.+��� $(��"   Выводимые данные��$��20(��� -   $ CompaniAdresEnable��$��
адрес��$ FalseY�$��20(��� -   $ CompaniTelephoneEnable��$��телефон��$ FalseY�$��20(��� -   $ CompaniEmailEnable��$��email��$ FalseY�$��20(��� $ Vertical=�$��3q�.+��� $�� ��$��20(��� -   $ CompaniTaxEnable��$��сумма долга��$ FalseY�$��20(��� -   $ CompaniChiefPeopleEnable��$��руководитель��$ FalseY�$��20(��� $��3q�$ Vertical=�.+��� $%��Задолжность(тыс):��$��20(��� $ 
Horizontal=�.+��� $��	15,0,10,0q�$
��от��$��25(��� -   $ CompaniUpTaxTextBox��$
	 True��$��20(�$	��120��$
��auto��${�False������ *	NumberBox+�� $ 
Horizontal=�$��0,20,0,0q�.+��� $��	15,0,10,0q�$
��до��$��25(��� -   $ CompaniDownTaxTextBox��$
	 True��$��20(�$	��120��$
��auto��${�False������ *	NumberBox+�� -   $ settingSearchProperty��$��1��$��4q�$ 
Horizontal=�$y�	Collapsed=�.+��� $ Vertical=�$��3q�.+��� $(��"   Выводимые данные��$��20(��� -   $ PropertyTypeEnable��$��тип��$ FalseY�$��20(��� -   $ PropertySizeEnable��$��площадь��$ FalseY�$��20(��� -   $ PropertyPriceEnable��$��стоимость��$ FalseY�$��20(��� $��50���� $��3q�$ Vertical=�.+��� $��Стоимость:��$��20(��� $ 
Horizontal=�.+��� $��	15,0,10,0q�$
��от��$��25(��� -   $ PropertyUpPriceTextBox��$
	 True��$��20(�$	��120��$
��auto��${�False������ *	NumberBox+�� $ 
Horizontal=�$��0,20,0,0q�.+��� $��	15,0,10,0q�$
��до��$��25(��� -   $ PropertyDownPriceTextBox��$
	 True��$��20(�$	��120��$
��auto��${�False������ *	NumberBox+�� $��3q�$ Vertical=�.+��� $��Площадь:��$��20(��� $ 
Horizontal=�.+��� $��	15,0,10,0q�$
��от��$��25(��� -   $ PropertyUpSizeTextBox��$
	 True��$��20(�$	��120��$
��auto��${�False������ *	NumberBox+�� $ 
Horizontal=�$��0,20,0,0q�.+��� $��	15,0,10,0q�$
��до��$��25(��� -   $ PropertyDownSizeTextBox��$
	 True��$��20(�$	��120��$
��auto��${�False������ *	NumberBox+�� -   $ settingSearchTransport��$��1��$��4q�$ 
Horizontal=�$y�	Collapsed=�.+��� $ Vertical=�$��3q�.+��� $(��"   Выводимые данные��$��20(��� -   $ TransportTypeEnable��$��тип��$ FalseY�$��20(��� -    $ TransportYearEnable��$��год. выпуска��$ FalseY�$��20(��� $ Vertical=�$��3q�.+��� $�� ��$��20(��� -!   $ TransportPriceEnable��$��стоимость��$ FalseY�$��20(��� $��3q�$ Vertical=�.+��� $��Стоимость:��$��20(��� $ 
Horizontal=�.+��� $��	15,0,10,0q�$
��от��$��25(��� -"   $ TransportUpPriceTextBox��$��20(�$
	 True��$	��120��$
��auto��${�False������ *	NumberBox+�� $ 
Horizontal=�$��0,20,0,0q�.+��� $��	15,0,10,0q�$
��до��$��25(��� -#   $ TransportDownPriceTextBox��$
	 True��$��20(�$	��120��$
��auto��${�False������ *	NumberBox+�� -$   $	��100��$��1��$��Center=�$��0,10,0,0q�$��30��
������ .��'  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 Magnify=� � Triggers :�  :� RoutedEvent$ Button.Click��.[��� .���� .����  �� TargetProperty$1 +(Button.Background).(SolidColorBrush.Color)�	 �� To
 Tomato g� Duration$ 0:0:0.8D��� $1 +(Button.Background).(SolidColorBrush.Color)� Transparent g� 	BeginTime	 0:0:1$ 0:0:0.1D�� -%    �Name$ loadTableBar��$y�Hidden=�$��
20,10,20,0q� � IsIndeterminate$
 True��&   System.Windows.Controls.DataGrid  -&     Name$ 
myDataGrid��$��	20,0,20,0q�$��1��  PrimaryHueDarkBrush#���  -  'MaterialDesignThemes.Wpf.DataGridAssist   SelectedCellBorderBrush
 �<��   
IsReadOnly$
 True��   SelectionMode$ Extended=�   SelectionUnit$
 Cell=�   CellPadding$ 4 2 2 2q�   ColumnHeaderPadding$ 4 2 2 2q�   CanUserAddRows$ False��   CanUserSortColumns$ False��