   M S B A M L   `   `   `  ����  RetroSnaker    RetroSnaker.MessageWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   >d2http://schemas.microsoft.com/expression/blend/2008    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � Title$  	消息框��5   	   $	��200��5   	   $	��300��6    � WindowStartupLocation$ CenterOwner=�5	   	    � WindowStyle$
 None=�5
   	    � AllowsTransparency . 
������ .��5      � 
�������.+�5   
   � 
���   � J� Opacity$	 0.6Q�6"   � 5   
    � RowDefinitions 5      �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� 
�������$��24(�6+   $��宋体)�69   $��Center=�6I   $��Center=�6d   �� 5      $�当前长度：��6    �� 5      -   5         ��Name$ runCount��5      $�20��6(   5      �� 5      $��1��6   
�������$��0,1,0,0q�66   ._�5      ��  �� Orientation$ 
Horizontal=�6   $
��0,10q�66   $��Center=�6D   .+�5      �� -   5         ��Name$ 
btnRestart��5      $��30��61   $��80��6=   $��0,0,20,0q�6H   ��5       �� 5!      .R�5"   "   �� 	 ��Name$	 
BorderStar��6)   ._�5#   &   �� $��重新开始��60   
�������$��Center=�6O   $��Center=�6l   $��14(�6�   5$   #   
 �� Triggers
 5&   "   P� 5'   &    P� Property �@J�IsMouseOver P� Value . . �5(   *   ��  �� 
TargetName$ 
BorderStar��61    �� Property � �� �� Value �#58DB6F6_   5)   '   P� 5+   &    �@J�IsMouseOver .  . �5,   *   �� $ 
BorderStar��61    � �� �#1FF2466_   5-   '   5/      51      �� 53      -   5        $ btnExit��53      $��30��6.   $��60��6:   ��54      �� 55      .R�56   "   �� $	 
BorderExit��6)   ._�57   &   �� $��退出��60   
�������$��Center=�6M   $��Center=�6j   $��14(�6�   58   #   
 5:   "   P� 5;   &    �@J�IsMouseOver . . �5<   *   �� $ 
BorderExit��61    � �� �#E3678B6_   5=   '   P� 5?   &    �@J�IsMouseOver .  . �5@   *   �� $ 
BorderExit��61    � �� �#DE1C526_   5A   '   5C      5E      5F      5G      5H      5I      5J      