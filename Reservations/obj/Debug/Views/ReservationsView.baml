   M S B A M L   `   `   `  ����  Reservations)    #Reservations.Views.ReservationsView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47toolkit)http://schemas.xceed.com/wpf/xaml/toolkit  5      $	��260��5   7   $	��550��6D     � 
ResizeMode$  NoResize=�6P    � Title$ Reservations��6f   .��5	      �  � 	Resources 5
   
    �� 
TargetType �� Property �� Value �� 
TargetType �� 
StartPoint �� EndPoint	 � Color
 � Offset��%�  '��       �� 5      " ��6   .�5      ��  � �� 5      �� 5      " ��6*   .R�5      � .+�5   "   A� $��30��6*   $��80��66   ��5   &   �� 5   *   $ 0,0.5&�6>   $ 1.0,0.5&�6Q   .��5   .   � $	 DarkSlateBlue��6;   $	
 0.0Q�6Q   � 5   .   $	 SkyBlue��6;   $	
 1.0Q�6K   5   +   5   #   �� 5   "   $��Center=�63   $��Center=�6P   5      5      5      5      5       � RowDefinitions 5    
   �� 5!      $
��Auto �6   6,   �� 5"      $
��Auto �6   6,   �� 5#      $
��Auto �6   6,    � ColumnDefinitions 5%   
   �� 5&      $
��Auto �6   6.   .+�5(   
   �� $��Tables��6   $��4q�6#   .��5)      �� $��70��62   $	��500��6>   $
��Left=�6J   $��2q�6e   $
��Auto=�5*      $
��Auto=�6B   ��5)      �� *Tables+��5+      �� 5,      .R�5-      ��  �� Orientation$ 
Horizontal=�6!   6<   5.      ��50      �� 51      .R�52      �� $��90��6   $��35��6(    �� CornerRadius$ 2��64   $��4q�6E   ��53      �� 54      $ 0,0.5&�62   $ 1.0,0.5&�6E   .��55   "   � $	 DarkSlateBlue��6/   $	
 0.0Q�6E   � 56   "   $	 SkyBlue��6/   $	
 1.0Q�6?   57      ._�59      �  5:      �� 5;   "   $
��Auto �63   6B   �� 5<   "   $
��Auto �63   6B   �� 5=   "   $
��Auto �63   6B   .+�5@      �� $��1q�6}    d� 	IsChecked 6'   �� *IsTableSelected+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   �� 5A      $��	Table of ��6(   $��1��69   $��1q�6I   6V   �� 5B      $��1q�6H   $��2��6S   ��6(   �� *TableOccupancy+6e   5D      5E      5F      5H      5I      �� 5J   
   $��Customer Details��6   $��1��6-   $��4q�6:   .��5K      �  5L      �� 5M      $
��Auto �6    �� 5N      $
��Auto �6    �� 5O      $
��Auto �6     5Q      �� 5R      $
��Auto �6#   �� 5S      $
��Auto �6#   �� 5T      $	��100 �6#   �� 5U      $
��Auto �6#   �� 5V      $
��Auto �6#   �� 5W      $
��Auto �6#   .+�5Y      �� $��Customer Name��6   $��2q�61   6>   �� 5Z      $��:��6   $��1��6%   $��2q�65   6B   �� 5[      $��2��6�   $��2q�6�   ��6   ��  �� Path$ CustomerName�$ PropertyChanged=�$ TwoWay=� �� ValidatesOnDataErrors . 6�   �� 5\      $��Contact Number��6   $��3��62   $��2q�6B   6O   �� 5]      $��:��6   $��4��6%   $��2q�65   6B   �� 5^      $��5��5_      $	��100��6*   $��2q�66   $
��Left=�6A   ��5^      �� *CustomerContactNumber+$ PropertyChanged=�$ TwoWay=� . 5_   ^   �� 5`      $��Party Of��6   $��1��6,   $��2q�69   6F   �� 5a      $��:��6   $��1��6%   $��1��62   $��2q�6B   6O   �� 5b      $��1��6~   $��2��6�   $��2q�6�   ��6   �� *	PartyOf+$ PropertyChanged=�$ TwoWay=� . 6�   �� 5g      $��Check-in Date/Time��6   $��1��66   $��3��6C   $��2q�6S   6`   �� 5h      $��:��6   $��1��6%   $��4��62   $��2q�6B   6O   &   Xceed.Wpf.Toolkit.DateTimePicker  5i      $��2q�6k   $	��200��6v   $��1��5j   J   $��5��6W   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 5i   )   �� *CheckinDate+$ PropertyChanged=� � ToolTip 5j   *   �� *CheckinDate+6j   5k      5l      �� 5m   
   $ 
Horizontal=�6   $��2��6.   $��Center=�6;   $	��Top=�6X   $��2q�6p   .+�5n      �� $
��Save��6   $
��Left=�6Q   $��2q�6l   ��6%   �� *SaveReservationsCommand+6y   �� 5o      $��Cancel��6   $
��Left=�6H   ��6&   �� *CancelCommand+6f   5p      5q      5r      