## Команда сборки контейнеров микросервисов

    docker-compose.exe -f seminar4_2.yml up

## Команды создания БД микросервисов

Базы данных создаем следующими командами из папок ссответствующих проектоа после запуска docker-compose:
cd .\UserService
dotnet ef database update --connection 'Host=localhost;Username=postgres;Password=example;Database=LibraryUsers'
cd ..\LibraryService\
dotnet ef database update --connection 'Host=localhost;Username=postgres;Password=example;Database=LibraryNew'
cd ..\TakeBookService\
dotnet ef database update --connection 'Host=localhost;Username=postgres;Password=example;Database=LibraryCB'

После этого можно проверять работу API сервисов

## Проблемы в случае работы с контейнероным API Getaway

При этом API Getaway в контейекпк не подгружает API сервисы пишет ошибку:
Sending HTTP request GET http://localhost:8096/swagger/v1/swagger.json
2024-09-09 18:42:12 fail: Microsoft.AspNetCore.Server.Kestrel[13]
2024-09-09 18:42:12 Connection id "0HN6GSNSA84BK", Request id "0HN6GSNSA84BK:00000002": An unhandled exception was thrown by the application.
2024-09-09 18:42:12 System.Net.Http.HttpRequestException: Connection refused (localhost:8096)

Причем поведение одинаковое что для localhost что для имени хоста например usrhost, как только не менял ocelot.json не работает.
Склорее всего проблема в настройке swagger внтури контейнеров других API сервисов, нужно привязывать его к имни хоста а не к локалхост.
Как не нашел пока.

Если запускать ApiGetaway не в контейнере а остальные сервисы в контейнерах то все работает.
Пока так и не разобрался как нстроить работу контейнерного API Getaway с контерйнерными API сервисами.
В лекции про это ничего не было.
