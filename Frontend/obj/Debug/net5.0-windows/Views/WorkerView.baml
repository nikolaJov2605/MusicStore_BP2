   M S B A M L   `   `   `  ����C  ?Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Frontend.ViewsFrontend.Views  5   	       Frontend.Views.WorkerView   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Frontend.Views     5   	   -   5          � Title$  
WorkerView��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $��Radnici��6   $��Center=�61   $��0,10,0,0q�6N   $	��Top=�6`   $��28(�6x   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dgWorkers��5      $��10,62,10,70q�6&      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6<      CanUserAddRows$ False��6L      
IsReadOnly$
 True��6c      SelectionMode$ Single=�6u   �� 5   
   -   5         ��Name$ cbWorkerType��5      $
��Left=�6)   $��
10,369,0,0q�6D   $	��Top=�6X   $	��120��6p   �� 5   
   -   5         ��Name$ btnAdd��5      $��Dodaj radnika��6!   $��Right=�69   $��690,369,0,0q�6U   $	��Top=�6j   $��20��6�   $	��100��6�   6�   �� 5   
   -   5        $ 	btnUpdate��5      $��Izmeni radnika��6$   $��Right=�6=   $��0,369,210,0q�6Y   $	��Top=�6n   $��20��6�   $	��100��6�   6�   �� 5   
   -   5        $ 	btnDelete��5      $��Izbriši radnika��6$   $��Right=�6>   $��0,369,105,0q�6Z   $	��Top=�6o   $��20��6�   $	��100��6�   6�   5      5      