   M S B A M L   `   `   `  ����C  ?Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Frontend.ViewsFrontend.Views  5   	        Frontend.Views.AddPurchase   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Frontend.Views     5   	   -   5          � Title$  AddPurchase��5   	   $	��650��6   $	��800��6*   .��5	      � .+�5
   
   �� -   5         ��Name$ label3��5
      $��Artikal:��6    $
��Left=�63   $��	13,61,0,0q�6N   $	��Top=�6a   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgInstruments��5      $��13,92,10,400q�6*      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6@      CanUserAddRows$ False��6P      
IsReadOnly$
 True��6g      SelectionMode$ Single=�6y     5   
   -   5        $ dgBuyers��5      $��36,270,383,216q�6%   $ * 6=   $ False��6M   $
 True��6d   $ Single=�6v   6�   �� 5   
   -   5        $ label��5      $��Nova kupovina��6   $��Center=�67   $��0,10,0,0q�6T   $	��Top=�6f   $��28(�6~   �� 5   
   -   5        $ label1��5      $��Kupac:��6    $
��Left=�61   $��
13,239,0,0q�6L   $	��Top=�6`   �� 5   
   -   5        $ label2��5      $
��Ime:��6    $
��Left=�6/   $��458,294,0,0q�6J   $	��Top=�6_   �� 5   
   -   5        $ label2_Copy��5      $��Prezime:��6%   $
��Left=�68   $��458,325,0,0q�6S   $	��Top=�6h   �� 5   
   -	   5        $ label2_Copy1��5      $��JMBG:��6&   $
��Left=�66   $��458,356,0,0q�6Q   $	��Top=�6f   �� 5   
   -
   5         ��Name$ tbBuyerName��5      $
��Left=�6'   $��531,298,0,0q�6B   $�� ��6W    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��213��6�   �� 5   
   -   5        $ tbBuyerLastName��5      $
��Left=�6+   $��531,329,0,0q�6F   $�� ��6[   $
 Wrap=�6c   $	��Top=�6w   $	��213��6�   �� 5   
   -   5        $ tbJmbg��5      $
��Left=�6"   $��531,359,0,0q�6=   $�� ��6R   $
 Wrap=�6Z   $	��Top=�6n   $	��213��6�     5   
   -   5        $ 	dgWorkers��5      $��36,470,383,10q�6&   $ * 6=   $ False��6M   $
 True��6d   $ Single=�6v   �� 5   
   -   5        $ label4��5      $��Prodavac��6    $
��Left=�63   $��
13,439,0,0q�6N   $	��Top=�6b   �� 5   
   -   5        	 ��Name$	 button��5      $��Potvrdi kupovinu��6!   $
��Left=�6<   $��531,547,0,0q�6W   $	��Top=�6l   $��43��6�   $	��213��6�   $��20(�6�   6�   5      5      