web_crm_training
================

��������!!1 ����� ��������� ����� � ������ Menu

Web CRM for training centers

===��������

�������� ����������� � ��� �� �������, ��� � nuget - Tools > Library Package Manager > Package Manager Console

����� "����������" ������� ��������� ���� ������ �� ��������(�������� ��������) ������������� �������
*update-database*

������ ���� ������ ���� �� ���� ������� � ������ � ���� �������� �� �����. ����� ������� ��������� ���� ������, ����� ����� ��������� �������
*update-database*

��� �������� ��������.

�������� ������, ��������, ��������� � ������ Student ���� public string MomName

����� ����� ������ � ������� 
*add-migration AddMomName*

� ���� ������ visual studio ���������� ��������� � ������� � ������� �� _���_ � �������� � ��������� AddMomName.
����������� ����� �������� � ������������ ����� �������� ����� ��������� � ��, �� �������� �� ��� �� ������� �� ������ ���� �������. �������� ����� �������� �������������. 

���� �������� �������� � �������� Migrations � �������� ��� ���������������_AddMomName (��������, 201412150712039_AddMomName)

������ ������ *update-database* � � ����� ���� � ��������� �������� ���� MomName.


�������� ������: 	
http://msdn.microsoft.com/ru-ru/data/jj591621
http://msdn.microsoft.com/ru-ru/data/jj554735
http://habrahabr.ru/post/121265/


=====



Перейти в Visual Studio:
Debug -> Exception
Убрать галочку на против Common Language Runtime Exception

Если будут ошибки по log4net, тут инструкция как его ставить.
https://www.nuget.org/packages/log4net
