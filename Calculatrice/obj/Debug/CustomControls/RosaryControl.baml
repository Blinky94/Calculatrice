   M S B A M L   `   `   `  ����G  CCalculatrice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Calculatrice.CustomControlsCalculatrice.CustomControls  5   ?  /    )Calculatrice.CustomControls.RosaryControl   6   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6B   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6�   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6�   @d2http://schemas.microsoft.com/expression/blend/2008     6  ;local)clr-namespace:Calculatrice.CustomControls     6?  
������ .��5      �   � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5	      $��* �6   z�5   
   V� 5      .~�5      ��  �� ScaleX$	 0.1Q�6!    �� ScaleY$	 0.1Q�6.   �� 5       �� Angle$ 45Q�6"   5      .+�5   
   4   .Calculatrice.CustomControls.DirectionalControl  -   5          Name$ DirectionalUp��5   #   4   .Calculatrice.CustomControls.DirectionalControl   Click$ DirectionalUp_Click��6�   $��0��6:   $��0��6J   
������ +   $DirectionControlRotateTransformAngle$	 315Q�6p   $��
0 0 0 -190q�6�   6�     5   
   -   5        $ DirectionalRight��5   #   $ DirectionalRight_Click��6�   $��1��6=   $��0��6M   
������ $ 45Q�6s   $��-190 0 0 -190q�6�   6�     5   
   -   5        $ DirectionalLeft��5   #   $ DirectionalLeft_Click��6�   $��0��6<   $��1��6L   
������ $	 225Q�6r   $��
0 0 0 -190q�6�   6�     5   
   -   5        $ DirectionalDown��5   #   $ DirectionalDown_Click��6�   $��1��6<   $��1��6L   
������ $	 135Q�6r   $��-190 0 0 -190q�6�   6�   5      5      