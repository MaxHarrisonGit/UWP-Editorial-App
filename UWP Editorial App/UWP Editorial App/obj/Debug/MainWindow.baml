   M S B A M L   `   `   `  ����L  HUWP Editorial App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:UWP_Editorial_AppUWP_Editorial_App  5   	   "    UWP_Editorial_App.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:UWP_Editorial_App     5   	   -   5          �Name$  
mainParent��5   w    � Title$ 
MainWindow��6	   $��453.5��6   $��604.5��6+    � WindowState$ 	Maximized=�69    � WindowStyle$
 None=�6Q   
���   �.��5	      � .+�5
   
   (� -   5         (�Name$ ViewBox��5
   !    (� Stretch$
 Fill=�6   $y�Visible=�62   .��5      � -   5         �Name$ 
parentGrid��5      .+�5      � -   5        $ Grid1��5   p   $��Stretch=�6   $��Stretch=�65   $	��249��6Q   
���   �$��0,0,268,141q�6   .+�5      r� -   5         r� Volume$ 0Q�5   $    r� Stretch$ UniformToFill=�6/   6G   5      � 5      -   5        $ Grid2��5   �   $��Stretch=�6   $��Stretch=�65   $	��268��6Q   
���   �$��249,0,0,159q�6p   .+�5      r� -   5        $ 0Q�5   $   $ UniformToFill=�6/   6G   5      � 5      -   5        $ Grid3��5   �   $��Stretch=�6   $	��159��65   $��Stretch=�6B   $	��161��6^   
���   �$��249,161,107,0q�6}   .+�5      r� -	   5        $ 0Q�5   $   $ UniformToFill=�6/   6G   5      � 5      -
   5        $ Grid4��5   �   $��Stretch=�6   $	��141��65   $��Stretch=�6B   $	��249��6^   
���   �$��0,179,268,0q�6}   .+�5      r� -   5        $ 0Q�5   #   $ UniformToFill=�6.   6F   5      � 5      -   5        $ Grid5��5   �   $��Stretch=�6   $
��79.5��65   $��Stretch=�6C   $	��107��6_   
���   �$��410,160,0,80q�6~   .+�5      r� -   5        $ 0Q�5   $   $ UniformToFill=�6/   6G   5      � 5      -   5        $ Grid6��5   �   $��Stretch=�6   $��Stretch=�65   $	��107��6Q   
���   �$��410,239,0,0q�6p   .+�5      r� -   5        $ 0Q�5   #   $ UniformToFill=�6.   6F   5      5      5       � 5!   
   -   5        $ 	TransGrid��5!      $y�Hidden=�6"   
�������	 J� Opacity$	 0Q�6J   5"      5$      5%      