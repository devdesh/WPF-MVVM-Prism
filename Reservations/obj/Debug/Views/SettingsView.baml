   M S B A M L   `   `   `  ����  Reservations%    Reservations.Views.SettingsView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          �Name$  SettingsWindow��5       � Title$ Settings��5       � 
ResizeMode$ NoResize=�60   $	��500��5   7   $	��160��6C   .��5	      �  � 	Resources 5
   
    �� 
TargetType �� Property �� Value �� 
TargetType �� 
StartPoint	 �� EndPoint
 � Color � Offset��%�  '��       �� 5      " ��6   .�5      ��  � �� 5      �� 5      " ��6*   .R�5      � .+�5   "   A� $��30��6*   $��80��66   ��5   &   �� 5   *   $ 0,0.5&�6>   $	 1.0,0.5&�6Q   .��5   .   � $
 DarkSlateBlue��6;   $	 0.0Q�6Q   � 5   .   $
 SkyBlue��6;   $	 1.0Q�6K   5   +   5   #   �� 5   "   $��Center=�63   $��Center=�6P   5      5      5      5      5       � RowDefinitions 5    
   �� 5!      $
��Auto �6   6,   �� 5"      $
��Auto �6   6,   �� 5#      $
��Auto �6   6,    � ColumnDefinitions 5%   
   �� 5&      $	��100 �6   6-   �� 5'      $
��Auto �6   6.   �� 5(      $
��Auto �6   6.   �� 5)      6!   .+�5+   
   �� $��Tables File��6   $��3q�6'   $
��Left=�62   $	��Top=�6M   6g   �� 5,   
   $��:��6   $��3q�6   $��1��6(   6:   �� 5-   
   {�.  $��3q�6m   $��2��6x   $	��250��6�   $��25��6�   $	��Top=�6�   ��6$   �� *TablesXMLFilePath+ � ToolTip 6G   �� *TablesXMLFilePath+6�   �� 5.   
   $��Browse��6   $��Table��6J   $��3q�6c   $��3��6n   $
��Auto��6~   $
��Auto��6�   $	��Top=�6�   ��6"   �� *FolderBrowseCommand+6�   �� 5/   
   $��Reservations File��6   $��1��6-   $��3q�6:   $
��Left=�6E   $	��Top=�6`   6z   �� 50   
   $��:��6   $��3q�6   $��1��6(   $��1��65   6G   �� 51   
   {�.  $��3q�6y   $��1��6�   $��2��6�   $	��250��6�   $��25��6�   $	��Top=�6�   ��6$   �� *ReservationsXMLFilePath+ 6M   �� *ReservationsXMLFilePath+6�   �� 52   
   $��Browse��6   $��Reservation��6J   $��3q�6i   $��1��6t   $��3��6�   $
��Auto��6�   $
��Auto��6�   $	��Top=�6�   ��6"   �� *FolderBrowseCommand+6�   �� 53   
   $��OK��6   $��3q�6t   $��Center=�6   $��2��54      $��2��6   $
��Auto��6.   $
��Auto��6;   $	��Top=�6I   ��53      �� *	OKCommand+��6<   ��  �� ElementName$ SettingsWindow��54   c   55      56      