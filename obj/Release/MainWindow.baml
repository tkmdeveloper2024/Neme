   M S B A M L   `   `   `  ���� ?  ;Neme, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:NemeNeme      Neme.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $localclr-namespace:Neme     _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$-  'TIIM-niň Maliýe-ykdysadyýet bölümi�� � WindowState$ 	Maximized=� � WindowStartupLocation$ CenterScreen=�$	��700��$
��1200�� � Icon$ Images/preview 1.png��.���  � ColumnDefinitions �� $��* ��� $	��310 �.+�� $��0�����#e8e8e8 � RowDefinitions �� $
��auto ��� $��* �.+�� $��0�����#035B57$	��Top=�$��60��$��	10 15 0 5q�$��2��.+��� 
�������$��20 0 0 0q�$��DM Sans)�$��Center=�$
��Left=�$��18(�$
��Bold"�.��Zähmet bölümçesi� -   $
��Esas��$y�Visible=�$��1��$	��610��$	��880�����#e8e8e8.+� � -   $
��Main��$��Stretch=�$��Stretch=�  � NavigationUIVisibility$ Hidden=�A� -   $��SuratEllipse��$��30��$��30��$��30��$��30��$��	0 15 20 0q�$��Center=�$��Right=���!�  !� Visual �� -   $��Surat������ �� -   $��
StackAdmin�� �� Orientation$ 
Horizontal=�$	��Top=�$��50��$��0 15 0 0q�$��Right=�$	��130��$y�	Collapsed=�.+��� $��Administrator��
�������$��DM Sans)�$��DemiBold"�$��Center=�$
��Left=��� -   $��StackMenuUser��$ 
Horizontal=�$y�Visible=�$	��Top=�$��50��$��0 15 0 0q�$��Right=�$	��130��.+��� $��	Baş Menu��
�������$��DM Sans)�$��DemiBold"�$
��Left=�$��Center=�� $��1�����#e8e8e8 �� $��8* ��� $��60 �.+��� $��0�����#035B57$��15q�._��  �� $��* ��� $��3* �.+�� $��0��.+��� $��Images/preview 1.png��$��70��$��85��$	��Top=�$
��Left=�$��	15 10 0 0q��� 
�������$��	50 10 0 0q�$��DM Sans)�$	��Top=�$��Center=�$��21(�$
��Bold"�.��	Maliýe�� 
�������$��	0 40 40 0q�$��DM Sans)�$	��Top=�$��Right=�$��21(�$
��Bold"�.��ykdysadyýet�� 
�������$��	50 70 0 0q�$��DM Sans)�$	��Top=�$��Center=�$��21(�$
��Bold"�.��
bölümi�� $��Bottom=�$��Center=�$��0 0 0 45q�$	��250�����#DFDFDF$��2��� $��1��.+��� -   $��
StackMenu2��$ Vertical=�$y�Visible=�.+��� -	   $��Umumybtn��$��40�����#035B57���#035B57$��0q�._��� -
   $��
Stackumumy��$ 
Horizontal=�	 J� Opacity$		 0.9Q�.+�'  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 ViewDashboard=�
�������$��25��$��25��$��	25,10,0,0q��� $��Umumy maglumat��$��DemiBold"�
�������$��16(�$��
10 10 30 0q�9� -   $��	Expander1�� 9� 
IsExpanded .  ���#035B57
�������$��16(����� $ 
Horizontal=�
������ .+�  $
 PersonDetails=�$��25��$��25��
�������$��0,0,10,0q��� $��Goşundylar��
�������$��DM Sans)�$��DemiBold"�$��Center=�.���� .+��� -   $��
Gosundylar��$��40�����#035B57���#035B57$��0q�._��� -   $��Stackgosundylar��$ 
Horizontal=�.+�  $
 ViewDashboard=�
�������$��25��$��25��$��	45,10,0,0q��� $��Goşundylaryň sanawy��
�������$��16(�$��
10 10 30 0q��� -   $��Tazeg��$��40�����#035B57���#035B57$��0q�._��� -   $��
Stacktazeg��$ 
Horizontal=�.+�  $
 ViewDashboard=�
�������$��25��$��25��$��	45,10,0,0q��� $��Täze goşundy girizmek��
�������$��16(�$��
10 10 30 0q�9� -   $��	Expander2�� .  ���#035B57
�������$��16(����� $ 
Horizontal=�.+�  $
 ChartBoxOutline=�$��25��$��25��$��0,0,12,0q��� $��Wezipe görnüşleri��$��DM Sans)�$��DemiBold"�$��Center=�.���� .+��� -   $��	Wezipeler��$��40�����#035B57���#035B57$��0q�._��� -   $��Stackwezipeler��$ 
Horizontal=�.+�  $
 ViewDashboard=�
�������$��25��$��25��$��	45,10,0,0q��� $#��Wezipe görnüşleriň sanawy��
�������$��16(�$��
10 10 30 0q��� -   $��Wezipeg��$��40�����#035B57���#035B57$��0q�._��� -   $��StackWezipeg��$ 
Horizontal=�.+�  $
 ViewDashboard=�
�������$��25��$��25��$��	45,10,0,0q��� $��Wezipe görnüş girizmek��
�������$��16(�$��
10 10 30 0q�9� -   $��	Expander3�� .  ���#035B57
�������$��16(����� $ 
Horizontal=�.+�  $
 ChartBoxOutline=�$��25��$��25��$��0,0,12,0q��� $��Ştat sanawy��$��DM Sans)�$��DemiBold"�$��Center=�.���� .+��� -   $��Statwezipelergozkezmek��$��40�����#035B57���#035B57$��0q�._��� -   $!��Stackstatwezipelergozkezmek��$ 
Horizontal=�.+�  $
 ViewDashboard=�
�������$��25��$��25��$��	45,10,0,0q��� $��Ştat sanawy görkezmek��
�������$��16(�$��
10 10 30 0q��� -   $��
Statgosmak��$��40�����#035B57���#035B57$��0q�._��� -   $��Stackstatgosmak��$ 
Horizontal=�.+�  $
 ViewDashboard=�
�������$��25��$��25��$��	45,10,0,0q��� $��Ştat sanawyny goşmak��
�������$��16(�$��
10 10 30 0q��� -   $��	Tazeisgar��$��40��$y�	Collapsed=����#035B57���#035B57$��0q�._��� -   $ 
Horizontal=�.+�  $
 ViewDashboard=�$��25��
�������$��25��$��	25,10,0,0q��� $��Täze işgär goşmak��
�������$��16(�$��
10 10 30 0q��� -   $��	StackMenu��$ Vertical=�$y�	Collapsed=�.+��� -   $��
Umumyadmin��$��40�����#035B57���#035B57$��0q�._��� -   $��Stackumumyadmin��$ 
Horizontal=�.+�  $
 ViewDashboard=�
�������$��25��$��25��$��	25,10,0,0q��� $��Umumy maglumat��
�������$��16(�$��
10 10 30 0q�9�  .  ���#035B57
�������$��16(����� $ 
Horizontal=�.+�  $
 PersonDetails=�$��25��$��25��$��0,0,10,0q��� $��
Ulanyjylar��$��DM Sans)�$��DemiBold"�$��Center=�.���� .+��� -   $��Usersborder��$��40�����#035B57���#035B57$��0q�._��� -    $��Stackusanawy��$ 
Horizontal=�$y�Visible=�.+�  $
 ViewDashboard=�
�������$��25��$��25��$��	45,10,0,0q��� $��Ulanyjylaryň sanawy��
�������$��16(�$��
10 10 30 0q��� -!   $��Tazeigosmak��$��40�����#035B57���#035B57$��0q�._��� -"   $��Stacktazeigosmak��$ 
Horizontal=�.+�  $
 ViewDashboard=�
�������$��25��$��25��$��	45,10,0,0q��� $��Täze ulanyjy goşmak ��
�������$��16(�$��
10 10 30 0q��� $��1��$��
15 0 15 10q����#035B57._�� .+�  -#   $��signout��$
 SignOut=�$��24��$��24��
�������$��Center=�$
��Left=�$��77 0 0 0q��� -$   $
��Exit��
������ 
�������$��0q�$��16(�$��Normal$�$��Roboto)�$��Center=�$��Center=�$	��280��$��Center=�$��	30 0 30 0q�$��Center=�$��50��$��0 0 0 0q�$��Çykmak��