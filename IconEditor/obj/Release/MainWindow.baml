   M S B A M L   `   `   `  ���� E  AIconEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:IconEditor
IconEditor      IconEditor.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:IconEditor     M IModernWpf.Controls, Version=0.9.4.0, Culture=neutral, PublicKeyToken=nullD @ModernWpf, Version=0.9.4.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019     � Title$  
IconEditor��$	��450��$	��800��0  *ModernWpf.Controls.Primitives.WindowHelper   UseModernWindowStyle .  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      IconEditor.MainWindow   UndoCommand   Command# Z   -      RedoCommand# Z   -      MenuItem_NewCommand# Z   -      MenuItem_OpenCommand# Z   -      MenuItem_SaveCommand# Z   -   	   MenuItem_SaveAsCommand# Z	   -   
   MenuItem_ExitCommand# Z
   -      MenuItem_CopyCommand# Z   -	      MenuItem_PasteCommand# Z   -
      MenuItem_HelpCommand# Z   -      MenuItem_AboutCommand# Z  J� InputBindings ��  �� Gesture$ Ctrl+Z�� �� Command# Z �� $ Ctrl+Y��# Z �� $ Ctrl+N��# Z �� $ Ctrl+O��# Z �� $ Ctrl+S��# Z �� $ Ctrl+Shift+S��# Z	 �� $ Alt+F4��# Z
 �� $ Ctrl+C��# Z �� $ Ctrl+V��# Z �� $ F1��# Z �� $ F2��# Z .��� 
���   � � RowDefinitions �� $
��auto ��� $
��auto ��� �� $
��auto �.+�o� -    o�Name$ MenuItem��$��0��$
��Auto��
�������.@�m� -    m�Name$ MenuItem_Name1��$��ファイル(_F)��.@�m� -   $ MenuItem_New��$��新規作成(_N)...�� m� InputGestureText$ Ctrl+N�� m� Icon �� $��ICON/NewFile_16x.png��m� -   $ MenuItem_Open��$��開く(_O)...��$ Ctrl+O�� �� $��ICON/OpenFile_16x.png��m� -   $ MenuItem_Save��$��上書き保存(_S)...��$ Ctrl+S�� �� $��ICON/Save_16x.png��m� -   $ MenuItem_SaveAs��$%��名前を付けて保存(_A)...��$ Ctrl+Shift+S�� �� $��ICON/SaveAs_16x.png���� m� -   $ MenuItem_Exit��$��終了(_E)...��$ Alt+F4�� �� $��ICON/Exit_16x.png��m� $��
編集(_E)��.@�m� -   $ MenuItem_Undo��$��元に戻す(_U)��$ Ctrl+Z�� m� Command# Z  �� $��ICON/Undo_16x.png��m� -   $ MenuItem_Redo��$��やり直す(_R)��$ Ctrl+Y��# Z  �� $��ICON/Redo_16x.png���� m� -   $ MenuItem_Copy��$��コピー(_C)��$ Ctrl+C�� �� $��ICON/Copy_16x.png��m� -   $ MenuItem_Paste��$��貼り付け(_P)��$ Ctrl+V�� �� $��ICON/Paste_16x.png��m� $��ヘルプ(_H)��.@�m� -   $ MenuItem_Help��$��ヘルプ(_H)��$ F1�� �� $��ICON/F1Help_16x.png��m� -   $ MenuItem_About��$��バージョン情報(_A)��$ F2���� $��1�� �� Orientation$ 
Horizontal=�$��0q����	#FFF0F0F0.+��� $��10q���Z� ��Z� .���� $��ICON/NewFile_16x.png���� -   $��	ZoomLabel��$
��100%��$��40��$��Right=�$��Center=�
���   ��� -   ��Z� ��Z� .���� $��ICON/ZoomOut_16x.png���� -    ��Name$ Slider_Zoom��$��Center=�$	��160�� �� IsSnapToTickEnabled .  � Minimum$ 25Q� � Maximum$	 400Q� �� Ticks$&  25,50,75,100,125,150,200,300,400R� � Value$	 100Q�$��Center=����	#FF008EFF�� -   ��Z� ��Z� .���� $��ICON/ZoomIn_16x.png��$��Center=�� $��2�� � ColumnDefinitions �� �� $
��Auto ��� $	��200 �.+��� -   $��scrowllViewer��$��0��$
��Auto=�$
��Auto=����	#FF818181��Z� .���� -     ��Name$  
MainCanvas��$	��640��$	��640�����	#FF818181z�u� -   matrixTransform���� $��1��$��4��$��Center=�$��Stretch=����	#00000000� $��2�����	#FFD4D4D4 �� -    $
��auto ��� $
��auto �.+��� $��0��$��カラーパレット��$��10q��� -!   ! ��Name$! ColorPalette��$��1��$��30��$��
10,0,10,10q�
���   ��� $��3��.@��� -"   $��StatusBarLabel��$��Position(Color)��