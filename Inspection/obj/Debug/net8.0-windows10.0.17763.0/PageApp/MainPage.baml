   M S B A M L   `   `   `  ����E  AInspection, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Inspection
Inspection  5      !    Inspection.PageApp.MainPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Inspection     5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  MainPage��5
      .��5      �  � RowDefinitions 5   
   �� 5      $	��130 �6   �� 5      $	��950 �6   .+�5   
   � $��0��6   $��2��6   .+�5      (  "MaterialDesignThemes.Wpf.ColorZone  $��16q�6'      Mode$ 
PrimaryMid=�64   $��Stretch=�6F   $��Stretch=�6d   .��5      � .+�5      � $��Center=�6   $��Center=�68   .+�5      �� $
��Left=�6(   $��80(�6>   $��Center=�6L   $��Center=�6g   $-��'Рабочее пространство��5   $   5      � 5      $��Right=�6   $��Stretch=�67    � ColumnDefinitions 5       �� 5!      �� 5"      .+�5&      �� -   5         /  +MaterialDesignFloatingActionSecondaryButton#��[  5'   !    � ToolTip$1 +MaterialDesignFloatingActionSecondaryButton��5(   !   $��0��6W    � Cursor$
 Hand��6g   {�5&   !   �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window.��5)      '  !MaterialDesignThemes.Wpf.PackIcon  -   5          Name$ ThemeButtonIcon��5)   6   $��Center=�6O   	   Kind$	 LampOutline=�5*   !   $��40��64   $��40��6?   5+      '  !MaterialDesignThemes.Wpf.PopupBox  5.      $��1��62   
   PlacementMode$
 BottomAndAlignRightEdges=�6B      PopupContent. 5/      �� .@�50   "   �� -   5         ��Name$ 	loginUser��50   ,   $$��Login пользователя��6?   �� 51   "   -   5        .��52   &   �� $-��'Сменить пользователя��60   53   #   �� 54   "   -   5        .��55   &   �� $��
Выход��60   56   #   57      58      59      5<      5>      5?      � 5A   
   $��1��6   .+�5B      #  MaterialDesignThemes.Wpf.Card  .��5C      �� -   5         ��Name$ MainMenu��5C      3  -MaterialDesignThemes.Wpf.NavigationRailAssist   ShowSelectionBackground$
 True��6/    J� SnapsToDevicePixels$
 True��6r    * &MaterialDesignNavigationRailTabControl#��[ 6�    �� TabStripPlacement$
 Left=�6�   .@�5D      �� ��5E      �� 5F      $
��auto��6)   $
��auto��66   .+�5G   "     $��24��6:   $��24��6E   $��Center=�6Q   $	 Magnify=�6n   �� 5H   "   $��Center=�6,   $��
Поиск��6I   $��5q�6V   5I      .��5K      � .+�5L       � -   5          �Name$ 
searchPage��5L   $   $��Stretch=�68   5M      5N      �� 5P      ��5Q      �� 5R      $
��auto��6)   $
��auto��66   .+�5S   "     $��24��6:   $��24��6E   $��Center=�6Q   $	 
PlusCircle=�6n   �� 5T   "   $��Center=�6,   $��11(�6I   $��Добавление��6W   $��5q�6i   5U      .��5W      �� .+�5X       � -   5        $ addPage��5X   $   $��Stretch=�65   5Y      5Z      �� 5\      ��5]      �� 5^      $
��auto��6)   $
��auto��66   .+�5_   "     $��24��6:   $��24��6E   $��Center=�6Q   $	 
CogOutline=�6n   �� 5`   "   $��Center=�6,   $��11(�6I   $��Настройки��6W   $��5q�6h   5a      .��5c      �� 5e      5f      5i      5j      5k      5n      5o      