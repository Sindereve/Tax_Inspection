   M S B A M L   `   `   `  ����E  AInspection, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Inspection.PageAppInspection.PageApp  5           Inspection.PageApp.addPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Inspection.PageApp     5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  addPage��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $��80 �6   �� 5      �� 5      $��80 �6   .+�5   
   �� $��1��6   .+�5      &   MaterialDesignThemes.Wpf.Flipper  $��Center=�6%      BackContent 5      �� 5       $	��500��6   $��8q�6)      FlipCommand#��Z 64   $��Частное лицо��6l      MaterialDesignFlatButton#��[  6�      FrontContent 5#      � 5$       � RowDefinitions 5&      �� 5'      $
��Auto �6,   �� 5(      $��* �6,   .+�5+      (  "MaterialDesignThemes.Wpf.ColorZone  $��6q�63      Mode$ SecondaryMid=�6?   .��5,      ��  �� Orientation$ 
Horizontal=�6)   .+�5-   "   �� $
��Left=�6)   #��Z 6D    & "MaterialDesignToolForegroundButton#��[ 6�   .��5.   &   '  !MaterialDesignThemes.Wpf.PackIcon  $��Right=�6>      Kind$ 	ArrowLeft=�6Z   5/   #   �� 50   "   $��8,0,8,0q�6,   $��Center=�6=   $A��;Добавление нового частного лица��6X   51      52      � 54      $��1��6   $	��500��6,   $��0,6,0,0q�68   $��Center=�6I   $	��Top=�6f    56      �� 57   "   �� 58   "   �� 59   "   �� 5:   "   .+�5=      �� $��0��6)   $ Vertical=�66   .+�5?   "   �� $ 
Horizontal=�6-   .+�5@   &   �� -   5        	 ��Name$	 lastNameBox��5@   .   $��5q�5A   )   $	��100��64   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Фамилия��6@      
IsFloating$
 True��6i   �� 5B   &   -   5        $	 nameBox��5B   .   $��5q�5C   )   $	��100��64   $
 Имя��6@   $
 True��6e   �� 5D   &   -   5        $	 middleNameBox��5D   .   $��5q�5E   )   $	��100��64   $
 Отчество��6@   $
 True��6j   5F   #   �� 5H   "   $ 
Horizontal=�6-   .+�5I   &   (  "System.Windows.Controls.DatePicker  -   5          Name$ birthdayBox��5I   1   $��5q�5J   1   $	��105��6<    � Language$ Ru-ru�5K   1   -  'MaterialDesignThemes.Wpf.CalendarAssist   IsHeaderVisible$
 True��5L   1   $
 True��5M   1   $
 Дата рождения��5N   1   5O   #   �� 5Q   "   $ 
Horizontal=�6-   .+�5R   &   �� -   5        $	 
addressBox��5R   .   $��5q�5S   .   $	��100��69   $
 
Адрес��6E   $
 True��6l   �� 5T   &   -   5        $	 telephonBox��5T   .   $��5q�5U   .   $	��100��69   $!
 Номер телефона��6E   $
 True��6u   �� 5V   &   -   5        $	 emailBox��5V   .   $��5q�5W   .   $	��100��69   $
 email��6E   $
 True��6l   5X   #   �� 5Z   "   $ 
Horizontal=�6-   .+�5[   &   �� -   5         ��Name$ chiefCheсkBox��5[   /   $[��UЯвляется руководителем существующей компании��6F     MaterialDesignCheckBox#��[ 5\   /   $��0,0,0,5q�6_   6p   5]   #   �� 5_   "   $ 
Horizontal=�6-   .+�5`   &   �� -	   5        $	 innCompaniChiefBox��5`   .   $y�	Collapsed=�6J   $��0,2,2,10q�5a   .   $	��120��6@   $
 ИНН компании��6L   $
 True��6z   5b   #   �� 5d   "   .+�5e   &   �� $��Right=�6-   $��Сохранить��6I   $��5q�5f   -    * &MaterialDesignFlatSecondaryMidBgButton#��[ 68    � ToolTip$. (MaterialDesignFlatSecondaryLightBgButton��6y   {�5e   ]   �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window5f   y   5g   #   5i      5m      5n      5p      5t      5w      5x      