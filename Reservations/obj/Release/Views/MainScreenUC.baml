   M S B A M L   `   `   `  ���� G  CReservations, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Reservations.ConvertersReservations.Converters  %    Reservations.Views.MainScreenUC   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47toolkit)http://schemas.xceed.com/wpf/xaml/toolkit  6
converters%clr-namespace:Reservations.Converters  -     >�Name$  mainScreenView��.��%  Xceed.Wpf.Toolkit.BusyIndicator  -     Name$ busyIndicator��.���  � 	Resources <   6Reservations.Converters.DisplayTablesSelectedConverter   tablesDisplayConverter �� 
TargetType �� Property �� Value �� 
TargetType �� 
StartPoint �� EndPoint	 � Color
 � Offset��%�   &	        '��        �� " ��.���  � �� �� " ��.R�� .+�A� $��30��$��60������ $ 0,0.5&�$ 1.0,0.5&�.��� $	 DarkSlateBlue��$	
 0.0Q�� $	 SkyBlue��$	
 1.0Q��� $��Center=�$��Center=� � RowDefinitions �� $
��Auto ��� ��  � ColumnDefinitions �� $
��Auto ��� .+���  �� Orientation$ 
Horizontal=�$��1��$	��Top=�$
��Left=�$��4q�.+��� $��Settings��$
��Auto��$
��Auto��$��4q����� *SettingsCommand+����  �� ElementName$ mainScreenView���� $	��New�� � ToolTip$ New Reservation��
���   �$
��Auto��$
��Auto��$��4q����� *NewReservationCommand+�� $��Update��$ Update Reservation��$
��Auto��$
��Auto��$��4q����� *EditReservationCommand+�� $��Delete��$ Delete Reservation��$
��Auto��$
��Auto��$��4q����� *DeleteReservationCommand+�� $��Close��$
��Auto��$
��Auto��$��4q����� *CloseCommand+�� $��Reservations��$��0��.��&   System.Windows.Controls.DataGrid  $��0��$��2��   AutoGenerateColumns .  $	��250��$
��Auto=�   SelectionMode$ Single=�   SelectionUnit$ FullRow=�   CanUserAddRows .  $��3q�   AlternatingRowBackground
 ��ح����� *ReservationModelList+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *SelectedReservationModel+$ PropertyChanged=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Customer Name��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *CustomerName+  $ Contact Number�� �� *ContactNumber+  $ Party Of�� �� *	PartyOf+  $ Table(s) ID�� ��  �� Path$ Table� �� 	Converter# [    $ Chekin Date/Time�� �� *CheckInDate+�� $��2��$Y��SPlease select the Tables and Reservations XML file paths using the Settings button.�� �� TextAlignment$
 Left=�$��2q�