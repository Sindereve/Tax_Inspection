   M S B A M L   `   `   `  ����E  AInspection, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Inspection.PageAppInspection.PageApp  5      %clr-namespace:NumberBox	NumberBox  5           Inspection.PageApp.addPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Inspection.PageApp     5      -	behaviorsclr-namespace:NumberBox     5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ] YXceed.Wpf.Toolkit.NET5, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5	        N� Title$  addPage��5
      .��5      �� -   5         ��Name$ scrllVwr��5      .��5   
   �  � ColumnDefinitions 5      �� 5      $��20 �6#   �� 5      �� 5      $��20 �6#   .+�5      �� $��1��6   $��Stretch=�6)   .+�5      &   MaterialDesignThemes.Wpf.Flipper  $��Center=�6)   $y�Visible=�6F      FrontContent 5      �� 5      .+�5      �� $	��500��6%   $��8q�61      FlipCommand#��Z 6<   $#��Физическое лицо��6t      MaterialDesignFlatButton#��[  6�   5         BackContent 5      �� 5      .+�5      �  � RowDefinitions 5       �� 5!   "   $
��Auto �60   �� 5"   "   $��* �60   .+�5%      (  "MaterialDesignThemes.Wpf.ColorZone  $��6q�67      Mode$ SecondaryMid=�6C   .��5&   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5'   &   �� $
��Left=�6-   #��Z 6H    & "MaterialDesignToolForegroundButton#��[ 6�   .��5(   *   '  !MaterialDesignThemes.Wpf.PackIcon  $��Right=�6B   	   Kind$	 	ArrowLeft=�6^   5)   '   �� 5*   &   $��30(�60   $��8,0,8,0q�6>   $��Center=�6O   $+��%Добавление физ. лица��6j   5+   #   5,      � 5.      $��1��6#   $	��500��60   $��Center=�6<   $	��Top=�6Y   .+�50   "   �� $ Vertical=�6-   .+�52   &   �� -   5        
 ��Name$
 errorPeopleStackPanel��52   1   $y�	Collapsed=�6P   $��Center=�53   1   .+�54   *     
���  ��
�������.  (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$	 Dp4=�56   C   $}�False��57   C      CornerRadius$ 	0,0,10,10��58   C   .��59   .   �� -   5         ��Name$ errorPeopleText��59   8   $2��,Не верно введены данные!��6Q   $��5q�6q   $��20(�5:   <   $��Center=�6J   5;   +   5<   '   �� 5>   &   $ 
Horizontal=�61   .+�5?   *   �� -   5         ��Name$ lastNameBox��5?   2   $��25(�5@   )   $	��140��67   $��15,5,5,5q�6F   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Фамилия��6X      
IsFloating$
 True��6�   �� 5A   *   -   5        $ nameBox��5A   2   $��25(�5B   )   $	��140��67   $��5q�6F   $ Имя��6Q   $
 True��6v   �� 5C   *   -   5        $ middleNameBox��5C   2   $��25(�5D   )   $	��140��67   $��5q�6F   $ Отчество��6Q   $
 True��6{   5E   '   �� 5G   &   $ 
Horizontal=�61   .+�5H   *   (  "System.Windows.Controls.DatePicker  -   5          Name$ birthdayBox��5H   5   $��25(�5I   1   $	��140��6?   $��15,5,5,5q�5J   1    � Language$ Ru-ru�5K   1   -  'MaterialDesignThemes.Wpf.CalendarAssist   IsHeaderVisible$
 True��5L   1   $
 True��5M   1   $ Дата рождения��5N   1   5O   '   �� 5Q   &   .+�5R   *   �� -   5        $ 
addressBox��5R   2   $��25(�5S   .   $	��140��6<   $��15,5,5,5q�6K   $ 
Адрес��5T   .   $
 True��5U   .   5V   '   �� 5X   &   $ 
Horizontal=�61   .+�5Z   *   %  Xceed.Wpf.Toolkit.MaskedTextBox  -	   5          Name$ telephonMaskBox��5Z   =      Mask$ +7 (000) 000-00-00��6V   $��15,5,5,5q�5[   9   $��25(�6K   $	��140��6Y   $! Номер телефона��5\   9   $
 True��5]   9    % !MaterialDesignFloatingHintTextBox#��[ 5^   9   �� 5`   *   -
   5        $ emailBox��5`   2   $��5q�5a   .   $��25(�69   $	��140��6G   $ email��5b   .   $
 True��5c   .   5e   '   �� 5g   &   $ 
Horizontal=�61   .+�5h   *   �� -   5         ��Name$  innChiefCompaniInPeopleBox��5h   3   $[��UЯвляется руководителем существующей компании��6W     MaterialDesignCheckBox#��[ 5i   /   $��20,0,0,5q�6_   6q   5j   '   �� 5l   &   $ 
Horizontal=�61   .+�5m   *     -   5        $% innChiefCompaniInPeopleMaskfBox��5m   =   $ 000000000000��6f   $y�	Collapsed=�6z   $��	15,2,2,10q�5n   =   $��25(�6P   $	��140��6^   $ ИНН��5o   =   $
 True��5p   =   #��[ 5q   =   5r   '   �� 5t   &   $ 
Horizontal=�61   .+�5u   *   �� -   5        $ innPeopleCheсkBox��5u   3   $��Уже имеет ИНН��6N   $��20,0,0,5q�5w   /   #��[ 5x   /   5y   '   �� 5{   &   $ 
Horizontal=�61   .+�5|   *     -   5        $ innPeopleMaskfBox��5|   =   $ 000000000000��6X   $y�	Collapsed=�6l   $��	15,2,2,10q�5}   9   $��25(�6L   $	��140��6Z   $ ИНН��5~   9   $
 True��5   9   #��[ 5�   9   5�   '   �� 5�   &   .+�5�   *   �� -   5         ��Name$ updatePeopleButton��5�   1   $��Сохранить��5�   1   $��Right=�5�   -   $��5q�6I    * &MaterialDesignFlatSecondaryMidBgButton#��[ 5�   -    � ToolTip$. (MaterialDesignFlatSecondaryLightBgButton��5�   -   {�5�   -   �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window5�   -   �� 5�   *   -   5        $
 updatePeopleStackPanel��5�   5   $y�	Collapsed=�6U   $ 
Horizontal=�5�   -   $��Right=�6F   .+�5�   .   � -   5         �Name$ updatePeopleProgressBar��5�   1   $��Right=�5�   1   $��5,5,5,5q�6M    � IsIndeterminate$
 True��5�   1    % !MaterialDesignCircularProgressBar#��[ 5�   1    � Value$ 55Q�5�   1   �� 5�   .   $��5,5,30,5q�5�   1   $��Сохранение��5�   1   $��Center=�5�   1   5�   +   5�   '   5�   #   5�      '	  !MaterialDesignThemes.Wpf.Snackbar	  5�      -   5         	 Name$! completedDataPeopleSnackBar��5�   6   $��20(�6[    	  IsActive$ False��6i     	  MessageF
  @MaterialDesignThemes.Wpf.Converters.SnackbarMessageTypeConverter$4  .Данные успешно сохранены
 6z   5�      5�      5�        5�      $��Center=�6)   $y�Visible=�6F    5�      �� 5�      $	��500��6!   $��8q�6-   #��Z 5�      $%��Юридическое лицо��5�      #��[  68    5�      � 5�       5�      �� 5�   "   $
��Auto �60   �� 5�   "   $��* �60   .+�5�        $��6q�67   $ SecondaryMid=�6C   .��5�   "   �� $ 
Horizontal=�6-   .+�5�   &   �� $
��Left=�6-   #��Z 6H   #��[ 6�   .��5�   *     $��Right=�6B   $	 	ArrowLeft=�6^   5�   '   �� 5�   &   $��30(�60   $��8,0,8,0q�6>   $��Center=�6O   $<��6Добавление юридического лица��6j   5�   #   5�      � 5�      $��1��6#   $	��500��60   $��Center=�6<   $	��Top=�6Y   .+�5�   "   �� $ Vertical=�6.   .+�5�   &   �� -   5        $
 errorCompaniStackPanel��5�   1   $y�	Collapsed=�6Q   $��Center=�5�   1   .+�5�   *     
���  ��
�������$	 Dp4=�5�   ?   $}�False��5�   ?   $ 	0,0,10,10��5�   ?   .��5�   .   �� -   5        $ errorCompaniText��5�   8   $2��,Не верно введены данные!��6R   $��5q�6r   $��20(�5�   8   $��Center=�6F   5�   +   5�   '   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� -   5        $ nameCompaniBox��5�   2   $��15,5,5,5q�5�   .   $��25(�6@   $	��140��6N   $ Название��5�   .   $
 True��5�   .   5�   '   �� 5�   &   .+�5�   *   �� -   5        $ addressCompaniBox��5�   2   $��15,5,5,5q�5�   2   $��25(�6D   $	��140��6R   $ 
Адрес��5�   2   $
 True��5�   2   5�   '   �� 5�   &   $ 
Horizontal=�61   .+�5�   *     -   5        $ telephoneCompaniMaskBox��5�   =   $ +7 (000) 000-00-00��6^   $��15,5,5,5q�5�   9   $��25(�6K   $	��140��6Y   $! Номер телефона��5�   9   $
 True��5�   9   #��[ 5�   9   �� 5�   *   -   5        $ emailCompaniBox��5�   2   $��5q�5�   .   $��25(�69   $	��140��6G   $ email��5�   .   $
 True��5�   .   5�   '   �� 5�   &   $ 
Horizontal=�61   .+�5�   *     -   5        $ innChiefCompaniMaskfBox��5�   =   $ 000000000000��6^   $��	15,2,2,10q�5�   =   $��25(�6P   $	��140��6^   $% ИНН руководителя��5�   =   $
 True��5�   =   #��[ 5�   =   5�   '   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� -   5        $ innCompaniCheсkBox��5�   3   $��Уже имеет ИНН��6O   $��20,0,0,5q�5�   3   #��[ 5�   3   5�   '   �� 5�   &   $ 
Horizontal=�61   .+�5�   *     -   5        $ innCompaniMaskfBox��5�   =   $ 000000000000��6Y   $y�	Collapsed=�6m   $��	15,2,2,10q�5�   =   $��25(�6P   $	��140��6^   $ ИНН��5�   =   $
 True��5�   =   #��[ 5�   =   5�   '   �� 5�   &   .+�5�   *   �� -   5        $ updateCompaniButton��5�   1   $��Right=�5   -   $��Сохранить��5  -   $��5q�6A   #��[ 5  -   $. (MaterialDesignFlatSecondaryLightBgButton��5  -   {�5  -   �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window5  -   �� 5  *   -   5        $
 updateCompaniStackPanel��5  5   $y�	Collapsed=�6V   $ 
Horizontal=�5  5   $��Right=�6N   .+�5  .   � -   5        $ updateCompaniProgressBar��5  :   $��Right=�5	  9   $��5,5,5,5q�6U   $
 True��5
  9   #��[ 5  9   $ 55Q�5  9   �� 5  .   $��5,5,30,5q�68   $��Сохранение��5  8   $��Center=�5  8   5  +   5  '   5  #   5     	  5     -   5        $" completedDataCompaniSnackBar��5  6   $��20(�6\   $ False��6j   $4  .Данные успешно сохранены
 6{   5     5       5     $��Center=�6)   $y�Visible=�6F    5     �� 5     $��Недвижимость��6!   $	��500��5  !   $��8q�6-   #��Z 5  !   #��[  5   !    5#     � 5$      5&     �� 5'  "   $
��Auto �60   �� 5(  "   $��* �60   .+�5+       $��6q�67   $ SecondaryMid=�6C   .��5,  "   �� $ 
Horizontal=�6-   .+�5-  &   �� $
��Left=�6-   #��Z 6H   #��[ 6�   .��5.  *     $��Right=�6B   $	 	ArrowLeft=�6^   5/  '   �� 50  &   $��30(�60   $��8,0,8,0q�6>   $��Center=�6O   $3��-Добавление недвижимости��6j   51  #   52     � 54     $��1��6#   $	��500��60   $��Center=�6<   $	��Top=�6Y   .+�56  "   �� $ Vertical=�6-   .+�58  &   �� -    5        $
 errorPropertyStackPanel��58  1   $y�	Collapsed=�6R   $��Center=�59  1   .+�5:  *     
���  ��
�������$	 Dp4=�5<  C   $}�False��5=  C   $ 	0,0,10,10��5>  C   .��5?  .   �� -!   5        $ errorPropertyText��5?  8   $2��,Не верно введены данные!��6S   $��5q�6s   $��20(�5@  8   $��Center=�6F   5A  +   5B  '   �� 5D  &   $ 
Horizontal=�61   .+�5F  *     -"   5        $ innOwnerPropertyMaskBox��5F  =   $ 000000000000��6^   $��15,5,5,5q�5G  =   $��25(�6O   $	��140��6]   $ ИНН владельца��5H  =   $
 True��5I  =   #��[ 5J  =   5L  '   �� 5N  &   .+�5O  *   �� -#   5        $ addressPropertyBox��5O  2   $��15,5,5,5q�5P  2   $��25(�6D   $	��140��6R   $ 
Адрес��5Q  2   $
 True��5R  2   5S  '   �� 5U  &   $ 
Horizontal=�61   .+�5V  *   �� -$   5        $ typePropertyBox��5V  2   $��15,5,5,5q�5W  2   $��25(�6D   $	��140��6R   $ Тип��5X  2   $
 True��5Y  2   5[  '   �� 5]  &   $ 
Horizontal=�61   .+�5_  *   �� -%   5        $ sizePropertyBox��5_  2   $��15,5,5,5q�5`  2   $��25(�6D   $	��140��6R   &    NumberBox.NumericTextBoxBehavior!   	IsNumeric$
! True��5b  2   $ Площадь��5c  2   $
 True��5d  2   ��5a  2   �� *	NumberBox+5d  2   �� 5f  *   -&   5        $ prisePropertyBox��5f  2   $��5q�5g  2   $��25(�6=   $	��140��6K   $
! True��5i  2   $ Стоимость��5j  2   $
 True��5k  2   ��5h  2   �� *	NumberBox+5k  2   5m  '   �� 5o  &   .+�5p  *   �� -'   5        $ updatePropertyButton��5p  1   $��Right=�5r  1   $��Сохранить��5s  1   $��5q�6E   #��[ 5u  1   $. (MaterialDesignFlatSecondaryLightBgButton��5v  1   {�5t  1   �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window5v  1   �� 5x  *   -(   5        $
 updatePropertyStackPanel��5x  5   $y�	Collapsed=�6W   $ 
Horizontal=�5y  5   $��Right=�6N   .+�5z  .   � -)   5        $ updatePropertyProgressBar��5z  :   $��Right=�5{  9   $��5,5,5,5q�6U   $
 True��5|  9   #��[ 5}  9   $ 55Q�5~  9   �� 5  .   $��5,5,30,5q�68   $��Сохранение��5�  8   $��Center=�5�  8   5�  +   5�  '   5�  #   5�     	  5�     -*   5        $# completedDataPropertySnackBar��5�  6   $��20(�6]   $ False��6k   $4  .Данные успешно сохранены
 6|   5�     5�       5�     $��Center=�6)   $y�Visible=�6F    5�     �� 5�     $/��)Транспортные средства��6!   $	��500��5�  !   $��8q�6-   #��Z 5�  !   #��[  5�  !    5�     � 5�      5�     �� 5�  "   $
��Auto �60   �� 5�  "   $��* �60   .+�5�       $��6q�67   $ SecondaryMid=�6C   .��5�  "   �� $ 
Horizontal=�6-   .+�5�  &   �� $
��Left=�6-   #��Z 6H   #��[ 6�   .��5�  *     $��Right=�6B   $	 	ArrowLeft=�6^   5�  '   �� 5�  &   $��30(�60   $��8,0,8,0q�6>   $��Center=�6O   $��Добавление ТС��6j   5�  #   5�     � 5�     $��1��6#   $	��500��60   $��Center=�6<   $	��Top=�6Y   .+�5�  "   �� $ Vertical=�6-   .+�5�  &   �� -+   5        $
 errorTransportStackPanel��5�  1   $y�	Collapsed=�6S   $��Center=�5�  1   .+�5�  *     
���  ��
�������$	 Dp4=�5�  C   $}�False��5�  C   $ 	0,0,10,10��5�  C   .��5�  .   �� -,   5        $ errorTransportText��5�  8   $2��,Не верно введены данные!��6T   $��5q�6t   $��20(�5�  8   $��Center=�6F   5�  +   5�  '   �� 5�  &   $ 
Horizontal=�61   .+�5�  *     --   5        $ innOwnerTransportMaskBox��5�  =   $ 000000000000��6_   $��15,5,5,5q�5�  -   $��25(�6?   $	��140��6M   $ ИНН владельца��5�  -   $
 True��5�  -   #��[ 5�  -   5�  '   �� 5�  &   $ 
Horizontal=�61   .+�5�  *   �� -.   5        $ brandTransportBox��5�  2   $��15,5,5,5q�5�  2   $��25(�6D   $	��140��6R   $ 
Марка��5�  2   $
 True��5�  2   �� 5�  *   -/   5        $ modelTransportBox��5�  2   $��5q�5�  2   $��25(�6=   $	��140��6K   $ Модель��5�  2   $
 True��5�  2   5�  '   �� 5�  &   .+�5�  *   �� -0   5        $ typeTransportBox��5�  2   $��15,5,5,5q�5�  2   $��25(�6D   $	��140��6R   $ Тип��5�  2   $
 True��5�  2   5�  '   �� 5�  &   $ 
Horizontal=�61   .+�5�  *   �� -1   5        $ priseTransportBox��5�  2   $��15,5,5,5q�5�  2   $��25(�6D   $	��140��6R   $
! True��5�  2   $ Стоимость��5�  2   $
 True��5�  2   ��5�  2   �� *	NumberBox+5�  2   �� 5�  *   -2   5        $ yearTransportBox��5�  2   $��5q�5�  2   $��25(�6=   $	��140��6K   $% Год производства��5�  2   $
 True��5�  2   5�  '   �� 5�  &   .+�5�  *   �� -3   5        $ updateTransportButton��5�  1   $��Right=�5�  1   $��Сохранить��5�  1   $��5q�6E   #��[ 5�  1   $. (MaterialDesignFlatSecondaryLightBgButton��5�  1   {�5�  1   �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window5�  1   �� 5�  *   -4   5        $
 updateTransportStackPanel��5�  5   $y�	Collapsed=�6X   $ 
Horizontal=�5�  5   $��Right=�6N   .+�5�  .   � -5   5        $  updateTransportProgressBar��5�  :   $��Right=�5�  9   $��5,5,5,5q�6U   $
 True��5�  9   #��[ 5�  9   $ 55Q�5�  9   �� 5�  .   $��5,5,30,5q�68   $��Сохранение��5�  8   $��Center=�5�  8   5�  +   5�  '   5�  #   5�     	  5�     -6   5        $$ completedDataTransportSnackBar��5�  6   $��20(�6^   $ False��6l   $4  .Данные успешно сохранены
 6}   5�     5       5     $��Center=�6)   $y�Visible=�6F    5     �� 5     $��Налоги��6!   $	��500��5  !   $��8q�6-   #��Z 5	  !   #��[  5
  !    5     � 5      5     �� 5  "   $
��Auto �60   �� 5  "   $��* �60   .+�5       $��6q�67   $ SecondaryMid=�6C   .��5  "   �� $ 
Horizontal=�6-   .+�5  &   �� $
��Left=�6-   #��Z 6H   #��[ 6�   .��5  *     $��Right=�6B   $	 	ArrowLeft=�6^   5  '   �� 5  &   $��30(�60   $��8,0,8,0q�6>   $��Center=�6O   $'��!Добавление налога��6j   5  #   5     � 5     $��1��6#   $	��500��60   $��Center=�6<   $	��Top=�6Y   .+�5  "   �� $ Vertical=�6-   .+�5!  &   �� -7   5        $
 errorTaxStackPanel��5!  1   $y�	Collapsed=�6M   $��Center=�5"  1   .+�5#  *     
���  ��
�������$	 Dp4=�5%  C   $}�False��5&  C   $ 	0,0,10,10��5'  C   .��5(  .   �� -8   5        $ errorTaxText��5(  8   $2��,Не верно введены данные!��6N   $��5q�6n   $��20(�5)  8   $��Center=�6F   5*  +   5+  '   �� 5-  &   $ 
Horizontal=�61   .+�5.  *     -9   5        $ innOwnerTaxMaskBox��5.  =   $ 000000000000��6Y   $��15,5,5,5q�5/  =   $��25(�6O   $	��140��6]   $ ИНН��50  =   $
 True��51  =   #��[ 52  =   54  '   �� 56  &   $ 
Horizontal=�61   .+�58  *   �� -:   5        $ 	sumTaxBox��58  2   $��15,5,5,5q�59  2   $��25(�6D   $	��140��6R   $
! True��5;  2   $ 
Сумма��5<  2   $
 True��5=  2   ��5:  2   �� *	NumberBox+5=  2   �� 5?  *   -;   5        $ statusTaxBox��5?  2   $��5q�5@  2   $��25(�6=   $	��140��6K   $ Статус��5A  2   $
 True��5B  2   5D  '   �� 5F  &   $ 
Horizontal=�61   .+�5G  *     -<   5        $ dataTaxPicker��5G  5   $��25(�5H  5   $	��140��6C   $��15,5,5,5q�5I  5   $ Ru-ru�5J  5   $
 True��5K  5   $
 True��5L  5   $, &Дата создания налога��5M  5   5N  '   �� 5P  &   .+�5Q  *   �� -=   5        $ 
typeTaxBox��5Q  2   $��15,5,5,5q�5R  2   $��25(�6D   $	��140��6R   $ Тип��5S  2   $
 True��5T  2   5U  '   �� 5W  &   .+�5X  *   �� ->   5        $ updateTaxButton��5X  1   $��Right=�5Y  1   $��Сохранить��5Z  1   $��5q�6E   #��[ 5\  1   $. (MaterialDesignFlatSecondaryLightBgButton��5]  1   {�5[  1   �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window5]  1   �� 5^  *   -?   5        $
 updateTaxStackPanel��5^  5   $y�	Collapsed=�6R   $ 
Horizontal=�5_  5   $��Right=�6N   .+�5`  .   � -@   5        $ updateTaxProgressBar��5`  :   $��Right=�5a  9   $��5,5,5,5q�6U   $
 True��5b  9   #��[ 5c  9   $ 55Q�5d  9   �� 5e  .   $��5,5,30,5q�68   $��Сохранение��5f  8   $��Center=�5g  8   5h  +   5i  '   5k  #   5l     	  5m     -A   5        $ completedDataTaxSnackBar��5m  6   $��20(�6X   $ False��6f   $4  .Данные успешно сохранены
 6w   5n     5p     5r     5t     5u     5v     