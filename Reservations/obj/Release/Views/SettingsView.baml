   M S B A M L   `   `   `  ����   Reservations%    Reservations.Views.SettingsView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -     �Name$  SettingsWindow�� � Title$ Settings�� � 
ResizeMode$ NoResize=�$	��500��$	��160��.���  � 	Resources  �� 
TargetType �� Property �� Value �� 
TargetType �� 
StartPoint	 �� EndPoint
 � Color � Offset��%�   '��       �� " ��.���  � �� �� " ��.R�� .+�A� $��30��$��80������ $ 0,0.5&�$	 1.0,0.5&�.��� $
 DarkSlateBlue��$	 0.0Q�� $
 SkyBlue��$	 1.0Q��� $��Center=�$��Center=� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $	��100 ��� $
��Auto ��� $
��Auto ��� .+��� $��Tables File��$��3q�$
��Left=�$	��Top=��� $��:��$��3q�$��1���� {�.  $��3q�$��2��$	��250��$��25��$	��Top=����� *TablesXMLFilePath+ � ToolTip �� *TablesXMLFilePath+�� $��Browse��$��Table��$��3q�$��3��$
��Auto��$
��Auto��$	��Top=����� *FolderBrowseCommand+�� $��Reservations File��$��1��$��3q�$
��Left=�$	��Top=��� $��:��$��3q�$��1��$��1���� {�.  $��3q�$��1��$��2��$	��250��$��25��$	��Top=����� *ReservationsXMLFilePath+ �� *ReservationsXMLFilePath+�� $��Browse��$��Reservation��$��3q�$��1��$��3��$
��Auto��$
��Auto��$	��Top=����� *FolderBrowseCommand+�� $��OK��$��3q�$��Center=�$��2��$��2��$
��Auto��$
��Auto��$	��Top=����� *	OKCommand+����  �� ElementName$ SettingsWindow��