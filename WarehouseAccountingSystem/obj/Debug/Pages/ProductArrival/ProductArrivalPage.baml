   M S B A M L   `   `   `  ����T  PWarehouseAccountingSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:WarehouseAccountingSystem.Pages.ProductArrival.WarehouseAccountingSystem.Pages.ProductArrival  5      G    AWarehouseAccountingSystem.Pages.ProductArrival.ProductArrivalPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Nlocal<clr-namespace:WarehouseAccountingSystem.Pages.ProductArrival     5        N� Title$/  )Приход товара на склад��5	      .��5      � 
�������.+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��DGProductArrival��5         AutoGenerateColumns .     
IsReadOnly . $��0, 40, 0, 0q�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 5   )   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   )   �� *Id+5   )     5      $ 
Товар��6%   $ * 5   )    5   )   �� *Product.Name+5   )     5      $ Кол-во��6%   $ 85 5   )    5   )   �� *
Quantity+5   )     5      $&  Цена за ед. товара��6%   $	 150 5   )    5   )   �� *	UnitPrice+5   )     5      $ Полная цена��6%   $	 120 5   )    5   )   �� *Price+5   )     5       $ Дата прихода��6%   $	 120 5"   )    5!   )   �� *ArrivalDate+ �� StringFormat$ 
dd/MM/yyyy��5"   )   4  .System.Windows.Controls.DataGridTemplateColumn  5#      $ * 6)      CellTemplate 5$      �� 5%      .R�5&      �� .+�5'   "   �� $��BtnShowInfo��6)   -   5        $��Подробнее��5)   -   ���#8D5122   MaterialDesignFlatButton#��[  5+   -   5,      5-      5/      51      �� 52   
   -   5        $��	TxbSearch��52      $	��Top=�53      $
��Left=�54      $I��CВведите название товара для поиска...��55        MaterialDesignTextBox#��[ 56      $	��250��57      	 �� 
CaretBrush	 �#8D5122
 �� SelectionBrush
 �#6435135:      �� 5;   
   -   5        $��	BtnSearch��5;      $��Искать��5=      ���#8D5122#��[  5?      $	��Top=�5@      $
��Left=�5A      $��260, 0, 0, 0q�5B      �� 5C   
   -   5        $��
BtnRefresh��5C      $��Обновить��5E      ���#8D5122#��[  5G      $	��Top=�5H      $��Right=�5I      $��
0, 0, 0, 0q�5J      �� 5K   
   -   5        $��BtnAdd��5K      $��Добавить��5M      ���#8D5122#��[  5O      $	��Top=�5P      $��Right=�5Q      $��0, 0, 90, 0q�5R      5S      5T      