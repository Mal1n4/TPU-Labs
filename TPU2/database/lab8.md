Отчет по лабораторной работе № 8

DDL. DML.

По дисциплине «Базы данных»

DDL

ЗАДАНИЕ 1

Создайте 2-3 таблицы из вашего ИДЗ (курсовая работа)  со всеми типами ограничений  (ограничения должны быть созданы как на уровне столбца, так и на уровне таблицы) и значением по умолчанию

ЗАПРОС:

CREATE TABLE Ticket (
  ticket_date date NOT NULL,
  event_title varchar(255) NOT NULL,
  _row integer NOT NULL,
  place integer NOT NULL,
  price integer default 300,
  PRIMARY KEY (ticket_date, event_title, _row, place)
);

CREATE TABLE _Event (
  event_title varchar(255) NOT NULL,
  event_lvl varchar(255),
  PRIMARY KEY (event_title)
);

CREATE TABLE Organization (
  organization_title varchar(255) NOT NULL,
  city varchar(255),
  address varchar(255),
  organization_type varchar(255),
  PRIMARY KEY (organization_title)
);

CREATE TABLE Organization_Event (
  event_date date NOT NULL,
  event_title varchar(255) NOT NULL,
  organization_title varchar(255) NOT NULL,
  PRIMARY KEY (event_date, event_title)
);

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/f2bf1e15-35f0-4570-90e1-7f9d345b4fb5)

ЗАДАНИЕ 2

Измените структуру таблицы (измените столбец, добавьте ограничение FK )

ЗАПРОС:

ALTER TABLE _Event add duration time;
ALTER TABLE ticket add status varchar(25) default 'stock';
ALTER TABLE Ticket ADD CONSTRAINT Ticket_DateTitle_fk FOREIGN KEY (ticket_date, event_title) REFERENCES Organization_Event (event_date, event_title);
ALTER TABLE Organization_Event ADD CONSTRAINT OrgEv_OrgTitle_fk FOREIGN KEY (organization_title) REFERENCES Organization (organization_title);
ALTER TABLE Organization_Event ADD CONSTRAINT OrgEv_EvTitle_fk FOREIGN KEY (event_title) REFERENCES _Event (event_title);

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/2f03fbb5-430c-409e-a53d-2ea7ec4c5fef)

ЗАДАНИЕ 3

Удалить столбцы и таблицу.

ЗАПРОС:

ALTER TABLE ticket DROP COLUMN place;
ALTER TABLE ticket DROP COLUMN ticket_date;
DROP TABLE organization_event;

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/f7d1e737-9554-4a93-a22c-a7d6d1c14c14)



DML

ЗАДАНИЕ 1

В созданные таблицы вставить данные.

ЗАПРОС:

INSERT INTO _event VALUES ('ITForum', 'городской', '05:00:00');
INSERT INTO organization VALUES ('TPU', 'Tomsk', 'Lenin Ave, 30, 208 room', 'University');
INSERT INTO organization_event VALUES ('11-02-2025', 'ITForum', 'TPU');
INSERT INTO ticket VALUES ('11-02-2025', 'ITForum', 5,5);
INSERT INTO ticket VALUES ('11-02-2025', 'ITForum', 1,5);
INSERT INTO ticket VALUES ('11-02-2025', 'ITForum', 2,5);
INSERT INTO ticket VALUES ('11-02-2025', 'ITForum', 3,5);
INSERT INTO ticket VALUES ('11-02-2025', 'ITForum', 4,5);

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/40c15096-dce9-453a-a1cb-73c8cb62c5a2)

ЗАДАНИЕ 2

Изменить данные, используя условия.

ЗАПРОС:

UPDATE ticket SET status = 'sold' WHERE (place=5 and _row < 5);
UPDATE ticket SET price = 400 WHERE (status='stock');

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/a5caa148-8afc-45a3-ad87-7b8305a46d9c)

ЗАДАНИЕ 3

Удалить данные, используя условия.

ЗАПРОС:

DELETE FROM ticket WHERE (place = 5 and _row<5);

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/234e4278-a34b-4640-9197-5cb1402be11d)
