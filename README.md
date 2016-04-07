web_crm_training
================

ВНИМАНИЕ!!1 Нужно поправить связи у модели Menu

Web CRM for training centers

===Миграции

Миграции запускаются в той же консоли, что и nuget - Tools > Library Package Manager > Package Manager Console

Чтобы "воссоздать" текущее состояние базы данных из миграций(накатить миграции) используеться команда
*update-database*

Старая база данных была из гита удалена и больше в гите хранится не будет. Чтобы создать локальную базу данных, нужно также запустить команду
*update-database*

Как добавить миграцию.

Изменяем модель, например, добавляем в модель Student поле public string MomName

После этого вводим в консоли 
*add-migration AddMomName*

в этот момент visual studio просмотрит изменения в моделях и добавит их _все_ в миграцию с названием AddMomName.
Обязательно перед коммитом и накатыванием своей миграции нужно заглянуть в неё, не добавила ли или не удалила ли студия чего лишнего. Миграцию можно свободно редактировать. 

Файл миграции появится в каталоге Migrations и выглядит как ЧисловойПрефикс_AddMomName (например, 201412150712039_AddMomName)

теперь вводим *update-database* и в нашей базе у студентов появится поле MomName.


Полезные ссылки: 	
http://msdn.microsoft.com/ru-ru/data/jj591621
http://msdn.microsoft.com/ru-ru/data/jj554735
http://habrahabr.ru/post/121265/


=====


Перейти в Visual Studio:
Debug -> Exception
Убрать галочку на против Common Language Runtime Exception

https://www.nuget.org/packages/log4net


====

для миграций с разными контекстами - 

Add-Migration SomeMigrationName -ConfigurationTypeName TrainingCentersCRM.Migrations.Configuration
update-Database -ConfigurationTypeName TrainingCentersCRM.Migrations.Configuration


Add-Migration SomeMigrationInApplicationDBContext -ConfigurationTypeName TrainingCentersCRM.Migrations.ApplicationDbContext.Configuration
update-Database -ConfigurationTypeName TrainingCentersCRM.Migrations.ApplicationDbContext.Configuration
