Отчет по лабораторной работе № 3
По дисциплине «Базы данных»

ЗАДАНИЕ 1

Найдите сотрудников (Last_name и First_name в одном столбце) должность, которые в первом месяце отработали меньше 10 дней

ЗАПРОС:

SELECT (last_name || ' ' || first_name) AS name, (extract(days from date_trunc('month', hire_date) + interval '1 month - 1 day') - extract(days from hire_date)) AS first_days FROM employees WHERE (extract(days from date_trunc('month', hire_date) + interval '1 month - 1 day') - extract(days from hire_date)) < 10


РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/768b9cf9-2dfb-453a-8460-7bd305cd12bb)

ЗАДАНИЕ 2

Выведете Last_name и первую букву First_name (в одном столбце), день найма сотрудника по юлианскому календарю, отсортируйте по фамилии в обратном порядке

ЗАПРОС:

SELECT (last_name || ' ' || SUBSTRING(first_name, 1, 1)) AS name, extract(julian from hire_date) AS julian_hire_date FROM employees ORDER BY last_name DESC

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/85bb5288-c0fa-4404-80d0-67116236fafc)

ЗАДАНИЕ 3

Вывод Фамилию и телефон через дефис в одном столбце, дату начала работы в виде "1 MAY 1995", количество отработанных им месяцев

ЗАПРОС:

SELECT CONCAT(last_name,' - ',phone_number) AS contact, to_char(hire_date, 'DD MONTH YYYY') AS format_hire_date, extract(year from age(current_date, hire_date)) * 12 + extract(month from age(current_date, hire_date)) AS work_month FROM employees

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/e60d3a0e-6f2a-41fe-8d87-417b144b969a)

ЗАДАНИЕ 4

Вывести сотрудников (имя и фамилию в одном столбце, дату найма), которые отработали более 30 лет, при этом были наняты с 1990 - 1995 года (включительно).

ЗАПРОС:

SELECT (first_name || ' ' || last_name) AS name, hire_date FROM employees WHERE extract(year from hire_date) <= '1995' AND extract(year from hire_date) >= '1990' AND extract(year from age(current_date, hire_date)) > 30

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/5da3ee53-7581-4826-9a91-5551125fd750)

ЗАДАНИЕ 5

Вывести в верхнем регистре фамилию и дату найма в одном столбце, во втором столбце дату приема на работу по формату «Вторник – май» для людей, у кого job_id от 14 до 19 или зарплата от 9 тысяч до 25

ЗАПРОС:

SELECT (UPPER(last_name) || ' ' || hire_date) AS employee_info, to_char(hire_date, 'TMDay') || ' - ' || (to_char(hire_date, 'TMmonth')) AS format_hire_day FROM employees WHERE (job_id >= 14 AND job_id <= 19) OR (salary >= 9000 AND salary <= 25000) 

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/daaf3beb-b647-4c4a-a4df-43dd250c8abe)

ЗАДАНИЕ 6

Придумать 2 запроса самостоятельно с использованием функций для работы с датами.

ЗАПРОС:

1. SELECT CONCAT(last_name, ' ', first_name) AS name, to_char(hire_date, 'CC') As hire_date_century FROM employees

2.  SELECT CONCAT(last_name,' - ',phone_number) AS contact, to_char(hire_date, 'DD MONTH YYYY') AS format_hire_date, to_char(hire_date, 'HH MI SS') AS hh_mi_ss, (extract(year from age(current_date, hire_date)) * 12 * 2160000) + (extract(month from age(current_date, hire_date)) * 2160000) AS work_sec FROM employees

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

1.
![изображение](https://github.com/user-attachments/assets/0f6dad25-b322-444e-9a37-5c08131f3d93)

2.
![изображение](https://github.com/user-attachments/assets/1463edcd-e71b-4e8e-a97f-02132d233f25)

ЗАЩИТА

Вывести в одном столбце фамилию и дату найма через дефис сотрудников, которые были трудоустроены в мае 1985-1995 г, и у которых зарплата между  10000 и 100000.

ЗАПРОС:

SELECT (last_name || ' - ' || hire_date) AS info, salary FROM employees WHERE (extract(month from hire_date) = '5') AND (extract(year from hire_date) BETWEEN '1985' and '1995') AND (salary BETWEEN 1000 and 100000)


РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/c48d8617-8513-4dee-a931-332cf0b613da)

