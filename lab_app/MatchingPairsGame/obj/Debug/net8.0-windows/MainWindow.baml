   M S B A M L   `   `   `  ����  MatchingPairsGame"    MatchingPairsGame.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Memory Game��5   	   $	��450��6   $	��800��6*   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ MoveCountTextBlock��5      $��Ходов: 0��60   $��Center=�5      $��10q�61   �� 5   
   -   5         ��Name$ CardGrid��5   $   $��1��6   $��10q�5      ��5      �� 5      .R�5      �  � Orientation$ 
Horizontal=�6    5      ��5      �� 5      .R�5      �� -   5        $��80��5      $��80��6(   $��5q�64   ��5      �� ��5      �� 5       �� 
TargetType" ��6$   .�5   "   ��  �� Property � �� �� Value
 �����6?    �� Triggers 5   "   P� 5   &   	 P� Property	 � {�
 P� Value$
 False��6C   . �5   *   ��  � ��
 � � �6G   5    '   P� 5!   &   	 �@�Tag$
 Flipped��6=   . �5"   *   ��  � ��
 �����6G   5#   '   5%      5'      5(      5*      5+      5,      