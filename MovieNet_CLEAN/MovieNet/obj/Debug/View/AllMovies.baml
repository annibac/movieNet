   M S B A M L   `   `   `  ����C  ?MovieNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MovieNet.ViewMovieNet.View  5          MovieNet.View.AllMovies   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:MovieNet.View     5        N� Title$  AddRate��5
       � DataContext 5	      ��    
VM_Locator �� Source# [   �� Path$ 
ShowMovies�.��5      � ��5   
   �� 5       �� ImageSource$- '/MovieNet;component/images/IMG_1413.png��6    �� Opacity$	 0.5Q�6O   .+�5   
   �� $
��Left=�6   $	��418��6/   $��	52,20,0,0q�6<   
���   �$	��Top=�6^   $	��711��6v   ��5      �� 5      $4 ./MovieNet;component/images/texture_blanche.jpg��6   5      �� 5   
   -   5         ��Name$ Movies��5       �� DisplayMemberPath$
 Name��6A   $��78,96,68,136q�6�   
���������6"   �� *Movies+ �� SelectedItem 6Z   �� *SelectedItem+6�   �� 5   
   $��Ajoutez un film��6/   $
��Left=�6I   $��
174,39,0,0q�6d   $	��Top=�6x   $	��196��6�   $��47��6�   ���	#FF8E0A0A���	#FF8E0A0A
�������$��16(�6�   ��6   �� *
AddMovie+	 � 	Resources	 5      
 �� 
TargetType �� Property �� Value��%^   '��       �� 5      "
 ��6   .�5      ��  �@��CornerRadius$ 7��65   5      5      5      �� 5    
   $��Voir les utilisateurs��60   $
��Left=�6P   $��
456,39,0,0q�6k   $	��Top=�6   $	��196��6�   $��47��6�   ���	#FF0A1B8E���	#FF0A1B8E
�������$��16(�6�   ��6   �� *	ShowUsers+	 5!      ��%^   '��       �� 5"      "
 ��6   .�5#      ��  �@��CornerRadius$ 7��65   5$      5%      5&      �� 5(   
   $��Editer��60   $
��Left=�6A   $��535,365,0,0q�6\   $	��Top=�6q   $	��196��6�   $��47��6�   ���	#FFE38F10���	#FFE3D410
�������$��16(�6�   ��6   �� *	EditMovie+	 5)      ��%^   '��       �� 5*      "
 ��6   .�5+      ��  �@��CornerRadius$ 7��65   5,      5-      5.      �� 50   
   $��	Supprimer��62   $
��Left=�6F   $��303,364,0,0q�6a   $	��Top=�6v   $	��196��6�   $��47��6�   ���	#FF424E4D
���   �
�������$��16(�6�   ��6   �� *DeleteMovie+	 51      ��%^   '��       �� 52      "
 ��6   .�53      ��  �@��CornerRadius$ 7��65   54      55      56      �� 58   
   $��Voir la fiche��60   $
��Left=�6H   $��
72,365,0,0q�6c   $	��Top=�6w   $	��196��6�   $��47��6�   ���	#FF0DAD9C���	#FF0DAD9C
�������$��16(�6�   ��6   �� *	InfoMovie+	 59      ��%^   '��       �� 5:      "
 ��6   .�5;      ��  �@��CornerRadius$ 7��65   5<      5=      5>      5?      5@      