   M S B A M L   `   `   `  ����L  HCaisseAutomatique, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:CaisseAutomatiqueCaisseAutomatique  5   	   &     CaisseAutomatique.Vue.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:CaisseAutomatique     5   	     � 
ResizeMode$  CanMinimize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ Caisse automatique��5
   	   $	��720��6$   $
��1280��61   .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��* �6   .+�5   
   � -   5         �Name$ ZonePrincipale��5      $��0��6'   .+�5      �� $��Ressources/Caisse2.png��6    K� ZIndex$ 0��64   6G   � 5      -   5        $ ZonePrincipaleSelection��5      $ 1��64    5      �� 5      $	��60* �6'   �� 5      $
��164* �6'   �� 5      $	��53* �6'   �� 5      $
��117* �6'   �� 5      $	��55* �6'   �� 5      $	��98* �6'   �� 5      $
��170* �6'   �� 5      $	��71* �6'    � RowDefinitions 5      �� 5      $	��54* �6$   �� 5      $
��107* �6$   �� 5       $	��33* �6$   �� 5!      $	��86* �6$   �� 5"      $	��79* �6$   �� 5#      $
��221* �6$   .+�5%      � -   5        $% GridSelectionZoneArticlesAVenir��5%   F   $��1��6   $��3��6%   $��1��66   .+�5&      � -   5        $/ )GridSelectionZoneArticlesAVenirBackground��5&   C   
������  J� Opacity$
 0.25Q�64   $ 0��6v   �� 5'      -   5         ��Name$ ZoneArticlesAVenirCanvas��5'      $ 1��6?   
������ 6P   5(      � 5)      -   5        $ GridSelectionZonePaiement��5)   \   
������ $
 0.25Q�60   $��1��6?   $��5��6L   5*      � 5+      -   5        $ GridSelectionZoneScan��5+   �   
������ $
 0.25Q�60   $��0��6?   $��3��6L   $��3��6]   $��2��6m   5,      � 5-      -   5        $* $GridSelectionZoneArticlesEnregistres��5-   Y   $��2��6   $��3��6$   $��4��65   $��3��6E   .+�5.      � -	   5        $4 .GridSelectionZoneArticlesEnregistresBackground��5.   C   
������ $
 0.25Q�64   $ 0��6{   �� 5/      -
   5        $# ZoneArticlesEnregistresCanvas��5/      $ 1��6D   
������ 6U   50      51      �� 52      -   5        $ 
CanvasDrag��52      $ 2��6)   53      � 54   
   -   5        $ ZoneMenu��54      $��1��6!    55      �� 56      $��* �6    �� 57      $��2* �6    �� 58      $��2* �6    .+�5:      � $��0��6   
����ح�.+�5;      �� -   5        	 ��Name$	 TextBlockMessageCaisse��5;      
 �� TextAlignment$
 Center=�6V   $��Center=�6m   $��Center=�6�   $��30(�6�   $
��Wrap=�6�   
���   ���6=   �� *	Message+6�   5<      � 5=      $��1��6   
�������.+�5>      &   System.Windows.Controls.DataGrid  
�������   AutoGenerateColumns$ False��6T      CanUserResizeColumns$ False��6p      CanUserResizeRows$ False��6�      CanUserSortColumns$ False��6�   $   HorizontalScrollBarVisibility$ Disabled=�6�   ��63   �� *
Articles+   Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn   Header$ Nom de l'article��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 240 6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6T   �� *Nom+  5A      $
 Prix��6-   $ 70 6;    6G   �� *Prix+ �� StringFormat$ N2��5C      5D      � 5E      $��2��6   
������� 5F      �� 5G      $��* �6$   �� 5H      $��3* �6$   .+�5J      �� $��10q�6   $��0��6(   $��Center=�66   $��Center=�6S   $��30(�6n   Client suivant6�   �� 5K      -   5         ��Name$ PanelClient��5K      $��1��62   {�6?   �� *EstDisponible+ �� Mode$ TwoWay=�.+�5L      �� -   5         ��Name$ ClientEtudiant��5L      $��12q�65   $��30(�6A   .��6l   
Etudiant6v   �� 5M      -   5        $ ClientGroupe��5M      $��12q�63   $��30(�6?   .��6h   Groupe6p   �� 5N      -   5        $ ClientAleatoire��5N      $��12q�66   $��30(�6B   .��6n   
Aléatoire6y   5O      5P      5Q      5R      5S      