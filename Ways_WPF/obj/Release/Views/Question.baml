   M S B A M L   `   `   `  ���� C  ?Ways_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Ways_WPF.ViewsWays_WPF.Views  9!clr-namespace:Ways_WPF.ViewModelsWays_WPF.ViewModels      Ways_WPF.Views.Question   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:Ways_WPF.Views     8
viewModels!clr-namespace:Ways_WPF.ViewModels       N� Title$  Question��$	��768��$
��1024�� � DataContext �� *QuestionViewModel+   Locator �� Source# [   � 	Resources  �� 
TargetType  RoundButtonDodgerBlue �� Property �� Value �� 
TargetType �� CornerRadius	 ��Name  AnswerRadioButton��%/  &	       &	 �     �� " ��.���  �@��TextAlignment$ Center=���  � ��
 �������  � �� �� " ��.R��� $ 4��
����� �._��� $	 contentPresenter��#��z��#��z��#��z��#��z��#��z���� " 	�.���  � ��$ 20 10q���  � ��$ 16(���  � ��$ Center=�.��]� 
�������.+��� $��	0 260 0 0q�$��Center=�$	��Top=�.+��� $��18(�
����=H����� *CurrentQuestionNumberLabel+
 �� UpdateSourceTrigger$
 PropertyChanged=��� 
����=H�$��24(����� *CurrentQuestion.Label+$
 PropertyChanged=��� ���� *CurrentChoices+$
 PropertyChanged=����� .R�	� #��[ ���� *Label+����  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" N� �� Path$) #DataContext.CheckRadioButtonCommand�����  	� 	GroupName �� *Question.Id+�� $��	0 100 0 0q�$��18(�$��10q�$	��200��#��[ ���� *AnswerQuestionCommand+.��	Répondre