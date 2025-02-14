Отчет по лабораторной работе № 4

Агрегирование и группировка данных

По дисциплине «Базы данных»

ЗАДАНИЕ 1

Вывести среднюю зарплату по каждому департаменту и сам департамент, в котором число сотрудников больше 5, отсортируйте по убыванию средней заработной плате.

ЗАПРОС:

SELECT department_id,COUNT(employee_id), AVG(salary) AS department_avg_salary FROM employees GROUP BY department_id HAVING COUNT(employee_id)>5 ORDER BY department_avg_salary DESC

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/0ddd4a55-210a-4440-a946-28acc40f46db)

ЗАДАНИЕ 2

Вывести количество сотрудников, которые были трудоустроены после 1990 года, сгруппировав их по должностям.

ЗАПРОС:

SELECT job_id, COUNT(employee_id) FROM employees WHERE date_part('year', hire_date) > '1990' GROUP BY job_id

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/23199ac6-ab54-4cdf-95fe-9c762591a2c8)

ЗАДАНИЕ 3

Вывести для каждого отдела: информацию о сотрудниках через запятую,в виде фамилия// job_id//salary// в одном столбце, минимальную, максимальную зарплату и среднюю зарплату в других столбцах.

ЗАПРОС:

SELECT department_id, STRING_AGG (concat(last_name, '//', job_id, '//', salary), ', ') AS employee_info, MIN(salary), MAX(salary), AVG(salary) FROM employees GROUP BY department_id ORDER BY department_id

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/fe87707b-c40c-4719-97d8-d40563cb6718)

ЗАДАНИЕ 4

Вывести количество сотрудников менеджера, средняя зарплата которых находится в диапазоне от 3000 до 7000, отсортировать этот столбец по возрастанию.

ЗАПРОС:

SELECT manager_id, COUNT(employee_id) AS number_of_employees FROM employees GROUP BY manager_id HAVING AVG(salary) BETWEEN 3000 AND 7000 ORDER BY number_of_employees

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/8e63140c-9287-454e-b2c1-9003b5a2f1ca)

ЗАДАНИЕ 5

Для каждого отдела вывести "department_id-количество сотрудников" в одном столбце, если средняя зарплата сотрудников этого отдела (второй столбец) менее 6000, вывести всех сотрудников в третьем столбце.

ЗАПРОС:

SELECT concat(department_id, '-', COUNT(employee_id)) AS number_of_department_employees, AVG(salary), STRING_AGG(concat(last_name,' ', first_name), ', ') as employees_info FROM employees GROUP BY department_id HAVING AVG(salary)<6000

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/31f6c32c-d7df-477c-b2ab-b4682b25001f)

ЗАДАНИЕ 6

Придумать 2 запроса с агрегацией данных самостоятельно.

ЗАПРОС:

1. Поиск однофамильцев на одинаковой должности

SELECT job_id, last_name, STRING_AGG(first_name, ' / ') AS first_name FROM employees GROUP BY job_id, last_name HAVING ABS(COUNT(DISTINCT last_name) - COUNT(job_id))>0

2.  Вывод всех почтовых адресов сотрудников отдела
   
SELECT department_id, STRING_AGG(email, E'\n') AS emails FROM employees GROUP BY department_id ORDER BY department_id

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

1.
![изображение](https://github.com/user-attachments/assets/d9833bc8-86c8-4080-b363-7ac9eb443964)

2.
![изображение](https://github.com/user-attachments/assets/c6017fd2-f171-4a93-97de-1c59fec09c16)

ЗАЩИТА

Вывод количества сотрудников, сгруппированных по дням недели даты найма.

ЗАПРОС:

SELECT EXTRACT(dow FROM hire_date), COUNT(employee_id) FROM employees GROUP BY EXTRACT(dow FROM hire_date) ORDER BY EXTRACT(dow FROM hire_date)

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/232949f1-9c5f-4249-aed5-47b5b9141cb6)

ЗАПРОС:

SELECT to_char(hire_date, 'Day'), COUNT(employee_id) FROM employees GROUP BY to_char(hire_date, 'Day') ORDER BY COUNT(employee_id) DESC

РЕЗУЛЬТАТ ВЫПОЛНЕНИЯ ЗАПРОСА:

![изображение](https://github.com/user-attachments/assets/d31907d6-8572-411a-a381-ea7bffe992ef)

