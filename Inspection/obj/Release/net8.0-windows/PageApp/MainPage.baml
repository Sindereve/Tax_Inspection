   M S B A M L   `   `   `  ���� E  AInspection, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Inspection
Inspection  !    Inspection.PageApp.MainPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:Inspection     _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    N� Title$  MainPage��.���  � RowDefinitions �� $	��130 ��� $	��950 �.+�� $��0��$��2��.+�(  "MaterialDesignThemes.Wpf.ColorZone  $��16q�   Mode$ 
PrimaryMid=�$��Stretch=�$��Stretch=�.��� .+�� $��Center=�$��Center=�.+��� $
��Left=�$��80(�$��Center=�$��Center=�$-��'Рабочее пространство��� $��Right=�$��Stretch=� � ColumnDefinitions �� �� .+��� -    /  +MaterialDesignFloatingActionSecondaryButton#��[   � ToolTip$1 +MaterialDesignFloatingActionSecondaryButton��$��0�� � Cursor$
 Hand��{��� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window.��'  !MaterialDesignThemes.Wpf.PackIcon  -     Name$ ThemeButtonIcon��$��Center=�	   Kind$	 LampOutline=�$��40��$��40��'  !MaterialDesignThemes.Wpf.PopupBox  $��1��
   PlacementMode$
 BottomAndAlignRightEdges=�   PopupContent. �� .@��� -    ��Name$ 	loginUser��$$��Login пользователя���� -   .���� $-��'Сменить пользователя���� -   .���� $��
Выход��� $��1��.+�#  MaterialDesignThemes.Wpf.Card  .���� -    ��Name$ MainMenu��3  -MaterialDesignThemes.Wpf.NavigationRailAssist   ShowSelectionBackground$
 True�� J� SnapsToDevicePixels$
 True�� * &MaterialDesignNavigationRailTabControl#��[  �� TabStripPlacement$
 Left=�.@��� $��70������ $
��auto��$
��auto��.+�  $��24��$��24��$��Center=�$	 Magnify=��� $��Center=�$��
Поиск��$��5q�.��� .+� � -     �Name$ 
searchPage��$��Stretch=��� ���� $
��auto��$
��auto��.+�  $��24��$��24��$��Center=�$	 
PlusCircle=��� $��Center=�$��11(�$��Добавление��$��5q�.���� .+� � -   $ addPage��$	��950��$��Stretch=��� ���� $
��auto��$
��auto��.+�  $��24��$��24��$��Center=�$	 InformationVariantCircle=��� $��Center=�$��11(�$��0,5,0,5q� �� TextAlignment$ Center=�
Поиск�� по ИНН.���� .+� � -	   $ searchForINN��$	��950��$��Stretch=��� ���� $
��auto��$
��auto��.+�  $��24��$��24��$��Center=�$		 ABC=��� $��Center=�$��11(�$��0,5,0,5q�$ Center=�
Инфо�� о программе.���� .+� � -
   $ infoProm��$	��950��$��Stretch=�