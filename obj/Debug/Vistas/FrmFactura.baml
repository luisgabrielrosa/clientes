   M S B A M L   `   `   `  ����B  >Cliente, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Cliente.VistasCliente.Vistas  5   	       Cliente.Vistas.FrmFactura   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Cliente.Vistas     5   	     � Title$  Detalle de factura��5      $	��500��6"   $	��525��6/    � 
ResizeMode$ NoResize=�6;    � ShowInTaskbar .  .��5	      �  � RowDefinitions 5
   
   �� 5      $
��398* �6   �� 5      $	��71* �6   .+�5   
   �� $��Detalle de Factura��6   $
��Left=�6-   $��
133,10,0,0q�6H   $	��Top=�6\   ���	#FF192A56$��24(�6�   $
��Bold"�6�   $	��238��6�   �� 5   
   $��CODIGO��6   $
��Left=�6!   $��28��6<   $��	19,55,0,0q�6H   $	��Top=�6[   $	��126��6s   ���	#FF192A566   �� 5   
   -   5         ��Name$ 	txtCodigo��5   +   $
��Left=�6>   $��30��6Y   $��	19,83,0,0q�6e    �� TextWrapping$
 Wrap=�6x   $�� ��6�   $	��Top=�6�   $	��145��6�   ���	#FF192A566�   �� 5   
   $��CLIENTE��6   $
��Left=�6"   $��28��6=   $��
180,55,0,0q�6I   $	��Top=�6]   $	��126��6u   ���	#FF192A566�   �� 5   
   -   5        $ 
txtCliente��5      $
��Left=�6&   $��30��6A   $��
180,83,0,0q�6M   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��311��6�   ���	#FF192A566�   �� 5   
   $��TOTAL ITBIS��6   $
��Left=�6&   $��28��6A   $��
19,115,0,0q�6M   $	��Top=�6a   $	��126��6y   ���	#FF192A566�   �� 5   
   -   5        $��txtTotalItbis��5   +   $
��Left=�6@   $��30��6[   $��
19,143,0,0q�6g   $
 Wrap=�6{   $�� ��6�   $	��Top=�6�   $	��145��6�   ���	#FF192A566�   �� 5   
   $��	SUB TOTAL��6   $
��Left=�6$   $��28��6?   $��180,115,0,0q�6K   $	��Top=�6`   $	��126��6x   ���	#FF192A566�   �� 5   
   -   5        $��txtSubTotal��5   +   $
��Left=�6>   $��30��6Y   $��180,143,0,0q�6e   $
 Wrap=�6z   $�� ��6�   $	��Top=�6�   $	��145��6�   ���	#FF192A566�   �� 5   
   $��TOTAL��6   $
��Left=�6    $��28��6;   $��346,115,0,0q�6G   $	��Top=�6\   $��74��6t   ���	#FF192A566   �� 5   
   -   5        $��txtTotal��5   +   $
��Left=�6;   $��30��6V   $��346,143,0,0q�6b   $
 Wrap=�6w   $�� ��6�   $	��Top=�6�   $	��145��6�   ���	#FF192A566�   � 5   
   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��gvDetalleFactura��5   0      CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .  $��23,184,25,61q�6�   	 �� AlternationCount$	 2��6�   ���	#FF333333
   AlternatingRowBackground

 �����   RowBackground �	#14000000   HorizontalGridLinesBrush �	#FFDDDDDD   VerticalGridLinesBrush �	#FFDDDDDD   	RowHeight$ 30Q�6r     ColumnHeaderHeight$ 30Q�6�  $��Center=�6�  $��Right=�6�  ��6�   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Código��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Id+  5       $ Cantidad��6)    6;   �� *Qty+  5!      $ Precio��6)    69   �� *Price+  5"      $ Total ITBIS��6)    6>   �� *
TotalItbis+  5#      $ SubTotal��6)    6;   �� *
SubTotal+  5$      $ Total��6)    68   �� *Total+5&      5'      �� 5(   
   -   5        $��341,385,0,0q�5(      ���	#FFC23616$��40��6=   $	��Top=�6I   $��2��6a   $
��Left=�6r   $	��155��6�   .+�5)      �� $��Cancelar��6    �� Left$ 40��6'   
 �� Top$ 8��68   
�������$��14(�6Z   $
��Bold"�6h   $��Arial)�6z   5*      5+      5,      