   M S B A M L   `   `   `  ����C  ?Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Frontend.ViewsFrontend.Views  5   	       Frontend.Views.Prices   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Frontend.Views     5   	   -   5          � Title$  Prices��5   	   $	��450��6   $	��500��6%   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgPrices��5
      $��10,62,10,172q�6%      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6;      CanUserAddRows$ False��6K      
IsReadOnly$
 True��6b      SelectionMode$ Single=�6t   �� 5   
   -   5         ��Name$ 
lblCaption��5      $�� ��6$   $��Center=�6/   $��0,10,0,0q�6L   $	��Top=�6^   $��28(�6v   �� 5   
   -   5         ��Name$ 
gbNewPrice��5      $��
Dodaj cenu��6'   $��10,267,10,27q�6;   .��5      � $��87��6   .+�5      �� .+�5      �� -   5        $ 
lblAmmount��5      $��Iznos:��61   �� 5      -   5        $ lblDateStart��5      $��Datum početka važenja:��63   �� 5      -   5        $ 
lblDateEnd��5      $ ��Datum završetka važenja:��61   5      �� 5      $	��133��6   .+�5      �� -   5         ��Name$ 	tbAmmount��5      $�� ��62   $��2q�6:   (  "System.Windows.Controls.DatePicker  5      -	   5        	  Name$	 dpDateStart��5   !   $��2q�66     5      -
   5        $	 	dpDateEnd��5   !   $��2q�65   5      �� 5      $	��159��6   $��21��6)   .+�5      �� -   5        
 ��Name$
 btnAddPrice��5      $��
Dodaj cenu��62   $��Center=�6G   $	��102��6b   $��Center=�6n   6�   5      5      5      5      5      