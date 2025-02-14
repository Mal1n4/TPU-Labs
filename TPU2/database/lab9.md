Отчет по лабораторной работе № 9
По дисциплине «Базы данных»

ИНДЕКСЫ

ЗАДАНИЕ 1

В 2х таблицах с искусственным ID в качестве первичного уникальный создайте  индекс для исключения дублирования данных.

ЗАПРОС:

create unique index Event_Title_id on _event(event_title);
create unique index Org_Title_id on organization(organization_title);

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/73904da6-bc54-4bb6-b90d-3675997e9037)

ЗАДАНИЕ 2

Создайте 2 неуникальных индекса для ускорения поиска данных, как минимум один из них должны быть составным.

ЗАПРОС:

create index Ticket_Place_id on ticket(_row, place);
create index OrgEv_EventPlace_id on organization_event(event_date, event_title);

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/684434c9-bb9d-490e-b8bf-f02bde0c5c4d)

ЗАДАНИЕ 3

Создайте 1 индекс для внешнего ключа.

ЗАПРОС:

create index Ev_Title_id on organization_event(event_title);

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/8e844f54-6e35-4be4-b29e-0c22b4138113)

ЗАДАНИЕ 4

Удалите индексы.

ЗАПРОС:

drop index Ticket_Place_id;
drop index event_title_id;
drop index ev_title_id;
drop index orgev_eventplace_id;
drop index org_title_id;

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/dbdc673c-ea81-470a-9df4-35eb782ae6bb)

![изображение](https://github.com/user-attachments/assets/518c5efa-13bc-4988-a159-14547e467b5a)



ПРЕДСТАВЛЕНИЯ

ЗАДАНИЕ 1

Создайте представление, основанное на таблицах по теме вашей индивидуальной работы. Данные должны быть внесены в исходные таблицы.

ЗАПРОС:

CREATE OR REPLACE VIEW available_tickets AS
SELECT * FROM ticket WHERE status = 'stock';

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/877da3a6-be76-46f2-9258-91c38f348266)

ЗАДАНИЕ 2

Удалите представление.

ЗАПРОС:

drop view available_tickets

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/ed77b3af-af1e-49a8-8289-7b0a61080564)


