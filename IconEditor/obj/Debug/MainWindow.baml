   M S B A M L   `   `   `  ����E  AIconEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:IconEditor
IconEditor  5   	       IconEditor.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:IconEditor     5   	   M IModernWpf.Controls, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullD @ModernWpf, Version=0.9.4.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5	   	     � Title$  
IconEditor��5   	   $	��450��6   $	��800��6)   0  *ModernWpf.Controls.Primitives.WindowHelper   UseModernWindowStyle .  J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           IconEditor.MainWindow   UndoCommand   Command# Z 5      5   8     5   
   -   5           RedoCommand# Z 5      5   8     5   
   -   5           MenuItem_NewCommand# Z 5      5        5   
   -   5           MenuItem_OpenCommand# Z 5      5        5   
   -   5           MenuItem_SaveCommand# Z 5      5        5   
   -   5        	   MenuItem_SaveAsCommand# Z	 5      5        5   
   -   5        
   MenuItem_ExitCommand# Z
 5      5        5   
   -   5           MenuItem_CopyCommand# Z 5      5        5   
   -	   5           MenuItem_PasteCommand# Z 5      5        5    
   -
   5           MenuItem_HelpCommand# Z 5       5!        5"   
   -   5           MenuItem_AboutCommand# Z 5"      5#       J� InputBindings 5&      �� 5'   
    �� Gesture$ Ctrl+Z��6    �� Command# Z 6&   �� 5)   
   $ Ctrl+Y��6   # Z 6&   �� 5+   
   $ Ctrl+N��6   # Z 6&   �� 5,   
   $ Ctrl+O��6   # Z 6&   �� 5-   
   $ Ctrl+S��6   # Z 6&   �� 5.   
   $ Ctrl+Shift+S��6   # Z	 6,   �� 5/   
   $ Alt+F4��6   # Z
 6&   �� 50   
   $ Ctrl+C��6   # Z 6&   �� 51   
   $ Ctrl+V��6   # Z 6&   �� 52   
   $ F1��6   # Z 6"   �� 53   
   $ F2��6   # Z 6"   .��57      � 
���   � � RowDefinitions 5=   
   �� 5>      $
��auto �6   �� 5?      $
��auto �6   �� 5@      �� 5A      $
��auto �6   .+�5D   
   o� -   5         o�Name$ MenuItem��5D      $��0��6!   $
��Auto��6.   
�������.@�5E      m� -   5         m�Name$ MenuItem_Name1��5E      $��ファイル(_F)��6/   .@�5F      m� -   5        $ MenuItem_New��5F      $��新規作成(_N)...��61    m� InputGestureText$ Ctrl+N��6F    m� Icon 5G      �� 5H      $��ICON/NewFile_16x.png��6    5J      m� 5L      -   5        $ MenuItem_Open��5L      $��開く(_O)...��62   $ Ctrl+O��6E    5M      �� 5N      $��ICON/OpenFile_16x.png��6    5P      m� 5R      -   5        $ MenuItem_Save��5R      $��上書き保存(_S)...��62   $ Ctrl+S��6H    5S      �� 5T      $��ICON/Save_16x.png��6    5V      m� 5X      -   5        $ MenuItem_SaveAs��5X      $%��名前を付けて保存(_A)...��64   $ Ctrl+Shift+S��6M    5Y      �� 5Z      $��ICON/SaveAs_16x.png��6    5\      �� 5^      m� 5_      -   5        $ MenuItem_Exit��5_      $��終了(_E)...��62   $ Alt+F4��6E    5`      �� 5a      $��ICON/Exit_16x.png��6    5c      5d      m� 5e      $��
編集(_E)��6   .@�5f      m� -   5        $ MenuItem_Undo��5f      $��元に戻す(_U)��62   $ Ctrl+Z��6D    m� Command# Z 6^    5g      �� 5h      $��ICON/Undo_16x.png��6    5j      m� 5l      -   5        $ MenuItem_Redo��5l      $��やり直す(_R)��62   $ Ctrl+Y��6D   # Z 6^    5m      �� 5n      $��ICON/Redo_16x.png��6    5p      �� 5q      m� 5r      -   5        $ MenuItem_Copy��5r      $��コピー(_C)��62   $ Ctrl+C��6C    5s      �� 5t      $��ICON/Copy_16x.png��6    5v      m� 5x      -   5        $ MenuItem_Paste��5x      $��貼り付け(_P)��63   $ Ctrl+V��6E    5y      �� 5z      $��ICON/Paste_16x.png��6    5|      5}      m� 5      $��ヘルプ(_H)��6   .@�5�      m� -   5        $ MenuItem_Help��5�      $��ヘルプ(_H)��62   $ F1��6C    5�      �� 5�      $��ICON/F1Help_16x.png��6    5�      m� 5�      -   5        $ MenuItem_About��5�      $��バージョン情報(_A)��63   $ F2��6H   6^   5�      5�      �� 5�   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��0q�6;   ���	#FFF0F0F0.+�5�      �� $��10q�6   ��6"   Z� ��69   Z� .��5�      �� $��ICON/NewFile_16x.png��6   5�      �� 5�      -   5        $��	ZoomLabel��5�      $
��100%��6%   $��40��64   $��Right=�6?   $��Center=�6[   
���   �6}   �� 5�      -   5        ��5�      Z� ��6+   Z� .��5�      �� $��ICON/ZoomOut_16x.png��6   5�      �� 5�      -   5         ��Name$ Slider_Zoom��5�      $��Center=�6*   $	��160��6E    �� IsSnapToTickEnabled .  � Minimum$ 25Q�5�       � Maximum$	 400Q�5�       �� Ticks$&  25,50,75,100,125,150,200,300,400R�5�       � Value$	 100Q�5�      $��Center=�6!   ���	#FF008EFF6k   �� 5�      -   5        ��5�      Z� ��6+   Z� .��5�      �� $��ICON/ZoomIn_16x.png��6   $��Center=�65   5�      5�      � 5�   
   $��2��6    � ColumnDefinitions 5�      �� 5�      �� 5�      $
��Auto �6#   �� 5�      $	��200 �6#   .+�5�      �� -   5        $��scrowllViewer��5�   (   $��0��6   $
��Auto=�6=   $
��Auto=�5�      ���	#FF818181��6S   Z� .��5�      �� -   5          ��Name$  
MainCanvas��5�      $	��640��6-   $	��640��6:   ���	#FF818181z�5�      u� 5�      -   5        matrixTransform��5�   *   5�      5�      �� 5�      $��1��6   $��4��6+   $��Center=�65   $��Stretch=�5�      ���	#0000000067   � 5�      $��2��6   ���	#FFD4D4D4 5�      �� 5�      -    5        $
��auto �5�   $   62   �� 5�      $
��auto �6$   .+�5�      �� $��0��6   $��カラーパレット��6%   $��10q�67   �� 5�      -!   5        ! ��Name$! ColorPalette��5�   )   $��1��6   $��30��6?   $��
10,0,10,10q�5�      
���   �6=   5�      5�      �� 5�   
   $��3��6   .@�5�      �� -"   5        $��StatusBarLabel��5�      $��Position(Color)��6*   5�      5�      5�      