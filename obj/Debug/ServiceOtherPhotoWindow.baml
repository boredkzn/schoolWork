   M S B A M L   `   `   `  ����E  AschoolWork, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:schoolWork
schoolWork  5   	   (    "schoolWork.ServiceOtherPhotoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:schoolWork     5   	     � Title$  Фотографии��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��0.1* �6   6,   �� 5      $��4* �6   6*   �� 5      $��1* �6   6*    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� -   5         ��Name$ AddPhotoButton��5      $��2��6)   $��1��66   $	��150��6F   $��25��6R   $��Добавить фото��6^   $
��Left=�6v   6�   �� 5   
   -   5        $ 
ExitButton��5      $	��150��6%   $��25��61   $��
Назад��6=   $��Right=�6M   $��2��6i   6�   �� 5   
   -   5         ��Name$ 
PhotosList��5      $��1��6'   $��0��64   $��2��6D   ��5      �� 5      .R�5      �  � 	ItemWidth$	 250��6     � 
ItemHeight$	 250��60   5      ��5      �� 5      .R�5       �� $��1q�6   
���   �._�5!      � $	��750��6    $	��150��6,   .+�5"      �� $	��100��6$   $	��100��61   ��6=   �� *" ServiceOtherPhoto.MainPhotoImage+5#      5$      5%      5'      5(      5)      