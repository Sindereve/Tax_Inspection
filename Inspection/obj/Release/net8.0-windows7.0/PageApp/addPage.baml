   M S B A M L   `   `   `  ���� E  AInspection, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Inspection.PageAppInspection.PageApp  %clr-namespace:NumberBox	NumberBox       Inspection.PageApp.addPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:Inspection.PageApp     -	behaviorsclr-namespace:NumberBox     _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  ] YXceed.Wpf.Toolkit.NET5, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    N� Title$  addPage��.���� -    ��Name$ scrllVwr��.���  � ColumnDefinitions �� $��20 ��� �� $��20 �.+��� $��1��$��Stretch=�.+�&   MaterialDesignThemes.Wpf.Flipper  $��Center=�$y�Visible=�   FrontContent �� .+��� $	��500��$��8q�   FlipCommand#��Z $#��Физическое лицо��   MaterialDesignFlatButton#��[     BackContent �� .+��  � RowDefinitions �� $
��Auto ��� $��* �.+�(  "MaterialDesignThemes.Wpf.ColorZone  $��6q�   Mode$ SecondaryMid=�.����  �� Orientation$ 
Horizontal=�.+��� $
��Left=�#��Z  & "MaterialDesignToolForegroundButton#��[ .��'  !MaterialDesignThemes.Wpf.PackIcon  $��Right=�	   Kind$	 	ArrowLeft=��� $��30(�$��8,0,8,0q�$��Center=�$+��%Добавление физ. лица��� $��1��$	��500��$��Center=�$	��Top=�.+��� $ Vertical=�.+��� -   
 ��Name$
 errorPeopleStackPanel��$y�	Collapsed=�$��Center=�.+�  
���  ��
�������.  (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$	 Dp4=�$}�False��   CornerRadius$ 	0,0,10,10��.���� -    ��Name$ errorPeopleText��$2��,Не верно введены данные!��$��5q�$��20(�$��Center=��� $ 
Horizontal=�.+��� -    ��Name$ lastNameBox��$��25(�$	��140��$��15,5,5,5q�)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Фамилия��   
IsFloating$
 True���� -   $ nameBox��$��25(�$	��140��$��5q�$ Имя��$
 True���� -   $ middleNameBox��$��25(�$	��140��$��5q�$ Отчество��$
 True���� $ 
Horizontal=�.+�(  "System.Windows.Controls.DatePicker  -     Name$ birthdayBox��$��25(�$	��140��$��15,5,5,5q� � Language$ Ru-ru�-  'MaterialDesignThemes.Wpf.CalendarAssist   IsHeaderVisible$
 True��$
 True��$ Дата рождения���� .+��� -   $ 
addressBox��$��25(�$	��140��$��15,5,5,5q�$ 
Адрес��$
 True���� $ 
Horizontal=�.+�%  Xceed.Wpf.Toolkit.MaskedTextBox  -	     Name$ telephonMaskBox��   Mask$ +7 (000) 000-00-00��$��15,5,5,5q�$��25(�$	��140��$! Номер телефона��$
 True�� % !MaterialDesignFloatingHintTextBox#��[ �� -
   $ emailBox��$��5q�$��25(�$	��140��$ email��$
 True���� $ 
Horizontal=�.+��� -    ��Name$  innChiefCompaniInPeopleBox��$[��UЯвляется руководителем существующей компании��  MaterialDesignCheckBox#��[ $��20,0,0,5q��� $ 
Horizontal=�.+�  -   $% innChiefCompaniInPeopleMaskfBox��$ 000000000000��$y�	Collapsed=�$��	15,2,2,10q�$��25(�$	��140��$ ИНН��$
 True��#��[ �� $ 
Horizontal=�.+��� -   $ innPeopleCheсkBox��$��Уже имеет ИНН��$��20,0,0,5q�#��[ �� $ 
Horizontal=�.+�  -   $ innPeopleMaskfBox��$ 000000000000��$y�	Collapsed=�$��	15,2,2,10q�$��25(�$	��140��$ ИНН��$
 True��#��[ �� .+��� -    ��Name$ updatePeopleButton��$��Сохранить��$��Right=�$��5q� * &MaterialDesignFlatSecondaryMidBgButton#��[  � ToolTip$. (MaterialDesignFlatSecondaryLightBgButton��{��� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window�� -   $
 updatePeopleStackPanel��$y�	Collapsed=�$ 
Horizontal=�$��Right=�.+�� -    �Name$ updatePeopleProgressBar��$��Right=�$��5,5,5,5q� � IsIndeterminate$
 True�� % !MaterialDesignCircularProgressBar#��[  � Value$ 55Q��� $��5,5,30,5q�$��Сохранение��$��Center=�'	  !MaterialDesignThemes.Wpf.Snackbar	  -    	 Name$! completedDataPeopleSnackBar��$��20(� 	  IsActive$ False��  	  MessageF
  @MaterialDesignThemes.Wpf.Converters.SnackbarMessageTypeConverter$4  .Данные успешно сохранены
   $��Center=�$y�Visible=� �� $	��500��$��8q�#��Z $%��Юридическое лицо��#��[   �  �� $
��Auto ��� $��* �.+�  $��6q�$ SecondaryMid=�.���� $ 
Horizontal=�.+��� $
��Left=�#��Z #��[ .��  $��Right=�$	 	ArrowLeft=��� $��30(�$��8,0,8,0q�$��Center=�$<��6Добавление юридического лица��� $��1��$	��500��$��Center=�$	��Top=�.+��� $ Vertical=�.+��� -   $
 errorCompaniStackPanel��$y�	Collapsed=�$��Center=�.+�  
���  ��
�������$	 Dp4=�$}�False��$ 	0,0,10,10��.���� -   $ errorCompaniText��$2��,Не верно введены данные!��$��5q�$��20(�$��Center=��� $ 
Horizontal=�.+��� -   $ nameCompaniBox��$��15,5,5,5q�$��25(�$	��140��$ Название��$
 True���� .+��� -   $ addressCompaniBox��$��15,5,5,5q�$��25(�$	��140��$ 
Адрес��$
 True���� $ 
Horizontal=�.+�  -   $ telephoneCompaniMaskBox��$ +7 (000) 000-00-00��$��15,5,5,5q�$��25(�$	��140��$! Номер телефона��$
 True��#��[ �� -   $ emailCompaniBox��$��5q�$��25(�$	��140��$ email��$
 True���� $ 
Horizontal=�.+�  -   $ innChiefCompaniMaskfBox��$ 000000000000��$��	15,2,2,10q�$��25(�$	��140��$% ИНН руководителя��$
 True��#��[ �� $ 
Horizontal=�.+��� -   $ innCompaniCheсkBox��$��Уже имеет ИНН��$��20,0,0,5q�#��[ �� $ 
Horizontal=�.+�  -   $ innCompaniMaskfBox��$ 000000000000��$y�	Collapsed=�$��	15,2,2,10q�$��25(�$	��140��$ ИНН��$
 True��#��[ �� .+��� -   $ updateCompaniButton��$��Right=�$��Сохранить��$��5q�#��[ $. (MaterialDesignFlatSecondaryLightBgButton��{��� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window�� -   $
 updateCompaniStackPanel��$y�	Collapsed=�$ 
Horizontal=�$��Right=�.+�� -   $ updateCompaniProgressBar��$��Right=�$��5,5,5,5q�$
 True��#��[ $ 55Q��� $��5,5,30,5q�$��Сохранение��$��Center=�	  -   $" completedDataCompaniSnackBar��$��20(�$ False��$4  .Данные успешно сохранены
   $��Center=�$y�Visible=� �� $��Недвижимость��$	��500��$��8q�#��Z #��[   �  �� $
��Auto ��� $��* �.+�  $��6q�$ SecondaryMid=�.���� $ 
Horizontal=�.+��� $
��Left=�#��Z #��[ .��  $��Right=�$	 	ArrowLeft=��� $��30(�$��8,0,8,0q�$��Center=�$3��-Добавление недвижимости��� $��1��$	��500��$��Center=�$	��Top=�.+��� $ Vertical=�.+��� -    $
 errorPropertyStackPanel��$y�	Collapsed=�$��Center=�.+�  
���  ��
�������$	 Dp4=�$}�False��$ 	0,0,10,10��.���� -!   $ errorPropertyText��$2��,Не верно введены данные!��$��5q�$��20(�$��Center=��� $ 
Horizontal=�.+�  -"   $ innOwnerPropertyMaskBox��$ 000000000000��$��15,5,5,5q�$��25(�$	��140��$ ИНН владельца��$
 True��#��[ �� .+��� -#   $ addressPropertyBox��$��15,5,5,5q�$��25(�$	��140��$ 
Адрес��$
 True���� $ 
Horizontal=�.+��� -$   $ typePropertyBox��$��15,5,5,5q�$��25(�$	��140��$ Тип��$
 True���� $ 
Horizontal=�.+��� -%   $ sizePropertyBox��$��15,5,5,5q�$��25(�$	��140��&    NumberBox.NumericTextBoxBehavior!   	IsNumeric$
! True��$ Площадь��$
 True������ *	NumberBox+�� -&   $ prisePropertyBox��$��5q�$��25(�$	��140��$
! True��$ Стоимость��$
 True������ *	NumberBox+�� .+��� -'   $ updatePropertyButton��$��Right=�$��Сохранить��$��5q�#��[ $. (MaterialDesignFlatSecondaryLightBgButton��{��� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window�� -(   $
 updatePropertyStackPanel��$y�	Collapsed=�$ 
Horizontal=�$��Right=�.+�� -)   $ updatePropertyProgressBar��$��Right=�$��5,5,5,5q�$
 True��#��[ $ 55Q��� $��5,5,30,5q�$��Сохранение��$��Center=�	  -*   $# completedDataPropertySnackBar��$��20(�$ False��$4  .Данные успешно сохранены
   $��Center=�$y�Visible=� �� $/��)Транспортные средства��$	��500��$��8q�#��Z #��[   �  �� $
��Auto ��� $��* �.+�  $��6q�$ SecondaryMid=�.���� $ 
Horizontal=�.+��� $
��Left=�#��Z #��[ .��  $��Right=�$	 	ArrowLeft=��� $��30(�$��8,0,8,0q�$��Center=�$��Добавление ТС��� $��1��$	��500��$��Center=�$	��Top=�.+��� $ Vertical=�.+��� -+   $
 errorTransportStackPanel��$y�	Collapsed=�$��Center=�.+�  
���  ��
�������$	 Dp4=�$}�False��$ 	0,0,10,10��.���� -,   $ errorTransportText��$2��,Не верно введены данные!��$��5q�$��20(�$��Center=��� $ 
Horizontal=�.+�  --   $ innOwnerTransportMaskBox��$ 000000000000��$��15,5,5,5q�$��25(�$	��140��$ ИНН владельца��$
 True��#��[ �� $ 
Horizontal=�.+��� -.   $ brandTransportBox��$��15,5,5,5q�$��25(�$	��140��$ 
Марка��$
 True���� -/   $ modelTransportBox��$��5q�$��25(�$	��140��$ Модель��$
 True���� .+��� -0   $ typeTransportBox��$��15,5,5,5q�$��25(�$	��140��$ Тип��$
 True���� $ 
Horizontal=�.+��� -1   $ priseTransportBox��$��15,5,5,5q�$��25(�$	��140��$
! True��$ Стоимость��$
 True������ *	NumberBox+�� -2   $ yearTransportBox��$��5q�$��25(�$	��140��$% Год производства��$
 True���� .+��� -3   $ updateTransportButton��$��Right=�$��Сохранить��$��5q�#��[ $. (MaterialDesignFlatSecondaryLightBgButton��{��� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window�� -4   $
 updateTransportStackPanel��$y�	Collapsed=�$ 
Horizontal=�$��Right=�.+�� -5   $  updateTransportProgressBar��$��Right=�$��5,5,5,5q�$
 True��#��[ $ 55Q��� $��5,5,30,5q�$��Сохранение��$��Center=�	  -6   $$ completedDataTransportSnackBar��$��20(�$ False��$4  .Данные успешно сохранены
   $��Center=�$y�Visible=� �� $��Налоги��$	��500��$��8q�#��Z #��[   �  �� $
��Auto ��� $��* �.+�  $��6q�$ SecondaryMid=�.���� $ 
Horizontal=�.+��� $
��Left=�#��Z #��[ .��  $��Right=�$	 	ArrowLeft=��� $��30(�$��8,0,8,0q�$��Center=�$'��!Добавление налога��� $��1��$	��500��$��Center=�$	��Top=�.+��� $ Vertical=�.+��� -7   $
 errorTaxStackPanel��$y�	Collapsed=�$��Center=�.+�  
���  ��
�������$	 Dp4=�$}�False��$ 	0,0,10,10��.���� -8   $ errorTaxText��$2��,Не верно введены данные!��$��5q�$��20(�$��Center=��� $ 
Horizontal=�.+�  -9   $ innOwnerTaxMaskBox��$ 000000000000��$��15,5,5,5q�$��25(�$	��140��$ ИНН��$
 True��#��[ �� $ 
Horizontal=�.+��� -:   $ 	sumTaxBox��$��15,5,5,5q�$��25(�$	��140��$
! True��$ 
Сумма��$
 True������ *	NumberBox+�� -;   $ statusTaxBox��$��5q�$��25(�$	��140��$ Статус��$
 True���� $ 
Horizontal=�.+�  -<   $ dataTaxPicker��$��25(�$	��140��$��15,5,5,5q�$ Ru-ru�$
 True��$
 True��$, &Дата создания налога���� .+��� -=   $ 
typeTaxBox��$��15,5,5,5q�$��25(�$	��140��$ Тип��$
 True���� .+��� ->   $ updateTaxButton��$��Right=�$��Сохранить��$��5q�#��[ $. (MaterialDesignFlatSecondaryLightBgButton��{��� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window�� -?   $
 updateTaxStackPanel��$y�	Collapsed=�$ 
Horizontal=�$��Right=�.+�� -@   $ updateTaxProgressBar��$��Right=�$��5,5,5,5q�$
 True��#��[ $ 55Q��� $��5,5,30,5q�$��Сохранение��$��Center=�	  -A   $ completedDataTaxSnackBar��$��20(�$ False��$4  .Данные успешно сохранены
 