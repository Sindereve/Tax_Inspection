   M S B A M L   `   `   `  ����E  AInspection, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Inspection.PageAppInspection.PageApp  5           Inspection.PageApp.addPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Inspection.PageApp     5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  addPage��5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��80 �6   �� 5      �� 5      $��80 �6   .+�5   
   �� $��1��6   .+�5      &   MaterialDesignThemes.Wpf.Flipper  $��Center=�6%      BackContent 5       �� 5!      $	��500��6   $��8q�6)      FlipCommand#��Z 64   $��Частное лицо��6l      MaterialDesignFlatButton#��[  6�      FrontContent 5$      � 5%       � RowDefinitions 5'      �� 5(      $
��Auto �6,   �� 5)      $��* �6,   .+�5,      (  "MaterialDesignThemes.Wpf.ColorZone  $��6q�63      Mode$ SecondaryMid=�6?   .��5-      ��  �� Orientation$ 
Horizontal=�6)   .+�5.   "   �� $
��Left=�6)   #��Z 6D    & "MaterialDesignToolForegroundButton#��[ 6|   .��5/   &   '  !MaterialDesignThemes.Wpf.PackIcon  $��Right=�6>      Kind$ 	ArrowLeft=�6Z   50   #   �� 51   "   $��8,0,8,0q�6,   $��Center=�6=   $A��;Добавление нового частного лица��6X   52      53      � 55      $��1��6   $	��500��6,   $��0,6,0,0q�68   $��Center=�6I   $	��Top=�6f    57      �� 58   "   �� 59   "   �� 5:   "   �� 5;   "   .+�5>      �� $��0��6)   $ Vertical=�66   .+�5@   "   �� $ 
Horizontal=�6-   .+�5A   &   �� -   5        	 ��Name$	 lastNameBox��5A   .   $��15,5,5,5q�5B   )   $	��100��6;   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Фамилия��6G      
IsFloating$
 True��6p   �� 5C   &   -   5        $	 nameBox��5C   .   $��5q�5D   )   $	��100��64   $
 Имя��6@   $
 True��6e   �� 5E   &   -   5        $	 middleNameBox��5E   .   $��5q�5F   )   $	��100��64   $
 Отчество��6@   $
 True��6j   5G   #   �� 5I   "   $ 
Horizontal=�6-   .+�5J   &   (  "System.Windows.Controls.DatePicker  -   5          Name$ birthdayBox��5J   1   $��15,5,5,5q�5K   1   $	��105��6C    � Language$ Ru-ru�5L   1   -  'MaterialDesignThemes.Wpf.CalendarAssist   IsHeaderVisible$
 True��5M   1   $
 True��5N   1   $
 Дата рождения��5O   1   5P   #   �� 5R   "   $ 
Horizontal=�6-   .+�5S   &   �� -   5        $	 
addressBox��5S   .   $��15,5,5,5q�5T   .   $	��100��6@   $
 
Адрес��6L   $
 True��6s   �� 5U   &   -   5        $	 telephonBox��5U   .   $��5q�5V   .   $	��100��69   $!
 Номер телефона��6E   $
 True��6u   �� 5W   &   -   5        $	 emailBox��5W   .   $��5q�5X   .   $	��100��69   $
 email��6E   $
 True��6l   5Y   #   �� 5[   "   $ 
Horizontal=�6-   .+�5\   &   �� -   5         ��Name$ chiefCheсkBox��5\   /   $[��UЯвляется руководителем существующей компании��6F     MaterialDesignCheckBox#��[ 5]   /   $��20,0,0,5q�6_   6q   5^   #   �� 5`   "   $ 
Horizontal=�6-   .+�5a   &   �� -	   5        $	 innCompaniChiefBox��5a   .   $y�	Collapsed=�6J   $��	15,2,2,10q�5b   .   $	��120��6A   $
 ИНН компании��6M   $
 True��6{   5c   #   �� 5e   "   .+�5f   &   �� $��Right=�6-   $��Сохранить��6I   $��5q�5g   -    * &MaterialDesignFlatSecondaryMidBgButton#��[ 68    � ToolTip$. (MaterialDesignFlatSecondaryLightBgButton��6y   {�5f   ]   �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window5g   y   5h   #   5j      5n      5o      5q      5u      5x      5y      