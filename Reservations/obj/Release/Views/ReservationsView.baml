   M S B A M L   `   `   `  ����   Reservations)    #Reservations.Views.ReservationsView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47toolkit)http://schemas.xceed.com/wpf/xaml/toolkit  $	��260��$	��450��  � 
ResizeMode$  NoResize=� � Title$ Reservations��.���  � 	Resources  �� 
TargetType �� Property �� Value �� 
TargetType �� 
StartPoint �� EndPoint	 � Color
 � Offset��%�   '��       �� " ��.���  � �� �� " ��.R�� .+�A� $��30��$��80������ $ 0,0.5&�$ 1.0,0.5&�.��� $	 DarkSlateBlue��$	
 0.0Q�� $	 SkyBlue��$	
 1.0Q��� $��Center=�$��Center=� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto �.+��� $��Tables��$��4q�.���� $��70��$	��422��$
��Left=�$��2q�$
��Auto=�$
��Auto=����� *Tables+���� .R���  �� Orientation$ 
Horizontal=����� .R��� $��90��$��35�� �� CornerRadius$ 2��$��4q����� $ 0,0.5&�$ 1.0,0.5&�.��� $	 DarkSlateBlue��$	
 0.0Q�� $	 SkyBlue��$	
 1.0Q�._��  �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��1q� d� 	IsChecked �� *IsTableSelected+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� $��	Table of ��$��1��$��1q��� $��1q�$��2������ *TableOccupancy+�� $��Customer Details��$��1��$��4q�.���  �� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto ��� $	��100 ��� $
��Auto ��� $
��Auto ��� $	��100 �.+��� $��Customer Name��$��2q��� $��:��$��1��$��2q��� $��2��$��2q�����  �� Path$ CustomerName�$ PropertyChanged=�$ TwoWay=� �� ValidatesOnDataErrors . �� $��Contact Number��$��3��$��2q��� $��:��$��4��$��2q��� $��5��$��2q����� *CustomerContactNumber+$ PropertyChanged=�$ TwoWay=� . �� $��Party Of��$��1��$��2q��� $��:��$��1��$��1��$��2q��� $��1��$��2��$��2q����� *	PartyOf+$ PropertyChanged=�$ TwoWay=� . �� $��Check-in Date/Time��$��1��$��3��$��2q��� $��:��$��1��$��4��$��2q�&   Xceed.Wpf.Toolkit.DateTimePicker  $��2q�&   Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ 	ShortDate=�   
TimeFormat$ 	ShortTime=�$��1��$��5���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value �� *CheckinDate+$ PropertyChanged=� � ToolTip �� *CheckinDate+�� $ 
Horizontal=�$��2��$��Center=�$	��Top=�$��2q�.+��� $
��Save��$
��Left=�$��2q����� *SaveReservationsCommand+�� $��Cancel��$
��Left=����� *CancelCommand+