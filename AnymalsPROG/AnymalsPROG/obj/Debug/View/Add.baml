   M S B A M L   `   `   `  ����F  BAnymalsPROG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AnymalsPROG.ViewAnymalsPROG.View  5   	   =#clr-namespace:AnymalsPROG.ViewModelAnymalsPROG.ViewModel  5   	       AnymalsPROG.View.Add   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:AnymalsPROG.View     5   	   2dc#clr-namespace:AnymalsPROG.ViewModel     5   	     � Title$-  'Добавление животного��5	   	   $	��324��6&   $	��400��63    � DataContext 5
      (  "AnymalsPROG.ViewModel.AddViewModel  5   
   .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      .+�5   
   �� $��Класс:��6   $��Center=�6"   �� 5   
   $��1��6   $��Тип:��6!   $��Center=�6-   �� 5   
   $��2��6   $��Имя:��6!   $��Center=�6-   �� 5   
   $��3��6   $ ��Дата рождения:��6!   $��Center=�67   �� 5   
   $��4��6   $��	Цвет:��6!   $��Center=�6.   �� 5!   
   -   5        $��SelectClass��5!      $��30��6&   $��0��62   $��1��6?   ��6O   �� *animalClesses+ �� SelectedValue 6u   �� *SelectedClass+��5"      �� 5#      .R�5$      �� ��6    �� *Value+5%      5'      �� 5(   
   $��1��6   $��30��6    $��1��6,   ��6<   �� *
animalType+ 6_   �� *SelectedType+��5)      �� 5*       �� 
TargetType" ��6   .�5+      ��  �� Property � {� �� Value . 62    �� Triggers 5,      �� 5-      	 �� Binding	 6&   �� 
 �� ElementName$
 SelectClass�� �� Path$ SelectedIndex� �� Value -16f   .a�5.      ��  � {� .  6:   5/      51      ��53      �� 54      .R�55      �� ��6    �� *Value+56      58      �� 59   
   $��2��6   $��1��6   $��30��6/   ��6;   �� *Name+(  "System.Windows.Controls.DatePicker  5:   
   $��3��6   $��1��6"   $��30��62      SelectedDate 6>   �� *
Birthday+�� 5;   
   $��4��6   $��1��6    $��30��60   ��6<   �� *	ColorList+ 6^   �� *SelectedColor+��5<      �� 5=      .R�5>      �� ��6    �� *Value+5?      5A      �� 5C   
   $��5��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��Right=�6K   $��Bottom=�6g   .+�5D      �� $��5q�6   $	��100��6    $��30��6,   ��68   �� *Create+��6T   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" �.��6�   Создать6�   �� 5E      $��5q�6   $	��100��6    $��30��6,   ��68   �� *Close+��6R   ��  �� $ FindAncestor=�" �.��6�   Отмена6�   5F      5G      5H      