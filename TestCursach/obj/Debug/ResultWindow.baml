   M S B A M L   `   `   `  ����F  BTestCursach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TestCursachTestCursach  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	       TestCursach.ResultWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TestCursach     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	     � Title$  ResultWindow��5	   	   $	��450��6   $	��800��6+   .��5
      � .+�5   
   �� $��24(�6   $
��Bold"�6   $	��Top=�60   $��Center=�6H   .��6e   Результаты6q   �� 5   
   -   5        $��Results��5      $	��400��6!   $��	200,0,0,0q�6-   ���#fdffb6��5      �� 5      .R�5      � $	��0,2q�6    � RowDefinitions 5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      $��0 �6/   �� 5      $	��150 �6/   �� 5      $��50 �6/   .+�5      �� $��Ваш ответ��6$   $��0��65   $��1��6B   $
��Wrap=�6R   �� 5      $��Счет��6$   $��0��60   $��2��6=   $
��Wrap=�6M   �� 5      $��1��6@   $��1��6M   $
��Wrap=�6]   ��6$   �� *
AnswerText+6]   �� 5      $��1��6;   $��2��6H   $
��Wrap=�6X   ��6$   �� *Score+6X   5      5      5       �� 5!   
   -   5         ��Name$ Score��5!      $��Общий счет: ��6   $��25(�66   $
��Bold"�6D   5"      5$      