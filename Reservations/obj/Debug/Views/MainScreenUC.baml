   M S B A M L   `   `   `  ����G  CReservations, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Reservations.ConvertersReservations.Converters  5      %    Reservations.Views.MainScreenUC   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47toolkit)http://schemas.xceed.com/wpf/xaml/toolkit  5      6
converters%clr-namespace:Reservations.Converters  5      -   5          >�Name$  mainScreenView��5      .��5
      %  Xceed.Wpf.Toolkit.BusyIndicator  -   5          Name$ busyIndicator��5
      .��5      �  � 	Resources 5   
   <   6Reservations.Converters.DisplayTablesSelectedConverter   tablesDisplayConverter �� 
TargetType �� Property �� Value �� 
TargetType �� 
StartPoint �� EndPoint	 � Color
 � Offset��%�  &	        '��        5      6Y   �� 5      " ��6   .�5      ��  � �� 5      �� 5      " ��6*   .R�5      � .+�5   "   A� $��30��6*   $��60��66   ��5   &   �� 5   *   $ 0,0.5&�6>   $ 1.0,0.5&�6Q   .��5   .   � $	 DarkSlateBlue��6;   $	
 0.0Q�6Q   � 5   .   $	 SkyBlue��6;   $	
 1.0Q�6K   5   +   5   "   �� 5   "   $��Center=�63   $��Center=�6P   5      5      5       5!      5"       � RowDefinitions 5#   
   �� 5$      $
��Auto �6   6,   �� 5%      6   �� 5&      6    � ColumnDefinitions 5(   
   �� 5)      $
��Auto �6   6.   �� 5*      6!   .+�5,   
   ��  �� Orientation$ 
Horizontal=�6   $��1��6.   $	��Top=�6;   $
��Left=�6S   $��4q�6n   .+�5-      �� $��Settings��6   $
��Auto��6�   $
��Auto��6�   $��4q�6�   ��6%   �� *SettingsCommand+��6I   ��  �� ElementName$ mainScreenView��6�   �� 5.      $	��New��6    � ToolTip$ New Reservation��6'   
���   �$
��Auto��6~   $
��Auto��6�   $��4q�6�   ��6T   �� *NewReservationCommand+6�   �� 5/      $��Update��6   $ Update Reservation��6&   $
��Auto��6n   $
��Auto��6{   $��4q�6�   ��6C   �� *EditReservationCommand+6�   �� 50      $��Delete��6   $ Delete Reservation��6&   $
��Auto��6p   $
��Auto��6}   $��4q�6�   ��6C   �� *DeleteReservationCommand+6�   �� 51      $��Close��6   $
��Auto��6F   $
��Auto��6S   $��4q�6a   ��6%   �� *CloseCommand+6n   52      �� 53   
   $��Reservations��6   $��0��6)   .��54   
   &   System.Windows.Controls.DataGrid  $��0��6   $��2��6       AutoGenerateColumns .  $	��250��6�   $
��Auto=�55   i      SelectionMode$ Single=�56         SelectionUnit$ FullRow=�6*      CanUserAddRows .  $��3q�6Y      AlternatingRowBackground
 ��ح���54   4   �� *ReservationModelList+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 55      �� *SelectedReservationModel+$ PropertyChanged=�   Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   Header$ Customer Name��6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *CustomerName+6_     59      $ Contact Number��6G    6%   �� *ContactNumber+6a     5:      $ Party Of��6A    6%   �� *	PartyOf+6U     5;      $ Table(s) ID��6v    6%   ��  �� Path$ Table� �� 	Converter# [  6�     5<      $ Chekin Date/Time��6I    6)   �� *CheckInDate+6e   5>      5?      �� 5@   
   $��2��6   $Y��SPlease select the Tables and Reservations XML file paths using the Settings button.��6!    �� TextAlignment$
 Left=�5A      $��2q�6)   66   5B      5C      5D      